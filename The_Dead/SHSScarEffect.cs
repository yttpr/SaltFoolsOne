// Decompiled with JetBrains decompiler
// Type: THE_DEAD.SHSScarEffect
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

namespace THE_DEAD
{
  public class SHSScarEffect : EffectSO
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
      if (caster.GetStoredValue((UnitStoredValueNames) 59995) == 1)
        return exitAmount == 0;
      for (int index = 0; index < targets.Length; ++index)
      {
        if (targets[index].HasUnit)
        {
          Scars_StatusEffect scarsStatusEffect = new Scars_StatusEffect(entryVariable);
          scarsStatusEffect.SetEffectInformation(effectInfo);
          if (targets[index].Unit.ApplyStatusEffect((IStatusEffect) scarsStatusEffect, entryVariable))
            ++exitAmount;
        }
        int newValue = caster.GetStoredValue((UnitStoredValueNames) 59997) + 1;
        caster.SetStoredValue((UnitStoredValueNames) 59997, newValue);
      }
      return exitAmount > 0;
    }
  }
}
