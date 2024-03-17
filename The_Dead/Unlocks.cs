// Decompiled with JetBrains decompiler
// Type: THE_DEAD.Unlocks
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using BrutalAPI;
using System;
using UnityEngine;

namespace THE_DEAD
{
    public static class Unlocks
    {
        public static bool _debug;

        public static bool byDefault => Unlocks._debug || UnlockSetup.UnlockedByDefault;

        public static void Setup()
        {
            Unlocks.PCall(new Action<bool>(Unlocks.Dead), Unlocks.byDefault, "dead unlocks");
            Unlocks.PCall(new Action<bool>(Unlocks.Free), Unlocks.byDefault, "free unlocks");
            Unlocks.PCall(new Action<bool>(Unlocks.Noise), Unlocks.byDefault, "noise unlocks");
            Unlocks.PCall(new Action<bool>(Unlocks.Paranoid), Unlocks.byDefault, "paranoid unlocks");
            Unlocks.PCall(new Action<bool>(Unlocks.Lost), Unlocks.byDefault, "lost unlocks");
            Unlocks.PCall(new Action<bool>(Unlocks.Living), Unlocks.byDefault, "living unlocks");
            Unlocks.PCall(new Action<bool>(Unlocks.Remnant), Unlocks.byDefault, "remnant unlocks");
            Unlocks.PCall(new Action<bool>(Unlocks.Toast), Unlocks.byDefault, "toast unlocks");
            Unlocks.PCall(new Action<bool>(Unlocks.Delusional), Unlocks.byDefault, "delusional unlocks");
            Unlocks.PCall(new Action<bool>(Unlocks.Abortion), Unlocks.byDefault, "abortion unlocks");
            Unlocks.PCall(new Action<bool>(Unlocks.Blooming), Unlocks.byDefault, "blooming unlocks");
        }

