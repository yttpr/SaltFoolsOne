// Decompiled with JetBrains decompiler
// Type: THE_DEAD.PynchonOnPausePassiveAbility
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using Tools;
using UnityEngine;

namespace THE_DEAD
{
  public class PynchonOnPausePassiveAbility : BasePassiveAbilitySO
  {
    public override bool IsPassiveImmediate => true;

    public override bool DoesPassiveTrigger => true;

    public override void TriggerPassive(object sender, object args)
    {
    }

    public override void OnPassiveConnected(IUnit unit) => CombatManager.Instance.AddObserver(new Action<object, object>(this.OnPauseTriggered), Utils.pauseTriggerNtf.ToString());

    public void OnPauseTriggered(object sender, object args)
    {
      if (!(args is BooleanReference booleanReference))
        return;
      if (!booleanReference.value)
        _04_TheParanoid.PynchonTimerThread.Abort();
      if (!booleanReference.value)
        return;
      Targetting_ByUnit_Side instance = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
      instance.getAllies = true;
      instance.getAllUnitSlots = false;
      CombatManager.Instance.AddSubAction((CombatAction) new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<NoEscapePauseHitEffect>(), 25, new IntentType?(), (BaseCombatTargettingSO) instance)
      }), (IUnit) CombatManager.Instance._stats.CharactersOnField.First<KeyValuePair<int, CharacterCombat>>().Value));
    }

    public override void OnPassiveDisconnected(IUnit unit) => CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnPauseTriggered), Utils.pauseTriggerNtf.ToString());
  }
}
