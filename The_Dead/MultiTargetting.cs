// Decompiled with JetBrains decompiler
// Type: THE_DEAD.MultiTargetting
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using System;
using UnityEngine;

namespace THE_DEAD
{
  public class MultiTargetting : BaseCombatTargettingSO
  {
    public BaseCombatTargettingSO first;
    public BaseCombatTargettingSO second;

    public override bool AreTargetAllies => this.first.AreTargetAllies && this.second.AreTargetAllies;

    public override bool AreTargetSlots => this.first.AreTargetSlots && this.second.AreTargetSlots;

    public override TargetSlotInfo[] GetTargets(
      SlotsCombat slots,
      int casterSlotID,
      bool isCasterCharacter)
    {
      TargetSlotInfo[] targets1 = this.first.GetTargets(slots, casterSlotID, isCasterCharacter);
      TargetSlotInfo[] targets2 = this.second.GetTargets(slots, casterSlotID, isCasterCharacter);
      TargetSlotInfo[] destinationArray = new TargetSlotInfo[targets1.Length + targets2.Length];
      Array.Copy((Array) targets1, (Array) destinationArray, targets1.Length);
      Array.Copy((Array) targets2, 0, (Array) destinationArray, targets1.Length, targets2.Length);
      return destinationArray;
    }

    public static MultiTargetting Create(
      BaseCombatTargettingSO first,
      BaseCombatTargettingSO second)
    {
      MultiTargetting instance = ScriptableObject.CreateInstance<MultiTargetting>();
      instance.first = first;
      instance.second = second;
      return instance;
    }
  }
}
