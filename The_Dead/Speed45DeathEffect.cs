// Decompiled with JetBrains decompiler
// Type: THE_DEAD.Speed45DeathEffect
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using UnityEngine;

namespace THE_DEAD
{
  public class Speed45DeathEffect : EffectSO
  {
    [SerializeField]
    public bool _obliterationDeath;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      int storedValue = caster.GetStoredValue((UnitStoredValueNames) 222223333);
      Joyce.paranoidTimer_InTurn = false;
      exitAmount = 0;
      if (storedValue > 45)
      {
        for (int index = 0; index < targets.Length; ++index)
        {
          if (targets[index].HasUnit && targets[index].Unit.DirectDeath(caster, true))
            ++exitAmount;
        }
      }
      return exitAmount > 0;
    }
  }
}
