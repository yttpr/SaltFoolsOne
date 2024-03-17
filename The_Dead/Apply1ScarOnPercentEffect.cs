// Decompiled with JetBrains decompiler
// Type: THE_DEAD.Apply1ScarOnPercentEffect
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using System.Collections.Generic;
using UnityEngine;

namespace THE_DEAD
{
  public class Apply1ScarOnPercentEffect : EffectSO
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
      stats.statusEffectDataBase.TryGetValue(StatusEffectType.Scars, out effectInfo);
      if (Random.Range(0, 100) < entryVariable)
      {
        if (this._justOneTarget)
        {
          List<TargetSlotInfo> targetSlotInfoList = new List<TargetSlotInfo>((IEnumerable<TargetSlotInfo>) targets);
          for (int index = targetSlotInfoList.Count - 1; index >= 0; --index)
          {
            if (!targetSlotInfoList[index].HasUnit)
              targetSlotInfoList.RemoveAt(index);
          }
          if (targetSlotInfoList.Count > 0)
          {
            int index = Random.Range(0, targetSlotInfoList.Count);
            int amount = 1;
            Scars_StatusEffect scarsStatusEffect = new Scars_StatusEffect(amount);
            scarsStatusEffect.SetEffectInformation(effectInfo);
            if (targetSlotInfoList[index].Unit.ApplyStatusEffect((IStatusEffect) scarsStatusEffect, amount))
              exitAmount += amount;
          }
        }
        else
        {
          for (int index = 0; index < targets.Length; ++index)
          {
            if (targets[index].HasUnit)
            {
              int amount = 1;
              Scars_StatusEffect scarsStatusEffect = new Scars_StatusEffect(amount);
              scarsStatusEffect.SetEffectInformation(effectInfo);
              if (targets[index].Unit.ApplyStatusEffect((IStatusEffect) scarsStatusEffect, amount))
                ++exitAmount;
            }
          }
        }
      }
      return exitAmount > 0;
    }
  }
}
