// Decompiled with JetBrains decompiler
// Type: THE_DEAD.NMHCValueModifier
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

namespace THE_DEAD
{
  internal class NMHCValueModifier : IntValueModifier
  {
    public readonly int Amount;

    public NMHCValueModifier(int numbaH)
      : base(88)
    {
      this.Amount = numbaH;
    }

    public override int Modify(int value)
    {
      value = this.Amount;
      return value;
    }
  }
}
