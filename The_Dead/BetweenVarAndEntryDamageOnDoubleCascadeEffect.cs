// Decompiled with JetBrains decompiler
// Type: THE_DEAD.BetweenVarAndEntryDamageOnDoubleCascadeEffect
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using System.Collections.Generic;
using UnityEngine;

namespace THE_DEAD
{
  public class BetweenVarAndEntryDamageOnDoubleCascadeEffect : EffectSO
  {
    [Header("Cascade Data")]
    [SerializeField]
    public int _cascadeDecrease = 1;
    [SerializeField]
    public bool _consistentCascade = true;
    [SerializeField]
    public bool _decreaseAsPercentage;
    [SerializeField]
    public bool _cascadeIsIndirect = true;
    [Header("Damage Data")]
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
      bool flag1 = false;
      if (targets.Length == 0)
        return false;
      TargetSlotInfo target1 = targets[0];
      if (!target1.HasUnit)
        return false;
      entryVariable = Random.Range(caster.GetStoredValue((UnitStoredValueNames) 2233456), entryVariable + 1);
      List<TargetSlotInfo> targetSlotInfoList1 = new List<TargetSlotInfo>();
      List<TargetSlotInfo> targetSlotInfoList2 = new List<TargetSlotInfo>();
      for (int index = 1; index < targets.Length; ++index)
      {
        if (targets[index].Unit != target1.Unit)
        {
          if (targets[index].SlotID > target1.SlotID)
            targetSlotInfoList2.Add(targets[index]);
          else if (targets[index].SlotID < target1.SlotID)
            targetSlotInfoList1.Add(targets[index]);
        }
      }
      int damageAmount1 = entryVariable;
      DamageInfo target2 = this.DealDamageToTarget(caster, target1, areTargetSlots, damageAmount1, this._indirect);
      int damageAmount2 = target2.damageAmount;
      bool flag2 = flag1 | target2.beenKilled;
      exitAmount += target2.damageAmount;
      int num1 = !this._decreaseAsPercentage ? damageAmount2 - this._cascadeDecrease : this.CalculatePercentualDamageAmount(damageAmount2);
      if (num1 <= 0)
      {
        if (!this._indirect && exitAmount > 0)
          caster.DidApplyDamage(exitAmount);
        return !this._returnKillAsSuccess || flag2;
      }
      int num2 = 0;
      bool flag3 = true;
      bool flag4 = true;
      for (int index = 0; index < targetSlotInfoList1.Count || index < targetSlotInfoList2.Count; ++index)
      {
        if (flag3)
        {
          if (index >= targetSlotInfoList1.Count || !targetSlotInfoList1[index].HasUnit)
          {
            if (this._consistentCascade)
              flag3 = false;
          }
          else
          {
            DamageInfo target3 = this.DealDamageToTarget(caster, targetSlotInfoList1[index], areTargetSlots, num1, this._cascadeIsIndirect);
            flag2 |= target3.beenKilled;
            num2 += target3.damageAmount;
          }
        }
        if (flag4)
        {
          if (index >= targetSlotInfoList2.Count || !targetSlotInfoList2[index].HasUnit)
          {
            if (this._consistentCascade)
              flag4 = false;
          }
          else
          {
            DamageInfo target4 = this.DealDamageToTarget(caster, targetSlotInfoList2[index], areTargetSlots, num1, this._cascadeIsIndirect);
            flag2 |= target4.beenKilled;
            num2 += target4.damageAmount;
          }
        }
        num1 = !this._decreaseAsPercentage ? num1 - this._cascadeDecrease : this.CalculatePercentualDamageAmount(num1);
        if (num1 <= 0)
          break;
      }
      int amount = (!this._indirect ? exitAmount : 0) + (!this._cascadeIsIndirect ? num2 : 0);
      if (amount > 0)
        caster.DidApplyDamage(amount);
      exitAmount += num2;
      return !this._returnKillAsSuccess || flag2;
    }

    public int CalculatePercentualDamageAmount(int currentDamage) => Mathf.Max(0, Mathf.FloorToInt((float) ((double) this._cascadeDecrease * 1.0 * (double) currentDamage / 100.0)));

    public DamageInfo DealDamageToTarget(
      IUnit caster,
      TargetSlotInfo target,
      bool areTargetSlots,
      int damageAmount,
      bool useIndirect)
    {
      int targetSlotOffset = areTargetSlots ? target.SlotID - target.Unit.SlotID : -1;
      if (useIndirect)
        return target.Unit.Damage(damageAmount, (IUnit) null, this._deathType, targetSlotOffset, false, false, true);
      damageAmount = caster.WillApplyDamage(damageAmount, target.Unit);
      return target.Unit.Damage(damageAmount, caster, this._deathType, targetSlotOffset, ignoresShield: this._ignoreShield);
    }
  }
}
