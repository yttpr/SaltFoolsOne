using System;

namespace THE_DEAD
{
    // Token: 0x02000097 RID: 151
    public static class Hi
    {
        // Token: 0x06000294 RID: 660 RVA: 0x0001BBF4 File Offset: 0x00019DF4
        public static void HelloWorld()
        {
            EZExtensions.PCall(new Action(Hi.SetConfig), "config setup");
            EZExtensions.PCall(new Action(UnlockSetup.Start), "unlock config stuff");
            EZExtensions.PCall(new Action(AbilityNameFix.Setup), "Set up ability name fixing");
            EZExtensions.PCall(new Action(HooksGeneral.Setup), "Generic hooks");
            EZExtensions.PCall(new Action(PynchonHandler.Setup), "Pynchon handler");
        }

        // Token: 0x06000295 RID: 661 RVA: 0x0001BC78 File Offset: 0x00019E78
        public static void GoodbyeWorld()
        {
            bool flag = !UnlockSetup.DisableAllItems;
            if (flag)
            {
                EZExtensions.PCall(new Action(Unlocks.Setup), "boss unlocks");
            }
            EZExtensions.PCall(new Action(FoolBossUnlockSystem.Setup), "fool boss unlock systme");
            EZExtensions.PCall(new Action(Backrooms.Setup), "Free fool events");
            bool debugger = Hi.Debugger;
            if (debugger)
            {
                EZExtensions.PCall(new Action(Backrooms.MoreFoolAll), "dump free fool events !!");
            }
        }

        // Token: 0x06000296 RID: 662 RVA: 0x0001BCF8 File Offset: 0x00019EF8
        public static void SetConfig()
        {
            Joyce.IncludeTheDead = Config.Check("IncludeTheDead");
            Joyce.IncludeTheFree = Config.Check("IncludeTheFree");
            Joyce.IncludeTheParanoid = Config.Check("IncludeTheParanoid");
            Joyce.IncludeTheLost = Config.Check("IncludeTheLost");
            Joyce.IncludeTheLiving = Config.Check("IncludeTheLiving");
            Joyce.IncludeTheRemnant = Config.Check("IncludeTheRemnant");
            Joyce.IncludeTheDelusional = Config.Check("IncludeTheDelusional");
            Joyce.IncludeTheBlooming = Config.Check("IncludeTheBlooming");
            Joyce.IncludeTheNoise = !Config.Check("ExcludeTheNoise");
            Joyce.IncludeTheAbortion = !Config.Check("ExcludeTheAbortion");
            Joyce.IncludeTheToasted = !Config.Check("ExcludeTheToasted");
            Joyce.IncludeVinceVersion = !Config.Check("DontUseVinceVersionOfRoger");
            Hi.AddSlop = !HiddenConfig.Check("NoSlopPleaseDontDisable");
            Config.TryWriteConfig();
        }

        // Token: 0x04000155 RID: 341
        public static bool Debugger;

        // Token: 0x04000156 RID: 342
        public static bool AddSlop;
    }
}
