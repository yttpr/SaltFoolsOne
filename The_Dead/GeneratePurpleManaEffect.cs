// Decompiled with JetBrains decompiler
// Type: THE_DEAD.GeneratePurpleManaEffect
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using BrutalAPI;

namespace THE_DEAD
{
  public class GeneratePurpleManaEffect : EffectSO
  {
    public bool usePreviousExitValue = true;
    public ManaColorSO mana = Pigments.Purple;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      if (this.usePreviousExitValue)
        entryVariable *= this.PreviousExitValue;
      exitAmount = entryVariable;
      CombatManager.Instance.ProcessImmediateAction((IImmediateAction) new AddManaToManaBarAction(this.mana, entryVariable, caster.IsUnitCharacter, caster.ID));
      return true;
    }
  }
}
