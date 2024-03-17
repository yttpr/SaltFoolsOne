// Decompiled with JetBrains decompiler
// Type: THE_DEAD.NoStallWItheringPassiveAbility
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

namespace THE_DEAD
{
  public class NoStallWItheringPassiveAbility : BasePassiveAbilitySO
  {
    public override bool DoesPassiveTrigger => true;

    public override bool IsPassiveImmediate => true;

    public override void TriggerPassive(object sender, object args)
    {
      if (!(sender is IUnit unit))
        return;
      if (unit.IsUnitCharacter)
        CombatManager.Instance.AddRootAction((CombatAction) new CharacterWitheringAction());
      else
        CombatManager.Instance.AddRootAction((CombatAction) new EnemyWitheringAction());
    }

    public override void OnPassiveConnected(IUnit unit)
    {
      if (unit.IsUnitCharacter)
        CombatManager.Instance.AddRootAction((CombatAction) new CharacterWitheringAction());
      else
        CombatManager.Instance.AddRootAction((CombatAction) new EnemyWitheringAction());
    }

    public override void OnPassiveDisconnected(IUnit unit)
    {
    }
  }
}
