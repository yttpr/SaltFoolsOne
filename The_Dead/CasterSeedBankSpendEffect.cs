// Decompiled with JetBrains decompiler
// Type: THE_DEAD.CasterSeedBankSpendEffect
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using UnityEngine;

namespace THE_DEAD
{
  public class CasterSeedBankSpendEffect : EffectSO
  {
    [SerializeField]
    public bool _increase = false;
    [SerializeField]
    public int _minimumValue = 0;
    [SerializeField]
    public UnitStoredValueNames _valueName = (UnitStoredValueNames) 202300;
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
      if (exitAmount < entryVariable)
        return false;
      exitAmount += this._increase ? entryVariable : -entryVariable;
      exitAmount = Mathf.Max(this._minimumValue, exitAmount);
      caster.SetStoredValue(this._valueName, exitAmount);
      return true;
    }
  }
}
