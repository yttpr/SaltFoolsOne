// Decompiled with JetBrains decompiler
// Type: THE_DEAD.Fun_StatusEffect
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using System;

namespace THE_DEAD
{
  public class Fun_StatusEffect : IStatusEffect, ITriggerEffect<IStatusEffector>
  {
    public int StatusContent => 1;

    public int Restrictor { get; set; }

    public bool CanBeRemoved => true;

    public bool IsPositive => true;

    public string DisplayText
    {
      get
      {
        string displayText = "";
        if (this.Restrictor > 0)
          displayText = displayText + "(" + this.Restrictor.ToString() + ")";
        return displayText;
      }
    }

    public int Amount { get; set; }

    public StatusEffectType EffectType => (StatusEffectType) 422442;

    public StatusEffectInfoSO EffectInfo { get; set; }

    public void SetEffectInformation(StatusEffectInfoSO effectInfo) => this.EffectInfo = effectInfo;

    public Fun_StatusEffect(int amount, int restrictors = 0) => this.Restrictor = restrictors;

    public bool AddContent(IStatusEffect content) => false;

    public bool TryAddContent(int amount) => false;

    public int JustRemoveAllContent() => 0;

    public void OnTriggerAttached(IStatusEffector caller)
    {
      CombatManager.Instance.AddObserver(new Action<object, object>(this.OnBeingDamagedTriggered), TriggerCalls.OnBeingDamaged.ToString(), (object) caller);
      CombatManager.Instance.AddObserver(new Action<object, object>(this.OnWillDamageTriggered), TriggerCalls.OnWillApplyDamage.ToString(), (object) caller);
    }

    public void OnTriggerDettached(IStatusEffector caller)
    {
      CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnBeingDamagedTriggered), TriggerCalls.OnBeingDamaged.ToString(), (object) caller);
      CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnWillDamageTriggered), TriggerCalls.OnWillApplyDamage.ToString(), (object) caller);
    }

    public void OnSubActionTrigger(object sender, object args, bool stateCheck)
    {
    }

    public void OnWillDamageTriggered(object sender, object args) => (args as DamageDealtValueChangeException).AddModifier((IntValueModifier) new FunValueModifier(this.Amount));

    public void OnBeingDamagedTriggered(object sender, object args) => (args as DamageReceivedValueChangeException).AddModifier((IntValueModifier) new FunValueModifier(this.Amount));

    public void ReduceDuration(IStatusEffector effector)
    {
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
