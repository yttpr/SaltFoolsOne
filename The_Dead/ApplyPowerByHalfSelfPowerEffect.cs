// Decompiled with JetBrains decompiler
// Type: THE_DEAD.ApplyPowerByHalfSelfPowerEffect
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using System;

namespace THE_DEAD
{
  public class ApplyPowerByHalfSelfPowerEffect : ApplyPowerEffect
  {
    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      int entryVariable1 = 0;
      if (caster is IStatusEffector statusEffector)
      {
        foreach (IStatusEffect statusEffect in statusEffector.StatusEffects)
        {
          if (statusEffect.EffectType == (StatusEffectType) 456789)
          {
            entryVariable1 = (int) Math.Ceiling((double) ((float) statusEffect.StatusContent / 2f));
            break;
          }
        }
      }
      return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable1, out exitAmount);
    }
  }
}
