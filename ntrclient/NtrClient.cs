namespace ntrclient
{
    using System;
    using System.IO;
    using System.Net.Sockets;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;

    internal class NtrClient
    {
        private uint currentSeq;
        private int heartbeatSendable;
        public string host;
        private string lastReadMemFileName = null;
        private uint lastReadMemSeq;
        public NetworkStream netStream;
        public Thread packetRecvThread;
        public int port;
        public volatile int progress = -1;
        private object syncLock = new object();
        public TcpClient tcp;

        public event logHandler onLogArrival;

        private string byteToHex(byte[] datBuf, int type)
        {
            string str = "";
            for (int i = 0; i < datBuf.Length; i++)
            {
                str = str + datBuf[i].ToString("X2") + " ";
            }
            return str;
        }

        public void connectToServer()
        {
            if (this.tcp != null)
            {
                this.disconnect(true);
            }
            this.tcp = new TcpClient();
            this.tcp.NoDelay = true;
            this.tcp.Connect(this.host, this.port);
            this.currentSeq = 0;
            this.netStream = this.tcp.GetStream();
            this.heartbeatSendable = 1;
            this.packetRecvThread = new Thread(new ThreadStart(this.packetRecvThreadStart));
            this.packetRecvThread.Start();
            this.log("Server connected.");
        }

        public void disconnect(bool waitPacketThread = true)
        {
            try
            {
                if (this.tcp != null)
                {
                    this.tcp.Close();
                }
                if (waitPacketThread && (this.packetRecvThread != null))
                {
                    this.packetRecvThread.Join();
                }
            }
            catch (Exception exception)
            {
                this.log(exception.Message);
            }
            this.tcp = null;
        }

        private void handlePacket(uint cmd, uint seq, byte[] dataBuf)
        {
            if (cmd == 9)
            {
                this.handleReadMem(seq, dataBuf);
            }
        }

        private void handleReadMem(uint seq, byte[] dataBuf)
        {
            if (seq != this.lastReadMemSeq)
            {
                this.log("seq != lastReadMemSeq, ignored");
            }
            else
            {
                this.lastReadMemSeq = 0;
                string lastReadMemFileName = this.lastReadMemFileName;
                if (lastReadMemFileName != null)
                {
                    FileStream stream = new FileStream(lastReadMemFileName, FileMode.Create);
                    stream.Write(dataBuf, 0, dataBuf.Length);
                    stream.Close();
                    this.log("dump saved into " + lastReadMemFileName + " successfully");
                }
                else
                {
                    this.log(this.byteToHex(dataBuf, 0));
                }
            }
        }

        public void log(string msg)
        {
            if (this.onLogArrival != null)
            {
                this.onLogArrival(msg);
            }
            try
            {
                Program.gCmdWindow.BeginInvoke(Program.gCmdWindow.delAddLog, new object[] { msg });
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void packetRecvThreadStart()
        {
            byte[] buf = new byte[0x54];
            uint[] numArray = new uint[0x10];
            NetworkStream netStream = this.netStream;
            while (true)
            {
                try
                {
                    byte[] buffer2;
                    if (this.readNetworkStream(netStream, buf, buf.Length) == 0)
                    {
                        break;
                    }
                    int startIndex = 0;
                    uint num3 = BitConverter.ToUInt32(buf, startIndex);
                    startIndex += 4;
                    uint num4 = BitConverter.ToUInt32(buf, startIndex);
                    startIndex += 4;
                    uint num5 = BitConverter.ToUInt32(buf, startIndex);
                    startIndex += 4;
                    uint num6 = BitConverter.ToUInt32(buf, startIndex);
                    for (int i = 0; i < numArray.Length; i++)
                    {
                        startIndex += 4;
                        numArray[i] = BitConverter.ToUInt32(buf, startIndex);
                    }
                    startIndex += 4;
                    uint num8 = BitConverter.ToUInt32(buf, startIndex);
                    if (num6 != 0)
                    {
                        this.log(string.Format("packet: cmd = {0}, dataLen = {1}", num6, num8));
                    }
                    if (num3 != 0x12345678)
                    {
                        this.log(string.Format("broken protocol: magic = {0}, seq = {1}", num3, num4));
                        break;
                    }
                    if (num6 == 0)
                    {
                        if (num8 != 0)
                        {
                            buffer2 = new byte[num8];
                            this.readNetworkStream(netStream, buffer2, buffer2.Length);
                            string msg = Encoding.UTF8.GetString(buffer2);
                            this.log(msg);
                        }
                        lock (this.syncLock)
                        {
                            this.heartbeatSendable = 1;
                        }
                    }
                    else if (num8 != 0)
                    {
                        buffer2 = new byte[num8];
                        this.readNetworkStream(netStream, buffer2, buffer2.Length);
                        this.handlePacket(num6, num4, buffer2);
                    }
                }
                catch (Exception exception)
                {
                    this.log(exception.Message);
                    break;
                }
            }
            this.log("Server disconnected.");
            this.disconnect(false);
        }

        private int readNetworkStream(NetworkStream stream, byte[] buf, int length)
        {
            int offset = 0;
            bool flag = false;
            if (length > 0x186a0)
            {
                flag = true;
            }
            do
            {
                if (flag)
                {
                    this.progress = (int) ((((double) offset) / ((double) length)) * 100.0);
                }
                int num2 = stream.Read(buf, offset, length - offset);
                if (num2 == 0)
                {
                    return 0;
                }
                offset += num2;
            }
            while (offset < length);
            this.progress = -1;
            return length;
        }

        public void sendEmptyPacket(uint cmd, uint arg0 = 0, uint arg1 = 0, uint arg2 = 0)
        {
            uint[] args = new uint[0x10];
            args[0] = arg0;
            args[1] = arg1;
            args[2] = arg2;
            this.sendPacket(0, cmd, args, 0);
        }

        public void sendHeartbeatPacket()
        {
            if (this.tcp != null)
            {
                lock (this.syncLock)
                {
                    if (this.heartbeatSendable == 1)
                    {
                        this.heartbeatSendable = 0;
                        this.sendPacket(0, 0, null, 0);
                    }
                }
            }
        }

        public void sendHelloPacket()
        {
            this.sendPacket(0, 3, null, 0);
        }

        public void sendPacket(uint type, uint cmd, uint[] args, uint dataLen)
        {
            int index = 0;
            this.currentSeq += 0x3e8;
            byte[] array = new byte[0x54];
            BitConverter.GetBytes(0x12345678).CopyTo(array, index);
            index += 4;
            BitConverter.GetBytes(this.currentSeq).CopyTo(array, index);
            index += 4;
            BitConverter.GetBytes(type).CopyTo(array, index);
            index += 4;
            BitConverter.GetBytes(cmd).CopyTo(array, index);
            for (int i = 0; i < 0x10; i++)
            {
                index += 4;
                uint num3 = 0;
                if (args != null)
                {
                    num3 = args[i];
                }
                BitConverter.GetBytes(num3).CopyTo(array, index);
            }
            index += 4;
            BitConverter.GetBytes(dataLen).CopyTo(array, index);
            this.netStream.Write(array, 0, array.Length);
        }

        public void sendReadMemPacket(uint addr, uint size, uint pid, string fileName)
        {
            this.sendEmptyPacket(9, pid, addr, size);
            this.lastReadMemSeq = this.currentSeq;
            this.lastReadMemFileName = fileName;
        }

        public void sendReloadPacket()
        {
            this.sendPacket(0, 4, null, 0);
        }

        public void sendSaveFilePacket(string fileName, byte[] fileData)
        {
            byte[] array = new byte[0x200];
            Encoding.UTF8.GetBytes(fileName).CopyTo(array, 0);
            this.sendPacket(1, 1, null, (uint) (array.Length + fileData.Length));
            this.netStream.Write(array, 0, array.Length);
            this.netStream.Write(fileData, 0, fileData.Length);
        }

        public void sendWriteMemPacket(uint addr, uint pid, byte[] buf)
        {
            uint[] args = new uint[0x10];
            args[0] = pid;
            args[1] = addr;
            args[2] = (uint) buf.Length;
            this.sendPacket(1, 10, args, args[2]);
            this.netStream.Write(buf, 0, buf.Length);
        }

        public void setServer(string serverHost, int serverPort)
        {
            this.host = serverHost;
            this.port = serverPort;
        }

        public delegate void logHandler(string msg);
    }
}

