using BrutalAPI;
using System;
using UnityEngine;

namespace THE_DEAD
{
    // Token: 0x0200007D RID: 125
    public class GenericItem<T> : Item where T : BaseWearableSO
    {
        // Token: 0x06000204 RID: 516 RVA: 0x00017EF4 File Offset: 0x000160F4
        public override BaseWearableSO Wearable()
        {
            T t = ScriptableObject.CreateInstance<T>();
            t.BaseWearable(this);
            this.Item = t;
            return t;
        }

        // Token: 0x0400011A RID: 282
        public T Item;
    }
}
