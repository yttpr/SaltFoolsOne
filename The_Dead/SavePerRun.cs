using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;

namespace THE_DEAD
{
    // Token: 0x02000080 RID: 128
    public static class SavePerRun
    {
        // Token: 0x170000BD RID: 189
        // (get) Token: 0x0600020C RID: 524 RVA: 0x000182CC File Offset: 0x000164CC
        private static string baseSave
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", "LocalLow") + "\\ItsTheMaceo\\BrutalOrchestra\\";
            }
        }

        // Token: 0x170000BE RID: 190
        // (get) Token: 0x0600020D RID: 525 RVA: 0x00018300 File Offset: 0x00016500
        private static string pathPlus
        {
            get
            {
                bool flag = !Directory.Exists(SavePerRun.baseSave + "Mods\\");
                if (flag)
                {
                    Directory.CreateDirectory(SavePerRun.baseSave + "Mods\\");
                }
                return SavePerRun.baseSave + "Mods\\";
            }
        }

        // Token: 0x170000BF RID: 191
        // (get) Token: 0x0600020E RID: 526 RVA: 0x00018354 File Offset: 0x00016554
        public static string SavePath
        {
            get
            {
                bool flag = !Directory.Exists(SavePerRun.pathPlus + "SaltTestNPC\\");
                if (flag)
                {
                    Directory.CreateDirectory(SavePerRun.pathPlus + "SaltTestNPC\\");
                }
                return SavePerRun.pathPlus + "SaltTestNPC\\";
            }
        }

        // Token: 0x170000C0 RID: 192
        // (get) Token: 0x0600020F RID: 527 RVA: 0x000183A8 File Offset: 0x000165A8
        public static string SaveName
        {
            get
            {
                bool flag = !File.Exists(SavePerRun.SavePath + "RunData.config");
                if (flag)
                {
                    SavePerRun.WriteConfig(SavePerRun.SavePath + "RunData.config");
                }
                return SavePerRun.SavePath + "RunData.config";
            }
        }

        // Token: 0x06000210 RID: 528 RVA: 0x000183FC File Offset: 0x000165FC
        public static void WriteConfig(string location)
        {
            StreamWriter streamWriter = File.CreateText(location);
            XmlDocument xmlDocument = new XmlDocument();
            string text = "<config";
            foreach (string text2 in SavePerRun.SaveConfigNames.Keys)
            {
                text += " ";
                text += text2;
                text += "='";
                text += SavePerRun.SaveConfigNames[text2].ToString().ToLower();
                text += "'";
            }
            text += "> </config>";
            xmlDocument.LoadXml(text);
            xmlDocument.Save(streamWriter);
            streamWriter.Close();
        }

        // Token: 0x06000211 RID: 529 RVA: 0x000184D8 File Offset: 0x000166D8
        public static bool Check(string name)
        {
            bool flag = SavePerRun.SaveConfigNames == null;
            if (flag)
            {
                SavePerRun.SaveConfigNames = new Dictionary<string, bool>();
            }
            string saveName = SavePerRun.SaveName;
            bool flag2 = false;
            FileStream fileStream = File.Open(SavePerRun.SaveName, FileMode.Open);
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
                bool flag5 = !SavePerRun.SaveConfigNames.Keys.Contains(name);
                if (flag5)
                {
                    SavePerRun.SaveConfigNames.Add(name, flag2);
                }
                else
                {
                    SavePerRun.SaveConfigNames[name] = flag2;
                }
            }
            fileStream.Close();
            return flag2;
        }

        // Token: 0x06000212 RID: 530 RVA: 0x000185D4 File Offset: 0x000167D4
        public static void Set(string name, bool value)
        {
            bool flag = SavePerRun.Check(name) != value;
            if (flag)
            {
                SavePerRun.SaveConfigNames[name] = value;
                SavePerRun.WriteConfig(SavePerRun.SaveName);
            }
        }

        // Token: 0x06000213 RID: 531 RVA: 0x0001860C File Offset: 0x0001680C
        public static void OnEmbarkPressed(Action<MainMenuController> orig, MainMenuController self)
        {
            orig(self);
            List<string> list = new List<string>();
            foreach (string item in SavePerRun.SaveConfigNames.Keys)
            {
                list.Add(item);
            }
            foreach (string key in list)
            {
                SavePerRun.SaveConfigNames[key] = false;
            }
            SavePerRun.WriteConfig(SavePerRun.SaveName);
        }

        // Token: 0x06000214 RID: 532 RVA: 0x000186CC File Offset: 0x000168CC
        public static void Setup()
        {
            IDetour detour = new Hook(typeof(MainMenuController).GetMethod("OnEmbarkPressed", (BindingFlags)(-1)), typeof(SavePerRun).GetMethod("OnEmbarkPressed", (BindingFlags)(-1)));
        }

        // Token: 0x0400011D RID: 285
        public const string ModID = "SaltTestNPC";

        // Token: 0x0400011E RID: 286
        public const string FileName = "RunData";

        // Token: 0x0400011F RID: 287
        public static Dictionary<string, bool> SaveConfigNames;
    }
}
