// Decompiled with JetBrains decompiler
// Type: THE_DEAD._06_TheLost
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using BrutalAPI;
using UnityEngine;

namespace THE_DEAD
{
    public static class _06_TheLost
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
            ScriptableObject.CreateInstance<PreviousEffectCondition>().wasSuccessful = true;
            ScriptableObject.CreateInstance<PreviousEffectCondition>().wasSuccessful = false;
            ScriptableObject.CreateInstance<RemoveStatusEffectEffect>()._statusToRemove = StatusEffectType.Scars;
            ScriptableObject.CreateInstance<RemoveStatusEffectEffect>()._statusToRemove = StatusEffectType.Frail;
            ExtraCCSprites_ArraySO instance7 = ScriptableObject.CreateInstance<ExtraCCSprites_ArraySO>();
            instance7._useDefault = ExtraSpriteType.None;
            instance7._doesLoop = false;
            instance7._useSpecial = (ExtraSpriteType)667;
            instance7._frontSprite = new Sprite[6]
            {
        ResourceLoader.LoadSprite("WItchFront1"),
        ResourceLoader.LoadSprite("WitchFront2"),
        ResourceLoader.LoadSprite("WitchFront3"),
        ResourceLoader.LoadSprite("WitchFront4"),
        ResourceLoader.LoadSprite("WitchFront5"),
        ResourceLoader.LoadSprite("WitchFront6")
            };
            instance7._backSprite = new Sprite[6]
            {
        ResourceLoader.LoadSprite("WitchBack1"),
        ResourceLoader.LoadSprite("WitchBack2"),
        ResourceLoader.LoadSprite("WitchBack3"),
        ResourceLoader.LoadSprite("WitchBack4"),
        ResourceLoader.LoadSprite("WitchBack5"),
        ResourceLoader.LoadSprite("WitchBack6")
            };
            SetCasterExtraSpritesEffect instance8 = ScriptableObject.CreateInstance<SetCasterExtraSpritesEffect>();
            instance8._spriteType = (ExtraSpriteType)667;
            PerformEffectImmediatePassiveAbility instance9 = ScriptableObject.CreateInstance<PerformEffectImmediatePassiveAbility>();
            instance9._passiveName = "Comfort Toy";
            instance9.passiveIcon = ResourceLoader.LoadSprite("WitchPassiveImages");
            instance9.type = (PassiveAbilityTypes)666777;
            instance9._enemyDescription = "";
            instance9._characterDescription = "This character is a little lonelier than most.";
            instance9.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
            {
        new Effect((EffectSO) instance8, 1, new IntentType?(), Slots.Self)
            });
            instance9._triggerOn = new TriggerCalls[1]
            {
        TriggerCalls.CanDie
            };
            PerformDoubleEffectPassiveAbilityImmediate instance10 = ScriptableObject.CreateInstance<PerformDoubleEffectPassiveAbilityImmediate>();
            instance10._passiveName = "Desperate";
            instance10.passiveIcon = ResourceLoader.LoadSprite("WitchPassiveDetermination");
            instance10.type = (PassiveAbilityTypes)666555;
            instance10._enemyDescription = "uhhh";
            instance10._characterDescription = "On taking any damage, 20% chance to apply 2 Determined to self.";
            PercentageEffectorCondition instance11 = ScriptableObject.CreateInstance<PercentageEffectorCondition>();
            instance11.triggerPercentage = 20;
            instance10.conditions = new EffectorConditionSO[1]
            {
        (EffectorConditionSO) instance11
            };
            instance10.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
            {
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyDeterminedEffect>(), 2, new IntentType?(), Slots.Self)
            });
            instance10._triggerOn = new TriggerCalls[1]
            {
        TriggerCalls.OnDamaged
            };
            instance10._secondEffects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
            {
        new Effect((EffectSO) instance8, 1, new IntentType?(), Slots.Self)
            });
            instance10._secondTriggerOn = new TriggerCalls[1]
            {
        TriggerCalls.CanDie
            };
            Character character = new Character();
            character.name = "Kafka";
            character.healthColor = Pigments.Purple;
            character.entityID = (EntityIDs)66677765;
            character.overworldSprite = ResourceLoader.LoadSprite("WitchOverworld", pivot: new Vector2?(new Vector2(0.5f, 0.0f)));
            character.frontSprite = ResourceLoader.LoadSprite("WitchFront0");
            character.backSprite = ResourceLoader.LoadSprite("WitchBack0");
            character.lockedSprite = ResourceLoader.LoadSprite("WitchLocked");
            character.unlockedSprite = ResourceLoader.LoadSprite("WitchMenu");
            character.extraSprites = (ExtraCharacterCombatSpritesSO)instance7;
            character.menuChar = true;
            character.isSupport = false;
            character.walksInOverworld = true;
            character.hurtSound = LoadedAssetsHandler.GetCharcater("Hans_CH").damageSound;
            character.deathSound = LoadedAssetsHandler.GetCharcater("Hans_CH").deathSound;
            character.dialogueSound = LoadedAssetsHandler.GetCharcater("Hans_CH").dxSound;
            character.passives = new BasePassiveAbilitySO[1]
            {
        (BasePassiveAbilitySO) instance10
            };
            Ability ability1 = new Ability();
            ability1.name = "Test Ability";
            ability1.description = "Curse, Gloom 10, 10 damage.";
            ability1.cost = new ManaColorSO[0];
            ability1.sprite = ResourceLoader.LoadSprite("ParanoidUnSlap");
            ability1.effects = new Effect[4];
            ability1.effects[0] = new Effect((EffectSO)ScriptableObject.CreateInstance<ExitValueSetterEffect>(), 1, new IntentType?(), Slots.Front);
            ability1.effects[1] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyGloomEffect>(), 10, new IntentType?(IntentType.Misc), Slots.Front);
            ability1.effects[2] = new Effect((EffectSO)ScriptableObject.CreateInstance<DamageEffect>(), 10, new IntentType?(IntentType.Damage_7_10), Slots.Front);
            ability1.effects[3] = new Effect((EffectSO)ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, new IntentType?(IntentType.Other_Refresh), Slots.Self);
            ability1.visuals = LoadedAssetsHandler.GetEnemyAbility("UglyOnTheInside_A").visuals;
            ability1.animationTarget = Slots.Front;
            Ability ability2 = new Ability();
            ability2.name = "Test Ability 2";
            ability2.description = "3 determined self, kill.";
            ability2.cost = new ManaColorSO[0];
            ability2.sprite = ResourceLoader.LoadSprite("ParanoidUnSlap");
            ability2.effects = new Effect[3];
            ability2.effects[0] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyDeterminedEffect>(), 3, new IntentType?(IntentType.Misc), Slots.Self);
            ability2.effects[1] = new Effect((EffectSO)ScriptableObject.CreateInstance<DamageEffect>(), 100, new IntentType?(IntentType.Damage_Death), Slots.Self);
            ability2.effects[2] = new Effect((EffectSO)ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, new IntentType?(IntentType.Other_Refresh), Slots.Self);
            ability2.visuals = LoadedAssetsHandler.GetEnemyAbility("UglyOnTheInside_A").visuals;
            ability2.animationTarget = Slots.Self;
            Ability ability3 = new Ability();
            ability3.name = "Test Ability 2";
            ability3.description = "indirect front.";
            ability3.cost = new ManaColorSO[0];
            ability3.sprite = ResourceLoader.LoadSprite("ParanoidUnSlap");
            ability3.effects = new Effect[2];
            ability3.effects[0] = new Effect((EffectSO)ScriptableObject.CreateInstance<DamageEffect>(), 1, new IntentType?(IntentType.Misc), Slots.Front);
            ((DamageEffect)ability3.effects[0]._effect)._indirect = true;
            ability3.effects[1] = new Effect((EffectSO)ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, new IntentType?(IntentType.Misc), Slots.Self);
            ability3.visuals = LoadedAssetsHandler.GetEnemyAbility("UglyOnTheInside_A").visuals;
            ability3.animationTarget = Slots.Front;
            Ability ability4 = new Ability();
            ability4.name = "Mild Envy";
            ability4.description = "Inflict 1 Gloom and deal 6 damage to the Opposing enemy.";
            ability4.cost = new ManaColorSO[3]
            {
        Pigments.Blue,
        Pigments.Red,
        Pigments.Red
            };
            ability4.sprite = ResourceLoader.LoadSprite("WitchEnvy");
            ability4.effects = new Effect[2];
            ability4.effects[0] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyGloomEffect>(), 1, new IntentType?((IntentType)987897), Slots.Front);
            ability4.effects[1] = new Effect((EffectSO)ScriptableObject.CreateInstance<DamageEffect>(), 6, new IntentType?(IntentType.Damage_3_6), Slots.Front);
            ability4.visuals = LoadedAssetsHandler.GetEnemyAbility("Weep_A").visuals;
            ability4.animationTarget = Slots.Front;
            Ability ability5 = ability4.Duplicate();
            ability5.name = "Festering Envy";
            ability5.description = "Inflict 3 Gloom and deal 8 damage to the Opposing enemy.";
            ability5.effects[0]._entryVariable = 3;
            ability5.effects[1]._intent = new IntentType?(IntentType.Damage_7_10);
            ability5.effects[1]._entryVariable = 8;
            Ability ability6 = ability5.Duplicate();
            ability6.name = "Furious Envy";
            ability6.description = "Inflict 5 Gloom and deal 10 damage to the Opposing enemy.";
            ability6.effects[0]._entryVariable = 5;
            ability6.effects[1]._entryVariable = 10;
            Ability ability7 = ability6.Duplicate();
            ability7.name = "Maddening Envy";
            ability7.description = "Inflict 6 Gloom and deal 12 damage to the Opposing enemy.";
            ability7.effects[0]._entryVariable = 6;
            ability7.effects[1]._intent = new IntentType?(IntentType.Damage_11_15);
            ability7.effects[1]._entryVariable = 12;
            Ability ability8 = new Ability();
            ability8.name = "Leaking Depression";
            ability8.description = "Inflict 15 Gloom, 2 Determined, and deal 6 dry shield-piercing damage to the left and right enemies.";
            ability8.cost = new ManaColorSO[3]
            {
        Pigments.Blue,
        Pigments.Blue,
        Pigments.Red
            };
            ability8.sprite = ResourceLoader.LoadSprite("WitchDepression");
            ability8.effects = new Effect[3];
            ability8.effects[0] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyGloomEffect>(), 15, new IntentType?((IntentType)987897), Slots.LeftRight);
            ability8.effects[1] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyDeterminedEffect>(), 2, new IntentType?((IntentType)987896), Slots.LeftRight);
            ability8.effects[2] = new Effect((EffectSO)ScriptableObject.CreateInstance<DryDirectDamagePierceEffect>(), 4, new IntentType?(IntentType.Damage_3_6), Slots.LeftRight);
            ability8.visuals = LoadedAssetsHandler.GetEnemyAbility("Weep_A").visuals;
            ability8.animationTarget = Slots.Self;
            Ability ability9 = ability8.Duplicate();
            ability9.name = "Flowing Depression";
            ability9.description = "Inflict 25 Gloom, 2 Determined, and deal 6 dry shield-piercing damage to the left and right enemies.";
            ability9.cost = new ManaColorSO[2]
            {
        Pigments.Blue,
        Pigments.Red
            };
            ability9.effects[0]._entryVariable = 25;
            Ability ability10 = ability9.Duplicate();
            ability10.name = "Streaming Depression";
            ability10.description = "Inflict 40 Gloom, 2 Determined, and deal 7 dry shield-piercing damage to the left, right, and opposing enemies.";
            ability10.cost = new ManaColorSO[2]
            {
        Pigments.Blue,
        Pigments.SplitPigment(Pigments.Blue, Pigments.Red)
            };
            ability10.effects[2]._entryVariable = 7;
            ability10.effects[0]._target = Slots.FrontLeftRight;
            ability10.effects[2]._target = Slots.FrontLeftRight;
            ability10.effects[1]._target = Slots.FrontLeftRight;
            ability10.effects[0]._entryVariable = 40;
            Ability ability11 = ability10.Duplicate();
            ability11.name = "Down-Pouring Depression";
            ability11.description = "Apply 50 Gloom, 2 Determined, and deal 9 dry shield-piercing damage to the left, right, and opposing enemies.";
            ability11.cost = new ManaColorSO[2]
            {
        Pigments.SplitPigment(Pigments.Blue, Pigments.Red),
        Pigments.SplitPigment(Pigments.Blue, Pigments.Red)
            };
            ability11.effects[2]._entryVariable = 9;
            ability11.effects[0]._entryVariable = 50;
            Ability ability12 = new Ability();
            ability12.name = "Minuscule Hope";
            ability12.description = "Apply 2 Gloom and 1 Determined to self. Heal the Left ally 7 health and apply 2 Determined.";
            ability12.cost = new ManaColorSO[3]
            {
        Pigments.Blue,
        Pigments.Purple,
        Pigments.Yellow
            };
            ability12.sprite = ResourceLoader.LoadSprite("WitchHope");
            ability12.effects = new Effect[4];
            ability12.effects[0] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyGloomEffect>(), 2, new IntentType?((IntentType)987897), Slots.Self);
            ability12.effects[1] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyDeterminedEffect>(), 2, new IntentType?((IntentType)987896), Slots.SlotTarget(new int[1]
            {
        -1
            }, true));
            ability12.effects[2] = new Effect((EffectSO)ScriptableObject.CreateInstance<HealEffect>(), 7, new IntentType?(IntentType.Heal_5_10), Slots.SlotTarget(new int[1]
            {
        -1
            }, true));
            ability12.effects[3] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyDeterminedEffect>(), 1, new IntentType?((IntentType)987896), Slots.Self);
            ability12.visuals = LoadedAssetsHandler.GetCharacterAbility("Showdown_1_A").visuals;
            ability12.animationTarget = Slots.Self;
            Ability ability13 = ability12.Duplicate();
            ability13.name = "Tiny Hope";
            ability13.description = "Apply 2 Gloom and 1 Determined to self. Heal the Left ally 9 health and apply 3 Determined.";
            ability13.effects[1]._entryVariable = 3;
            ability13.effects[2]._entryVariable = 9;
            Ability ability14 = ability13.Duplicate();
            ability14.name = "Small Hope";
            ability14.description = "Apply 2 Gloom and 1 Determined to self. Heal the Left ally 12 health and apply 4 Determined.";
            ability14.cost = new ManaColorSO[2]
            {
        Pigments.Blue,
        Pigments.Purple
            };
            ability14.effects[1]._entryVariable = 4;
            ability14.effects[2]._entryVariable = 12;
            ability14.effects[2]._intent = new IntentType?(IntentType.Heal_11_20);
            Ability ability15 = ability14.Duplicate();
            ability15.name = "Lesser Hope";
            ability15.description = "Apply 2 Gloom and 1 Determined to self. Heal the Left ally 15 health and apply 5 Determined.";
            ability15.effects[1]._entryVariable = 5;
            ability15.effects[2]._entryVariable = 15;
            character.AddLevel(8, new Ability[3]
            {
        ability4,
        ability8,
        ability12
            }, 0);
            character.AddLevel(11, new Ability[3]
            {
        ability5,
        ability9,
        ability13
            }, 1);
            character.AddLevel(13, new Ability[3]
            {
        ability6,
        ability10,
        ability14
            }, 2);
            character.AddLevel(14, new Ability[3]
            {
        ability7,
        ability11,
        ability15
            }, 3);
            _06_TheLost.Chara = character;
            if (!Joyce.IncludeTheLost)
                return;
            character.AddCharacter();
        }
    }
}
