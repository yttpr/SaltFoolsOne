// Decompiled with JetBrains decompiler
// Type: THE_DEAD.IndirectPlusStoredValueEffect
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using UnityEngine;

namespace THE_DEAD
{
  public class IndirectPlusStoredValueEffect : EffectSO
  {
    [SerializeField]
    public DeathType _deathType = DeathType.Basic;
    [SerializeField]
    public bool _usePreviousExitValue;
    [SerializeField]
    public bool _ignoreShield;
    [SerializeField]
    public bool _indirect;
    [SerializeField]
    public bool _returnKillAsSuccess;
    public UnitStoredValueNames _valueName = UnitStoredValueNames.None;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      if (this._usePreviousExitValue)
        entryVariable *= this.PreviousExitValue;
      exitAmount = 0;
      foreach (TargetSlotInfo target in targets)
      {
        if (target.HasUnit)
        {
          int targetSlotOffset = areTargetSlots ? target.SlotID - target.Unit.SlotID : -1;
          int amount = entryVariable;
          int storedValue = caster.GetStoredValue(this._valueName);
          int num = caster.WillApplyDamage(amount, target.Unit);
          DamageInfo damageInfo = target.Unit.Damage(num + storedValue, (IUnit) null, DeathType.Basic, targetSlotOffset, false, false, true);
          exitAmount += damageInfo.damageAmount;
        }
      }
      if (exitAmount > 0)
        caster.DidApplyDamage(exitAmount);
      return exitAmount > 0;
    }
  }
}
