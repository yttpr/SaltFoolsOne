// Decompiled with JetBrains decompiler
// Type: THE_DEAD.RootActionEffect
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using BrutalAPI;
using UnityEngine;

namespace THE_DEAD
{
  public class RootActionEffect : EffectSO
  {
    public Effect[] effects;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      EffectInfo[] effectInfoArray = ExtensionMethods.ToEffectInfoArray(this.effects);
      exitAmount = 0;
      foreach (TargetSlotInfo target in targets)
      {
        if (target.HasUnit)
        {
          CombatManager.Instance.AddRootAction((CombatAction) new EffectAction(effectInfoArray, target.Unit));
          ++exitAmount;
        }
      }
      return exitAmount > 0;
    }

    public static RootActionEffect Create(Effect[] e)
    {
      RootActionEffect instance = ScriptableObject.CreateInstance<RootActionEffect>();
      instance.effects = e;
      return instance;
    }
  }
}
