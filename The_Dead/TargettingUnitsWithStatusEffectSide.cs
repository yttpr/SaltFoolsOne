// Decompiled with JetBrains decompiler
// Type: THE_DEAD.TargettingUnitsWithStatusEffectSide
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using System.Collections.Generic;

namespace THE_DEAD
{
  public class TargettingUnitsWithStatusEffectSide : Targetting_ByUnit_Side
  {
    public StatusEffectType targetStatus;

    public static bool IsUnitAlreadyContained(List<TargetSlotInfo> targets, TargetSlotInfo target)
    {
      foreach (TargetSlotInfo target1 in targets)
      {
        if (target1.Unit == target.Unit)
          return true;
      }
      return false;
    }

    public override TargetSlotInfo[] GetTargets(
      SlotsCombat slots,
      int casterSlotID,
      bool isCasterCharacter)
    {
      List<TargetSlotInfo> targets = new List<TargetSlotInfo>();
      foreach (TargetSlotInfo target in base.GetTargets(slots, casterSlotID, isCasterCharacter))
      {
        if (target != null && target.HasUnit && !TargettingUnitsWithStatusEffectSide.IsUnitAlreadyContained(targets, target) && target.Unit.ContainsStatusEffect(this.targetStatus))
          targets.Add(target);
      }
      return targets.ToArray();
    }
  }
}
