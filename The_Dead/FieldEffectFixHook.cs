using MonoMod.RuntimeDetour;
using System;
using System.Reflection;
using UnityEngine;

namespace THE_DEAD
{
    // Token: 0x0200007F RID: 127
    public static class FieldEffectFixHook
    {
        // Token: 0x0600020A RID: 522 RVA: 0x00018018 File Offset: 0x00016218
        public static bool ApplySlotStatusEffect(Func<CombatSlot, ISlotStatusEffect, int, bool> orig, CombatSlot self, ISlotStatusEffect statusEffect, int amount)
        {
            bool flag = false;
            int index = -1;
            for (int i = 0; i < self.StatusEffects.Count; i++)
            {
                bool flag2 = self.StatusEffects[i].EffectType == statusEffect.EffectType && self.StatusEffects[i].GetType() != statusEffect.GetType();
                if (flag2)
                {
                    flag = true;
                    index = i;
                    break;
                }
            }
            bool flag3 = flag;
            if (flag3)
            {
                ConstructorInfo[] constructors = self.StatusEffects[index].GetType().GetConstructors();
                foreach (ConstructorInfo constructorInfo in constructors)
                {
                    ParameterInfo[] parameters = constructorInfo.GetParameters();
                    bool flag4 = parameters.Length == 4 && parameters[0].ParameterType == typeof(int) && parameters[1].ParameterType == typeof(int) && parameters[2].ParameterType == typeof(bool) && parameters[3].ParameterType == typeof(int);
                    if (flag4)
                    {
                        statusEffect = (ISlotStatusEffect)Activator.CreateInstance(self.StatusEffects[index].GetType(), new object[]
                        {
                            self.SlotID,
                            amount,
                            self.IsCharacter,
                            statusEffect.Restrictor
                        });
                    }
                    else
                    {
                        bool flag5 = parameters.Length == 3 && parameters[0].ParameterType == typeof(int) && parameters[1].ParameterType == typeof(int) && parameters[2].ParameterType == typeof(int);
                        if (flag5)
                        {
                            statusEffect = (ISlotStatusEffect)Activator.CreateInstance(self.StatusEffects[index].GetType(), new object[]
                            {
                                self.SlotID,
                                amount,
                                statusEffect.Restrictor
                            });
                        }
                    }
                }
            }
            bool result;
            try
            {
                result = orig(self, statusEffect, amount);
            }
            catch
            {
                Debug.LogError("super epic field effect compatibility failure!");
                result = false;
            }
            return result;
        }

        // Token: 0x0600020B RID: 523 RVA: 0x0001828C File Offset: 0x0001648C
        public static void Setup()
        {
            IDetour detour = new Hook(typeof(CombatSlot).GetMethod("ApplySlotStatusEffect", (BindingFlags)(-1)), typeof(FieldEffectFixHook).GetMethod("ApplySlotStatusEffect", (BindingFlags)(-1)));
        }
    }
}
