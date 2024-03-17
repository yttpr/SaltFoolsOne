// Decompiled with JetBrains decompiler
// Type: THE_DEAD.WitherIfLessHealthEffect
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using BrutalAPI;

namespace THE_DEAD
{
  public class WitherIfLessHealthEffect : EffectSO
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
      foreach (TargetSlotInfo target in targets)
      {
        if (target.HasUnit && target.Unit.CurrentHealth < caster.CurrentHealth && target.Unit.AddPassiveAbility(Passives.Withering))
          ++exitAmount;
      }
      return exitAmount > 0;
    }
  }
}
