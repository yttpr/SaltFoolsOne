// Decompiled with JetBrains decompiler
// Type: THE_DEAD.SabotageEffect
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using System.Collections.Generic;

namespace THE_DEAD
{
  public class SabotageEffect : EffectSO
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
      foreach (CharacterCombat characterCombat in stats.CharactersOnField.Values)
      {
        foreach (IStatusEffect statusEffect in new List<IStatusEffect>((IEnumerable<IStatusEffect>) characterCombat.StatusEffects))
        {
          if (characterCombat.ApplyStatusEffect(statusEffect, 0))
            ++exitAmount;
        }
      }
      foreach (EnemyCombat enemyCombat in stats.EnemiesOnField.Values)
      {
        foreach (IStatusEffect statusEffect in new List<IStatusEffect>((IEnumerable<IStatusEffect>) enemyCombat.StatusEffects))
        {
          if (enemyCombat.ApplyStatusEffect(statusEffect, 0))
            ++exitAmount;
        }
      }
      foreach (CombatSlot characterSlot in stats.combatSlots._characterSlots)
      {
        foreach (ISlotStatusEffect statusEffect in new List<ISlotStatusEffect>((IEnumerable<ISlotStatusEffect>) characterSlot.StatusEffects))
        {
          if (characterSlot.ApplySlotStatusEffect(statusEffect, 0))
            ++exitAmount;
        }
      }
      foreach (CombatSlot enemySlot in stats.combatSlots._enemySlots)
      {
        foreach (ISlotStatusEffect statusEffect in new List<ISlotStatusEffect>((IEnumerable<ISlotStatusEffect>) enemySlot.StatusEffects))
        {
          if (enemySlot.ApplySlotStatusEffect(statusEffect, 0))
            ++exitAmount;
        }
      }
      return exitAmount > 0;
    }
  }
}
