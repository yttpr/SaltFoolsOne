// Decompiled with JetBrains decompiler
// Type: THE_DEAD.NotTrueDeathEffect
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using BrutalAPI;
using UnityEngine;

namespace THE_DEAD
{
  public class NotTrueDeathEffect : EffectSO
  {
    [SerializeField]
    public bool _obliterationDeath;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      DamageEffect instance = ScriptableObject.CreateInstance<DamageEffect>();
      instance._indirect = true;
      Effect effect = new Effect((EffectSO) instance, 1, new IntentType?(IntentType.Damage_1_2), Slots.Self);
      exitAmount = 0;
      int storedValue = caster.GetStoredValue((UnitStoredValueNames) 98789);
      int num = entryVariable + storedValue;
      if (Random.Range(0, 100) >= num)
        return exitAmount == 0;
      for (int index = 0; index < targets.Length; ++index)
      {
        if (targets[index].HasUnit && targets[index].Unit.DirectDeath(caster, true))
        {
          ++exitAmount;
          caster.SetStoredValue((UnitStoredValueNames) 98789, 0);
          CombatManager.Instance.AddSubAction((CombatAction) new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1]
          {
            effect
          }), caster));
        }
      }
      return exitAmount > 0;
    }
  }
}
