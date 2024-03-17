// Decompiled with JetBrains decompiler
// Type: THE_DEAD.FunValueModifier
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using System;

namespace THE_DEAD
{
  public class FunValueModifier : IntValueModifier
  {
    public readonly Decimal value;

    public FunValueModifier(int value)
      : base(70)
    {
      this.value = (Decimal) value;
    }

    public override int Modify(int value)
    {
      int num1 = UnityEngine.Random.Range(0, 19);
      Decimal num2 = 1M;
      Decimal num3 = (Decimal) value;
      if (num1 == 0)
        num2 = -1M;
      if (num1 == 1)
        num2 = 0M;
      if (num1 == 2)
        num2 /= 10M;
      if (num1 == 3)
        num2 /= 5M;
      if (num1 == 4)
        num2 /= 4M;
      if (num1 == 5)
        num2 /= 3M;
      if (num1 == 6)
        num2 /= 2M;
      if (num1 == 7)
      {
        num2 = 7M;
        num2 /= 10M;
      }
      if (num1 == 8)
      {
        num2 = 4M;
        num2 /= 5M;
      }
      if (num1 == 9)
        num2 *= 1M;
      if (num1 == 10)
      {
        num2 = 6M;
        num2 /= 5M;
      }
      if (num1 == 11)
      {
        num2 = 5M;
        num2 /= 4M;
      }
      if (num1 == 12)
      {
        num2 = 3M;
        num2 /= 2M;
      }
      if (num1 == 13)
      {
        num2 = 9M;
        num2 /= 5M;
      }
      if (num1 == 14)
        num2 = 2M;
      if (num1 == 15)
      {
        num2 = 21M;
        num2 /= 10M;
      }
      if (num1 == 16)
      {
        num2 = 5M;
        num2 /= 2M;
      }
      if (num1 == 17)
        num2 = 3M;
      if (num1 == 18)
        num2 = 10M;
      Decimal d = num3 * num2;
      value = UnityEngine.Random.Range((int) Math.Ceiling(d), (int) Math.Floor(d) + 1);
      return value;
    }
  }
}
