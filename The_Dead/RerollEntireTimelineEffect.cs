﻿// Decompiled with JetBrains decompiler
// Type: THE_DEAD.RerollEntireTimelineEffect
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

namespace THE_DEAD
{
  public class RerollEntireTimelineEffect : ReRollRandomTimelineAbilityEffect
  {
    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      return base.PerformEffect(stats, caster, targets, areTargetSlots, stats.timeline.Round.Count - 1, out exitAmount);
    }
  }
}
