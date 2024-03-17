// Decompiled with JetBrains decompiler
// Type: THE_DEAD.NoEscapePauseHitEffect
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using BrutalAPI;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

namespace THE_DEAD
{
  public class NoEscapePauseHitEffect : EffectSO
  {
    public static void paranoidTimer45()
    {
      Thread.Sleep(1000);
      Thread.Sleep(Random.Range(0, 2000));
      while (Joyce.paranoidTimer_InCombat)
      {
        Thread.Sleep(3000);
        Targetting_ByUnit_Side instance = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
        instance.getAllies = true;
        CombatManager.Instance.AddPriorityRootAction((CombatAction) new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1]
        {
          new Effect((EffectSO) ScriptableObject.CreateInstance<ParanoidTimerIncrease>(), 1, new IntentType?(), (BaseCombatTargettingSO) instance)
        }), (IUnit) CombatManager.Instance._stats.CharactersOnField.First<KeyValuePair<int, CharacterCombat>>().Value));
      }
    }

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 0;
      foreach (CharacterCombat characterCombat in stats.CharactersOnField.Values)
        characterCombat.Damage(Random.Range(1, 5), (IUnit) null, DeathType.Basic, addHealthMana: false, directDamage: false, ignoresShield: true);
      SlotStatusEffectInfoSO effectInfo;
      stats.slotStatusEffectDataBase.TryGetValue(SlotStatusEffectType.Constricted, out effectInfo);
      for (int slotID = 0; slotID < 5; ++slotID)
      {
        Constricted_SlotStatusEffect effect = new Constricted_SlotStatusEffect(slotID, 1);
        effect.SetEffectInformation(effectInfo);
        stats.combatSlots.ApplySlotStatusEffect(slotID, true, 1, (ISlotStatusEffect) effect);
      }
      return true;
    }
  }
}
