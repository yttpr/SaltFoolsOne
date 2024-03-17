// Decompiled with JetBrains decompiler
// Type: THE_DEAD.BloomIfBuddingEffect
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using UnityEngine;

namespace THE_DEAD
{
  public class BloomIfBuddingEffect : EffectSO
  {
    [SerializeField]
    public PassiveAbilityTypes _type = (PassiveAbilityTypes) 222300;
    [SerializeField]
    public BasePassiveAbilitySO _passiveToAdd;

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
        if (target.HasUnit && target.Unit.ContainsPassiveAbility(this._type))
        {
          target.Unit.TryRemovePassiveAbility(this._type);
          if (target.HasUnit && target.Unit.AddPassiveAbility(this._passiveToAdd))
            ++exitAmount;
        }
        if (target.Unit.ContainsPassiveAbility(this._type))
          return false;
      }
      return exitAmount > 0;
    }
  }
}
