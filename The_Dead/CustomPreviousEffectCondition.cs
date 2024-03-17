// Decompiled with JetBrains decompiler
// Type: THE_DEAD.CustomPreviousEffectCondition
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using UnityEngine;

namespace THE_DEAD
{
  public class CustomPreviousEffectCondition : EffectConditionSO
  {
    public bool wasSuccessful = false;
    [Range(1f, 20f)]
    public int previousAmount = 1;
    public UnitStoredValueNames _valueName = UnitStoredValueNames.None;
    public int minimumAmount = 1;
    public int _checkValue = 0;

    public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
    {
      int index = currentIndex - this.previousAmount;
      return index >= 0 && index <= effects.Length && caster.GetStoredValue(this._valueName) == this._checkValue && effects[index].EffectSuccess == this.wasSuccessful;
    }
  }
}
