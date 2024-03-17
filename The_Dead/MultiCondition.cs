// Decompiled with JetBrains decompiler
// Type: THE_DEAD.MultiCondition
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using UnityEngine;

namespace THE_DEAD
{
  public class MultiCondition : EffectConditionSO
  {
    public EffectConditionSO[] conditions;
    public bool And = true;

    public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
    {
      foreach (EffectConditionSO condition in this.conditions)
      {
        bool flag = condition.MeetCondition(caster, effects, currentIndex);
        if (this.And && !flag)
          return false;
        if (!this.And & flag)
          return true;
      }
      return this.And;
    }

    public static MultiCondition Create(EffectConditionSO[] cond, bool and = true)
    {
      MultiCondition instance = ScriptableObject.CreateInstance<MultiCondition>();
      instance.conditions = cond;
      instance.And = and;
      return instance;
    }

    public static MultiCondition Create(
      EffectConditionSO first,
      EffectConditionSO second,
      bool and = true)
    {
      MultiCondition instance = ScriptableObject.CreateInstance<MultiCondition>();
      instance.conditions = new EffectConditionSO[2]
      {
        first,
        second
      };
      instance.And = and;
      return instance;
    }
  }
}
