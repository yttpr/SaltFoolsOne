// Decompiled with JetBrains decompiler
// Type: THE_DEAD.ParanoidPauseCheckerEffect
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using System;
using Tools;
using UnityEngine;

namespace THE_DEAD
{
  public class ParanoidPauseCheckerEffect : EffectSO
  {
    [SerializeField]
    public PassiveAbilityTypes _type;
    [SerializeField]
    public bool _pauseMenuIsOpen;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      CombatManager.Instance.AddObserver(new Action<object, object>(OnPauseTriggered), Utils.pauseTriggerNtf.ToString());
      exitAmount = 1;
      return exitAmount > 0;

      static void OnPauseTriggered(object sender, object args)
      {
        if (!(args is BooleanReference booleanReference))
          return;
        if (booleanReference.value)
          Joyce.paranoidTimer_InPause = true;
        if (booleanReference.value)
          return;
        Joyce.paranoidTimer_InPause = false;
      }
    }
  }
}
