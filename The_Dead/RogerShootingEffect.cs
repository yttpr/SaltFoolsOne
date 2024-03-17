// Decompiled with JetBrains decompiler
// Type: THE_DEAD.RogerShootingEffect
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using BrutalAPI;
using UnityEngine;

namespace THE_DEAD
{
  public class RogerShootingEffect : EffectSO
  {
    [SerializeField]
    public BaseCombatTargettingSO leftShot = Slots.SlotTarget(new int[5]
    {
      0,
      -1,
      -2,
      -3,
      -4
    });
    [SerializeField]
    public BaseCombatTargettingSO rightShot = Slots.SlotTarget(new int[5]
    {
      0,
      1,
      2,
      3,
      4
    });

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 0;
      int num1 = Random.Range(0, 2);
      Effect effect1 = new Effect((EffectSO) ScriptableObject.CreateInstance<BetweenVarAndEntryDamageOnDoubleCascadeEffect>(), entryVariable, new IntentType?(), this.leftShot);
      Effect effect2 = new Effect((EffectSO) ScriptableObject.CreateInstance<BetweenVarAndEntryDamageOnDoubleCascadeEffect>(), entryVariable, new IntentType?(), this.rightShot);
      int num2 = 1;
      int num3 = -1;
      bool flag1 = false;
      bool flag2 = false;
      foreach (TargetSlotInfo target in targets)
      {
        if (target.HasUnit && target.Unit.IsAlive)
        {
          int num4 = target.Unit.Size - 1;
          TargetSlotInfo targetSlotInfo;
          if (target.Unit.SlotID + num4 >= caster.SlotID)
          {
            if (num3 < 0)
            {
              targetSlotInfo = target;
              num3 = target.Unit.SlotID;
              flag1 = true;
            }
            else if (target.Unit.SlotID > num3)
            {
              targetSlotInfo = target;
              num3 = target.Unit.SlotID;
              flag1 = true;
            }
          }
        }
      }
      TargetSlotInfo targetSlotInfo1;
      foreach (TargetSlotInfo target in targets)
      {
        if (target.HasUnit && target.Unit.IsAlive && target.Unit.SlotID <= caster.SlotID)
        {
          if (num2 > 0)
          {
            targetSlotInfo1 = target;
            num2 = target.Unit.SlotID;
            flag2 = true;
          }
          else if (target.Unit.SlotID < num2)
          {
            targetSlotInfo1 = target;
            num2 = target.Unit.SlotID;
            flag2 = true;
          }
        }
      }
      if (num1 == 0 && flag1 && flag2)
        CombatManager.Instance.AddSubAction((CombatAction) new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[2]
        {
          effect2,
          effect1
        }), caster));
      if (num1 == 1 && flag2 && flag1)
        CombatManager.Instance.AddSubAction((CombatAction) new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[2]
        {
          effect1,
          effect2
        }), caster));
      if (!flag1 && flag2)
        CombatManager.Instance.AddSubAction((CombatAction) new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1]
        {
          effect1
        }), caster));
      if (!flag2 && flag1)
        CombatManager.Instance.AddSubAction((CombatAction) new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1]
        {
          effect2
        }), caster));
      return exitAmount > 0;
    }
  }
}
