// Decompiled with JetBrains decompiler
// Type: THE_DEAD.ParanoidPauseThreadStartEffect
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Tools;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace THE_DEAD
{
  public class ParanoidPauseThreadStartEffect : EffectSO
  {
    [SerializeField]
    public bool _increase = true;
    [SerializeField]
    public int _minimumValue = 0;
    [SerializeField]
    public UnitStoredValueNames _valueName = (UnitStoredValueNames) 222223333;
    [SerializeField]
    public bool _randomBetweenPrevious;
    [SerializeField]
    public bool _pauseMenuIsOpen;

    public static void PauseThreadStartThread()
    {
      Thread thread = new Thread(new ThreadStart(ParanoidPauseThreadStartEffect.paranoidPauseCheck));
      Thread.Sleep(UnityEngine.Random.Range(0, 250));
      if (Joyce.paranoidTimer_PauseThreadStarted)
        return;
      thread.Start();
      Joyce.paranoidTimer_PauseThreadStarted = true;
    }

    public static void paranoidTimer45()
    {
      Thread.Sleep(UnityEngine.Random.Range(0, 2000));
      Joyce.paranoidTimer_InCombat = true;
      while (Joyce.paranoidTimer_InCombat && !Joyce.paranoidTimer_InPause)
      {
        if (!Joyce.paranoidTimer_InPause && Joyce.paranoidTimer_InTurn)
        {
          Thread.Sleep(1000);
          if (!Joyce.paranoidTimer_InPause && Joyce.paranoidTimer_InTurn)
            Joyce.paranoidTimer_Increased = false;
          Thread.Sleep(2000);
          Targetting_ByUnit_Side instance = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
          instance.getAllies = true;
          Effect effect = new Effect((EffectSO) ScriptableObject.CreateInstance<ParanoidTimerIncrease>(), 1, new IntentType?(), (BaseCombatTargettingSO) instance);
          if (!Joyce.paranoidTimer_Increased && !Joyce.paranoidTimer_InPause && Joyce.paranoidTimer_InTurn)
            CombatManager.Instance.AddPriorityRootAction((CombatAction) new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1]
            {
              effect
            }), (IUnit) CombatManager.Instance._stats.CharactersOnField.First<KeyValuePair<int, CharacterCombat>>().Value));
          if (!Joyce.paranoidTimer_Increased)
            ;
        }
      }
      Joyce.paranoidTimer_UnPaused = false;
    }

    public static void paranoidPauseCheck()
    {
      Thread.Sleep(1000);
      Joyce.paranoidTimer_InCombat = true;
      CombatManager.Instance.AddObserver(new Action<object, object>(OnPauseTriggered), Utils.pauseTriggerNtf.ToString());
      Transform child1 = UnityEngine.Object.FindObjectOfType<PauseUIHandler>(true).transform.GetChild(1).GetChild(1).GetChild(0);
      Transform child2 = child1.GetChild(3);
      Transform child3 = child1.GetChild(4);
      Button component1 = child2.GetComponent<Button>();
      Button component2 = child3.GetComponent<Button>();
      component1.onClick.AddListener((UnityAction) (() => killThreads()));
      component2.onClick.AddListener((UnityAction) (() => killThreads()));
      Thread.Sleep(100);

      static void killThreads()
      {
        Joyce.paranoidTimer_InCombat = false;
        Joyce.paranoidTimer_ThreadStarted = false;
      }

      static void OnPauseTriggered(object sender, object args)
      {
        if (!(args is BooleanReference booleanReference))
          return;
        if (booleanReference.value && !Joyce.paranoidTimer_InPause)
          Joyce.paranoidTimer_InPause = true;
        if (booleanReference.value || !Joyce.paranoidTimer_InPause || !Joyce.paranoidTimer_InCombat)
          return;
        Targetting_ByUnit_Side instance = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
        instance.getAllies = true;
        CombatManager.Instance.AddPriorityRootAction((CombatAction) new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1]
        {
          new Effect((EffectSO) ScriptableObject.CreateInstance<NoEscapePauseHitEffect>(), 1, new IntentType?(), (BaseCombatTargettingSO) instance)
        }), (IUnit) CombatManager.Instance._stats.CharactersOnField.First<KeyValuePair<int, CharacterCombat>>().Value));
        Thread thread = new Thread(new ThreadStart(ParanoidPauseThreadStartEffect.paranoidTimer45));
        if (!Joyce.paranoidTimer_UnPaused)
        {
          thread.Start();
          Joyce.paranoidTimer_UnPaused = true;
        }
        Joyce.paranoidTimer_InPause = false;
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
      new Thread(new ThreadStart(ParanoidPauseThreadStartEffect.PauseThreadStartThread)).Start();
      exitAmount = 0;
      return true;
    }
  }
}
