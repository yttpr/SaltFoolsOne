// Decompiled with JetBrains decompiler
// Type: THE_DEAD.ApplyAnestheticsEffect
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using System;
using System.Reflection;
using UnityEngine;

namespace THE_DEAD
{
  public class ApplyAnestheticsEffect : EffectSO
  {
    [SerializeField]
    public bool _justOneTarget;
    [SerializeField]
    public bool _randomBetweenPrevious;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 0;
      if (entryVariable <= 0)
        return false;
      StatusEffectInfoSO effectInfo;
      stats.statusEffectDataBase.TryGetValue((StatusEffectType) 204308, out effectInfo);
      stats.statusEffectDataBase.TryGetValue(StatusEffectType.Scars, out StatusEffectInfoSO _);
      for (int index = 0; index < targets.Length; ++index)
      {
        if (targets[index].HasUnit)
        {
          int amount = this._randomBetweenPrevious ? UnityEngine.Random.Range(this.PreviousExitValue, entryVariable + 1) : entryVariable;
          IStatusEffect statusEffect1 = (IStatusEffect) new Anesthetics_StatusEffect(amount);
          statusEffect1.SetEffectInformation(effectInfo);
          IStatusEffector unit = targets[index].Unit as IStatusEffector;
          bool flag = false;
          IStatusEffect statusEffect2 = (IStatusEffect) null;
          foreach (IStatusEffect statusEffect3 in unit.StatusEffects)
          {
            if (statusEffect3.EffectType == statusEffect1.EffectType)
            {
              statusEffect2 = statusEffect3;
              flag = true;
            }
          }
          if (flag && statusEffect2 != null)
          {
            foreach (MethodBase constructor in statusEffect2.GetType().GetConstructors())
            {
              if (constructor.GetParameters().Length == 2)
                statusEffect1 = (IStatusEffect) Activator.CreateInstance(statusEffect2.GetType(), (object) amount, (object) 0);
            }
          }
          if (targets[index].Unit.ApplyStatusEffect(statusEffect1, amount))
            ++exitAmount;
        }
      }
      return exitAmount > 0;
    }
  }
}
