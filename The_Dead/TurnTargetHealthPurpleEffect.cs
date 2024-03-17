// Decompiled with JetBrains decompiler
// Type: THE_DEAD.TurnTargetHealthPurpleEffect
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using BrutalAPI;
using UnityEngine;

namespace THE_DEAD
{
  public class TurnTargetHealthPurpleEffect : EffectSO
  {
    public static Sprite icon = ResourceLoader.LoadSprite("RemnantH_item.png");

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 0;
      foreach (TargetSlotInfo target in targets)
      {
        if (target.HasUnit && target.Unit.ChangeHealthColor(Pigments.Purple))
          ++exitAmount;
      }
      return exitAmount > 0;
    }
  }
}
