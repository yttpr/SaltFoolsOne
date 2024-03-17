// Decompiled with JetBrains decompiler
// Type: THE_DEAD.Pigment3xPassiveAbility
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using UnityEngine;

namespace THE_DEAD
{
  public class Pigment3xPassiveAbility : BasePassiveAbilitySO
  {
    [Header("Multiplier Data")]
    [SerializeField]
    [Min(0.0f)]
    private int _modifyVal = 3;

    public override bool IsPassiveImmediate => true;

    public override bool DoesPassiveTrigger => true;

    public override void TriggerPassive(object sender, object args)
    {
      IUnit unit = sender as IUnit;
      if (!(args is DamageReceivedValueChangeException) || (args as DamageReceivedValueChangeException).Equals((object) null) || (args as DamageReceivedValueChangeException).damageType != DamageType.Mana)
        return;
      (args as DamageReceivedValueChangeException).AddModifier((IntValueModifier) new Pigment3xValueModifier(this._modifyVal));
    }

    public override void OnPassiveConnected(IUnit unit)
    {
    }

    public override void OnPassiveDisconnected(IUnit unit)
    {
    }
  }
}