        public static void Dead(bool byDefault)
        {
            ExtraPassiveAbility_Wearable_SMS instance1 = ScriptableObject.CreateInstance<ExtraPassiveAbility_Wearable_SMS>();
            instance1._extraPassiveAbility = Passiver.NoStallWithering;
            ExtraPassiveAbility_Wearable_SMS instance2 = ScriptableObject.CreateInstance<ExtraPassiveAbility_Wearable_SMS>();
            instance2._extraPassiveAbility = Passives.Immortal;
            EffectItem heavenUnlock = new EffectItem();
            heavenUnlock.name = "False Sacrifice";
            heavenUnlock.flavorText = "\"We got the wrong guy!\"";
            heavenUnlock.description = "On any party member or enemy performing an ability, apply 1 Anesthetics on this party member. \nThis party member has Withering and Immortal as passives.";
            heavenUnlock.sprite = ResourceLoader.LoadSprite("DeadH_item.png");
            heavenUnlock.trigger = TriggerCalls.OnAnyAbilityUsed;
            heavenUnlock.consumeTrigger = TriggerCalls.Count;
            heavenUnlock.unlockableID = (UnlockableID)302100;
            heavenUnlock.namePopup = false;
            heavenUnlock.itemPools = ItemPools.Shop;
            heavenUnlock.shopPrice = 10;
            heavenUnlock.startsLocked = false;
            heavenUnlock.immediate = false;
            heavenUnlock.triggerConditions = new EffectorConditionSO[0];
            heavenUnlock.consumeConditions = new EffectorConditionSO[0];
            heavenUnlock.equippedModifiers = new WearableStaticModifierSetterSO[2]
            {
        (WearableStaticModifierSetterSO) instance1,
        (WearableStaticModifierSetterSO) instance2
            };
            heavenUnlock.effects = new Effect[1]
            {
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyAnestheticsEffect>(), 1, new IntentType?(), Slots.Self)
            };
            DoubleEffectItem osmanUnlock = new DoubleEffectItem();
            osmanUnlock.name = "Meditation";
            osmanUnlock.flavorText = "\"Don't interrupt.\"";
            osmanUnlock.description = "On taking direct damage, instantly die. Apply 10 shield to this party member's Left and Right positions on turn start.";
            osmanUnlock.sprite = ResourceLoader.LoadSprite("DeadO_item.png");
            osmanUnlock.trigger = TriggerCalls.OnDirectDamaged;
            osmanUnlock.consumeTrigger = TriggerCalls.Count;
            osmanUnlock.unlockableID = (UnlockableID)302101;
            osmanUnlock.namePopup = true;
            osmanUnlock.itemPools = ItemPools.Shop;
            osmanUnlock.shopPrice = 3;
            osmanUnlock.startsLocked = false;
            osmanUnlock.triggerConditions = new EffectorConditionSO[0];
            osmanUnlock.consumeConditions = new EffectorConditionSO[0];
            osmanUnlock.equippedModifiers = new WearableStaticModifierSetterSO[0];
            osmanUnlock.SecondTrigger = new TriggerCalls[1]
            {
        TriggerCalls.OnTurnStart
            };
            osmanUnlock._firsteEffectImmediate = false;
            osmanUnlock._secondImmediateEffect = false;
            osmanUnlock.secondPopUp = true;
            osmanUnlock.secondTriggerConditions = new EffectorConditionSO[0];
            osmanUnlock.firstEffects = new Effect[1]
            {
        new Effect((EffectSO) ScriptableObject.CreateInstance<DirectDeathEffect>(), 1, new IntentType?(), Slots.Self)
            };
            osmanUnlock.secondEffects = new Effect[1]
            {
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 10, new IntentType?(), Slots.Sides)
            };
            if (byDefault)
            {
                heavenUnlock.AddItem();
                osmanUnlock.AddItem();
            }
            else
            {
                new FoolBossUnlockSystem.FoolItemPairs((EntityIDs)98789, "Didion", (Item)heavenUnlock, (Item)osmanUnlock).Add();
                new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement)302100, AchievementUnlockType.TheDivine, "False Sacrifice", "Unlocked a new item.", ResourceLoader.LoadSprite("DeadH_Panel.png")).Prepare((EntityIDs)98789, BossType.Heaven);
                new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement)302101, AchievementUnlockType.TheWitness, "Meditation", "Unlocked a new item.", ResourceLoader.LoadSprite("DeadO_Panel.png")).Prepare((EntityIDs)98789, BossType.OsmanSinnoks);
            }
        }

        public static void Free(bool byDefault)
        {
            ExtraPassiveAbility_Wearable_SMS instance1 = ScriptableObject.CreateInstance<ExtraPassiveAbility_Wearable_SMS>();
            instance1._extraPassiveAbility = Passives.Confusion;
            ExtraPassiveAbility_Wearable_SMS instance2 = ScriptableObject.CreateInstance<ExtraPassiveAbility_Wearable_SMS>();
            instance2._extraPassiveAbility = Passives.Skittish;
            PerformDoubleEffectPassiveAbility instance3 = ScriptableObject.CreateInstance<PerformDoubleEffectPassiveAbility>();
            instance3._passiveName = "MultiAttack (3)";
            instance3.passiveIcon = Passives.Multiattack.passiveIcon;
            instance3.type = PassiveAbilityTypes.MultiAttack;
            instance3._enemyDescription = "This shouldn't be on an enemy.";
            instance3._characterDescription = "This party member can perform three abilities per turn.";
            instance3.specialStoredValue = (UnitStoredValueNames)77889;
            CasterSetStoredValueEffect instance4 = ScriptableObject.CreateInstance<CasterSetStoredValueEffect>();
            instance4._valueName = (UnitStoredValueNames)77889;
            instance3._triggerOn = new TriggerCalls[1]
            {
        TriggerCalls.OnTurnStart
            };
            instance3.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
            {
        new Effect((EffectSO) instance4, 2, new IntentType?(), Slots.Self)
            });
            RefreshIfStoredValueNotZero instance5 = ScriptableObject.CreateInstance<RefreshIfStoredValueNotZero>();
            instance5._valueName = (UnitStoredValueNames)77889;
            ScriptableObject.CreateInstance<CasterLowerStoredValueEffect>()._valueName = (UnitStoredValueNames)77889;
            instance3._secondTriggerOn = new TriggerCalls[1]
            {
        TriggerCalls.OnAbilityUsed
            };
            instance3._secondEffects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
            {
        new Effect((EffectSO) instance5, 1, new IntentType?(), Slots.Self)
            });
            instance3.doesPassiveTriggerInformationPanel = false;
            instance3._secondDoesPerformPopUp = true;
            ExtraPassiveAbility_Wearable_SMS instance6 = ScriptableObject.CreateInstance<ExtraPassiveAbility_Wearable_SMS>();
            instance6._extraPassiveAbility = (BasePassiveAbilitySO)instance3;
            EffectItem heavenUnlock = new EffectItem();
            heavenUnlock.name = "Foggy Glasses";
            heavenUnlock.flavorText = "\"Can't see with 'em, can't see without 'em.\"";
            heavenUnlock.description = "This party member has Confusion, Skittish, and Multiattack (3) as passives.";
            heavenUnlock.sprite = ResourceLoader.LoadSprite("FreeH_item.png");
            heavenUnlock.trigger = TriggerCalls.Count;
            heavenUnlock.consumeTrigger = TriggerCalls.Count;
            heavenUnlock.unlockableID = (UnlockableID)302110;
            heavenUnlock.namePopup = false;
            heavenUnlock.itemPools = ItemPools.Shop;
            heavenUnlock.shopPrice = 6;
            heavenUnlock.startsLocked = false;
            heavenUnlock.triggerConditions = new EffectorConditionSO[0];
            heavenUnlock.consumeConditions = new EffectorConditionSO[0];
            heavenUnlock.equippedModifiers = new WearableStaticModifierSetterSO[3]
            {
        (WearableStaticModifierSetterSO) instance1,
        (WearableStaticModifierSetterSO) instance2,
        (WearableStaticModifierSetterSO) instance6
            };
            heavenUnlock.immediate = false;
            heavenUnlock.effects = new Effect[0];
            EffectItem osmanUnlock = new EffectItem();
            osmanUnlock.name = "Tooth Gun";
            osmanUnlock.flavorText = "\"It hurts.\"";
            osmanUnlock.description = "Increase this party member's damage by the amount of health they are missing, then take 10% of their maximum health as indirect damage.";
            osmanUnlock.sprite = ResourceLoader.LoadSprite("FreeO_item.png");
            osmanUnlock.trigger = TriggerCalls.OnWillApplyDamage;
            osmanUnlock.consumeTrigger = TriggerCalls.Count;
            osmanUnlock.unlockableID = (UnlockableID)302111;
            osmanUnlock.namePopup = true;
            osmanUnlock.itemPools = ItemPools.Treasure;
            osmanUnlock.shopPrice = 6;
            osmanUnlock.startsLocked = false;
            osmanUnlock.triggerConditions = new EffectorConditionSO[1]
            {
        (EffectorConditionSO) ScriptableObject.CreateInstance<ToothGunCondition>()
            };
            osmanUnlock.consumeConditions = new EffectorConditionSO[0];
            osmanUnlock.equippedModifiers = new WearableStaticModifierSetterSO[0];
            osmanUnlock.immediate = true;
            osmanUnlock.effects = new Effect[1]
            {
        new Effect((EffectSO) SubActionEffect.Create(new Effect[1]
        {
          new Effect((EffectSO) SubActionEffect.Create(new Effect[1]
          {
            new Effect((EffectSO) ScriptableObject.CreateInstance<ToothGunSelfEffect>(), 1, new IntentType?(), Slots.Self)
          }), 1, new IntentType?(), Slots.Self)
        }), 1, new IntentType?(), Slots.Self)
            };
            if (byDefault)
            {
                heavenUnlock.AddItem();
                osmanUnlock.AddItem();
            }
            else
            {
                new FoolBossUnlockSystem.FoolItemPairs((EntityIDs)98787, "Verne", (Item)heavenUnlock, (Item)osmanUnlock).Add();
                new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement)302110, AchievementUnlockType.TheDivine, "Foggy Glasses", "Unlocked a new item.", ResourceLoader.LoadSprite("FreeH_Panel.png")).Prepare((EntityIDs)98787, BossType.Heaven);
                new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement)302111, AchievementUnlockType.TheWitness, "Tooth Gun", "Unlocked a new item.", ResourceLoader.LoadSprite("FreeO_Panel.png")).Prepare((EntityIDs)98787, BossType.OsmanSinnoks);
            }
        }

        public static void Paranoid(bool byDefault)
        {
            EffectItem heavenUnlock = new EffectItem();
            heavenUnlock.name = "March of Time";
            heavenUnlock.flavorText = "\"Two by two\"";
            heavenUnlock.description = "At the end of each turn, deal indirect damage to the Opposing enemy for the amount of turns spent in combat.";
            heavenUnlock.sprite = ResourceLoader.LoadSprite("ParanoidH_item.png");
            heavenUnlock.trigger = TriggerCalls.OnTurnFinished;
            heavenUnlock.consumeTrigger = TriggerCalls.Count;
            heavenUnlock.unlockableID = (UnlockableID)302120;
            heavenUnlock.namePopup = true;
            heavenUnlock.itemPools = ItemPools.Treasure;
            heavenUnlock.shopPrice = 5;
            heavenUnlock.startsLocked = false;
            heavenUnlock.triggerConditions = new EffectorConditionSO[0];
            heavenUnlock.consumeConditions = new EffectorConditionSO[0];
            heavenUnlock.equippedModifiers = new WearableStaticModifierSetterSO[0];
            heavenUnlock.immediate = false;
            heavenUnlock.effects = new Effect[1]
            {
        new Effect((EffectSO) ScriptableObject.CreateInstance<IndirectDamageByTurnsEffect>(), 1, new IntentType?(), Slots.Front)
            };
            EffectItem osmanUnlock = new EffectItem();
            osmanUnlock.name = "Burning Blood";
            osmanUnlock.flavorText = "\"Boiling from deep inside.\"";
            osmanUnlock.description = "On dealing damage, inflict 1 Fire on the target's position. On taking any damage, inflict 2 fire on self.";
            osmanUnlock.sprite = ResourceLoader.LoadSprite("ParanoidO_item.png");
            osmanUnlock.trigger = TriggerCalls.OnDamaged;
            osmanUnlock.consumeTrigger = TriggerCalls.Count;
            osmanUnlock.unlockableID = (UnlockableID)302121;
            osmanUnlock.namePopup = true;
            osmanUnlock.itemPools = ItemPools.Shop;
            osmanUnlock.shopPrice = 5;
            osmanUnlock.startsLocked = false;
            osmanUnlock.triggerConditions = new EffectorConditionSO[0];
            osmanUnlock.consumeConditions = new EffectorConditionSO[0];
            osmanUnlock.equippedModifiers = new WearableStaticModifierSetterSO[0];
            osmanUnlock.immediate = false;
            osmanUnlock.effects = new Effect[1]
            {
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), 2, new IntentType?(), Slots.Self)
            };
            if (byDefault)
            {
                heavenUnlock.AddItem();
                osmanUnlock.AddItem();
            }
            else
            {
                new FoolBossUnlockSystem.FoolItemPairs((EntityIDs)9878770, "Pynchon", (Item)heavenUnlock, (Item)osmanUnlock).Add();
                new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement)302120, AchievementUnlockType.TheDivine, "March of Time", "Unlocked a new item.", ResourceLoader.LoadSprite("ParanoidH_Panel.png")).Prepare((EntityIDs)9878770, BossType.Heaven);
                new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement)302121, AchievementUnlockType.TheWitness, "Burning Blood", "Unlocked a new item.", ResourceLoader.LoadSprite("ParanoidO_Panel.png")).Prepare((EntityIDs)9878770, BossType.OsmanSinnoks);
            }
        }

        public static void Lost(bool byDefault)
        {
            ExtraPassiveAbility_Wearable_SMS instance = ScriptableObject.CreateInstance<ExtraPassiveAbility_Wearable_SMS>();
            instance._extraPassiveAbility = Passives.Constricting;
            EffectItem heavenUnlock = new EffectItem();
            heavenUnlock.name = "Bloodfalls";
            heavenUnlock.flavorText = "\"Slowly dripping out of me\"";
            heavenUnlock.description = "On combat start, permenantly inflict all enemies with Ruptured. This party member has Constricting as a passive.";
            heavenUnlock.sprite = ResourceLoader.LoadSprite("LostH_item.png");
            heavenUnlock.trigger = TriggerCalls.OnCombatStart;
            heavenUnlock.consumeTrigger = TriggerCalls.Count;
            heavenUnlock.unlockableID = (UnlockableID)302130;
            heavenUnlock.namePopup = true;
            heavenUnlock.itemPools = ItemPools.Shop;
            heavenUnlock.shopPrice = 6;
            heavenUnlock.startsLocked = false;
            heavenUnlock.triggerConditions = new EffectorConditionSO[0];
            heavenUnlock.consumeConditions = new EffectorConditionSO[0];
            heavenUnlock.equippedModifiers = new WearableStaticModifierSetterSO[1]
            {
        (WearableStaticModifierSetterSO) instance
            };
            heavenUnlock.immediate = false;
            heavenUnlock.effects = new Effect[1]
            {
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyPermenantRupturedEffect>(), 1, new IntentType?(), (BaseCombatTargettingSO) EZEffects.TargetSide<Targetting_ByUnit_Side>(false, false))
            };
            EffectItem osmanUnlock = new EffectItem();
            osmanUnlock.name = "Page 11";
            osmanUnlock.flavorText = "\"#!&?%8#\"";
            osmanUnlock.description = "At the start of combat, heal all party members 5 health, then Curse all party members and enemies.";
            osmanUnlock.sprite = ResourceLoader.LoadSprite("LostO_item.png");
            osmanUnlock.trigger = TriggerCalls.OnCombatStart;
            osmanUnlock.consumeTrigger = TriggerCalls.Count;
            osmanUnlock.unlockableID = (UnlockableID)302131;
            osmanUnlock.namePopup = true;
            osmanUnlock.itemPools = ItemPools.Treasure;
            osmanUnlock.shopPrice = 4;
            osmanUnlock.startsLocked = false;
            osmanUnlock.triggerConditions = new EffectorConditionSO[0];
            osmanUnlock.consumeConditions = new EffectorConditionSO[0];
            osmanUnlock.equippedModifiers = new WearableStaticModifierSetterSO[0];
            osmanUnlock.immediate = false;
            osmanUnlock.effects = new Effect[2]
            {
        new Effect((EffectSO) ScriptableObject.CreateInstance<HealEffect>(), 5, new IntentType?(), (BaseCombatTargettingSO) EZEffects.TargetSide<Targetting_ByUnit_Side>(true, false)),
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyCursedEffect>(), 1, new IntentType?(), (BaseCombatTargettingSO) MultiTargetting.Create((BaseCombatTargettingSO) EZEffects.TargetSide<Targetting_ByUnit_Side>(true, false), (BaseCombatTargettingSO) EZEffects.TargetSide<Targetting_ByUnit_Side>(false, false)))
            };
            if (byDefault)
            {
                heavenUnlock.AddItem();
                osmanUnlock.AddItem();
            }
            else
            {
                new FoolBossUnlockSystem.FoolItemPairs((EntityIDs)66677765, "Kafka", (Item)heavenUnlock, (Item)osmanUnlock).Add();
                new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement)302130, AchievementUnlockType.TheDivine, "Bloodfalls", "Unlocked a new item.", ResourceLoader.LoadSprite("LostH_Panel.png")).Prepare((EntityIDs)66677765, BossType.Heaven);
                new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement)302131, AchievementUnlockType.TheWitness, "Page 11", "Unlocked a new item.", ResourceLoader.LoadSprite("LostO_Panel.png")).Prepare((EntityIDs)66677765, BossType.OsmanSinnoks);
            }
        }

        public static void Living(bool byDefault)
        {
            PerformEffectPassiveAbility instance1 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            instance1._passiveName = "Wrist Cutter";
            instance1.passiveIcon = (Sprite)null;
            instance1.type = (PassiveAbilityTypes)98765;
            instance1._enemyDescription = "Whargh.";
            instance1._characterDescription = (string)null;
            ApplyScarsEffect instance2 = ScriptableObject.CreateInstance<ApplyScarsEffect>();
            instance1.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
            {
        new Effect((EffectSO) instance2, 1, new IntentType?(), Slots.Self, (EffectConditionSO) Conditions.Chance(50))
            });
            instance1._triggerOn = new TriggerCalls[1]
            {
        TriggerCalls.OnTurnStart
            };
            MultiplyPercentDamageItem heavenUnlock = new MultiplyPercentDamageItem();
            heavenUnlock.name = "Wrist Cutter";
            heavenUnlock.flavorText = "\"Healthy coping mechanism!\"";
            heavenUnlock.description = "At the start of every turn, 50% chance to apply 1 scar to self. This party member does 25% more damage than they otherwise would have.";
            heavenUnlock.sprite = ResourceLoader.LoadSprite("Wrist Cutter Icon");
            heavenUnlock.trigger = TriggerCalls.OnWillApplyDamage;
            heavenUnlock.consumeTrigger = TriggerCalls.Count;
            heavenUnlock.unlockableID = (UnlockableID)98789;
            heavenUnlock.namePopup = true;
            heavenUnlock.itemPools = ItemPools.Shop;
            heavenUnlock.shopPrice = 5;
            heavenUnlock.startsLocked = false;
            heavenUnlock.useDealt = true;
            heavenUnlock._percentageToModify = 25;
            heavenUnlock.equippedModifiers = new WearableStaticModifierSetterSO[1];
            heavenUnlock.equippedModifiers[0] = (WearableStaticModifierSetterSO)ScriptableObject.CreateInstance<ExtraPassiveAbility_Wearable_SMS>();
            ((ExtraPassiveAbility_Wearable_SMS)heavenUnlock.equippedModifiers[0])._extraPassiveAbility = (BasePassiveAbilitySO)instance1;
            DoubleEffectItem osmanUnlock = new DoubleEffectItem();
            osmanUnlock.name = "Envious Ambition";
            osmanUnlock.flavorText = "\"Hunger for more than you are.\"";
            osmanUnlock.description = "On any party member or enemy using an ability, gain 1 Power. On dealing damage, apply half of the Power on self to all enemies.";
            osmanUnlock.sprite = ResourceLoader.LoadSprite("AliveO_item.png");
            osmanUnlock.trigger = TriggerCalls.OnAnyAbilityUsed;
            osmanUnlock.consumeTrigger = TriggerCalls.Count;
            osmanUnlock.unlockableID = (UnlockableID)302141;
            osmanUnlock.namePopup = false;
            osmanUnlock.itemPools = ItemPools.Treasure;
            osmanUnlock.shopPrice = 8;
            osmanUnlock.startsLocked = false;
            osmanUnlock.triggerConditions = new EffectorConditionSO[0];
            osmanUnlock.consumeConditions = new EffectorConditionSO[0];
            osmanUnlock.equippedModifiers = new WearableStaticModifierSetterSO[0];
            osmanUnlock._firsteEffectImmediate = false;
            osmanUnlock.firstEffects = new Effect[1]
            {
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyPowerEffect>(), 1, new IntentType?(), Slots.Self)
            };
            osmanUnlock.SecondTrigger = new TriggerCalls[1]
            {
        TriggerCalls.OnDidApplyDamage
            };
            osmanUnlock.secondPopUp = true;
            osmanUnlock.secondTriggerConditions = new EffectorConditionSO[0];
            osmanUnlock.secondEffects = new Effect[1]
            {
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyPowerByHalfSelfPowerEffect>(), 1, new IntentType?(), (BaseCombatTargettingSO) EZEffects.TargetSide<Targetting_ByUnit_Side>(false, false))
            };
            if (byDefault)
            {
                heavenUnlock.AddItem();
                osmanUnlock.AddItem();
            }
            else
            {
                new FoolBossUnlockSystem.FoolItemPairs((EntityIDs)456654567, "Rose", (Item)heavenUnlock, (Item)osmanUnlock).Add();
                new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement)302140, AchievementUnlockType.TheDivine, "Wrist Cutter", "Unlocked a new item.", ResourceLoader.LoadSprite("AliveH_Panel.png")).Prepare((EntityIDs)456654567, BossType.Heaven);
                new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement)302141, AchievementUnlockType.TheWitness, "Envious Ambition", "Unlocked a new item.", ResourceLoader.LoadSprite("AliveO_Panel.png")).Prepare((EntityIDs)456654567, BossType.OsmanSinnoks);
            }
        }

        public static void Remnant(bool byDefault)
        {
            EffectItem heavenUnlock = new EffectItem();
            heavenUnlock.name = "Jim Crow Laws";
            heavenUnlock.flavorText = "\"What the f#?@\"";
            heavenUnlock.description = "On dealing damage, turn the Opposing enemy Purple. Deal double damage to Purple enemies.";
            heavenUnlock.sprite = ResourceLoader.LoadSprite("RemnantH_item.png");
            heavenUnlock.trigger = TriggerCalls.OnDidApplyDamage;
            heavenUnlock.consumeTrigger = TriggerCalls.Count;
            heavenUnlock.unlockableID = (UnlockableID)302150;
            heavenUnlock.namePopup = true;
            heavenUnlock.itemPools = ItemPools.Treasure;
            heavenUnlock.shopPrice = 8;
            heavenUnlock.startsLocked = false;
            heavenUnlock.triggerConditions = new EffectorConditionSO[0];
            heavenUnlock.consumeConditions = new EffectorConditionSO[0];
            heavenUnlock.equippedModifiers = new WearableStaticModifierSetterSO[0];
            heavenUnlock.immediate = false;
            heavenUnlock.effects = new Effect[1]
            {
        new Effect((EffectSO) ScriptableObject.CreateInstance<TurnTargetHealthPurpleEffect>(), 1, new IntentType?(), Slots.Front)
            };
            EffectItem osmanUnlock = new EffectItem();
            osmanUnlock.name = "Vowkeeper";
            osmanUnlock.flavorText = "''Purble...''";
            osmanUnlock.description = "At the end of each turn, consume 0-10 random pigment and replace it with an equal amount of Purble pigment.";
            osmanUnlock.sprite = ResourceLoader.LoadSprite("VowKeeper");
            osmanUnlock.trigger = TriggerCalls.OnTurnFinished;
            osmanUnlock.unlockableID = (UnlockableID)778822;
            osmanUnlock.consumeTrigger = TriggerCalls.Count;
            osmanUnlock.namePopup = true;
            osmanUnlock.consumedOnUse = false;
            osmanUnlock.itemPools = ItemPools.Shop;
            osmanUnlock.shopPrice = 0;
            osmanUnlock.startsLocked = false;
            GeneratePurpleManaEffect instance1 = ScriptableObject.CreateInstance<GeneratePurpleManaEffect>();
            ConsumeRandomRandomManaEffect instance2 = ScriptableObject.CreateInstance<ConsumeRandomRandomManaEffect>();
            osmanUnlock.immediate = false;
            osmanUnlock.equippedModifiers = new WearableStaticModifierSetterSO[0];
            osmanUnlock.effects = new Effect[2]
            {
        new Effect((EffectSO) instance2, 10, new IntentType?(), Slots.Self),
        new Effect((EffectSO) instance1, 1, new IntentType?(), Slots.Self)
            };
            if (byDefault)
            {
                heavenUnlock.AddItem();
                osmanUnlock.AddItem();
            }
            else
            {
                new FoolBossUnlockSystem.FoolItemPairs((EntityIDs)86484, "Faith", (Item)heavenUnlock, (Item)osmanUnlock).Add();
                new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement)372150, AchievementUnlockType.TheDivine, "Jim Crow Laws", "Unlocked a new item.", ResourceLoader.LoadSprite("RemnantH_Panel.png")).Prepare((EntityIDs)86484, BossType.Heaven);
                new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement)372151, AchievementUnlockType.TheWitness, "Vowkeeper", "Unlocked a new item.", ResourceLoader.LoadSprite("RemnantO_Panel.png")).Prepare((EntityIDs)86484, BossType.OsmanSinnoks);
            }
        }

        public static void Delusional(bool byDefault)
        {
            Ability ability = new Ability()
            {
                name = "Randomizer",
                description = "Reroll all turns on the timeline. Randomize all enemy positions.",
                cost = new ManaColorSO[1] { Pigments.Yellow },
                animationTarget = (BaseCombatTargettingSO)EZEffects.TargetSide<Targetting_ByUnit_Side>(false, false),
                visuals = LoadedAssetsHandler.GetCharacterAbility("Insult_1_A").visuals
            };
            ability.effects = new Effect[2]
            {
        new Effect((EffectSO) ScriptableObject.CreateInstance<RerollEntireTimelineEffect>(), 1, new IntentType?(IntentType.Misc), ability.animationTarget),
        new Effect((EffectSO) ScriptableObject.CreateInstance<MassSwapZoneEffect>(), 1, new IntentType?(IntentType.Swap_Mass), ability.animationTarget)
            };
            ExtraAbility_Wearable_SMS instance1 = ScriptableObject.CreateInstance<ExtraAbility_Wearable_SMS>();
            instance1._extraAbility = ability.CharacterAbility();
            EffectItem heavenUnlock = new EffectItem();
            heavenUnlock.name = "Auto-Shuffler";
            heavenUnlock.flavorText = "\"Easy deal\"";
            heavenUnlock.description = "Give this party member the extra ability \"Randomizer\", a cheap ability that rerolls all turns on the timeline and shuffles all enemy positions.";
            heavenUnlock.sprite = ResourceLoader.LoadSprite("DelusionalH_item.png");
            heavenUnlock.trigger = TriggerCalls.Count;
            heavenUnlock.consumeTrigger = TriggerCalls.Count;
            heavenUnlock.unlockableID = (UnlockableID)302160;
            heavenUnlock.namePopup = false;
            heavenUnlock.itemPools = ItemPools.Treasure;
            heavenUnlock.shopPrice = 4;
            heavenUnlock.startsLocked = false;
            heavenUnlock.triggerConditions = new EffectorConditionSO[0];
            heavenUnlock.consumeConditions = new EffectorConditionSO[0];
            heavenUnlock.equippedModifiers = new WearableStaticModifierSetterSO[1]
            {
        (WearableStaticModifierSetterSO) instance1
            };
            heavenUnlock.immediate = false;
            heavenUnlock.effects = new Effect[0];
            ExtraPassiveAbility_Wearable_SMS instance2 = ScriptableObject.CreateInstance<ExtraPassiveAbility_Wearable_SMS>();
            instance2._extraPassiveAbility = Passives.Leaky;
            EffectItem osmanUnlock = new EffectItem();
            osmanUnlock.name = "Brain Tumor";
            osmanUnlock.flavorText = "\"You'll be fine, probably, maybe.\"";
            if (UnityEngine.Random.Range(0, 100) < 1)
                osmanUnlock.flavorText = "\"Trolling organ.\"";
            osmanUnlock.description = "This party member has Leaky as a passive. On dealing damage to an enemy, produce 2 additional Pigment of their health color.";
            osmanUnlock.sprite = ResourceLoader.LoadSprite("DelusionalO_item.png");
            osmanUnlock.trigger = TriggerCalls.Count;
            osmanUnlock.consumeTrigger = TriggerCalls.Count;
            osmanUnlock.unlockableID = (UnlockableID)302161;
            osmanUnlock.namePopup = true;
            osmanUnlock.itemPools = ItemPools.Treasure;
            osmanUnlock.shopPrice = 3;
            osmanUnlock.startsLocked = false;
            osmanUnlock.triggerConditions = new EffectorConditionSO[0];
            osmanUnlock.consumeConditions = new EffectorConditionSO[0];
            osmanUnlock.equippedModifiers = new WearableStaticModifierSetterSO[1]
            {
        (WearableStaticModifierSetterSO) instance2
            };
            osmanUnlock.immediate = false;
            osmanUnlock.effects = new Effect[0];
            if (byDefault)
            {
                heavenUnlock.AddItem();
                osmanUnlock.AddItem();
            }
            else
            {
                new FoolBossUnlockSystem.FoolItemPairs((EntityIDs)2233456, "Roger", (Item)heavenUnlock, (Item)osmanUnlock).Add();
                new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement)302160, AchievementUnlockType.TheDivine, "Auto-Shuffler", "Unlocked a new item.", ResourceLoader.LoadSprite("DelusionalH_Panel.png")).Prepare((EntityIDs)2233456, BossType.Heaven);
                new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement)302161, AchievementUnlockType.TheWitness, "Brain Tumor", "Unlocked a new item.", ResourceLoader.LoadSprite("DelusionalO_Panel.png")).Prepare((EntityIDs)2233456, BossType.OsmanSinnoks);
            }
        }

        public static void Blooming(bool byDefault)
        {
            EffectItem heavenUnlock = new EffectItem();
            heavenUnlock.name = "Potted Plant?";
            heavenUnlock.flavorText = "\"I think it's one...\"";
            heavenUnlock.description = "At the start of combat, spawn Venus.";
            heavenUnlock.sprite = ResourceLoader.LoadSprite("BloomingH_item.png");
            heavenUnlock.trigger = TriggerCalls.OnCombatStart;
            heavenUnlock.consumeTrigger = TriggerCalls.Count;
            heavenUnlock.unlockableID = (UnlockableID)302170;
            heavenUnlock.namePopup = true;
            heavenUnlock.itemPools = ItemPools.Shop;
            heavenUnlock.shopPrice = 8;
            heavenUnlock.startsLocked = false;
            heavenUnlock.triggerConditions = new EffectorConditionSO[0];
            heavenUnlock.consumeConditions = new EffectorConditionSO[0];
            heavenUnlock.equippedModifiers = new WearableStaticModifierSetterSO[0];
            heavenUnlock.immediate = false;
            CopyAndSpawnCustomCharacterAnywhereEffect instance = ScriptableObject.CreateInstance<CopyAndSpawnCustomCharacterAnywhereEffect>();
            instance._rank = 0;
            instance._permanentSpawn = true;
            instance._extraModifiers = new WearableStaticModifierSetterSO[0];
            instance._characterCopy = "Venus_CH";
            heavenUnlock.effects = new Effect[1]
            {
        new Effect((EffectSO) instance, 1, new IntentType?(), Slots.Self)
            };
            EffectItem osmanUnlock = new EffectItem();
            osmanUnlock.name = "Lung Spores";
            osmanUnlock.flavorText = "\"Better than nicotine!?\"";
            osmanUnlock.description = "On taking Wrong Pigment or Overflow damage, apply 2 Spores to every enemy.";
            osmanUnlock.sprite = ResourceLoader.LoadSprite("BloomingO_item.png");
            osmanUnlock.trigger = TriggerCalls.OnBeingDamaged;
            osmanUnlock.consumeTrigger = TriggerCalls.Count;
            osmanUnlock.unlockableID = (UnlockableID)302171;
            osmanUnlock.namePopup = true;
            osmanUnlock.itemPools = ItemPools.Treasure;
            osmanUnlock.shopPrice = 6;
            osmanUnlock.startsLocked = false;
            osmanUnlock.triggerConditions = new EffectorConditionSO[1]
            {
        (EffectorConditionSO) ScriptableObject.CreateInstance<ManaDamageCondition>()
            };
            osmanUnlock.consumeConditions = new EffectorConditionSO[0];
            osmanUnlock.equippedModifiers = new WearableStaticModifierSetterSO[0];
            osmanUnlock.immediate = false;
            osmanUnlock.effects = new Effect[1]
            {
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplySporesEffect>(), 2, new IntentType?(), (BaseCombatTargettingSO) EZEffects.TargetSide<Targetting_ByUnit_Side>(false, false))
            };
            if (byDefault)
            {
                heavenUnlock.AddItem();
                osmanUnlock.AddItem();
            }
            else
            {
                new FoolBossUnlockSystem.FoolItemPairs((EntityIDs)202300, "Venus", (Item)heavenUnlock, (Item)osmanUnlock).Add();
                new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement)302170, AchievementUnlockType.TheDivine, "Potted Plant?", "Unlocked a new item.", ResourceLoader.LoadSprite("BloomingH_Panel.png")).Prepare((EntityIDs)202300, BossType.Heaven);
                new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement)302171, AchievementUnlockType.TheWitness, "Lung Spores", "Unlocked a new item.", ResourceLoader.LoadSprite("BloomingO_Panel.png")).Prepare((EntityIDs)202300, BossType.OsmanSinnoks);
            }
        }

        public static void Noise(bool byDefault)
        {
            EffectItem effectItem1 = new EffectItem();
            effectItem1.name = "Mung Coin";
            effectItem1.flavorText = "\"Little fish, big fish, lucky me.\"";
            effectItem1.description = "At the start of combat, produce 1 random Pigment and heal this party member 1 health.";
            effectItem1.sprite = ResourceLoader.LoadSprite("NoiseH_item.png");
            effectItem1.trigger = TriggerCalls.OnCombatStart;
            effectItem1.consumeTrigger = TriggerCalls.Count;
            effectItem1.unlockableID = (UnlockableID)302180;
            effectItem1.namePopup = true;
            effectItem1.itemPools = ItemPools.Fish;
            effectItem1.shopPrice = 1;
            effectItem1.startsLocked = false;
            effectItem1.triggerConditions = new EffectorConditionSO[0];
            effectItem1.consumeConditions = new EffectorConditionSO[0];
            effectItem1.equippedModifiers = new WearableStaticModifierSetterSO[0];
            effectItem1.immediate = false;
            effectItem1.effects = new Effect[2]
            {
        new Effect((EffectSO) ScriptableObject.CreateInstance<GenerateRandomManaIncludingGrayEffect>(), 1, new IntentType?(), Slots.Self),
        new Effect((EffectSO) ScriptableObject.CreateInstance<HealEffect>(), 1, new IntentType?(), Slots.Self)
            };
            EffectItem effectItem2 = new EffectItem();
            effectItem2.name = "Ouroboros Coin";
            effectItem2.flavorText = "\"Tails or Heads or it won't flow\"";
            effectItem2.description = "On using an ability, either refresh this party member or apply 2 Stunned to this party member.";
            effectItem2.sprite = ResourceLoader.LoadSprite("NoiseO_item.png");
            effectItem2.trigger = TriggerCalls.OnAbilityUsed;
            effectItem2.consumeTrigger = TriggerCalls.Count;
            effectItem2.unlockableID = (UnlockableID)302181;
            effectItem2.namePopup = true;
            effectItem2.itemPools = ItemPools.Fish;
            effectItem2.shopPrice = 5;
            effectItem2.startsLocked = false;
            effectItem2.triggerConditions = new EffectorConditionSO[1]
            {
        (EffectorConditionSO) ScriptableObject.CreateInstance<CantAbilityCondition>()
            };
            effectItem2.consumeConditions = new EffectorConditionSO[0];
            effectItem2.equippedModifiers = new WearableStaticModifierSetterSO[0];
            effectItem2.immediate = false;
            effectItem2.effects = new Effect[2]
            {
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyStunnedAlwaysTrueEffect>(), 2, new IntentType?(), Slots.Self, (EffectConditionSO) Conditions.Chance(50)),
        new Effect((EffectSO) ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, new IntentType?(), Slots.Self, (EffectConditionSO) EZEffects.DidThat<PreviousEffectCondition>(false))
            };
            if (byDefault)
            {
                effectItem1.AddItem();
                effectItem2.AddItem();
                FoolBossUnlockSystem.AddToFishPool(FoolBossUnlockSystem.GetItemName((Item)effectItem1), 1);
                FoolBossUnlockSystem.AddToFishPool(FoolBossUnlockSystem.GetItemName((Item)effectItem2), 1);
            }
            else
            {
                new FoolBossUnlockSystem.FoolItemPairs((EntityIDs)864841, "Maru", (Item)effectItem1, (Item)effectItem2, 1, 1).Add();
                new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement)302180, AchievementUnlockType.TheDivine, "Mung Coin", "Unlocked a new item.", ResourceLoader.LoadSprite("NoiseH_Panel.png")).Prepare((EntityIDs)864841, BossType.Heaven);
                new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement)302181, AchievementUnlockType.TheWitness, "Orroboros Coin", "Unlocked a new item.", ResourceLoader.LoadSprite("NoiseO_Panel.png")).Prepare((EntityIDs)864841, BossType.OsmanSinnoks);
            }
        }

        public static void Toast(bool byDefault)
        {
            EffectItem effectItem = new EffectItem();
            effectItem.name = "Unhelpful Item";
            effectItem.flavorText = "\"On combat start, take 2 damage and inflict 2 Ruptured on self.\"";
            effectItem.description = "On combat start, take 2 damage and inflict 2 Ruptured on self.";
            effectItem.sprite = ResourceLoader.LoadSprite("ToastH_item.png");
            effectItem.trigger = TriggerCalls.OnCombatStart;
            effectItem.consumeTrigger = TriggerCalls.Count;
            effectItem.unlockableID = (UnlockableID)302190;
            effectItem.namePopup = true;
            effectItem.itemPools = ItemPools.Fish;
            effectItem.shopPrice = 1;
            effectItem.startsLocked = false;
            effectItem.triggerConditions = new EffectorConditionSO[0];
            effectItem.consumeConditions = new EffectorConditionSO[0];
            effectItem.equippedModifiers = new WearableStaticModifierSetterSO[0];
            effectItem.immediate = false;
            effectItem.effects = new Effect[2]
            {
        new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), 2, new IntentType?(), Slots.Self),
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 2, new IntentType?(), Slots.Self)
            };
            EffectItem osmanUnlock = new EffectItem();
            osmanUnlock.name = "Salt's Egotism";
            osmanUnlock.flavorText = "\"Troll.\"";
            osmanUnlock.description = "On turn start, this character has 'Fun'.";
            osmanUnlock.sprite = ResourceLoader.LoadSprite("SaltItem");
            osmanUnlock.unlockableID = (UnlockableID)422442;
            osmanUnlock.itemPools = ItemPools.Treasure;
            osmanUnlock.namePopup = true;
            osmanUnlock.shopPrice = 0;
            osmanUnlock.effects = new Effect[1]
            {
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyFunEffect>(), 1, new IntentType?(), Slots.Self)
            };
            osmanUnlock.trigger = TriggerCalls.OnTurnStart;
            osmanUnlock.consumeTrigger = TriggerCalls.Count;
            if (byDefault)
            {
                effectItem.AddItem();
                osmanUnlock.AddItem();
                FoolBossUnlockSystem.AddToFishPool(FoolBossUnlockSystem.GetItemName((Item)effectItem), 1);
            }
            else
            {
                new FoolBossUnlockSystem.FoolItemPairs((EntityIDs)676733, nameof(Toast), (Item)effectItem, (Item)osmanUnlock, 1).Add();
                new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement)302190, AchievementUnlockType.TheDivine, "Unhelpful Item", "Unlocked a new item.", ResourceLoader.LoadSprite("ToastH_Panel.png")).Prepare((EntityIDs)676733, BossType.Heaven);
                new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement)302191, AchievementUnlockType.TheWitness, "Salt's Egotism", "Unlocked a new item.", ResourceLoader.LoadSprite("ToastO_Panel.png")).Prepare((EntityIDs)676733, BossType.OsmanSinnoks);
            }
        }

        public static void Abortion(bool byDefault)
        {
            EffectItem heavenUnlock = new EffectItem();
            heavenUnlock.name = "School Shooter";
            heavenUnlock.flavorText = "\"You're projecting.\"";
            heavenUnlock.description = "On killing an enemy, deal 7-11 direct damage to a random enemy.";
            heavenUnlock.sprite = ResourceLoader.LoadSprite("AbortionH_item.png");
            heavenUnlock.trigger = TriggerCalls.OnKill;
            heavenUnlock.consumeTrigger = TriggerCalls.Count;
            heavenUnlock.unlockableID = (UnlockableID)302200;
            heavenUnlock.namePopup = true;
            heavenUnlock.itemPools = ItemPools.Shop;
            heavenUnlock.shopPrice = 10;
            heavenUnlock.startsLocked = false;
            heavenUnlock.triggerConditions = new EffectorConditionSO[0];
            heavenUnlock.consumeConditions = new EffectorConditionSO[0];
            heavenUnlock.equippedModifiers = new WearableStaticModifierSetterSO[0];
            heavenUnlock.immediate = false;
            TargettingRandomUnit instance1 = ScriptableObject.CreateInstance<TargettingRandomUnit>();
            instance1.getAllies = false;
            heavenUnlock.effects = new Effect[1]
            {
        new Effect((EffectSO) ScriptableObject.CreateInstance<SchoolShooterDamageEffect>(), 1, new IntentType?(), (BaseCombatTargettingSO) instance1)
            };
            Ability ability = new Ability();
            ability.name = "Sabotage";
            ability.description = "Double all Status and Field effects on every party member and enemy.";
            ability.cost = new ManaColorSO[3]
            {
        Pigments.Red,
        Pigments.Red,
        Pigments.Red
            };
            ability.visuals = ((AnimationVisualsEffect)((PerformEffectWearable)LoadedAssetsHandler.GetWearable("DemonCore_SW")).effects[0].effect)._visuals;
            ability.animationTarget = Slots.Self;
            ability.effects = new Effect[1];
            ability.effects[0] = new Effect((EffectSO)ScriptableObject.CreateInstance<SabotageEffect>(), 1, new IntentType?(IntentType.Misc), Slots.Self);
            ExtraAbility_Wearable_SMS instance2 = ScriptableObject.CreateInstance<ExtraAbility_Wearable_SMS>();
            instance2._extraAbility = ability.CharacterAbility();
            EffectItem osmanUnlock = new EffectItem();
            osmanUnlock.name = "Polygon Pipe-Bomb";
            osmanUnlock.flavorText = "\"In a videogame, in a videogame.\"";
            osmanUnlock.description = "Gives the extra ability \"Sabotage\", which doubles all Status and Field Effects.";
            osmanUnlock.sprite = ResourceLoader.LoadSprite("AbortionO_item.png");
            osmanUnlock.trigger = TriggerCalls.Count;
            osmanUnlock.consumeTrigger = TriggerCalls.Count;
            osmanUnlock.unlockableID = (UnlockableID)302201;
            osmanUnlock.namePopup = true;
            osmanUnlock.itemPools = ItemPools.Shop;
            osmanUnlock.shopPrice = 5;
            osmanUnlock.startsLocked = false;
            osmanUnlock.triggerConditions = new EffectorConditionSO[0];
            osmanUnlock.consumeConditions = new EffectorConditionSO[0];
            osmanUnlock.equippedModifiers = new WearableStaticModifierSetterSO[1]
            {
        (WearableStaticModifierSetterSO) instance2
            };
            osmanUnlock.immediate = false;
            osmanUnlock.effects = new Effect[0];
            if (byDefault)
            {
                heavenUnlock.AddItem();
                osmanUnlock.AddItem();
            }
            else
            {
                new FoolBossUnlockSystem.FoolItemPairs((EntityIDs)655443, "Infanticide", (Item)heavenUnlock, (Item)osmanUnlock).Add();
                new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement)302200, AchievementUnlockType.TheDivine, "School Shooter", "Unlocked a new item.", ResourceLoader.LoadSprite("AbortionH_Panel.png")).Prepare((EntityIDs)655443, BossType.Heaven);
                new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement)302201, AchievementUnlockType.TheWitness, "Polygon Pipe-Bomb", "Unlocked a new item.", ResourceLoader.LoadSprite("AbortionO_Panel.png")).Prepare((EntityIDs)655443, BossType.OsmanSinnoks);
            }
        }

        public static bool PCall(Action<bool> orig, bool para, string name = null)
        {
            try
            {
                orig(para);
            }
            catch (Exception ex)
            {
                Debug.LogError(name != null ? (object)(name + " failed") : (object)(orig.ToString() + " failed"));
                Debug.LogError((object)(ex.ToString() + ex.Message + ex.StackTrace));
                return false;
            }
            return true;
        }
    }
}
