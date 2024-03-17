// Decompiled with JetBrains decompiler
// Type: THE_DEAD.SHSShieldEffect
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using UnityEngine;

namespace THE_DEAD
{
  public class SHSShieldEffect : EffectSO
  {
    [SerializeField]
    public bool _usePreviousExitValue;
    [SerializeField]
    public int _previousExtraAddition;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      if (this._usePreviousExitValue)
        entryVariable = this._previousExtraAddition + entryVariable * this.PreviousExitValue;
      exitAmount = 0;
      if (entryVariable <= 0)
        return false;
      SlotStatusEffectInfoSO effectInfo;
      stats.slotStatusEffectDataBase.TryGetValue(SlotStatusEffectType.Shield, out effectInfo);
      for (int index = 0; index < targets.Length; ++index)
      {
        Shield_SlotStatusEffect effect = new Shield_SlotStatusEffect(targets[index].SlotID, entryVariable, targets[index].IsTargetCharacterSlot);
        effect.SetEffectInformation(effectInfo);
        if (stats.combatSlots.ApplySlotStatusEffect(targets[index].SlotID, targets[index].IsTargetCharacterSlot, entryVariable, (ISlotStatusEffect) effect))
          exitAmount += entryVariable;
      }
      caster.SetStoredValue((UnitStoredValueNames) 59995, 1);
      return exitAmount > 0;
    }
  }
}
