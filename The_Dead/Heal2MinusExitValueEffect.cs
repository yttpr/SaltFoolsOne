﻿// Decompiled with JetBrains decompiler
// Type: THE_DEAD.Heal2MinusExitValueEffect
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using UnityEngine;

namespace THE_DEAD
{
  public class Heal2MinusExitValueEffect : EffectSO
  {
    public bool usePreviousExitValue;
    public bool entryAsPercentage;
    [SerializeField]
    public bool _directHeal = true;
    [SerializeField]
    public bool _onlyIfHasHealthOver0;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      entryVariable = this.PreviousExitValue - 2;
      if (entryVariable < 0)
        entryVariable = 0;
      exitAmount = 0;
      foreach (TargetSlotInfo target in targets)
      {
        if (target.HasUnit && (!this._onlyIfHasHealthOver0 || target.Unit.CurrentHealth > 0))
        {
          int num = entryVariable;
          if (this.entryAsPercentage)
            num = target.Unit.CalculatePercentualAmount(num);
          exitAmount += target.Unit.Heal(num, HealType.Heal, this._directHeal);
        }
      }
      return exitAmount > 0;
    }
  }
}
