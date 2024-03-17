// Decompiled with JetBrains decompiler
// Type: THE_DEAD.Passiver
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using BrutalAPI;
using System.Collections.Generic;
using UnityEngine;

namespace THE_DEAD
{
  public static class Passiver
  {
    private static BasePassiveAbilitySO _noStallWithering;

    public static BasePassiveAbilitySO Fleeting(int amount)
    {
      FleetingPassiveAbility fleetingPassiveAbility = Object.Instantiate<FleetingPassiveAbility>(Passives.Fleeting as FleetingPassiveAbility);
      fleetingPassiveAbility._passiveName = "Fleeting (" + amount.ToString() + ")";
      fleetingPassiveAbility._characterDescription = "After " + amount.ToString() + " rounds this party member will flee... Coward.";
      fleetingPassiveAbility._enemyDescription = "After " + amount.ToString() + " rounds this enemy will flee.";
      fleetingPassiveAbility._turnsBeforeFleeting = amount;
      return (BasePassiveAbilitySO) fleetingPassiveAbility;
    }

    public static BasePassiveAbilitySO Overexert(int amount)
    {
      IntegerReferenceOverEqualValueEffectorCondition instance = ScriptableObject.CreateInstance<IntegerReferenceOverEqualValueEffectorCondition>();
      instance.compareValue = amount;
      BasePassiveAbilitySO passiveAbilitySo = Object.Instantiate<BasePassiveAbilitySO>(LoadedAssetsHandler.GetEnemy("Scrungie_EN").passiveAbilities[2]);
      passiveAbilitySo._passiveName = "Overexert (" + amount.ToString() + ")";
      passiveAbilitySo._characterDescription = "Won't work with this version.";
      passiveAbilitySo._enemyDescription = "Upon receiving " + amount.ToString() + " or more direct damage, cancel 1 of this enemy's actions.";
      passiveAbilitySo.conditions = new EffectorConditionSO[1]
      {
        (EffectorConditionSO) instance
      };
      return passiveAbilitySo;
    }

    public static BasePassiveAbilitySO Leaky(int amount)
    {
      PerformEffectPassiveAbility instance = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
      instance._passiveName = "Leaky (" + amount.ToString() + ")";
      instance.passiveIcon = Passives.Leaky.passiveIcon;
      instance._enemyDescription = "Upon receiving direct damage, this enemy generates " + amount.ToString() + " extra pigment of its health color.";
      instance._characterDescription = "Upon receiving direct damage, this character generates " + amount.ToString() + " extra pigment of its health color.";
      instance.type = PassiveAbilityTypes.Leaky;
      instance.doesPassiveTriggerInformationPanel = true;
      instance._triggerOn = new TriggerCalls[1]
      {
        TriggerCalls.OnDirectDamaged
      };
      instance.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<GenerateCasterHealthManaEffect>(), amount, new IntentType?(), Slots.Self)
      });
      return (BasePassiveAbilitySO) instance;
    }

    public static BasePassiveAbilitySO Multiattack(int amount)
    {
      IntegerSetterPassiveAbility setterPassiveAbility = Object.Instantiate<IntegerSetterPassiveAbility>(Passives.Multiattack as IntegerSetterPassiveAbility);
      setterPassiveAbility._passiveName = "Multi Attack (" + amount.ToString() + ")";
      setterPassiveAbility._characterDescription = "won't work boowomp";
      setterPassiveAbility._enemyDescription = "This enemy will perform " + amount.ToString() + " actions each turn.";
      setterPassiveAbility.integerValue = amount - 1;
      return (BasePassiveAbilitySO) setterPassiveAbility;
    }

    public static BasePassiveAbilitySO Inferno(int amount)
    {
      PerformEffectPassiveAbility instance = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
      instance._passiveName = "Inferno (" + amount.ToString() + ")";
      instance.passiveIcon = Passives.Inferno.passiveIcon;
      instance._enemyDescription = "On turn start, this enemy inflicts " + amount.ToString() + " Fire on their position.";
      instance._characterDescription = "On turn start, this character inflicts " + amount.ToString() + " Fire on their position.";
      instance.type = PassiveAbilityTypes.Inferno;
      instance.doesPassiveTriggerInformationPanel = true;
      instance._triggerOn = new TriggerCalls[1]
      {
        TriggerCalls.OnTurnStart
      };
      instance.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), amount, new IntentType?(), Slots.Self)
      });
      return (BasePassiveAbilitySO) instance;
    }

    public static BasePassiveAbilitySO Abomination => LoadedAssetsHandler.GetEnemy("OneManBand_EN").passiveAbilities[1];

    public static BasePassiveAbilitySO NoStallWithering
    {
      get
      {
        if ((Object) Passiver._noStallWithering == (Object) null)
        {
          Passiver._noStallWithering = (BasePassiveAbilitySO) ScriptableObject.CreateInstance<NoStallWItheringPassiveAbility>();
          Passiver._noStallWithering._passiveName = Passives.Withering._passiveName;
          Passiver._noStallWithering.passiveIcon = Passives.Withering.passiveIcon;
          Passiver._noStallWithering._characterDescription = "If all remaining party members also have Withering, this party member will die.\nThis check is run repeatedly throughout combat.";
          Passiver._noStallWithering._enemyDescription = "If all remaining enemies also have Withering, this enemy will die.\nThis check is run repeatedly throughout combat.";
          Passiver._noStallWithering._triggerOn = new List<TriggerCalls>((IEnumerable<TriggerCalls>) Passives.Withering._triggerOn)
          {
            TriggerCalls.OnTurnStart,
            TriggerCalls.OnTurnFinished,
            TriggerCalls.OnPlayerTurnEnd_ForEnemy,
            TriggerCalls.OnMiscPlayerTurnStart,
            TriggerCalls.OnRoundFinished
          }.ToArray();
          Passiver._noStallWithering.type = Passives.Withering.type;
          Passiver._noStallWithering.doesPassiveTriggerInformationPanel = false;
          Passiver._noStallWithering.conditions = new EffectorConditionSO[0];
        }
        return Passiver._noStallWithering;
      }
    }
  }
}
