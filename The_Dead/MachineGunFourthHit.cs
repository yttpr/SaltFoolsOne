// Decompiled with JetBrains decompiler
// Type: THE_DEAD.MachineGunFourthHit
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using UnityEngine;

namespace THE_DEAD
{
  public class MachineGunFourthHit : EffectSO
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
      if (this._usePreviousExitValue)
        entryVariable *= this.PreviousExitValue;
      if (this._randomBetweenPrevious)
        entryVariable = Random.Range(this.PreviousExitValue, entryVariable + 1);
      exitAmount = 0;
      bool flag = false;
      if (caster.GetStoredValue((UnitStoredValueNames) 98788) < 8)
        return false;
      foreach (TargetSlotInfo target in targets)
      {
        if (target.HasUnit)
        {
          int targetSlotOffset = areTargetSlots ? target.SlotID - target.Unit.SlotID : -1;
          int amount1 = entryVariable;
          DamageInfo damageInfo;
          if (this._indirect)
          {
            damageInfo = target.Unit.Damage(amount1, (IUnit) null, this._deathType, targetSlotOffset, false, false, true);
          }
          else
          {
            int amount2 = caster.WillApplyDamage(amount1, target.Unit);
            damageInfo = target.Unit.Damage(amount2, caster, this._deathType, targetSlotOffset, ignoresShield: this._ignoreShield);
          }
          flag |= damageInfo.beenKilled;
          exitAmount += damageInfo.damageAmount;
        }
      }
      if (!this._indirect && exitAmount > 0)
        caster.DidApplyDamage(exitAmount);
      return !this._returnKillAsSuccess ? exitAmount > 0 : flag;
    }
  }
}
