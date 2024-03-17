// Decompiled with JetBrains decompiler
// Type: THE_DEAD.ApplySporesEffect
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using System;
using System.Reflection;
using UnityEngine;

namespace THE_DEAD
{
  public class ApplySporesEffect : EffectSO
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
      stats.statusEffectDataBase.TryGetValue((StatusEffectType) 202303, out effectInfo);
      for (int index1 = 0; index1 < targets.Length; ++index1)
      {
        if (targets[index1].HasUnit)
        {
          int amount = this._randomBetweenPrevious ? UnityEngine.Random.Range(this.PreviousExitValue, entryVariable + 1) : entryVariable;
          IStatusEffect statusEffect = (IStatusEffect) new Spores_StatusEffect(amount);
          IStatusEffector unit = targets[index1].Unit as IStatusEffector;
          bool flag = false;
          int index2 = 999;
          for (int index3 = 0; index3 < unit.StatusEffects.Count; ++index3)
          {
            if (unit.StatusEffects[index3].EffectType == statusEffect.EffectType)
            {
              index2 = index3;
              flag = true;
            }
          }
          if (flag)
          {
            foreach (MethodBase constructor in unit.StatusEffects[index2].GetType().GetConstructors())
            {
              if (constructor.GetParameters().Length == 2)
                statusEffect = (IStatusEffect) Activator.CreateInstance(unit.StatusEffects[index2].GetType(), (object) amount, (object) 0);
            }
          }
          statusEffect.SetEffectInformation(effectInfo);
          if (targets[index1].Unit.ApplyStatusEffect(statusEffect, amount))
            ++exitAmount;
        }
      }
      return exitAmount > 0;
    }
  }
}
