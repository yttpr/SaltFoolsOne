// Decompiled with JetBrains decompiler
// Type: THE_DEAD.AnxietyFinishBattleEffect
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using UnityEngine;

namespace THE_DEAD
{
  public class AnxietyFinishBattleEffect : EffectSO
  {
    [SerializeField]
    public bool _obliterationDeath;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 1;
      Joyce.paranoidTimer_InCombat = false;
      if (_04_TheParanoid.PynchonTimerThread != null)
        _04_TheParanoid.PynchonTimerThread.Abort();
      return exitAmount > 0;
    }
  }
}
