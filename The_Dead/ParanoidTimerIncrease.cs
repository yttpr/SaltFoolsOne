// Decompiled with JetBrains decompiler
// Type: THE_DEAD.ParanoidTimerIncrease
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using UnityEngine;

namespace THE_DEAD
{
  public class ParanoidTimerIncrease : EffectSO
  {
    [SerializeField]
    public PassiveAbilityTypes _type;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 1;
      foreach (TargetSlotInfo target in targets)
      {
        if (target.HasUnit && target.Unit.ContainsPassiveAbility((PassiveAbilityTypes) 9878776))
        {
          exitAmount = target.Unit.GetStoredValue((UnitStoredValueNames) 222223333);
          exitAmount += 3;
          target.Unit.SetStoredValue((UnitStoredValueNames) 222223333, exitAmount);
        }
      }
      Joyce.paranoidTimer_Increased = true;
      return exitAmount > 0;
    }
  }
}
