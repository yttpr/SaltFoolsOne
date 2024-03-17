using BepInEx;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace THE_DEAD
{
    // Token: 0x02000082 RID: 130
    public static class Config
    {
        // Token: 0x0600021D RID: 541 RVA: 0x00018A4F File Offset: 0x00016C4F
        public static void TryWriteConfig()
        {
            Config.WriteConfig(Config.SaveName);
        }

        // Token: 0x0600021E RID: 542 RVA: 0x00018A5C File Offset: 0x00016C5C
        public static void ExampleAwake()
        {
            bool flag = Config.Check("AddMisterOne");
            if (flag)
            {
            }
            bool flag2 = Config.Check("AddMisterTwo");
            if (flag2)
            {
            }
            bool flag3 = Config.Check("AddMisterThree");
            if (flag3)
            {
            }
            Config.TryWriteConfig();
        }

        // Token: 0x0600021F RID: 543 RVA: 0x00018AA0 File Offset: 0x00016CA0
        public static void WriteConfig(string location)
        {
            StreamWriter streamWriter = File.CreateText(location);
            XmlDocument xmlDocument = new XmlDocument();
            string text = "<config";
            foreach (string text2 in Config.SaveConfigNames.Keys)
            {
                text += " ";
                text += text2;
                text += "='";
                text += Config.SaveConfigNames[text2].ToString().ToLower();
                text += "'";
            }
            text += "> </config>";
            xmlDocument.LoadXml(text);
            xmlDocument.Save(streamWriter);
            streamWriter.Close();
        }

        // Token: 0x06000220 RID: 544 RVA: 0x00018B7C File Offset: 0x00016D7C
        public static bool Check(string name)
        {
            bool flag = Config.SaveConfigNames == null;
            if (flag)
            {
                Config.SaveConfigNames = new Dictionary<string, bool>();
            }
            string saveName = Config.SaveName;
            bool flag2 = true;
            FileStream fileStream = File.Open(Config.SaveName, FileMode.Open);
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
                bool flag5 = !Config.SaveConfigNames.Keys.Contains(name);
                if (flag5)
                {
                    Config.SaveConfigNames.Add(name, flag2);
                }
                else
                {
                    Config.SaveConfigNames[name] = flag2;
                }
            }
            fileStream.Close();
            return flag2;
        }

        // Token: 0x06000221 RID: 545 RVA: 0x00018C78 File Offset: 0x00016E78
        public static void Set(string name, bool value)
        {
            bool flag = Config.Check(name) != value;
            if (flag)
            {
                Config.SaveConfigNames[name] = value;
                Config.WriteConfig(Config.SaveName);
            }
        }

        // Token: 0x170000C5 RID: 197
        // (get) Token: 0x06000222 RID: 546 RVA: 0x00018CB0 File Offset: 0x00016EB0
        private static string pathPlus
        {
            get
            {
                return Paths.BepInExRootPath + "\\Plugins\\";
            }
        }

        // Token: 0x170000C6 RID: 198
        // (get) Token: 0x06000223 RID: 547 RVA: 0x00018CD4 File Offset: 0x00016ED4
        public static string SavePath
        {
            get
            {
                bool flag = !Directory.Exists(Config.pathPlus + "SaltFoolsTM\\");
                if (flag)
                {
                    Directory.CreateDirectory(Config.pathPlus + "SaltFoolsTM\\");
                }
                return Config.pathPlus + "SaltFoolsTM\\";
            }
        }

        // Token: 0x170000C7 RID: 199
        // (get) Token: 0x06000224 RID: 548 RVA: 0x00018D28 File Offset: 0x00016F28
        public static string SaveName
        {
            get
            {
                bool flag = !File.Exists(Config.SavePath + "Joyce.config");
                if (flag)
                {
                    Config.WriteConfig(Config.SavePath + "Joyce.config");
                }
                return Config.SavePath + "Joyce.config";
            }
        }

        // Token: 0x04000123 RID: 291
        public const string FolderName = "SaltFoolsTM";

        // Token: 0x04000124 RID: 292
        public const string FileName = "Joyce";

        // Token: 0x04000125 RID: 293
        public const bool Default = true;

        // Token: 0x04000126 RID: 294
        public static Dictionary<string, bool> SaveConfigNames;
    }
}
