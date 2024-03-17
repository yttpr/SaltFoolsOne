// Decompiled with JetBrains decompiler
// Type: THE_DEAD.SkipValueChangeEffect
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using UnityEngine;

namespace THE_DEAD
{
  public class SkipValueChangeEffect : EffectSO
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
      exitAmount = 1;
      int storedValue = caster.GetStoredValue((UnitStoredValueNames) 222223333);
      int num1 = caster.GetStoredValue((UnitStoredValueNames) 9889998);
      int num2 = 0;
      int num3 = 0;
      if (entryVariable == 0)
      {
        num2 = 5;
        num3 = 14;
      }
      if (entryVariable == 1)
      {
        num2 = 6;
        num3 = 16;
      }
      if (entryVariable == 2)
      {
        num2 = 7;
        num3 = 18;
      }
      if (entryVariable == 3)
      {
        num2 = 8;
        num3 = 20;
      }
      if (Random.Range(0, 100) < num1)
      {
        int newValue = storedValue + num3;
        caster.SetStoredValue((UnitStoredValueNames) 222223333, newValue);
        num2 = 0;
        num1 = 0;
      }
      int newValue1 = num1 + num2;
      caster.SetStoredValue((UnitStoredValueNames) 9889998, newValue1);
      return true;
    }
  }
}
