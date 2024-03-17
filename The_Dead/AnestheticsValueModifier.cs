﻿// Decompiled with JetBrains decompiler
// Type: THE_DEAD.AnestheticsValueModifier
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using System;

namespace THE_DEAD
{
  public class AnestheticsValueModifier : IntValueModifier
  {
    public readonly int toNumb;

    public AnestheticsValueModifier(int toNumb)
      : base(70)
    {
      this.toNumb = toNumb;
    }

    public override int Modify(int value) => value > 0 ? Math.Max(value - this.toNumb, 0) : Math.Max(value, 0);
  }
}
