// Decompiled with JetBrains decompiler
// Type: THE_DEAD.AdditionNotNegativeValueModifier
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using System;

namespace THE_DEAD
{
  public class AdditionNotNegativeValueModifier : IntValueModifier
  {
    public readonly int toAdd;

    public AdditionNotNegativeValueModifier(bool dmgDealt, int toAdd)
      : base(dmgDealt ? 10 : 66)
    {
      this.toAdd = toAdd;
    }

    public override int Modify(int value) => Math.Max(0, value + this.toAdd);
  }
}
