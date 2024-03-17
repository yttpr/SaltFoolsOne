﻿// Decompiled with JetBrains decompiler
// Type: THE_DEAD.ApplyPermenantRupturedEffect
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

namespace THE_DEAD
{
  public class ApplyPermenantRupturedEffect : EffectSO
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
      stats.statusEffectDataBase.TryGetValue(StatusEffectType.Ruptured, out effectInfo);
      for (int index = 0; index < targets.Length; ++index)
      {
        if (targets[index].HasUnit)
        {
          Ruptured_StatusEffect rupturedStatusEffect = new Ruptured_StatusEffect(0, 1);
          rupturedStatusEffect.SetEffectInformation(effectInfo);
          if (targets[index].Unit.ApplyStatusEffect((IStatusEffect) rupturedStatusEffect, 0))
            ++exitAmount;
        }
      }
      return exitAmount > 0;
    }
  }
}
