// Decompiled with JetBrains decompiler
// Type: THE_DEAD.Power_StatusEffect
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using System;
using UnityEngine;

namespace THE_DEAD
{
  public class Power_StatusEffect : IStatusEffect, ITriggerEffect<IStatusEffector>
  {
    public int StatusContent => this.Amount;

    public int Restrictor { get; set; }

    public bool CanBeRemoved => this.Restrictor <= 0;

    public bool IsPositive => true;

    public string DisplayText
    {
      get
      {
        string displayText = "";
        if (this.Amount > 0)
          displayText += this.Amount.ToString();
        if (this.Restrictor > 0)
          displayText = displayText + "(" + this.Restrictor.ToString() + ")";
        return displayText;
      }
    }

    public int Amount { get; set; }

    public StatusEffectType EffectType => (StatusEffectType) 456789;

    public StatusEffectInfoSO EffectInfo { get; set; }

    public void SetEffectInformation(StatusEffectInfoSO effectInfo) => this.EffectInfo = effectInfo;

    public bool CanReduceDuration
    {
      get
      {
        BooleanReference result = new BooleanReference(true);
        CombatManager.Instance.ProcessImmediateAction((IImmediateAction) new CheckHasStatusFieldReductionBlockIAction(result));
        return !result.value;
      }
    }

    public Power_StatusEffect(int amount, int restrictors = 0)
    {
      this.Amount = amount;
      this.Restrictor = restrictors;
    }

    public bool AddContent(IStatusEffect content)
    {
      this.Amount += content.StatusContent;
      this.Restrictor += content.Restrictor;
      return true;
    }

    public bool TryAddContent(int amount)
    {
      if (this.Amount <= 0)
        return false;
      this.Amount += amount;
      return true;
    }

    public int JustRemoveAllContent()
    {
      int amount = this.Amount;
      this.Amount = 0;
      return amount;
    }

    public void OnTriggerAttached(IStatusEffector caller) => CombatManager.Instance.AddObserver(new Action<object, object>(this.OnStatusTriggered), TriggerCalls.OnWillApplyDamage.ToString(), (object) caller);

    public void OnTriggerDettached(IStatusEffector caller) => CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnStatusTriggered), TriggerCalls.OnWillApplyDamage.ToString(), (object) caller);

    public void OnSubActionTrigger(object sender, object args, bool stateCheck)
    {
    }

    public void OnStatusTriggered(object sender, object args)
    {
      (args as DamageDealtValueChangeException).AddModifier((IntValueModifier) new PowerValueModifier(this.Amount));
      this.ReduceDuration(sender as IStatusEffector);
    }

    public void OnTurnEnd(object sender, object args) => this.ReduceDuration(sender as IStatusEffector);

    public void ReduceDuration(IStatusEffector effector)
    {
      if (!this.CanReduceDuration || UnityEngine.Random.Range(0, 100) > 50)
        return;
      int amount = this.Amount;
      this.Amount = Mathf.Max(0, this.Amount - 1);
      if (this.TryRemoveStatusEffect(effector) || amount == this.Amount)
        return;
      effector.StatusEffectValuesChanged(this.EffectType, this.Amount - amount);
      this.ReduceDurationAgain(effector);
    }

    public void ReduceDurationAgain(IStatusEffector effector)
    {
      if (!this.CanReduceDuration || UnityEngine.Random.Range(0, 100) > 33)
        return;
      int amount = this.Amount;
      this.Amount = Mathf.Max(0, this.Amount - 1);
      if (this.TryRemoveStatusEffect(effector) || amount == this.Amount)
        return;
      effector.StatusEffectValuesChanged(this.EffectType, this.Amount - amount);
      this.ReduceDurationAgain(effector);
    }

    public void IncreaseDuration(IStatusEffector effector, int amount)
    {
    }

    public void DettachRestrictor(IStatusEffector effector)
    {
      --this.Restrictor;
      if (this.TryRemoveStatusEffect(effector))
        return;
      effector.StatusEffectValuesChanged(this.EffectType, 0);
    }

    public bool TryRemoveStatusEffect(IStatusEffector effector)
    {
      if (this.Amount > 0 || !this.CanBeRemoved)
        return false;
      effector.RemoveStatusEffect(this.EffectType);
      return true;
    }
  }
}
