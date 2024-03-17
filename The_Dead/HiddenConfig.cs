using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace THE_DEAD
{
    // Token: 0x02000099 RID: 153
    public static class HiddenConfig
    {
        // Token: 0x170000E6 RID: 230
        // (get) Token: 0x06000298 RID: 664 RVA: 0x0001BE08 File Offset: 0x0001A008
        private static string baseSave
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", "LocalLow") + "\\ItsTheMaceo\\BrutalOrchestra\\";
            }
        }

        // Token: 0x170000E7 RID: 231
        // (get) Token: 0x06000299 RID: 665 RVA: 0x0001BE3C File Offset: 0x0001A03C
        private static string pathPlus
        {
            get
            {
                bool flag = !Directory.Exists(HiddenConfig.baseSave + "Mods\\");
                if (flag)
                {
                    Directory.CreateDirectory(HiddenConfig.baseSave + "Mods\\");
                }
                return HiddenConfig.baseSave + "Mods\\";
            }
        }

        // Token: 0x170000E8 RID: 232
        // (get) Token: 0x0600029A RID: 666 RVA: 0x0001BE90 File Offset: 0x0001A090
        public static string SavePath
        {
            get
            {
                bool flag = !Directory.Exists(HiddenConfig.pathPlus + "Trash\\");
                if (flag)
                {
                    Directory.CreateDirectory(HiddenConfig.pathPlus + "Trash\\");
                }
                return HiddenConfig.pathPlus + "Trash\\";
            }
        }

        // Token: 0x170000E9 RID: 233
        // (get) Token: 0x0600029B RID: 667 RVA: 0x0001BEE4 File Offset: 0x0001A0E4
        public static string SaveName
        {
            get
            {
                bool flag = !File.Exists(HiddenConfig.SavePath + "THE_DEAD_HiddenConfig.config");
                if (flag)
                {
                    HiddenConfig.WriteConfig(HiddenConfig.SavePath + "THE_DEAD_HiddenConfig.config");
                }
                return HiddenConfig.SavePath + "THE_DEAD_HiddenConfig.config";
            }
        }

        // Token: 0x0600029C RID: 668 RVA: 0x0001BF38 File Offset: 0x0001A138
        public static void WriteConfig(string location)
        {
            StreamWriter streamWriter = File.CreateText(location);
            XmlDocument xmlDocument = new XmlDocument();
            string text = "<config";
            foreach (string text2 in HiddenConfig.SaveConfigNames.Keys)
            {
                text += " ";
                text += text2;
                text += "='";
                text += HiddenConfig.SaveConfigNames[text2].ToString().ToLower();
                text += "'";
            }
            text += "> </config>";
            xmlDocument.LoadXml(text);
            xmlDocument.Save(streamWriter);
            streamWriter.Close();
        }

        // Token: 0x0600029D RID: 669 RVA: 0x0001C014 File Offset: 0x0001A214
        public static bool Check(string name)
        {
            bool flag = HiddenConfig.SaveConfigNames == null;
            if (flag)
            {
                HiddenConfig.SaveConfigNames = new Dictionary<string, bool>();
            }
            string saveName = HiddenConfig.SaveName;
            bool flag2 = true;
            FileStream fileStream = File.Open(HiddenConfig.SaveName, FileMode.Open);
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(fileStream);
            bool flag3 = xmlDocument.GetElementsByTagName("config").Count > 0;
            if (flag3)
            {
                bool flag4 = xmlDocument.GetElementsByTagName("config")[0].Attributes[name] != null;
                if (flag4)
                {
                    flag2 = bool.Parse(xmlDocument.GetElementsByTagName("config")[0].Attributes[name].Value);
                }
                bool flag5 = !HiddenConfig.SaveConfigNames.Keys.Contains(name);
                if (flag5)
                {
                    HiddenConfig.SaveConfigNames.Add(name, flag2);
                }
                else
                {
                    HiddenConfig.SaveConfigNames[name] = flag2;
                }
            }
            fileStream.Close();
            return flag2;
        }

        // Token: 0x0600029E RID: 670 RVA: 0x0001C110 File Offset: 0x0001A310
        public static void Set(string name, bool value)
        {
            bool flag = HiddenConfig.Check(name) != value;
            if (flag)
            {
                HiddenConfig.SaveConfigNames[name] = value;
                HiddenConfig.WriteConfig(HiddenConfig.SaveName);
            }
        }

        // Token: 0x0600029F RID: 671 RVA: 0x0001C148 File Offset: 0x0001A348
        public static void Setup()
        {
        }

        // Token: 0x04000159 RID: 345
        public const string ModID = "Trash";

        // Token: 0x0400015A RID: 346
        public const string FileName = "THE_DEAD_HiddenConfig";

        // Token: 0x0400015B RID: 347
        public const bool _default = true;

        // Token: 0x0400015C RID: 348
        public static Dictionary<string, bool> SaveConfigNames;
    }
}
