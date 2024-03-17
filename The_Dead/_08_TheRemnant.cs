// Decompiled with JetBrains decompiler
// Type: THE_DEAD._08_TheRemnant
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using BrutalAPI;
using UnityEngine;

namespace THE_DEAD
{
    public static class _08_TheRemnant
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
            ScriptableObject.CreateInstance<SetCasterExtraSpritesEffect>()._spriteType = (ExtraSpriteType)667;
            CasterStoredValueChangeEffect instance7 = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
            instance7._minimumValue = 0;
            instance7._valueName = (UnitStoredValueNames)456765;
            instance7._increase = true;
            ScriptableObject.CreateInstance<SetCasterExtraSpritesEffect>()._spriteType = (ExtraSpriteType)456654;
            ScriptableObject.CreateInstance<CasterCheckStoredValueAboveCondition>()._valueName = (UnitStoredValueNames)456765;
            PerformEffectPassiveAbility instance8 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            instance8._passiveName = "Purple Essence";
            instance8.passiveIcon = ResourceLoader.LoadSprite("Purple Essence");
            instance8.type = PassiveAbilityTypes.Essence;
            instance8._enemyDescription = "This shouldn't be on an enemy.";
            instance8._characterDescription = "Allows lucky pigment to be toggled to Purble.";
            instance8.doesPassiveTriggerInformationPanel = false;
            LuckyBlueColorSetEffect instance9 = ScriptableObject.CreateInstance<LuckyBlueColorSetEffect>();
            instance9._luckyColor = Pigments.Purple;
            instance8.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
            {
        new Effect((EffectSO) instance9, 1, new IntentType?(), Slots.Self)
            });
            instance8._triggerOn = new TriggerCalls[1]
            {
        TriggerCalls.OnCombatStart
            };
            Character character = new Character();
            character.passives = new BasePassiveAbilitySO[2]
            {
        Passives.Withering,
        (BasePassiveAbilitySO) instance8
            };
            character.name = "Faith";
            character.healthColor = Pigments.Purple;
            character.entityID = (EntityIDs)86484;
            character.overworldSprite = ResourceLoader.LoadSprite("FAITHoverworld", pivot: new Vector2?(new Vector2(0.5f, 0.0f)));
            character.frontSprite = ResourceLoader.LoadSprite("FAITHfront");
            character.backSprite = ResourceLoader.LoadSprite("FAITHback");
            character.lockedSprite = ResourceLoader.LoadSprite("FAITHlocked");
            character.unlockedSprite = ResourceLoader.LoadSprite("FAITHmenu");
            character.menuChar = true;
            character.isSupport = false;
            character.walksInOverworld = true;
            character.hurtSound = LoadedAssetsHandler.GetEnemy("SkinningHomunculus_EN").damageSound;
            character.deathSound = LoadedAssetsHandler.GetEnemy("SkinningHomunculus_EN").deathSound;
            character.dialogueSound = LoadedAssetsHandler.GetEnemy("SkinningHomunculus_EN").damageSound;
            Ability ability1 = new Ability();
            ability1.name = "Patience";
            ability1.description = "Produce 1 purple pigment, 95% chance to produce an additional one. 5% chance to refresh this party member's ability usage.";
            ability1.cost = new ManaColorSO[1] { Pigments.Gray };
            ability1.sprite = ResourceLoader.LoadSprite("Patience Prayer");
            ability1.effects = new Effect[3];
            ability1.effects[0] = new Effect((EffectSO)ScriptableObject.CreateInstance<GenerateColorManaEffect>(), 1, new IntentType?(IntentType.Mana_Generate), Slots.Self);
            ((GenerateColorManaEffect)ability1.effects[0]._effect).mana = Pigments.Purple;
            ability1.effects[1] = new Effect((EffectSO)ScriptableObject.CreateInstance<GenerateColorManaEffect>(), 1, new IntentType?(), Slots.Self, (EffectConditionSO)Conditions.Chance(95));
            ((GenerateColorManaEffect)ability1.effects[1]._effect).mana = Pigments.Purple;
            ability1.effects[2] = new Effect((EffectSO)ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, new IntentType?(IntentType.Other_Refresh), Slots.Self, (EffectConditionSO)Conditions.Chance(10));
            ability1.visuals = LoadedAssetsHandler.GetEnemy("Mung_EN").abilities[1].ability.visuals;
            ability1.animationTarget = Slots.Self;
            character.baseAbility = ability1;
            Ability ability2 = new Ability();
            ability2.name = "Pain the Soul";
            ability2.description = "Apply 1 frail and deal 4 damage to the opposing enemy.";
            ability2.cost = new ManaColorSO[2]
            {
        Pigments.Purple,
        Pigments.Purple
            };
            ability2.sprite = ResourceLoader.LoadSprite("Hit the Soul");
            ability2.effects = new Effect[2];
            ability2.effects[0] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyFrailEffect>(), 1, new IntentType?(IntentType.Status_Frail), Slots.Front);
            ability2.effects[1] = new Effect((EffectSO)ScriptableObject.CreateInstance<DamageEffect>(), 4, new IntentType?(IntentType.Damage_3_6), Slots.Front);
            ability2.visuals = LoadedAssetsHandler.GetEnemy("ChoirBoy_EN").abilities[2].ability.visuals;
            ability2.animationTarget = Slots.Front;
            Ability ability3 = new Ability();
            ability3.name = "Shock the Mind";
            ability3.description = "Deal 5 damage to the left and right enemies.";
            ability3.cost = new ManaColorSO[3]
            {
        Pigments.Red,
        Pigments.Purple,
        Pigments.Purple
            };
            ability3.sprite = ResourceLoader.LoadSprite("Hit the Mind");
            ability3.effects = new Effect[1];
            ability3.effects[0] = new Effect((EffectSO)ScriptableObject.CreateInstance<DamageEffect>(), 5, new IntentType?(IntentType.Damage_3_6), Slots.LeftRight);
            ability3.visuals = LoadedAssetsHandler.GetEnemy("HeavensGateRed_BOSS").abilities[1].ability.visuals;
            ability3.animationTarget = Slots.LeftRight;
            Ability ability4 = new Ability();
            ability4.name = "Fester the Body";
            ability4.description = "Apply 1 scar and deal 7 damage to the opposing enemy.";
            ability4.cost = new ManaColorSO[3]
            {
        Pigments.Blue,
        Pigments.Purple,
        Pigments.Purple
            };
            ability4.sprite = ResourceLoader.LoadSprite("Hit the Body");
            ability4.effects = new Effect[2];
            ability4.effects[0] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyScarsEffect>(), 1, new IntentType?(IntentType.Status_Scars), Slots.Front);
            ability4.effects[1] = new Effect((EffectSO)ScriptableObject.CreateInstance<DamageEffect>(), 7, new IntentType?(IntentType.Damage_7_10), Slots.Front);
            ability4.visuals = LoadedAssetsHandler.GetEnemy("Charcarrion_Alive_BOSS").abilities[2].ability.visuals;
            ability4.animationTarget = Slots.Front;
            Ability ability5 = ability2.Duplicate();
            ability5.name = "Assault the Soul";
            ability5.description = "Apply 1 frail and deal 5 damage to the opposing enemy.";
            ability5.effects[0]._entryVariable = 2;
            ability5.effects[1]._entryVariable = 5;
            Ability ability6 = ability3.Duplicate();
            ability6.cost = new ManaColorSO[3]
            {
        Pigments.SplitPigment(Pigments.Red, Pigments.Purple),
        Pigments.Purple,
        Pigments.Purple
            };
            ability6.name = "Assault the Minds";
            ability6.description = "Deal 8 damage to the left and right enemies.";
            ability6.effects[0]._entryVariable = 8;
            ability6.effects[0]._intent = new IntentType?(IntentType.Damage_7_10);
            Ability ability7 = ability4.Duplicate();
            ability7.name = "Rot the Body";
            ability7.description = "Apply 1-2 scars and deal 8 damage to the opposing enemy.";
            ability7.effects[0] = new Effect((EffectSO)ScriptableObject.CreateInstance<ScarsInRangeFromOneEffect>(), 1, new IntentType?(IntentType.Status_Scars), Slots.Front);
            ability7.effects[1]._entryVariable = 8;
            Ability ability8 = ability5.Duplicate();
            ability8.name = "Tear the Soul";
            ability8.description = "Apply 2 frail and deal 6 damage to the opposing enemy.";
            ability8.effects[0]._entryVariable = 2;
            ability8.effects[1]._entryVariable = 6;
            ability8.cost = new ManaColorSO[2]
            {
        Pigments.Purple,
        Pigments.SplitPigment(Pigments.Purple, Pigments.Red)
            };
            Ability ability9 = ability6.Duplicate();
            ability9.name = "Panic the Minds";
            ability9.description = "Deal 10 damage to the left and right enemies.";
            ability9.effects[0]._entryVariable = 10;
            Ability ability10 = ability7.Duplicate();
            ability10.name = "Decompose the Body";
            ability10.description = "Apply 2 scars and deal 9 damage to the opposing enemy.";
            ability10.effects[0] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyScarsEffect>(), 2, new IntentType?(IntentType.Status_Scars), Slots.Front);
            ability10.effects[1]._entryVariable = 9;
            ability10.effects[1]._intent = new IntentType?(IntentType.Damage_7_10);
            ability10.cost = new ManaColorSO[2]
            {
        Pigments.Blue,
        Pigments.Purple
            };
            Ability ability11 = ability8.Duplicate();
            ability11.name = "Destroy the Soul";
            ability11.description = "Apply 3 frail and deal 7 damage to the opposing enemy.";
            ability11.effects[0]._entryVariable = 3;
            ability11.effects[1]._entryVariable = 7;
            ability11.effects[1]._intent = new IntentType?(IntentType.Damage_7_10);
            Ability ability12 = ability9.Duplicate();
            ability12.name = "Terrorize the Minds";
            ability12.description = "Deal 10 damage to the left, opposing, and right enemies.";
            ability12.cost = new ManaColorSO[3]
            {
        Pigments.SplitPigment(Pigments.Red, Pigments.Purple),
        Pigments.SplitPigment(Pigments.Red, Pigments.Purple),
        Pigments.Purple
            };
            ability12.effects[0]._target = Slots.FrontLeftRight;
            ability12.animationTarget = Slots.FrontLeftRight;
            ability12.effects[0]._entryVariable = 12;
            ability12.cost = new ManaColorSO[3]
            {
        Pigments.Red,
        Pigments.Purple,
        Pigments.SplitPigment(Pigments.Purple, Pigments.Yellow)
            };
            Ability ability13 = ability10.Duplicate();
            ability13.name = "Disintegrate the Body";
            ability13.description = "Apply 2-3 scars and deal 10 damage to the opposing enemy.";
            ability13.effects[0] = new Effect((EffectSO)ScriptableObject.CreateInstance<ScarsInRangeFromTwoEffect>(), 1, new IntentType?(IntentType.Status_Scars), Slots.Front);
            ability13.effects[1]._entryVariable = 10;
            ability13.cost = new ManaColorSO[2]
            {
        Pigments.SplitPigment(Pigments.Blue, Pigments.Purple),
        Pigments.Purple
            };
            character.AddLevel(12, new Ability[3]
            {
        ability2,
        ability3,
        ability4
            }, 0);
            character.AddLevel(16, new Ability[3]
            {
        ability5,
        ability6,
        ability7
            }, 1);
            character.AddLevel(20, new Ability[3]
            {
        ability8,
        ability9,
        ability10
            }, 2);
            character.AddLevel(24, new Ability[3]
            {
        ability11,
        ability12,
        ability13
            }, 3);
            _08_TheRemnant.Chara = character;
            if (!Joyce.IncludeTheRemnant)
                return;
            character.AddCharacter();
        }
    }
}
