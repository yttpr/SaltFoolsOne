// Decompiled with JetBrains decompiler
// Type: THE_DEAD.ApplySpores7_13Effect
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using UnityEngine;

namespace THE_DEAD
{
  public class ApplySpores7_13Effect : EffectSO
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
      entryVariable = Random.Range(7, 14);
      for (int index = 0; index < targets.Length; ++index)
      {
        if (targets[index].HasUnit)
        {
          int amount = Random.Range(9, 22);
          Spores_StatusEffect sporesStatusEffect = new Spores_StatusEffect(amount);
          sporesStatusEffect.SetEffectInformation(effectInfo);
          if (targets[index].Unit.ApplyStatusEffect((IStatusEffect) sporesStatusEffect, amount))
            ++exitAmount;
        }
      }
      return exitAmount > 0;
    }
  }
}
