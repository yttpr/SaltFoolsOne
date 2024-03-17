// Decompiled with JetBrains decompiler
// Type: THE_DEAD.RootActionAction
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using System.Collections;

namespace THE_DEAD
{
  public class RootActionAction : CombatAction
  {
    public CombatAction ex;

    public RootActionAction(CombatAction a) => this.ex = a;

    public override IEnumerator Execute(CombatStats stats)
    {
      CombatManager.Instance.AddRootAction(this.ex);
      yield return (object) null;
    }
  }
}
