// Decompiled with JetBrains decompiler
// Type: THE_DEAD._15_TheBlooming
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using BrutalAPI;
using MonoMod.RuntimeDetour;
using System.Reflection;
using UnityEngine;

namespace THE_DEAD
{
    public static class _15_TheBlooming
    {
        public static Character Chara;

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
            PreviousEffectCondition instance7 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            instance7.wasSuccessful = true;
            ScriptableObject.CreateInstance<PreviousEffectCondition>().wasSuccessful = false;
            ScriptableObject.CreateInstance<RemoveStatusEffectEffect>()._statusToRemove = StatusEffectType.Scars;
            ScriptableObject.CreateInstance<RemoveStatusEffectEffect>()._statusToRemove = StatusEffectType.Frail;
            ScriptableObject.CreateInstance<SetCasterExtraSpritesEffect>()._spriteType = (ExtraSpriteType)667;
            CasterStoredValueChangeEffect instance8 = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
            instance8._minimumValue = 0;
            instance8._valueName = (UnitStoredValueNames)456765;
            instance8._increase = true;
            ScriptableObject.CreateInstance<SetCasterExtraSpritesEffect>()._spriteType = (ExtraSpriteType)456654;
            ScriptableObject.CreateInstance<CasterCheckStoredValueAboveCondition>()._valueName = (UnitStoredValueNames)456765;
            ScriptableObject.CreateInstance<RemoveStatusEffectEffect>()._statusToRemove = StatusEffectType.DivineProtection;
            ScriptableObject.CreateInstance<RemoveStatusEffectEffect>()._statusToRemove = StatusEffectType.Cursed;
            ScriptableObject.CreateInstance<RemoveStatusEffectEffect>()._statusToRemove = StatusEffectType.Frail;
            ScriptableObject.CreateInstance<RemoveStatusEffectEffect>()._statusToRemove = StatusEffectType.Ruptured;
            ScriptableObject.CreateInstance<RemoveStatusEffectEffect>()._statusToRemove = StatusEffectType.Linked;
            ScriptableObject.CreateInstance<RemoveStatusEffectEffect>()._statusToRemove = StatusEffectType.Scars;
            ScriptableObject.CreateInstance<HealEffect>().usePreviousExitValue = true;
            ScriptableObject.CreateInstance<RemoveStatusEffectEffect>()._statusToRemove = StatusEffectType.Cursed;
            ScriptableObject.CreateInstance<ChangeMaxHealthEffect>()._increase = false;
            CasterStoredValueSetEffect instance9 = ScriptableObject.CreateInstance<CasterStoredValueSetEffect>();
            instance9._minimumValue = 0;
            instance9._valueName = (UnitStoredValueNames)2233456;
            ScriptableObject.CreateInstance<PreviousEffectCondition>().wasSuccessful = false;
            ScriptableObject.CreateInstance<PreviousEffectCondition>().wasSuccessful = true;
            CheckTwoPassiveAbilityEffect instance10 = ScriptableObject.CreateInstance<CheckTwoPassiveAbilityEffect>();
            instance10._type = PassiveAbilityTypes.Infantile;
            instance10._type1 = PassiveAbilityTypes.Infestation;
            CheckThreePassiveAbilityEffect instance11 = ScriptableObject.CreateInstance<CheckThreePassiveAbilityEffect>();
            instance11._type = PassiveAbilityTypes.Skittish;
            instance11._type1 = PassiveAbilityTypes.Slippery;
            instance11._type2 = PassiveAbilityTypes.Masochism;
            CheckFourPassiveAbilityEffect instance12 = ScriptableObject.CreateInstance<CheckFourPassiveAbilityEffect>();
            instance12._type = PassiveAbilityTypes.Obscure;
            instance12._type1 = PassiveAbilityTypes.Confusion;
            instance12._type2 = PassiveAbilityTypes.Forgetful;
            instance12._type3 = PassiveAbilityTypes.Formless;
            ScriptableObject.CreateInstance<DamageEffect>()._usePreviousExitValue = true;
            PerformEffectPassiveAbility instance13 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            instance13._passiveName = "Health Lock";
            instance13.passiveIcon = ResourceLoader.LoadSprite("VenusMaxHPLock");
            instance13.type = (PassiveAbilityTypes)666668;
            instance13._enemyDescription = "This shouldn't be on an enemy.";
            instance13._characterDescription = "On combat start and any time this character's max health is changed to a value that isn't the normal max health for this level, resets their max health.";
            instance13.doesPassiveTriggerInformationPanel = false;
            instance13.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
            {
        new Effect((EffectSO) ScriptableObject.CreateInstance<ResetMaxHealthEffect>(), 1, new IntentType?(), Slots.Self)
            });
            instance13._triggerOn = new TriggerCalls[2]
            {
        TriggerCalls.OnCombatStart,
        TriggerCalls.OnMaxHealthChanged
            };
            Pigment3xPassiveAbility instance14 = ScriptableObject.CreateInstance<Pigment3xPassiveAbility>();
            instance14._passiveName = "Particular";
            instance14.passiveIcon = ResourceLoader.LoadSprite("VenusParticular");
            instance14.type = (PassiveAbilityTypes)556665;
            instance14._enemyDescription = "Takes 3x pigmetn damage, but is that even possible?";
            instance14._characterDescription = "This character takes 3x pigment damage.";
            instance14.doesPassiveTriggerInformationPanel = false;
            instance14._triggerOn = new TriggerCalls[1]
            {
        TriggerCalls.OnBeingDamaged
            };
            IDetour detour = (IDetour)new Hook((MethodBase)typeof(TooltipTextHandlerSO).GetMethod("ProcessStoredValue", ~BindingFlags.Default), typeof(Joyce).GetMethod("AddStoredValueName202300", ~BindingFlags.Default));
            CasterStoredValueChangeEffect instance15 = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
            instance15._valueName = (UnitStoredValueNames)202300;
            instance15._increase = true;
            CasterSeedBankSpendEffect instance16 = ScriptableObject.CreateInstance<CasterSeedBankSpendEffect>();
            instance16._valueName = (UnitStoredValueNames)202300;
            PerformDoubleEffectPassiveAbility instance17 = ScriptableObject.CreateInstance<PerformDoubleEffectPassiveAbility>();
            instance17._passiveName = "Seed Bank";
            instance17.passiveIcon = ResourceLoader.LoadSprite("VenusSpores");
            instance17.type = (PassiveAbilityTypes)202300;
            instance17._enemyDescription = "This shouldn't be on an enemy.";
            instance17._characterDescription = "This character uses a 'Seed Bank' as an additional cost for some of its abilities.";
            instance17.doesPassiveTriggerInformationPanel = false;
            instance17._secondDoesPerformPopUp = false;
            instance17.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
            {
        new Effect((EffectSO) instance15, 1, new IntentType?(), Slots.Self)
            });
            instance17._triggerOn = new TriggerCalls[1]
            {
        (TriggerCalls) 202301
            };
            instance17.doesPassiveTriggerInformationPanel = false;
            instance17._secondEffects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
            {
        new Effect((EffectSO) instance16, 3, new IntentType?(), Slots.Self)
            });
            instance17._secondTriggerOn = new TriggerCalls[1]
            {
        (TriggerCalls) 202303
            };
            ScriptableObject.CreateInstance<SetCasterExtraSpritesEffect>()._spriteType = (ExtraSpriteType)202303;
            SetCasterExtraSpritesEffect instance18 = ScriptableObject.CreateInstance<SetCasterExtraSpritesEffect>();
            instance18._spriteType = (ExtraSpriteType)202300;
            CasterCheckStoredValueAboveCondition instance19 = ScriptableObject.CreateInstance<CasterCheckStoredValueAboveCondition>();
            instance19._valueName = (UnitStoredValueNames)202302;
            instance19._checkValue = 0;
            CasterStoredValueSetEffect instance20 = ScriptableObject.CreateInstance<CasterStoredValueSetEffect>();
            instance20._valueName = (UnitStoredValueNames)202302;
            PerformDoubleEffectCoinOnExitPassiveAbility instance21 = ScriptableObject.CreateInstance<PerformDoubleEffectCoinOnExitPassiveAbility>();
            instance21._passiveName = "Blooming";
            instance21.passiveIcon = ResourceLoader.LoadSprite("VenusBloomingPassive");
            instance21.type = (PassiveAbilityTypes)200333;
            instance21._enemyDescription = "This shouldn't be on an enemy.";
            instance21._characterDescription = "This character has a 50% chance to die at the start of each turn. If they die, spawn 2 permanent copies of this character. \nProduce 1 coin on death.";
            instance21.doesPassiveTriggerInformationPanel = true;
            PercentageEffectorCondition instance22 = ScriptableObject.CreateInstance<PercentageEffectorCondition>();
            instance22.triggerPercentage = 50;
            instance21.conditions = new EffectorConditionSO[1]
            {
        (EffectorConditionSO) instance22
            };
            CopyAndSpawnCustomCharacterPerLevelPlusOneEffect instance23 = ScriptableObject.CreateInstance<CopyAndSpawnCustomCharacterPerLevelPlusOneEffect>();
            instance23._characterCopy = "Venus_CH";
            instance21.effects = ExtensionMethods.ToEffectInfoArray(new Effect[3]
            {
        new Effect((EffectSO) ScriptableObject.CreateInstance<DirectDeathEffect>(), 1, new IntentType?(), Slots.Self, (EffectConditionSO) instance19),
        new Effect((EffectSO) instance23, 2, new IntentType?(), Slots.Self, (EffectConditionSO) instance19),
        new Effect((EffectSO) ScriptableObject.CreateInstance<AddSeedBankShareSubActionEffect>(), 1, new IntentType?(), Slots.Self, (EffectConditionSO) instance19)
            });
            instance21._triggerOn = new TriggerCalls[1]
            {
        TriggerCalls.OnTurnStart
            };
            instance21.doesPassiveTriggerInformationPanel = true;
            instance21._secondDoesPerformPopUp = false;
            instance21._secondEffects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
            {
        new Effect((EffectSO) instance20, 0, new IntentType?(), Slots.Self)
            });
            instance21._secondTriggerOn = new TriggerCalls[1]
            {
        TriggerCalls.OnTurnFinished
            };
            CustomIntentInfo customIntentInfo1 = new CustomIntentInfo("Budding", (IntentType)738103, ResourceLoader.LoadSprite("VenusBuddingPassive"), IntentType.Misc);
            CustomIntentInfo customIntentInfo2 = new CustomIntentInfo("Blooming", (IntentType)738163, ResourceLoader.LoadSprite("VenusBloomingPassive"), IntentType.Other_Spawn);
            PerformEffectPassiveAbility instance24 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            instance24._passiveName = "Budding";
            instance24.passiveIcon = ResourceLoader.LoadSprite("VenusBuddingPassive");
            instance24.type = (PassiveAbilityTypes)222300;
            instance24._enemyDescription = "I have no idea what this will do";
            instance24._characterDescription = "This character has a 25% chance to Bloom at the start of every turn.";
            PercentageEffectorCondition instance25 = ScriptableObject.CreateInstance<PercentageEffectorCondition>();
            instance25.triggerPercentage = 25;
            instance24.conditions = new EffectorConditionSO[1]
            {
        (EffectorConditionSO) instance25
            };
            AddPassiveEffect instance26 = ScriptableObject.CreateInstance<AddPassiveEffect>();
            instance26._passiveToAdd = (BasePassiveAbilitySO)instance21;
            RemovePassiveEffect instance27 = ScriptableObject.CreateInstance<RemovePassiveEffect>();
            instance27._passiveToRemove = (PassiveAbilityTypes)222300;
            instance24.effects = ExtensionMethods.ToEffectInfoArray(new Effect[4]
            {
        new Effect((EffectSO) instance26, 1, new IntentType?(), Slots.Self),
        new Effect((EffectSO) instance18, 1, new IntentType?(), Slots.Self),
        new Effect((EffectSO) instance20, 10, new IntentType?(), Slots.Self),
        new Effect((EffectSO) instance27, 1, new IntentType?(), Slots.Self)
            });
            instance24._triggerOn = new TriggerCalls[1]
            {
        TriggerCalls.OnTurnStart
            };
            ExtraCCSprites_ArraySO instance28 = ScriptableObject.CreateInstance<ExtraCCSprites_ArraySO>();
            instance28._doesLoop = true;
            instance28._useDefault = (ExtraSpriteType)202303;
            instance28._useSpecial = (ExtraSpriteType)202300;
            instance28._frontSprite = new Sprite[1]
            {
        ResourceLoader.LoadSprite("VenusFrontBloom")
            };
            instance28._backSprite = new Sprite[1]
            {
        ResourceLoader.LoadSprite("VenusBackBloom")
            };
            Character character = new Character()
            {
                name = "Venus",
                healthColor = Pigments.Blue,
                entityID = (EntityIDs)202300,
                overworldSprite = ResourceLoader.LoadSprite("VenusOverworld", pivot: new Vector2?(new Vector2(0.5f, 0.0f))),
                frontSprite = ResourceLoader.LoadSprite("VenusFrontBud"),
                backSprite = ResourceLoader.LoadSprite("VenusBackBud"),
                lockedSprite = ResourceLoader.LoadSprite("VenusLocked"),
                unlockedSprite = ResourceLoader.LoadSprite("VenusMenu"),
                extraSprites = (ExtraCharacterCombatSpritesSO)instance28,
                menuChar = true,
                isSupport = true,
                walksInOverworld = false,
                passives = new BasePassiveAbilitySO[3]
              {
          (BasePassiveAbilitySO) instance24,
          (BasePassiveAbilitySO) instance17,
          Passives.Withering
              },
                hurtSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").damageSound,
                deathSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").deathSound
            };
            character.dialogueSound = character.hurtSound;
            character.levels = new CharacterRankedData[1];
            CheckPassiveAbilityEffect instance29 = ScriptableObject.CreateInstance<CheckPassiveAbilityEffect>();
            instance29._type = (PassiveAbilityTypes)200333;
            CustomPreviousEffectCondition instance30 = ScriptableObject.CreateInstance<CustomPreviousEffectCondition>();
            instance30._valueName = (UnitStoredValueNames)200300;
            instance30._checkValue = 10;
            CasterCheckStoredValueAboveCondition instance31 = ScriptableObject.CreateInstance<CasterCheckStoredValueAboveCondition>();
            instance31._valueName = (UnitStoredValueNames)200300;
            instance31._checkValue = 0;
            CasterStoredValueSetEffect instance32 = ScriptableObject.CreateInstance<CasterStoredValueSetEffect>();
            instance32._valueName = (UnitStoredValueNames)200300;
            Targetting_ByUnit_Side instance33 = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            instance33.getAllies = false;
            instance33.getAllUnitSlots = false;
            BloomIfBuddingEffect instance34 = ScriptableObject.CreateInstance<BloomIfBuddingEffect>();
            instance34._passiveToAdd = (BasePassiveAbilitySO)instance21;
            Effect effect = new Effect((EffectSO)ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, new IntentType?(IntentType.Other_Refresh), Slots.Self);
            Targetting_ByUnit_Side instance35 = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            instance35.getAllies = true;
            TargettingOtherVenus target1 = TargettingOtherVenus.Create(Slots.SlotTarget(new int[8]
            {
        -4,
        -3,
        -2,
        -1,
        1,
        2,
        3,
        4
            }, true));
            TargettingOtherVenus target2 = TargettingOtherVenus.Create((BaseCombatTargettingSO)instance35);
            Ability ability1 = new Ability();
            ability1.name = "Cycle of Life";
            ability1.description = "This move costs 3 Seed Bank. If Budding, Bloom and refresh this character. If Blooming, apply 9-21 spores to all enemies.";
            ability1.cost = new ManaColorSO[0];
            ability1.sprite = ResourceLoader.LoadSprite("VenusCycleOfLife");
            ability1.effects = new Effect[8];
            ability1.effects[0] = new Effect((EffectSO)instance32, 0, new IntentType?(), Slots.Self);
            ability1.effects[1] = new Effect((EffectSO)ScriptableObject.CreateInstance<CasterSeedBankSpendEffect>(), 3, new IntentType?(), Slots.Self);
            ability1.effects[2] = new Effect((EffectSO)ScriptableObject.CreateInstance<SeedBankMinus3Effect>(), 1, new IntentType?(CustomIntentIconSystem.GetIntent("Budding")), (BaseCombatTargettingSO)target1, (EffectConditionSO)instance7);
            ability1.effects[3] = new Effect((EffectSO)instance32, 10, new IntentType?(), Slots.Self, (EffectConditionSO)instance7);
            ability1.effects[4] = new Effect((EffectSO)instance34, 1, new IntentType?(CustomIntentIconSystem.GetIntent("Blooming")), Slots.Self, (EffectConditionSO)instance7);
            ability1.effects[5] = new Effect((EffectSO)instance18, 1, new IntentType?(), Slots.Self, (EffectConditionSO)instance7);
            ability1.effects[6] = effect;
            ability1.effects[6]._condition = (EffectConditionSO)instance7;
            ability1.effects[7] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplySpores7_13Effect>(), 7, new IntentType?((IntentType)987892), (BaseCombatTargettingSO)instance33, (EffectConditionSO)instance30);
            ability1.visuals = LoadedAssetsHandler.GetEnemyAbility("Repent_A").visuals;
            ability1.animationTarget = Slots.Self;
            character.baseAbility = ability1;
            Ability ability2 = new Ability();
            ability2.name = "free seed bank";
            ability2.description = "FREE";
            ability2.cost = new ManaColorSO[0];
            ability2.sprite = ResourceLoader.LoadSprite("VenusCycleOfLife");
            ability2.effects = new Effect[2];
            ability2.effects[0] = new Effect((EffectSO)ScriptableObject.CreateInstance<SeedBankPlus1Effect>(), 1, new IntentType?(), (BaseCombatTargettingSO)target2);
            ability2.effects[1] = effect;
            ability2.visuals = LoadedAssetsHandler.GetEnemyAbility("Repent_A").visuals;
            ability2.animationTarget = Slots.Self;
            character.baseAbility = ability1;
            Ability ability3 = new Ability();
            ability3.name = "Silent Photosynthesis";
            ability3.description = "Heal all other allies half of this character's current health. Increase Seed Bank by 1. If Blooming, refresh this character.";
            ability3.cost = new ManaColorSO[3]
            {
        Pigments.Yellow,
        Pigments.Blue,
        Pigments.Blue
            };
            ability3.sprite = ResourceLoader.LoadSprite("VenusPhotosynthesis");
            ability3.effects = new Effect[4];
            ability3.effects[0] = new Effect((EffectSO)ScriptableObject.CreateInstance<HealCurrentHealthEffect>(), 1, new IntentType?(IntentType.Heal_1_4), Slots.SlotTarget(new int[8]
            {
        -4,
        -3,
        -2,
        -1,
        1,
        2,
        3,
        4
            }, true));
            ability3.effects[1] = new Effect((EffectSO)ScriptableObject.CreateInstance<SeedBankPlus1Effect>(), 1, new IntentType?(CustomIntentIconSystem.GetIntent("Budding")), (BaseCombatTargettingSO)target2);
            ability3.effects[2] = new Effect((EffectSO)instance29, 1, new IntentType?(), Slots.Self);
            ability3.effects[3] = effect;
            ability3.effects[3]._condition = (EffectConditionSO)instance7;
            ability3.visuals = LoadedAssetsHandler.GetEnemyAbility("Dependancy_A").visuals;
            ability3.animationTarget = Slots.Self;
            Ability ability4 = new Ability();
            ability4.name = "Infinite Reforestation";
            ability4.description = "Apply 3-5 Spore to the Opposing enemy. Increase Seed Bank by 1. If Blooming, refresh this character.";
            ability4.cost = new ManaColorSO[2]
            {
        Pigments.Yellow,
        Pigments.Blue
            };
            ability4.sprite = ResourceLoader.LoadSprite("VenusInfinite");
            ability4.effects = new Effect[6];
            ability4.effects[0] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplySporesEffect>(), 3, new IntentType?((IntentType)987892), Slots.Front);
            ability4.effects[1] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplySporesEffect>(), 1, new IntentType?(), Slots.Front, (EffectConditionSO)Conditions.Chance(40));
            ability4.effects[2] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplySporesEffect>(), 1, new IntentType?(), Slots.Front, (EffectConditionSO)Conditions.Chance(40));
            ability4.effects[3] = new Effect((EffectSO)ScriptableObject.CreateInstance<SeedBankPlus1Effect>(), 1, new IntentType?(CustomIntentIconSystem.GetIntent("Budding")), (BaseCombatTargettingSO)target2);
            ability4.effects[4] = new Effect((EffectSO)instance29, 1, new IntentType?(), Slots.Self);
            ability4.effects[5] = effect;
            ability4.effects[5]._condition = (EffectConditionSO)instance7;
            ability4.visuals = LoadedAssetsHandler.GetEnemyAbility("Gunk_A").visuals;
            ability4.animationTarget = Slots.Front;
            ScriptableObject.CreateInstance<HealEffect>().usePreviousExitValue = true;
            Ability ability5 = new Ability();
            ability5.name = "Interstellar Colonization";
            ability5.description = "Gain 1 Seed and heal this party member 1 health. 50% chance to refresh this character. If Blooming, produce another Seed.";
            ability5.cost = new ManaColorSO[1] { Pigments.Blue };
            ability5.sprite = ResourceLoader.LoadSprite("VenusColonization");
            ability5.effects = new Effect[5];
            ability5.effects[0] = new Effect((EffectSO)ScriptableObject.CreateInstance<SeedBankPlus1Effect>(), 1, new IntentType?(CustomIntentIconSystem.GetIntent("Budding")), (BaseCombatTargettingSO)target2);
            ability5.effects[1] = new Effect((EffectSO)ScriptableObject.CreateInstance<HealEffect>(), 1, new IntentType?(IntentType.Heal_1_4), Slots.Self);
            ability5.effects[2] = effect;
            ability5.effects[2]._condition = (EffectConditionSO)Conditions.Chance(50);
            ability5.effects[3] = new Effect((EffectSO)instance29, 1, new IntentType?(), Slots.Self);
            ability5.effects[4] = new Effect((EffectSO)ScriptableObject.CreateInstance<SeedBankPlus1Effect>(), 1, new IntentType?(CustomIntentIconSystem.GetIntent("Budding")), (BaseCombatTargettingSO)target2, (EffectConditionSO)instance7);
            ability5.visuals = LoadedAssetsHandler.GetEnemyAbility("Genesis_A").visuals;
            ability5.animationTarget = Slots.Self;
            character.AddLevel(6, new Ability[3]
            {
        ability3,
        ability4,
        ability5
            }, 0);
            _15_TheBlooming.Chara = character;
            if (!Joyce.IncludeTheBlooming)
                return;
            character.AddCharacter();
        }
    }
}
