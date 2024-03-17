// Decompiled with JetBrains decompiler
// Type: THE_DEAD.ScarsInRangeFromTwoEffect
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using UnityEngine;

namespace THE_DEAD
{
  public class ScarsInRangeFromTwoEffect : EffectSO
  {
    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 0;
      StatusEffectInfoSO effectInfo;
      stats.statusEffectDataBase.TryGetValue(StatusEffectType.Scars, out effectInfo);
      for (int index = 0; index < targets.Length; ++index)
      {
        if (targets[index].HasUnit)
        {
          int amount = Random.Range(0, entryVariable + 2);
          if (amount > 0)
          {
            Scars_StatusEffect scarsStatusEffect = new Scars_StatusEffect(amount);
            scarsStatusEffect.SetEffectInformation(effectInfo);
            if (targets[index].Unit.ApplyStatusEffect((IStatusEffect) scarsStatusEffect, amount))
              ++exitAmount;
          }
        }
      }
      return exitAmount > 0;
    }
  }
}
