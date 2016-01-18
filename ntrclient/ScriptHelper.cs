namespace ntrclient
{
    using System;
    using System.IO;
    using System.Runtime.InteropServices;

    public class ScriptHelper
    {
        public void attachprocess(int pid, uint patchAddr = 0)
        {
            Program.ntrClient.sendEmptyPacket(6, (uint) pid, patchAddr, 0);
        }

        public void connect(string host, int port)
        {
            Program.ntrClient.setServer(host, port);
            Program.ntrClient.connectToServer();
        }

        public void data(uint addr, uint size = 0x100, int pid = -1, string filename = null)
        {
            if ((filename == null) && (size > 0x400))
            {
                size = 0x400;
            }
            Program.ntrClient.sendReadMemPacket(addr, size, (uint) pid, filename);
        }

        public void disconnect()
        {
            Program.ntrClient.disconnect(true);
        }

        public void listprocess()
        {
            Program.ntrClient.sendEmptyPacket(5, 0, 0, 0);
        }

        public void listthread(int pid)
        {
            Program.ntrClient.sendEmptyPacket(7, (uint) pid, 0, 0);
        }

        public void memlayout(int pid)
        {
            Program.ntrClient.sendEmptyPacket(8, (uint) pid, 0, 0);
        }

        public void reload()
        {
            Program.ntrClient.sendReloadPacket();
        }

        public void sayhello()
        {
            Program.ntrClient.sendHelloPacket();
        }

        public void sendfile(string localPath, string remotePath)
        {
            FileStream stream = new FileStream(localPath, FileMode.Open);
            byte[] buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);
            stream.Close();
            Program.ntrClient.sendSaveFilePacket(remotePath, buffer);
        }

        public void write(uint addr, byte[] buf, int pid = -1)
        {
            Program.ntrClient.sendWriteMemPacket(addr, (uint) pid, buf);
        }
    }
}

