// Decompiled with JetBrains decompiler
// Type: THE_DEAD.CasterRootActionEffect
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using BrutalAPI;
using UnityEngine;

namespace THE_DEAD
{
  public class CasterRootActionEffect : EffectSO
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
      CombatManager.Instance.AddRootAction((CombatAction) new EffectAction(effectInfoArray, caster));
      return true;
    }

    public static CasterRootActionEffect Create(Effect[] e)
    {
      CasterRootActionEffect instance = ScriptableObject.CreateInstance<CasterRootActionEffect>();
      instance.effects = e;
      return instance;
    }
  }
}
