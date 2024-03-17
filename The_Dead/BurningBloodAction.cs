// Decompiled with JetBrains decompiler
// Type: THE_DEAD.BurningBloodAction
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using BrutalAPI;
using System.Collections;
using UnityEngine;

namespace THE_DEAD
{
  public class BurningBloodAction : CombatAction
  {
    public IUnit caster;
    private static ApplyFireSlotEffect fire;
    public static Sprite icon = ResourceLoader.LoadSprite("ParanoidO_item.png");

    public BurningBloodAction(IUnit caster) => this.caster = caster;

    public override IEnumerator Execute(CombatStats stats)
    {
      if ((Object) BurningBloodAction.fire == (Object) null)
        BurningBloodAction.fire = ScriptableObject.CreateInstance<ApplyFireSlotEffect>();
      BurningBloodAction.fire.PerformEffect(stats, this.caster, Slots.Self.GetTargets(stats.combatSlots, this.caster.SlotID, this.caster.IsUnitCharacter), Slots.Self.AreTargetSlots, 1, out int _);
      yield return (object) null;
    }
  }
}
