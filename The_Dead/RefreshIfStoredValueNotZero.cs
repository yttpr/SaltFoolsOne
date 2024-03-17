// Decompiled with JetBrains decompiler
// Type: THE_DEAD.RefreshIfStoredValueNotZero
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using UnityEngine;

namespace THE_DEAD
{
  public class RefreshIfStoredValueNotZero : EffectSO
  {
    [SerializeField]
    public bool _doesExhaustInstead;
    [SerializeField]
    public UnitStoredValueNames _valueName = UnitStoredValueNames.PunchA;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 0;
      if (caster.GetStoredValue(this._valueName) > 0)
      {
        for (int index = 0; index < targets.Length; ++index)
        {
          if (targets[index].HasUnit && (this._doesExhaustInstead ? targets[index].Unit.ExhaustAbilityUse() : targets[index].Unit.RefreshAbilityUse()))
          {
            ++exitAmount;
            int newValue = caster.GetStoredValue(this._valueName) - entryVariable;
            if (newValue < 0)
              newValue = 0;
            caster.SetStoredValue(this._valueName, newValue);
          }
        }
      }
      return exitAmount > 0;
    }
  }
}
