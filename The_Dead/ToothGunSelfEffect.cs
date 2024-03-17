// Decompiled with JetBrains decompiler
// Type: THE_DEAD.ToothGunSelfEffect
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using System;

namespace THE_DEAD
{
    public class ToothGunSelfEffect : EffectSO
    {
        public override bool PerformEffect(
          CombatStats stats,
          IUnit caster,
          TargetSlotInfo[] targets,
          bool areTargetSlots,
          int entryVariable,
          out int exitAmount)
        {
            int amount = (int)Math.Max(Math.Ceiling((double)((float)caster.MaximumHealth / 10f)), 1.0);
            exitAmount = caster.Damage(amount, (IUnit)null, DeathType.Basic, -1, false, false, true).damageAmount;
            return exitAmount > 0;
        }
    }
}
