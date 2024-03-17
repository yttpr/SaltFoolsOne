// Decompiled with JetBrains decompiler
// Type: THE_DEAD.PlayAbilityAnimationByGivenTargetsAction
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using System.Collections;

namespace THE_DEAD
{
  public class PlayAbilityAnimationByGivenTargetsAction : CombatAction
  {
    public TargetSlotInfo[] _targetting;
    public bool AreTargetsSlots;
    public AttackVisualsSO _visuals;
    public IUnit _caster;

    public PlayAbilityAnimationByGivenTargetsAction(
      AttackVisualsSO visuals,
      TargetSlotInfo[] targetting,
      bool AreTargetsSlots,
      IUnit caster)
    {
      this._visuals = visuals;
      this._targetting = targetting;
      this.AreTargetsSlots = AreTargetsSlots;
      this._caster = caster;
    }

    public override IEnumerator Execute(CombatStats stats)
    {
      TargetSlotInfo[] targets = (TargetSlotInfo[]) null;
      bool areTargetSlots = true;
      if (this._targetting != null)
      {
        targets = this._targetting;
        areTargetSlots = this.AreTargetsSlots;
      }
      yield return (object) stats.combatUI.PlayAbilityAnimation(this._visuals, targets, areTargetSlots);
    }
  }
}
