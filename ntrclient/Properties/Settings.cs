﻿namespace ntrclient.Properties
{
    using System.CodeDom.Compiler;
    using System.Collections.Specialized;
    using System.Configuration;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0"), CompilerGenerated]
    internal sealed class Settings : ApplicationSettingsBase
    {
        private static Settings defaultInstance = ((Settings) SettingsBase.Synchronized(new Settings()));

        public static Settings Default
        {
            get
            {
                return defaultInstance;
            }
        }

        [ApplicationScopedSetting, DebuggerNonUserCode]
        public StringCollection quickcmd
        {
            get
            {
                return (StringCollection) this["quickcmd"];
            }
        }
    }
}

