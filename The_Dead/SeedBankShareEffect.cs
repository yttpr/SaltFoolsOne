// Decompiled with JetBrains decompiler
// Type: THE_DEAD.SeedBankShareEffect
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

namespace THE_DEAD
{
  public class SeedBankShareEffect : EffectSO
  {
    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      int num1 = entryVariable;
      for (int index = 0; index < num1; ++index)
      {
        foreach (TargetSlotInfo target in targets)
        {
          if (target.HasUnit)
          {
            int num2 = areTargetSlots ? target.SlotID - target.Unit.SlotID : -1;
            if (target.Unit.GetStoredValue((UnitStoredValueNames) 202300) < num1)
              CombatManager.Instance.PostNotification(((TriggerCalls) 202301).ToString(), (object) target.Unit, (object) null);
          }
        }
      }
      exitAmount = 1;
      return true;
    }
  }
}
