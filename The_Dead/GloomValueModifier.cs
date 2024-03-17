// Decompiled with JetBrains decompiler
// Type: THE_DEAD.GloomValueModifier
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using System;

namespace THE_DEAD
{
  public class GloomValueModifier : IntValueModifier
  {
    public readonly int toNumb;

    public GloomValueModifier(int toNumb)
      : base(70)
    {
      this.toNumb = toNumb;
    }

    public override int Modify(int value)
    {
      if (value <= 0)
        return value;
      Decimal toNumb = (Decimal) this.toNumb;
      Decimal num1 = (Decimal) value;
      Decimal num2 = toNumb * num1;
      value = (int) Math.Ceiling((num1 * 100M + num2) / 100M);
      return value;
    }
  }
}
