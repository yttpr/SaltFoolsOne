using System;
using UnityEngine;

namespace BrutalAPI
{
    // Token: 0x02000002 RID: 2
    public class DoubleEffectItem : Item
    {
        // Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
        public override BaseWearableSO Wearable()
        {
            CustomDoublePerformEffectWearable customDoublePerformEffectWearable = ScriptableObject.CreateInstance<CustomDoublePerformEffectWearable>();
            customDoublePerformEffectWearable.BaseWearable(this);
            customDoublePerformEffectWearable._firstEffects = ExtensionMethods.ToEffectInfoArray(this.firstEffects);
            customDoublePerformEffectWearable._firstImmediateEffect = this._firsteEffectImmediate;
            customDoublePerformEffectWearable.doesItemPopUp = this.firstPopUp;
            customDoublePerformEffectWearable._secondEffects = ExtensionMethods.ToEffectInfoArray(this.secondEffects);
            customDoublePerformEffectWearable._secondImmediateEffect = this._firsteEffectImmediate;
            customDoublePerformEffectWearable._secondPerformTriggersOn = this.SecondTrigger;
            customDoublePerformEffectWearable._secondDoesPerformItemPopUp = this.secondPopUp;
            customDoublePerformEffectWearable._secondPerformConditions = this.secondTriggerConditions;
            return customDoublePerformEffectWearable;
        }

        // Token: 0x04000001 RID: 1
        public Effect[] firstEffects = new Effect[0];

        // Token: 0x04000002 RID: 2
        public Effect[] secondEffects = new Effect[0];

        // Token: 0x04000003 RID: 3
        public bool _firsteEffectImmediate = false;

        // Token: 0x04000004 RID: 4
        public bool _secondImmediateEffect = false;

        // Token: 0x04000005 RID: 5
        public TriggerCalls[] SecondTrigger = new TriggerCalls[0];

        // Token: 0x04000006 RID: 6
        public TriggerCalls[] FirstTrigger = new TriggerCalls[0];

        // Token: 0x04000007 RID: 7
        public bool firstPopUp = true;

        // Token: 0x04000008 RID: 8
        public bool secondPopUp = true;

        // Token: 0x04000009 RID: 9
        public EffectorConditionSO[] secondTriggerConditions = new EffectorConditionSO[0];
    }
}
