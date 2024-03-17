// Decompiled with JetBrains decompiler
// Type: THE_DEAD.TargettingByHasUnit
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using System.Collections.Generic;
using UnityEngine;

namespace THE_DEAD
{
  public class TargettingByHasUnit : BaseCombatTargettingSO
  {
    public BaseCombatTargettingSO source;

    public override bool AreTargetAllies => this.source.AreTargetAllies;

    public override bool AreTargetSlots => this.source.AreTargetSlots;

    public override TargetSlotInfo[] GetTargets(
      SlotsCombat slots,
      int casterSlotID,
      bool isCasterCharacter)
    {
      TargetSlotInfo[] targets = this.source.GetTargets(slots, casterSlotID, isCasterCharacter);
      List<TargetSlotInfo> targetSlotInfoList = new List<TargetSlotInfo>();
      foreach (TargetSlotInfo targetSlotInfo in targets)
      {
        if (targetSlotInfo.HasUnit)
          targetSlotInfoList.Add(targetSlotInfo);
      }
      return targetSlotInfoList.ToArray();
    }

    public static TargettingByHasUnit Create(BaseCombatTargettingSO orig)
    {
      TargettingByHasUnit instance = ScriptableObject.CreateInstance<TargettingByHasUnit>();
      instance.source = orig;
      return instance;
    }
  }
}
