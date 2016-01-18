namespace ntrclient
{
    using IronPython.Hosting;
    using Microsoft.Scripting.Hosting;
    using System;
    using System.Windows.Forms;

    internal static class Program
    {
        public static CmdWindow gCmdWindow;
        public static ScriptScope globalScope;
        public static NtrClient ntrClient;
        public static ScriptEngine pyEngine;
        public static ScriptHelper scriptHelper;
        public static SettingsManager sm;

        public static void loadConfig()
        {
            sm = SettingsManager.LoadFromXml("ntrconfig.xml");
            sm.init();
        }

        [STAThread]
        private static void Main()
        {
            pyEngine = Python.CreateEngine();
            ntrClient = new NtrClient();
            scriptHelper = new ScriptHelper();
            globalScope = pyEngine.CreateScope();
            globalScope.SetVariable("nc", scriptHelper);
            loadConfig();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            gCmdWindow = new CmdWindow();
            Application.Run(gCmdWindow);
        }

        public static void saveConfig()
        {
            SettingsManager.SaveToXml("ntrconfig.xml", sm);
        }
    }
}

