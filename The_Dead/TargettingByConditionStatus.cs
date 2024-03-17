// Decompiled with JetBrains decompiler
// Type: THE_DEAD.TargettingByConditionStatus
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using System.Collections.Generic;
using UnityEngine;

namespace THE_DEAD
{
  public class TargettingByConditionStatus : BaseCombatTargettingSO
  {
    public BaseCombatTargettingSO orig;
    public StatusEffectType status = StatusEffectType.Frail;
    public bool Has;

    public override bool AreTargetAllies => this.orig.AreTargetAllies;

    public override bool AreTargetSlots => this.orig.AreTargetSlots;

    public override TargetSlotInfo[] GetTargets(
      SlotsCombat slots,
      int casterSlotID,
      bool isCasterCharacter)
    {
      TargetSlotInfo[] targets = this.orig.GetTargets(slots, casterSlotID, isCasterCharacter);
      List<TargetSlotInfo> targetSlotInfoList = new List<TargetSlotInfo>();
      foreach (TargetSlotInfo targetSlotInfo in targets)
      {
        if (targetSlotInfo.HasUnit && this.Has == targetSlotInfo.Unit.ContainsStatusEffect(this.status))
          targetSlotInfoList.Add(targetSlotInfo);
      }
      return targetSlotInfoList.ToArray();
    }

    public static TargettingByConditionStatus Create(
      BaseCombatTargettingSO orig,
      StatusEffectType status,
      bool Has = true)
    {
      TargettingByConditionStatus instance = ScriptableObject.CreateInstance<TargettingByConditionStatus>();
      instance.orig = orig;
      instance.status = status;
      instance.Has = Has;
      return instance;
    }
  }
}
