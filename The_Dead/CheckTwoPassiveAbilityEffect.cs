// Decompiled with JetBrains decompiler
// Type: THE_DEAD.CheckTwoPassiveAbilityEffect
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using UnityEngine;

namespace THE_DEAD
{
  public class CheckTwoPassiveAbilityEffect : EffectSO
  {
    [SerializeField]
    public PassiveAbilityTypes _type;
    [SerializeField]
    public PassiveAbilityTypes _type1;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 0;
      foreach (TargetSlotInfo target in targets)
      {
        if (target.HasUnit && target.Unit.ContainsPassiveAbility(this._type1))
          exitAmount = 2;
        if (target.HasUnit && target.Unit.ContainsPassiveAbility(this._type))
          exitAmount = 10;
      }
      return exitAmount > 0;
    }
  }
}
