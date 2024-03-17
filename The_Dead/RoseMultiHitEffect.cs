// Decompiled with JetBrains decompiler
// Type: THE_DEAD.RoseMultiHitEffect
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

namespace THE_DEAD
{
  public class RoseMultiHitEffect : DamageEffect
  {
    public AttackVisualsSO _visuals;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      CombatManager.Instance.AddUIAction((CombatAction) new PlayAbilityAnimationByGivenTargetsAction(this._visuals, targets, areTargetSlots, caster));
      return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
    }
  }
}
