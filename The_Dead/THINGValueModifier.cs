// Decompiled with JetBrains decompiler
// Type: THE_DEAD.THINGValueModifier
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

namespace THE_DEAD
{
  internal class THINGValueModifier : IntValueModifier
  {
    public readonly int Amount;
    public readonly int Health;

    public THINGValueModifier(int stacksAmount, int unitCurrentHealth)
      : base(70)
    {
      this.Amount = stacksAmount;
      this.Health = unitCurrentHealth;
    }

    public override int Modify(int value)
    {
      if (this.Health - value < this.Amount)
        value = this.Health - this.Amount;
      return value;
    }
  }
}
