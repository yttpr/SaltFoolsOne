// Decompiled with JetBrains decompiler
// Type: THE_DEAD.TargettingWeakestUnit
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using System.Collections.Generic;

namespace THE_DEAD
{
  public class TargettingWeakestUnit : Targetting_ByUnit_Side
  {
    public bool OnlyOne;

    public override TargetSlotInfo[] GetTargets(
      SlotsCombat slots,
      int casterSlotID,
      bool isCasterCharacter)
    {
      List<TargetSlotInfo> list = new List<TargetSlotInfo>();
      foreach (TargetSlotInfo target in base.GetTargets(slots, casterSlotID, isCasterCharacter))
      {
        if (target != null && target.HasUnit)
        {
          if (list.Count <= 0)
            list.Add(target);
          else if (list[0].Unit.CurrentHealth > target.Unit.CurrentHealth)
          {
            list.Clear();
            list.Add(target);
          }
          else if (list[0].Unit.CurrentHealth == target.Unit.CurrentHealth)
            list.Add(target);
        }
      }
      if (list.Count <= 0)
        return new TargetSlotInfo[0];
      if (!this.OnlyOne)
        return list.ToArray();
      return new TargetSlotInfo[1]
      {
        list.GetRandom<TargetSlotInfo>()
      };
    }
  }
}
