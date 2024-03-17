// Decompiled with JetBrains decompiler
// Type: THE_DEAD.FireUpToPlusTwoEffect
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using UnityEngine;

namespace THE_DEAD
{
  public class FireUpToPlusTwoEffect : EffectSO
  {
    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 0;
      SlotStatusEffectInfoSO effectInfo;
      stats.slotStatusEffectDataBase.TryGetValue(SlotStatusEffectType.OnFire, out effectInfo);
      for (int index = 0; index < targets.Length; ++index)
      {
        int num = Random.Range(entryVariable, entryVariable + 2);
        if (num > 0)
        {
          OnFire_SlotStatusEffect effect = new OnFire_SlotStatusEffect(targets[index].SlotID, num);
          effect.SetEffectInformation(effectInfo);
          if (stats.combatSlots.ApplySlotStatusEffect(targets[index].SlotID, targets[index].IsTargetCharacterSlot, num, (ISlotStatusEffect) effect))
            ++exitAmount;
        }
      }
      return exitAmount > 0;
    }
  }
}
