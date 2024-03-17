// Decompiled with JetBrains decompiler
// Type: THE_DEAD.CasterCheckStoredValueConditionTime45
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

namespace THE_DEAD
{
  public class CasterCheckStoredValueConditionTime45 : EffectConditionSO
  {
    public int minimumAmount = 1;

    public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex) => caster.GetStoredValue((UnitStoredValueNames) 32233223) >= 45;
  }
}
