// Decompiled with JetBrains decompiler
// Type: THE_DEAD.PanicDeathEffect
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using UnityEngine;

namespace THE_DEAD
{
  public class PanicDeathEffect : EffectSO
  {
    [SerializeField]
    public bool _obliterationDeath;
    [SerializeField]
    public GameInformationHolder _informationHolder;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      float timer = CombatManager.Instance._informationHolder.Run.Timer;
      int num1 = Mathf.FloorToInt(timer / 60f);
      Mathf.FloorToInt(timer % 60f);
      Joyce.paranoidWorldTimer = num1;
      caster.SetStoredValue((UnitStoredValueNames) 7788778, 0);
      caster.SetStoredValue((UnitStoredValueNames) 12334566, Joyce.paranoidWorldTimer);
      int num2 = Joyce.paranoidWorldTimer - 60;
      if (num2 < 0)
        num2 = 0;
      int num3 = num2 * 5;
      int num4 = num2 * 10;
      exitAmount = 0;
      if (Random.Range(0, 99) < num4)
      {
        int newValue = caster.GetStoredValue((UnitStoredValueNames) 69696969) + 1;
        caster.SetStoredValue((UnitStoredValueNames) 69696969, newValue);
      }
      if (Random.Range(0, 99) < num3)
      {
        foreach (TargetSlotInfo target in targets)
        {
          if (target.HasUnit && target.Unit.TryPerformRandomAbility())
            ++exitAmount;
        }
      }
      if (Random.Range(0, 99) < num3)
      {
        for (int index = 0; index < targets.Length; ++index)
        {
          if (targets[index].HasUnit && targets[index].Unit.DirectDeath(caster, true))
            ++exitAmount;
        }
      }
      return exitAmount > 0;
    }
  }
}
