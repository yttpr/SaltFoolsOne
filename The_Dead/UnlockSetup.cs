using System;

namespace THE_DEAD
{
    // Token: 0x02000098 RID: 152
    public static class UnlockSetup
    {
        // Token: 0x06000297 RID: 663 RVA: 0x0001BDDE File Offset: 0x00019FDE
        public static void Start()
        {
            UnlockSetup.UnlockedByDefault = !Config.Check("DoBossUnlockItems");
            UnlockSetup.DisableAllItems = !Config.Check("IncludeItemsAtAll");
        }

        // Token: 0x04000157 RID: 343
        public static bool UnlockedByDefault;

        // Token: 0x04000158 RID: 344
        public static bool DisableAllItems;
    }
}
