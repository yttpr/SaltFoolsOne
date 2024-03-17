// Decompiled with JetBrains decompiler
// Type: THE_DEAD.PerformTripleEffectPassiveAbility
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using System;
using UnityEngine;

namespace THE_DEAD
{
  public class PerformTripleEffectPassiveAbility : BasePassiveAbilitySO
  {
    [Header("Passive Effects")]
    public EffectInfo[] effects;
    [Header("Passive Secondary data")]
    [SerializeField]
    public TriggerCalls[] _secondTriggerOn;
    [SerializeField]
    public EffectorConditionSO[] _secondPerformConditions;
    [SerializeField]
    public bool _secondDoesPerformPopUp = true;
    [SerializeField]
    public EffectInfo[] _secondEffects;
    [Header("Passive Tertiary data")]
    [SerializeField]
    public TriggerCalls[] _thirdTriggerOn;
    [SerializeField]
    public EffectorConditionSO[] _thirdPerformConditions;
    [SerializeField]
    public bool _thirdDoesPerformPopUp = false;
    [SerializeField]
    public EffectInfo[] _thirdEffects;

    public override bool IsPassiveImmediate => false;

    public override bool DoesPassiveTrigger => true;

    public override void TriggerPassive(object sender, object args) => CombatManager.Instance.AddSubAction((CombatAction) new EffectAction(this.effects, sender as IUnit));

    public override void OnPassiveConnected(IUnit unit)
    {
    }

    public override void OnPassiveDisconnected(IUnit unit)
    {
    }

    public override void CustomOnTriggerAttached(IPassiveEffector caller)
    {
      foreach (TriggerCalls triggerCalls in this._secondTriggerOn)
      {
        if (triggerCalls != TriggerCalls.Count)
          CombatManager.Instance.AddObserver(new Action<object, object>(this.CustomTryTriggerPassive), triggerCalls.ToString(), (object) caller);
      }
    }

    public void ExtraCustomOnTriggerAttached(IPassiveEffector caller)
    {
      foreach (TriggerCalls triggerCalls in this._thirdTriggerOn)
      {
        if (triggerCalls != TriggerCalls.Count)
          CombatManager.Instance.AddObserver(new Action<object, object>(this.ExtraCustomTryTriggerPassive), triggerCalls.ToString(), (object) caller);
      }
    }

    public override void CustomOnTriggerDettached(IPassiveEffector caller)
    {
      foreach (TriggerCalls triggerCalls in this._secondTriggerOn)
      {
        if (triggerCalls != TriggerCalls.Count)
          CombatManager.Instance.RemoveObserver(new Action<object, object>(this.CustomTryTriggerPassive), triggerCalls.ToString(), (object) caller);
      }
    }

    public void ExtraCustomOnTriggerDettached(IPassiveEffector caller)
    {
      foreach (TriggerCalls triggerCalls in this._thirdTriggerOn)
      {
        if (triggerCalls != TriggerCalls.Count)
          CombatManager.Instance.RemoveObserver(new Action<object, object>(this.ExtraCustomTryTriggerPassive), triggerCalls.ToString(), (object) caller);
      }
    }

    public override void FinalizeCustomTriggerPassive(object sender, object args, int triggerID)
    {
      if (!(sender is IPassiveEffector passiveEffector) || passiveEffector.Equals((object) null))
        return;
      if (this._secondDoesPerformPopUp)
        CombatManager.Instance.AddUIAction((CombatAction) new ShowPassiveInformationUIAction(passiveEffector.ID, passiveEffector.IsUnitCharacter, this.GetPassiveLocData().text, this.passiveIcon));
      CombatManager.Instance.AddSubAction((CombatAction) new EffectAction(this._secondEffects, sender as IUnit));
    }

    public void FinalizeExtraCustomTriggerPassive(object sender, object args, int triggerID)
    {
      if (!(sender is IPassiveEffector passiveEffector) || passiveEffector.Equals((object) null))
        return;
      if (this._thirdDoesPerformPopUp)
        CombatManager.Instance.AddUIAction((CombatAction) new ShowPassiveInformationUIAction(passiveEffector.ID, passiveEffector.IsUnitCharacter, this.GetPassiveLocData().text, this.passiveIcon));
      CombatManager.Instance.AddSubAction((CombatAction) new EffectAction(this._thirdEffects, sender as IUnit));
    }

    public void CustomTryTriggerPassive(object sender, object args)
    {
      if (!(sender is IPassiveEffector effector) || effector.Equals((object) null) || !effector.CanPassiveTrigger(this.type))
        return;
      if (this._secondPerformConditions != null && !this._secondPerformConditions.Equals((object) null))
      {
        foreach (EffectorConditionSO performCondition in this._secondPerformConditions)
        {
          if (!performCondition.MeetCondition((IEffectorChecks) effector, args))
            return;
        }
      }
      CombatManager.Instance.AddSubAction((CombatAction) new PerformPassiveCustomAction((BasePassiveAbilitySO) this, sender, args, 0));
    }

    public void ExtraCustomTryTriggerPassive(object sender, object args)
    {
      if (!(sender is IPassiveEffector effector) || effector.Equals((object) null) || !effector.CanPassiveTrigger(this.type))
        return;
      if (this._thirdPerformConditions != null && !this._thirdPerformConditions.Equals((object) null))
      {
        foreach (EffectorConditionSO performCondition in this._thirdPerformConditions)
        {
          if (!performCondition.MeetCondition((IEffectorChecks) effector, args))
            return;
        }
      }
      CombatManager.Instance.AddSubAction((CombatAction) new PerformPassiveCustomAction((BasePassiveAbilitySO) this, sender, args, 0));
    }
  }
}
