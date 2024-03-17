// Decompiled with JetBrains decompiler
// Type: THE_DEAD.NoMaxHealthChangePassiveAbility
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using System;
using UnityEngine;

namespace THE_DEAD
{
  public class NoMaxHealthChangePassiveAbility : BasePassiveAbilitySO
  {
    [Header("Multiplier Data")]
    [SerializeField]
    [Min(0.0f)]
    private int _modifyVal = 1;

    public override bool IsPassiveImmediate => true;

    public override bool DoesPassiveTrigger => true;

    public override void TriggerPassive(object sender, object args) => (args as IntValueChangeException).AddModifier((IntValueModifier) new NMHCValueModifier(0));

    public override void OnPassiveConnected(IUnit unit) => CombatManager.Instance.AddObserver(new Action<object, object>(((BasePassiveAbilitySO) this).TriggerPassive), TriggerCalls.OnMaxHealthChanged.ToString(), (object) unit);

    public override void OnPassiveDisconnected(IUnit unit) => CombatManager.Instance.RemoveObserver(new Action<object, object>(((BasePassiveAbilitySO) this).TriggerPassive), TriggerCalls.OnMaxHealthChanged.ToString(), (object) unit);
  }
}
