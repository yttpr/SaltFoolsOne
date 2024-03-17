// Decompiled with JetBrains decompiler
// Type: THE_DEAD.NoiseBothValuesChangeEffect
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using UnityEngine;

namespace THE_DEAD
{
  public class NoiseBothValuesChangeEffect : EffectSO
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
      int storedValue = caster.GetStoredValue((UnitStoredValueNames) 59996);
      int num1 = 40;
      int num2 = 5;
      if (entryVariable == 1)
      {
        num1 = 40;
        num2 = 5;
      }
      if (entryVariable == 2)
      {
        num1 = 50;
        num2 = 10;
      }
      if (entryVariable == 3)
      {
        num1 = 60;
        num2 = 15;
      }
      if (entryVariable == 4)
      {
        num1 = 70;
        num2 = 20;
      }
      if (Random.Range(0, 100) < num1 - storedValue)
      {
        exitAmount = caster.GetStoredValue(this._valueName);
        exitAmount += this._increase ? 1 : -1;
        exitAmount = Mathf.Max(this._minimumValue, exitAmount);
        caster.SetStoredValue(this._valueName, exitAmount);
        int newValue = caster.GetStoredValue((UnitStoredValueNames) 59996) + num2;
        caster.SetStoredValue((UnitStoredValueNames) 59996, newValue);
        return true;
      }
      exitAmount = caster.GetStoredValue(this._valueName);
      exitAmount = Mathf.Max(this._minimumValue, exitAmount);
      caster.SetStoredValue(this._valueName, exitAmount);
      return true;
    }
  }
}
