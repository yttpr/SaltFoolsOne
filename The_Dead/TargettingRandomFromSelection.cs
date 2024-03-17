// Decompiled with JetBrains decompiler
// Type: THE_DEAD.TargettingRandomFromSelection
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using System.Collections.Generic;
using UnityEngine;

namespace THE_DEAD
{
  public class TargettingRandomFromSelection : BaseCombatTargettingSO
  {
    public BaseCombatTargettingSO source;
    public bool IncludeEmpty;
    public bool IncludeDead;

    public override bool AreTargetAllies => this.source.AreTargetAllies;

    public override bool AreTargetSlots => this.source.AreTargetSlots;

    public override TargetSlotInfo[] GetTargets(
      SlotsCombat slots,
      int casterSlotID,
      bool isCasterCharacter)
    {
      TargetSlotInfo[] targets = this.source.GetTargets(slots, casterSlotID, isCasterCharacter);
      List<TargetSlotInfo> list = new List<TargetSlotInfo>();
      foreach (TargetSlotInfo targetSlotInfo in targets)
      {
        if (targetSlotInfo.HasUnit && (targetSlotInfo.Unit.IsAlive || this.IncludeDead) || this.IncludeEmpty)
          list.Add(targetSlotInfo);
      }
      return list.Count <= 0 ? new TargetSlotInfo[0] : list.GetRandom<TargetSlotInfo>().SelfArray<TargetSlotInfo>();
    }

    public static TargettingRandomFromSelection Create(
      BaseCombatTargettingSO orig,
      bool empty = false,
      bool onlyAlive = true)
    {
      TargettingRandomFromSelection instance = ScriptableObject.CreateInstance<TargettingRandomFromSelection>();
      instance.source = orig;
      instance.IncludeDead = !onlyAlive;
      instance.IncludeEmpty = empty;
      return instance;
    }
  }
}
