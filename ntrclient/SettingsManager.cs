namespace ntrclient
{
    using System;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    using System.Xml.Serialization;

    public class SettingsManager
    {
        public void init()
        {
            if (this.quickCmds == null)
            {
                this.quickCmds = new string[10];
                for (int i = 0; i < this.quickCmds.Length; i++)
                {
                    this.quickCmds[i] = "";
                }
            }
        }

        public static SettingsManager LoadFromXml(string filePath)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(SettingsManager));
                    return (SettingsManager) serializer.Deserialize(reader);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            return new SettingsManager();
        }

        public static void SaveToXml(string filePath, SettingsManager sourceObj)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    new XmlSerializer(sourceObj.GetType()).Serialize((TextWriter) writer, sourceObj);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        public string[] quickCmds { get; set; }
    }
}

