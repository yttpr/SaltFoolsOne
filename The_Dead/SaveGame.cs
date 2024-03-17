using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace THE_DEAD
{
    // Token: 0x02000081 RID: 129
    public static class SaveGame
    {
        // Token: 0x170000C1 RID: 193
        // (get) Token: 0x06000215 RID: 533 RVA: 0x0001870C File Offset: 0x0001690C
        private static string baseSave
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", "LocalLow") + "\\ItsTheMaceo\\BrutalOrchestra\\";
            }
        }

        // Token: 0x170000C2 RID: 194
        // (get) Token: 0x06000216 RID: 534 RVA: 0x00018740 File Offset: 0x00016940
        private static string pathPlus
        {
            get
            {
                bool flag = !Directory.Exists(SaveGame.baseSave + "Mods\\");
                if (flag)
                {
                    Directory.CreateDirectory(SaveGame.baseSave + "Mods\\");
                }
                return SaveGame.baseSave + "Mods\\";
            }
        }

        // Token: 0x170000C3 RID: 195
        // (get) Token: 0x06000217 RID: 535 RVA: 0x00018794 File Offset: 0x00016994
        public static string SavePath
        {
            get
            {
                bool flag = !Directory.Exists(SaveGame.pathPlus + "SaltTestNPC\\");
                if (flag)
                {
                    Directory.CreateDirectory(SaveGame.pathPlus + "SaltTestNPC\\");
                }
                return SaveGame.pathPlus + "SaltTestNPC\\";
            }
        }

        // Token: 0x170000C4 RID: 196
        // (get) Token: 0x06000218 RID: 536 RVA: 0x000187E8 File Offset: 0x000169E8
        public static string SaveName
        {
            get
            {
                bool flag = !File.Exists(SaveGame.SavePath + "GameData.config");
                if (flag)
                {
                    SaveGame.WriteConfig(SaveGame.SavePath + "GameData.config");
                }
                return SaveGame.SavePath + "GameData.config";
            }
        }

        // Token: 0x06000219 RID: 537 RVA: 0x0001883C File Offset: 0x00016A3C
        public static void WriteConfig(string location)
        {
            StreamWriter streamWriter = File.CreateText(location);
            XmlDocument xmlDocument = new XmlDocument();
            string text = "<config";
            foreach (string text2 in SaveGame.SaveConfigNames.Keys)
            {
                text += " ";
                text += text2;
                text += "='";
                text += SaveGame.SaveConfigNames[text2].ToString().ToLower();
                text += "'";
            }
            text += "> </config>";
            xmlDocument.LoadXml(text);
            xmlDocument.Save(streamWriter);
            streamWriter.Close();
        }

        // Token: 0x0600021A RID: 538 RVA: 0x00018918 File Offset: 0x00016B18
        public static bool Check(string name)
        {
            bool flag = SaveGame.SaveConfigNames == null;
            if (flag)
            {
                SaveGame.SaveConfigNames = new Dictionary<string, bool>();
            }
            string saveName = SaveGame.SaveName;
            bool flag2 = false;
            FileStream fileStream = File.Open(SaveGame.SaveName, FileMode.Open);
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
                bool flag5 = !SaveGame.SaveConfigNames.Keys.Contains(name);
                if (flag5)
                {
                    SaveGame.SaveConfigNames.Add(name, flag2);
                }
                else
                {
                    SaveGame.SaveConfigNames[name] = flag2;
                }
            }
            fileStream.Close();
            return flag2;
        }

        // Token: 0x0600021B RID: 539 RVA: 0x00018A14 File Offset: 0x00016C14
        public static void Set(string name, bool value)
        {
            bool flag = SaveGame.Check(name) != value;
            if (flag)
            {
                SaveGame.SaveConfigNames[name] = value;
                SaveGame.WriteConfig(SaveGame.SaveName);
            }
        }

        // Token: 0x0600021C RID: 540 RVA: 0x00018A4C File Offset: 0x00016C4C
        public static void Setup()
        {
        }

        // Token: 0x04000120 RID: 288
        public const string ModID = "SaltTestNPC";

        // Token: 0x04000121 RID: 289
        public const string FileName = "GameData";

        // Token: 0x04000122 RID: 290
        public static Dictionary<string, bool> SaveConfigNames;
    }
}
