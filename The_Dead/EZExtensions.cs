using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace THE_DEAD
{
    // Token: 0x0200007B RID: 123
    public static class EZExtensions
    {
        // Token: 0x060001FA RID: 506 RVA: 0x00017C0C File Offset: 0x00015E0C
        public static T GetRandom<T>(this T[] array)
        {
            bool flag = array.Length == 0;
            T result;
            if (flag)
            {
                result = default(T);
            }
            else
            {
                result = array[UnityEngine.Random.Range(0, array.Length)];
            }
            return result;
        }

        // Token: 0x060001FB RID: 507 RVA: 0x00017C44 File Offset: 0x00015E44
        public static T GetRandom<T>(this List<T> list)
        {
            bool flag = list.Count <= 0;
            T result;
            if (flag)
            {
                result = default(T);
            }
            else
            {
                result = list[UnityEngine.Random.Range(0, list.Count)];
            }
            return result;
        }

        // Token: 0x060001FC RID: 508 RVA: 0x00017C84 File Offset: 0x00015E84
        public static T[] SelfArray<T>(this T self)
        {
            return new T[]
            {
                self
            };
        }

        // Token: 0x060001FD RID: 509 RVA: 0x00017CA4 File Offset: 0x00015EA4
        public static int GetStatus(this IUnit self, StatusEffectType type)
        {
            IStatusEffector statusEffector = self as IStatusEffector;
            bool flag = statusEffector != null;
            if (flag)
            {
                foreach (IStatusEffect statusEffect in statusEffector.StatusEffects)
                {
                    bool flag2 = statusEffect.EffectType == type;
                    if (flag2)
                    {
                        return statusEffect.StatusContent;
                    }
                }
            }
            return 0;
        }

        // Token: 0x060001FE RID: 510 RVA: 0x00017D28 File Offset: 0x00015F28
        public static Type[] GetAllDerived(Type baze)
        {
            List<Type> list = new List<Type>();
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (Type type in assembly.GetTypes())
                {
                    bool flag = baze.IsAssignableFrom(type) && !list.Contains(type) && type != baze;
                    if (flag)
                    {
                        list.Add(type);
                    }
                }
            }
            return list.ToArray();
        }

        // Token: 0x060001FF RID: 511 RVA: 0x00017DC0 File Offset: 0x00015FC0
        public static bool PCall(Action orig, string name = null)
        {
            try
            {
                orig();
            }
            catch
            {
                Debug.LogError((name != null) ? (name + " failed") : (orig.ToString() + " failed"));
                return false;
            }
            return true;
        }
    }
}
