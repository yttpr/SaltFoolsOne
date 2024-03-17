// Decompiled with JetBrains decompiler
// Type: THE_DEAD.CasterStoredValueSetEffect
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using UnityEngine;

namespace THE_DEAD
{
  public class CasterStoredValueSetEffect : EffectSO
  {
    [SerializeField]
    public bool _increase = true;
    [SerializeField]
    public int _minimumValue = 1;
    [SerializeField]
    public UnitStoredValueNames _valueName = UnitStoredValueNames.PunchA;
    [SerializeField]
    public bool _randomBetweenPrevious;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = caster.GetStoredValue(this._valueName);
      if (this._randomBetweenPrevious)
        entryVariable = Random.Range(this.PreviousExitValue, entryVariable + 1);
      exitAmount = entryVariable;
      caster.SetStoredValue(this._valueName, exitAmount);
      return true;
    }
  }
}
