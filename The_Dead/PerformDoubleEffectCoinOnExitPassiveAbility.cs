// Decompiled with JetBrains decompiler
// Type: THE_DEAD.PerformDoubleEffectCoinOnExitPassiveAbility
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

namespace THE_DEAD
{
  public class PerformDoubleEffectCoinOnExitPassiveAbility : PerformDoubleEffectPassiveAbility
  {
    public override void OnPassiveDisconnected(IUnit unit)
    {
      int currencyAmount = CombatManager.Instance._stats.TryGainCurrency(1, true);
      if (currencyAmount <= 0)
        return;
      CombatManager.Instance.AddUIAction((CombatAction) new PlayCurrencyEffectUIAction(unit.ID, unit.IsUnitCharacter, currencyAmount, false));
    }
  }
}
