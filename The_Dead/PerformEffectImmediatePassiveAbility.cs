// Decompiled with JetBrains decompiler
// Type: THE_DEAD.PerformEffectImmediatePassiveAbility
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using UnityEngine;

namespace THE_DEAD
{
  public class PerformEffectImmediatePassiveAbility : BasePassiveAbilitySO
  {
    [Header("Passive Effects")]
    public EffectInfo[] effects;

    public override bool IsPassiveImmediate => true;

    public override bool DoesPassiveTrigger => true;

    public override void TriggerPassive(object sender, object args) => CombatManager.Instance.AddPrioritySubAction((CombatAction) new EffectAction(this.effects, sender as IUnit));

    public override void OnPassiveConnected(IUnit unit)
    {
    }

    public override void OnPassiveDisconnected(IUnit unit)
    {
    }
  }
}
