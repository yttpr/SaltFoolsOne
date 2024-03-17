// Decompiled with JetBrains decompiler
// Type: THE_DEAD._10_TheMerciful
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using BrutalAPI;
using UnityEngine;

namespace THE_DEAD
{
    public static class _10_TheMerciful
    {
        public static void Add()
        {
            ScriptableObject.CreateInstance<DirectPlusStoredValueEffect>()._valueName = (UnitStoredValueNames)59998;
            CasterStoredValueChangeEffect instance1 = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
            instance1._minimumValue = 0;
            instance1._valueName = (UnitStoredValueNames)59998;
            instance1._increase = true;
            ScriptableObject.CreateInstance<IndirectPlusStoredValueEffect>()._valueName = (UnitStoredValueNames)59997;
            NoiseBothValuesChangeEffect instance2 = ScriptableObject.CreateInstance<NoiseBothValuesChangeEffect>();
            instance2._minimumValue = 0;
            instance2._valueName = (UnitStoredValueNames)59997;
            instance2._increase = true;
            CasterStoredValueChangeEffect instance3 = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
            instance3._minimumValue = 0;
            instance3._valueName = (UnitStoredValueNames)50334;
            instance3._increase = true;
            ScriptableObject.CreateInstance<DirectDeathEffect>()._obliterationDeath = true;
            ScriptableObject.CreateInstance<CasterCheckStoredValueConditionTime45>();
            CasterStoredValueChangeEffect instance4 = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
            instance4._minimumValue = 0;
            instance4._valueName = (UnitStoredValueNames)69696969;
            instance4._increase = true;
            CasterStoredValueChangeEffect instance5 = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
            instance5._minimumValue = 0;
            instance5._valueName = (UnitStoredValueNames)222223333;
            instance5._increase = true;
            CasterStoredValueChangeEffect instance6 = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
            instance6._minimumValue = 0;
            instance6._valueName = (UnitStoredValueNames)222223333;
            instance6._increase = false;
            ScriptableObject.CreateInstance<CasterStoreValueCheckEffect>()._valueName = (UnitStoredValueNames)50334;
            ScriptableObject.CreateInstance<PreviousEffectCondition>().wasSuccessful = true;
            ScriptableObject.CreateInstance<PreviousEffectCondition>().wasSuccessful = false;
            ScriptableObject.CreateInstance<RemoveStatusEffectEffect>()._statusToRemove = StatusEffectType.Scars;
            ScriptableObject.CreateInstance<RemoveStatusEffectEffect>()._statusToRemove = StatusEffectType.Frail;
            ScriptableObject.CreateInstance<SetCasterExtraSpritesEffect>()._spriteType = (ExtraSpriteType)667;
            CasterStoredValueChangeEffect instance7 = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
            instance7._minimumValue = 0;
            instance7._valueName = (UnitStoredValueNames)456765;
            instance7._increase = true;
            ScriptableObject.CreateInstance<SetCasterExtraSpritesEffect>()._spriteType = (ExtraSpriteType)456654;
            ScriptableObject.CreateInstance<CasterCheckStoredValueAboveCondition>()._valueName = (UnitStoredValueNames)456765;
            ScriptableObject.CreateInstance<RemoveStatusEffectEffect>()._statusToRemove = StatusEffectType.DivineProtection;
            ScriptableObject.CreateInstance<RemoveStatusEffectEffect>()._statusToRemove = StatusEffectType.Cursed;
            ScriptableObject.CreateInstance<RemoveStatusEffectEffect>()._statusToRemove = StatusEffectType.Frail;
            ScriptableObject.CreateInstance<RemoveStatusEffectEffect>()._statusToRemove = StatusEffectType.Ruptured;
            ScriptableObject.CreateInstance<RemoveStatusEffectEffect>()._statusToRemove = StatusEffectType.Linked;
            ScriptableObject.CreateInstance<RemoveStatusEffectEffect>()._statusToRemove = StatusEffectType.Scars;
            DeathReferenceDetectionEffectorCondition instance8 = ScriptableObject.CreateInstance<DeathReferenceDetectionEffectorCondition>();
            instance8._witheringDeath = false;
            instance8._useWithering = true;
            PerformEffectPassiveAbility instance9 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            instance9._passiveName = "Decay";
            instance9.passiveIcon = ResourceLoader.LoadSprite("DecayPassiveIcon");
            instance9.type = (PassiveAbilityTypes)87301;
            instance9._enemyDescription = "Upon death this enemy decays into a Goa.";
            instance9._characterDescription = "Upon death this party member decays into Woolf.";
            CopyAndSpawnCustomCharacterAnywhereEffect instance10 = ScriptableObject.CreateInstance<CopyAndSpawnCustomCharacterAnywhereEffect>();
            instance10._characterCopy = "Angel2_CH";
            instance10._rank = 0;
            instance10._permanentSpawn = true;
            instance10._extraModifiers = new WearableStaticModifierSetterSO[0];
            instance9.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
            {
        new Effect((EffectSO) instance10, 1, new IntentType?(), Slots.Self)
            });
            instance9.conditions = new EffectorConditionSO[1]
            {
        (EffectorConditionSO) instance8
            };
            instance9._triggerOn = new TriggerCalls[1]
            {
        TriggerCalls.OnDeath
            };
            PerformEffectPassiveAbility instance11 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            instance11._passiveName = "Decay";
            instance11.passiveIcon = ResourceLoader.LoadSprite("DecayPassiveIcon");
            instance11.type = (PassiveAbilityTypes)87302;
            instance11._enemyDescription = "Upon death this enemy decays into a Goa.";
            instance11._characterDescription = "Upon death this party member decays into Virginia.";
            CopyAndSpawnCustomCharacterAnywhereEffect instance12 = ScriptableObject.CreateInstance<CopyAndSpawnCustomCharacterAnywhereEffect>();
            instance12._characterCopy = "Virginia_CH";
            instance12._rank = 0;
            instance12._permanentSpawn = true;
            instance12._extraModifiers = new WearableStaticModifierSetterSO[0];
            instance11.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
            {
        new Effect((EffectSO) instance12, 1, new IntentType?(), Slots.Self)
            });
            instance11._triggerOn = new TriggerCalls[1]
            {
        TriggerCalls.OnDeath
            };
            instance11.conditions = new EffectorConditionSO[1]
            {
        (EffectorConditionSO) instance8
            };
            Character character1 = new Character();
            character1.name = "Virginia";
            character1.healthColor = Pigments.Purple;
            character1.entityID = (EntityIDs)87303;
            character1.overworldSprite = ResourceLoader.LoadSprite("angeloverworld", pivot: new Vector2?(new Vector2(0.5f, 0.0f)));
            character1.frontSprite = ResourceLoader.LoadSprite("angelfront");
            character1.backSprite = ResourceLoader.LoadSprite("angelback");
            character1.lockedSprite = ResourceLoader.LoadSprite("angellocked");
            character1.unlockedSprite = ResourceLoader.LoadSprite("angelmenu");
            character1.passives = new BasePassiveAbilitySO[2]
            {
        Passives.Withering,
        (BasePassiveAbilitySO) instance9
            };
            character1.menuChar = true;
            character1.isSupport = true;
            character1.walksInOverworld = true;
            character1.hurtSound = LoadedAssetsHandler.GetCharcater("Bimini_CH").damageSound;
            character1.deathSound = LoadedAssetsHandler.GetCharcater("Bimini_CH").deathSound;
            character1.dialogueSound = LoadedAssetsHandler.GetCharcater("Bimini_CH").dxSound;
            Character character2 = new Character();
            character2.name = "Woolf";
            character2.healthColor = Pigments.Purple;
            character2.entityID = (EntityIDs)87302;
            character2.characterID = "Angel2_CH";
            character2.overworldSprite = ResourceLoader.LoadSprite("overworldevil", pivot: new Vector2?(new Vector2(0.5f, 0.0f)));
            character2.frontSprite = ResourceLoader.LoadSprite("frontevil");
            character2.backSprite = ResourceLoader.LoadSprite("backevil");
            character2.lockedSprite = ResourceLoader.LoadSprite("lockedevil");
            character2.unlockedSprite = ResourceLoader.LoadSprite("menuevil");
            character2.passives = new BasePassiveAbilitySO[3]
            {
        Passives.Withering,
        (BasePassiveAbilitySO) instance11,
        Passives.Dying
            };
            character2.menuChar = false;
            character2.isSupport = false;
            character2.walksInOverworld = true;
            character2.appearsInShops = false;
            character2.hurtSound = LoadedAssetsHandler.GetEnemy("SkinningHomunculus_EN").damageSound;
            character2.deathSound = LoadedAssetsHandler.GetEnemy("SkinningHomunculus_EN").deathSound;
            Ability ability1 = new Ability();
            ability1.name = "Perfunctory Bonding";
            ability1.description = "Apply 2 Linked to all party members. Heal the left ally 1 health and the right ally 2 health.";
            ability1.cost = new ManaColorSO[2]
            {
        Pigments.Purple,
        Pigments.Blue
            };
            ability1.sprite = ResourceLoader.LoadSprite("battleIcon bonding");
            ability1.effects = new Effect[3];
            ability1.effects[0] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyLinkedEffect>(), 2, new IntentType?(IntentType.Status_Linked), Slots.SlotTarget(new int[9]
            {
        -4,
        -3,
        -2,
        -1,
        0,
        1,
        2,
        3,
        4
            }, true));
            ability1.effects[1] = new Effect((EffectSO)ScriptableObject.CreateInstance<HealEffect>(), 1, new IntentType?(IntentType.Heal_1_4), Slots.SlotTarget(new int[1]
            {
        -1
            }, true));
            ability1.effects[2] = new Effect((EffectSO)ScriptableObject.CreateInstance<HealEffect>(), 2, new IntentType?(IntentType.Heal_1_4), Slots.SlotTarget(new int[1]
            {
        1
            }, true));
            ability1.visuals = LoadedAssetsHandler.GetEnemy("ManicMan_EN").abilities[0].ability.visuals;
            ability1.animationTarget = Slots.SlotTarget(new int[9]
            {
        -4,
        -3,
        -2,
        -1,
        0,
        1,
        2,
        3,
        4
            }, true);
            Ability ability2 = new Ability();
            ability2.name = "Unwilling Confession";
            ability2.description = "Apply 2 Frail to the opposing enemy and 3 Frail to self. Deal 2 damage to the opposing enemy.";
            ability2.cost = new ManaColorSO[2]
            {
        Pigments.Red,
        Pigments.Blue
            };
            ability2.sprite = ResourceLoader.LoadSprite("battleIcon confession");
            ability2.effects = new Effect[3];
            ability2.effects[0] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyFrailEffect>(), 2, new IntentType?(IntentType.Status_Frail), Slots.Front);
            ability2.effects[1] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyFrailEffect>(), 3, new IntentType?(IntentType.Status_Frail), Slots.Self);
            ability2.effects[2] = new Effect((EffectSO)ScriptableObject.CreateInstance<DamageEffect>(), 2, new IntentType?(IntentType.Damage_1_2), Slots.Front);
            ability2.visuals = LoadedAssetsHandler.GetEnemy("ChoirBoy_EN").abilities[2].ability.visuals;
            ability2.animationTarget = Slots.Front;
            Ability ability3 = new Ability();
            ability3.name = "Cautiously Empower";
            ability3.description = "Apply 2 Divine Protection and 5 Shield to self.";
            ability3.cost = new ManaColorSO[2]
            {
        Pigments.Yellow,
        Pigments.Blue
            };
            ability3.sprite = ResourceLoader.LoadSprite("battleIcon empower");
            ability3.effects = new Effect[2];
            ability3.effects[0] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyDivineProtectionEffect>(), 2, new IntentType?(IntentType.Status_DivineProtection), Slots.Self);
            ability3.effects[1] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 5, new IntentType?(IntentType.Field_Shield), Slots.Self);
            ability3.visuals = LoadedAssetsHandler.GetCharcater("Griffin_CH").rankedData[0].rankAbilities[0].ability.visuals;
            ability3.animationTarget = Slots.Self;
            Ability ability4 = new Ability();
            ability4.name = "Perfunctory Bonding";
            ability4.description = "Apply 1 Linked to all enemies and 1 Linked to self. Deal 6 damage to self. 10% chance to refresh this party member's ability use.";
            ability4.cost = new ManaColorSO[3]
            {
        Pigments.Yellow,
        Pigments.Purple,
        Pigments.Blue
            };
            ability4.sprite = ResourceLoader.LoadSprite("battleIcon bonding");
            ability4.effects = new Effect[4];
            ability4.effects[0] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyLinkedEffect>(), 1, new IntentType?(IntentType.Status_Linked), Slots.SlotTarget(new int[9]
            {
        -4,
        -3,
        -2,
        -1,
        0,
        1,
        2,
        3,
        4
            }));
            ability4.effects[1] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyLinkedEffect>(), 1, new IntentType?(IntentType.Status_Linked), Slots.Self);
            ability4.effects[2] = new Effect((EffectSO)ScriptableObject.CreateInstance<DamageEffect>(), 6, new IntentType?(IntentType.Damage_3_6), Slots.Self);
            ability4.effects[3] = new Effect((EffectSO)ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, new IntentType?(IntentType.Other_Refresh), Slots.Self, (EffectConditionSO)Conditions.Chance(10));
            ability4.visuals = LoadedAssetsHandler.GetCharcater("Kleiver_CH").rankedData[0].rankAbilities[0].ability.visuals;
            ability4.animationTarget = Slots.SlotTarget(new int[9]
            {
        -4,
        -3,
        -2,
        -1,
        0,
        1,
        2,
        3,
        4
            });
            Ability ability5 = new Ability();
            ability5.name = "Half-Hearted Confession";
            ability5.description = "Apply 1 Scar to the opposing enemy and 1 Scar to self. Deal 5 damage to the opposing enemy.";
            ability5.cost = new ManaColorSO[3]
            {
        Pigments.Red,
        Pigments.Blue,
        Pigments.Purple
            };
            ability5.sprite = ResourceLoader.LoadSprite("battleIcon confession");
            ability5.effects = new Effect[3];
            ability5.effects[0] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyScarsEffect>(), 1, new IntentType?(IntentType.Status_Scars), Slots.Front);
            ability5.effects[1] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyScarsEffect>(), 1, new IntentType?(IntentType.Status_Scars), Slots.Self);
            ability5.effects[2] = new Effect((EffectSO)ScriptableObject.CreateInstance<DamageEffect>(), 5, new IntentType?(IntentType.Damage_3_6), Slots.Front);
            ability5.visuals = LoadedAssetsHandler.GetEnemy("HeavensGateRed_BOSS").abilities[1].ability.visuals;
            ability5.animationTarget = Slots.Front;
            Ability ability6 = new Ability();
            ability6.name = "Cautiously Empower";
            ability6.description = "Apply 1 Divine Protection and 1 Frail to the opposing enemy. Apply 1 Scar and 1 Frail to self. Deal 6 damage to the opposing enemy.";
            ability6.cost = new ManaColorSO[3]
            {
        Pigments.Yellow,
        Pigments.Red,
        Pigments.Purple
            };
            ability6.sprite = ResourceLoader.LoadSprite("battleIcon empower");
            ability6.effects = new Effect[6];
            ability6.effects[0] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyDivineProtectionEffect>(), 1, new IntentType?(IntentType.Status_DivineProtection), Slots.Front);
            ability6.effects[1] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyFrailEffect>(), 1, new IntentType?(IntentType.Status_Frail), Slots.Front);
            ability6.effects[2] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyScarsEffect>(), 1, new IntentType?(IntentType.Status_Scars), Slots.Self);
            ability6.effects[3] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyFrailEffect>(), 1, new IntentType?(IntentType.Status_Frail), Slots.Self);
            ability6.effects[4] = new Effect((EffectSO)ScriptableObject.CreateInstance<DamageEffect>(), 6, new IntentType?(IntentType.Damage_3_6), Slots.Front);
            ability6.effects[5] = new Effect((EffectSO)ScriptableObject.CreateInstance<DamageEffect>(), 6, new IntentType?(), Slots.Front, (EffectConditionSO)Conditions.Chance(0));
            ability6.visuals = LoadedAssetsHandler.GetEnemy("Psaltery_EN").abilities[0].ability.visuals;
            ability6.animationTarget = Slots.Front;
            Ability ability7 = ability1.Duplicate();
            ability7.name = "Weak Bonding";
            ability7.description = "Apply 2 Linked to all party members. Heal the left and right allies 2 health.";
            ability7.effects[1]._entryVariable = 2;
            Ability ability8 = ability2.Duplicate();
            ability8.name = "Willing Confession";
            ability8.description = "Apply 2 Frail to the opposing enemy and 3 Frail to self. Deal 3 damage.";
            ability8.effects[2]._entryVariable = 3;
            ability8.effects[2]._intent = new IntentType?(IntentType.Damage_3_6);
            Ability ability9 = ability3.Duplicate();
            ability9.name = "Carefully Empower";
            ability9.description = "Apply 2 Divine Protection to self and 6 Shield to self.";
            ability9.effects[1]._entryVariable = 6;
            Ability ability10 = ability4.Duplicate();
            ability10.name = "Simple Bonding";
            ability10.description = "Apply 1 Linked to all enemies and 1 Linked to self. Deal 7 damage to the opposing enemy. 20% chance to refresh this party member's ability usage.";
            ability10.effects[2]._entryVariable = 7;
            ability10.effects[2]._intent = new IntentType?(IntentType.Damage_7_10);
            ability10.effects[3]._condition = (EffectConditionSO)Conditions.Chance(20);
            Ability ability11 = ability5.Duplicate();
            ability11.name = "Forceful Confession";
            ability11.description = "Apply 2 Scars to the opposing enemy and 1 Scar to self. Deal 6 damage.";
            ability11.effects[0]._entryVariable = 2;
            ability11.effects[2]._entryVariable = 6;
            Ability ability12 = ability6.Duplicate();
            ability12.name = "Pridefully Empower";
            ability12.description = "Apply 1 Divine Protection and 1 Frail to the opposing enemy. Apply 1 Frail and 1 Scar to self. Deal 8 damage twice.";
            ability12.effects[4]._entryVariable = 8;
            ability12.effects[4]._intent = new IntentType?(IntentType.Damage_7_10);
            ability12.effects[5] = new Effect((EffectSO)ScriptableObject.CreateInstance<DamageEffect>(), 8, new IntentType?(IntentType.Damage_7_10), Slots.Front);
            Ability ability13 = ability7.Duplicate();
            ability13.name = "Simple Bonding";
            ability13.description = "Apply 2 Linked to all party members. Heal the left ally 3 health and the right ally 2 health.";
            ability13.effects[1]._entryVariable = 3;
            Ability ability14 = ability8.Duplicate();
            ability14.name = "Honest Confession";
            ability14.description = "Apply 3 Frail to the opposing enemy and 2 Frail to self. Deal 5 damage.";
            ability14.effects[0]._entryVariable = 3;
            ability14.effects[1]._entryVariable = 2;
            ability14.effects[2]._entryVariable = 5;
            Ability ability15 = ability9.Duplicate();
            ability15.name = "Gently Empower";
            ability15.description = "Apply 2 Divine Protection to self and 6 Shield to self.";
            ability15.cost = new ManaColorSO[2]
            {
        Pigments.SplitPigment(Pigments.Yellow, Pigments.Blue),
        Pigments.Blue
            };
            ability15.effects[1]._entryVariable = 6;
            Ability ability16 = ability10.Duplicate();
            ability16.name = "Cruel Bonding";
            ability16.description = "Apply 1 Linked to all enemies and 1 Linked to self. Deal 9 damage to the opposing enemy. 30% chance to refresh this party member's ability usage.";
            ability16.effects[2]._entryVariable = 9;
            ability16.effects[2]._intent = new IntentType?(IntentType.Damage_7_10);
            ability16.effects[3]._condition = (EffectConditionSO)Conditions.Chance(30);
            Ability ability17 = ability11.Duplicate();
            ability17.name = "Torturous Confession";
            ability17.description = "Apply 3 Scar to the opposing enemy and 1 Scar to self. Deal 7 damage.";
            ability17.effects[0]._entryVariable = 3;
            ability17.effects[2]._entryVariable = 7;
            ability17.effects[2]._intent = new IntentType?(IntentType.Damage_7_10);
            Ability ability18 = ability12.Duplicate();
            ability18.name = "Ambitiously Empower";
            ability18.description = "Apply 1 Divine Protection and 2 Frail to the opposing enemy. Apply 1 Frail and 1 Scar to self. Deal 8 damage twice.";
            ability18.effects[1]._entryVariable = 2;
            Ability ability19 = ability13.Duplicate();
            ability19.name = "Careful Bonding";
            ability19.description = "Apply 2 Linked to all party members. Heal the left and right allies 3 health.";
            ability19.effects[2]._entryVariable = 3;
            Ability ability20 = ability14.Duplicate();
            ability20.name = "Total Confession";
            ability20.description = "Apply 3 Frail to the opposing enemy and 2 Frail to self. Deal 8 damage.";
            ability20.effects[0]._entryVariable = 4;
            ability20.effects[2]._entryVariable = 8;
            ability20.effects[2]._intent = new IntentType?(IntentType.Damage_7_10);
            Ability ability21 = ability15.Duplicate();
            ability21.name = "Lovingly Empower";
            ability21.description = "Apply 2 Divine Protection to self and 7 Shield to self.";
            ability21.effects[1]._entryVariable = 7;
            Ability ability22 = ability16.Duplicate();
            ability22.name = "Toxic Bonding";
            ability22.description = "Apply 1 Linked to all enemies and 1 Linked to self. Deal 11 damage to the opposing enemy. 35% chance to refresh this party member's ability usage.";
            ability22.effects[2]._entryVariable = 11;
            ability22.effects[2]._intent = new IntentType?(IntentType.Damage_11_15);
            ability22.effects[3]._condition = (EffectConditionSO)Conditions.Chance(35);
            Ability ability23 = ability17.Duplicate();
            ability23.name = "Traitorous Confession";
            ability23.description = "Apply 4 Scar to the opposing enemy and 1 Scar to self. Deal 8 damage.";
            ability23.effects[0]._entryVariable = 4;
            ability23.effects[2]._entryVariable = 8;
            Ability ability24 = ability18.Duplicate();
            ability24.name = "Deservingly Empower";
            ability24.description = "Apply 1 Divine Protection and 2 Frail to the opposing enemy. Apply 1 Frail and 1 Scar to self. Deal 13 damage twice.";
            ability24.effects[4]._entryVariable = 13;
            ability24.effects[5]._entryVariable = 13;
            ability24.effects[4]._intent = new IntentType?(IntentType.Damage_11_15);
            ability24.effects[5]._intent = new IntentType?(IntentType.Damage_11_15);
            character1.AddLevel(11, new Ability[3]
            {
        ability1,
        ability2,
        ability3
            }, 0);
            character1.AddLevel(13, new Ability[3]
            {
        ability7,
        ability8,
        ability9
            }, 1);
            character1.AddLevel(15, new Ability[3]
            {
        ability13,
        ability14,
        ability15
            }, 2);
            character1.AddLevel(16, new Ability[3]
            {
        ability19,
        ability20,
        ability21
            }, 3);
            character2.AddLevel(12, new Ability[3]
            {
        ability4,
        ability5,
        ability6
            }, 0);
            character2.AddLevel(15, new Ability[3]
            {
        ability10,
        ability11,
        ability12
            }, 1);
            character2.AddLevel(18, new Ability[3]
            {
        ability16,
        ability17,
        ability18
            }, 2);
            character2.AddLevel(22, new Ability[3]
            {
        ability22,
        ability23,
        ability24
            }, 3);
            if (!Joyce.IncludeTheMerciful)
                return;
            character1.AddCharacter();
            character2.AddCharacter();
        }
    }
}
