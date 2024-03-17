// Decompiled with JetBrains decompiler
// Type: THE_DEAD.ParanoidPanicThreadStartEffect
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
  public class ParanoidPanicThreadStartEffect : EffectSO
  {
    [SerializeField]
    public bool _increase = true;
    [SerializeField]
    public int _minimumValue = 0;
    [SerializeField]
    public UnitStoredValueNames _valueName = (UnitStoredValueNames) 222223333;
    [SerializeField]
    public bool _randomBetweenPrevious;

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

    public static void printShitTestThread()
    {
      while (true)
      {
        Debug.Log((object) "3222");
        Thread.Sleep(5000);
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
      caster.SetStoredValue((UnitStoredValueNames) 222223333, 1);
      if ((Object) PynchonHandler.Instance != (Object) null)
      {
        Object.Destroy((Object) PynchonHandler.Instance);
        PynchonHandler.Instance = (PynchonHandler) null;
      }
      PynchonHandler.Instance = CombatManager.Instance.gameObject.AddComponent<PynchonHandler>();
      exitAmount = 0;
      return true;
    }
  }
}
