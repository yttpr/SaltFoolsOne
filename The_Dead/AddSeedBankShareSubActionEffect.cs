// Decompiled with JetBrains decompiler
// Type: THE_DEAD.AddSeedBankShareSubActionEffect
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using BrutalAPI;
using UnityEngine;

namespace THE_DEAD
{
  public class AddSeedBankShareSubActionEffect : EffectSO
  {
    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      Targetting_ByUnit_Side instance = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
      instance.getAllies = true;
      int storedValue = caster.GetStoredValue((UnitStoredValueNames) 202300);
      CombatManager.Instance.AddPriorityRootAction((CombatAction) new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<SeedBankShareEffect>(), storedValue, new IntentType?(), (BaseCombatTargettingSO) instance)
      }), caster));
      exitAmount = 0;
      return true;
    }
  }
}
