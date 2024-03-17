// Decompiled with JetBrains decompiler
// Type: THE_DEAD.ParanoiaDeathEffect
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
  public class ParanoiaDeathEffect : EffectSO
  {
    [SerializeField]
    public bool _obliterationDeath;

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
      int storedValue = caster.GetStoredValue((UnitStoredValueNames) 7788778);
      Joyce.paranoidTimer_InCombat = true;
      exitAmount = 0;
      if (storedValue >= 5 && Random.Range(0, 100) < 3)
      {
        for (int index = 0; index < targets.Length; ++index)
        {
          if (targets[index].HasUnit && targets[index].Unit.DirectDeath(caster))
            ++exitAmount;
        }
      }
      int newValue = storedValue + 1;
      caster.SetStoredValue((UnitStoredValueNames) 7788778, newValue);
      return exitAmount > 0;
    }
  }
}
