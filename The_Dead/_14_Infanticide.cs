// Decompiled with JetBrains decompiler
// Type: THE_DEAD._14_Infanticide
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using BrutalAPI;
using UnityEngine;

namespace THE_DEAD
{
    public static class _14_Infanticide
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
            ScriptableObject.CreateInstance<RemoveStatusEffectEffect>()._statusToRemove = StatusEffectType.DivineProtection;
            ScriptableObject.CreateInstance<RemoveStatusEffectEffect>()._statusToRemove = StatusEffectType.Cursed;
            ScriptableObject.CreateInstance<RemoveStatusEffectEffect>()._statusToRemove = StatusEffectType.Frail;
            ScriptableObject.CreateInstance<RemoveStatusEffectEffect>()._statusToRemove = StatusEffectType.Ruptured;
            ScriptableObject.CreateInstance<RemoveStatusEffectEffect>()._statusToRemove = StatusEffectType.Linked;
            ScriptableObject.CreateInstance<RemoveStatusEffectEffect>()._statusToRemove = StatusEffectType.Scars;
            ScriptableObject.CreateInstance<HealEffect>().usePreviousExitValue = true;
            ScriptableObject.CreateInstance<RemoveStatusEffectEffect>()._statusToRemove = StatusEffectType.Cursed;
            ScriptableObject.CreateInstance<ChangeMaxHealthEffect>()._increase = false;
            CasterStoredValueSetEffect instance8 = ScriptableObject.CreateInstance<CasterStoredValueSetEffect>();
            instance8._minimumValue = 0;
            instance8._valueName = (UnitStoredValueNames)2233456;
            PreviousEffectCondition instance9 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            instance9.wasSuccessful = false;
            PreviousEffectCondition instance10 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            instance10.wasSuccessful = true;
            Character character = new Character();
            character.name = "Violence";
            character.healthColor = Pigments.Purple;
            character.entityID = (EntityIDs)655443;
            character.overworldSprite = ResourceLoader.LoadSprite("Cat Grill Overworld", pivot: new Vector2?(new Vector2(0.5f, 0.0f)));
            character.frontSprite = ResourceLoader.LoadSprite("Cat Grill Front");
            character.backSprite = ResourceLoader.LoadSprite("Cat Grill Back");
            character.lockedSprite = ResourceLoader.LoadSprite("Cat Grill Locked");
            character.unlockedSprite = ResourceLoader.LoadSprite("Cat Grill Unlocked");
            character.menuChar = true;
            character.isSupport = false;
            character.walksInOverworld = true;
            character.passives = new BasePassiveAbilitySO[1]
            {
        LoadedAssetsHandler.GetCharcater("Nowak_CH").passiveAbilities[0]
            };
            character.passives[0] = Object.Instantiate<BasePassiveAbilitySO>(character.passives[0]);
            character.passives[0]._characterDescription = "Upon killing an enemy, Violence becomes focused.";
            character.hurtSound = LoadedAssetsHandler.GetCharcater("Bimini_CH").damageSound;
            character.deathSound = LoadedAssetsHandler.GetCharcater("Bimini_CH").deathSound;
            character.dialogueSound = LoadedAssetsHandler.GetCharcater("Bimini_CH").dxSound;
            ExtraCCSprites_BasicSO instance11 = ScriptableObject.CreateInstance<ExtraCCSprites_BasicSO>();
            instance11._frontSprite = ResourceLoader.LoadSprite("Cat Grill Focus");
            instance11._backSprite = ResourceLoader.LoadSprite("Cat Grill Back");
            instance11._useDefault = ExtraSpriteType.Unfocused;
            instance11._useSpecial = ExtraSpriteType.Focused;
            character.extraSprites = (ExtraCharacterCombatSpritesSO)instance11;
            CheckTwoPassiveAbilityEffect instance12 = ScriptableObject.CreateInstance<CheckTwoPassiveAbilityEffect>();
            instance12._type = PassiveAbilityTypes.Infantile;
            instance12._type1 = PassiveAbilityTypes.Infestation;
            CheckThreePassiveAbilityEffect instance13 = ScriptableObject.CreateInstance<CheckThreePassiveAbilityEffect>();
            instance13._type = PassiveAbilityTypes.Skittish;
            instance13._type1 = PassiveAbilityTypes.Slippery;
            instance13._type2 = PassiveAbilityTypes.Masochism;
            CheckFourPassiveAbilityEffect instance14 = ScriptableObject.CreateInstance<CheckFourPassiveAbilityEffect>();
            instance14._type = PassiveAbilityTypes.Obscure;
            instance14._type1 = PassiveAbilityTypes.Confusion;
            instance14._type2 = PassiveAbilityTypes.Forgetful;
            instance14._type3 = PassiveAbilityTypes.Formless;
            DamageEffect instance15 = ScriptableObject.CreateInstance<DamageEffect>();
            instance15._usePreviousExitValue = true;
            Ability ability1 = new Ability();
            ability1.name = "Infant Beater";
            ability1.description = "Deal 8 damage to the opposing enemy. Deal 2x damage if the opposing enemy has Infestation and 10x damage if they have Infantile.";
            ability1.cost = new ManaColorSO[2]
            {
        Pigments.Red,
        Pigments.Red
            };
            ability1.sprite = ResourceLoader.LoadSprite("Kill Babies");
            ability1.effects = new Effect[4];
            ability1.effects[0] = new Effect((EffectSO)instance12, 1, new IntentType?(), Slots.Front);
            ability1.effects[1] = new Effect((EffectSO)instance15, 8, new IntentType?(), Slots.Front, (EffectConditionSO)instance10);
            ability1.effects[2] = new Effect((EffectSO)instance12, 1, new IntentType?(), Slots.Front);
            ability1.effects[3] = new Effect((EffectSO)ScriptableObject.CreateInstance<DamageEffect>(), 8, new IntentType?(IntentType.Damage_7_10), Slots.Front, (EffectConditionSO)instance9);
            ability1.visuals = LoadedAssetsHandler.GetCharcater("Burnout_CH").rankedData[0].rankAbilities[0].ability.visuals;
            ability1.animationTarget = Slots.Front;
            Ability ability2 = ability1.Duplicate();
            ability2.name = "Infant Killer";
            ability2.description = "Deal 10 damage to the opposing enemy. Deal 2x damage if the opposing enemy has Infestation and 10x damage if they have Infantile.";
            ability2.effects[1]._entryVariable = 10;
            ability2.effects[3]._entryVariable = 10;
            Ability ability3 = ability2.Duplicate();
            ability3.name = "Infant Hunter";
            ability3.description = "Deal 13 damage to the opposing enemy. Deal 2x damage if the opposing enemy has Infestation and 10x damage if they have Infantile.";
            ability3.effects[1]._entryVariable = 13;
            ability3.effects[3]._entryVariable = 13;
            ability3.effects[3]._intent = new IntentType?(IntentType.Damage_11_15);
            Ability ability4 = ability3.Duplicate();
            ability4.name = "Infant Genocider";
            ability4.description = "Deal 15 damage to the opposing enemy. Deal 2x damage if the opposing enemy has Infestation and 10x damage if they have Infantile.";
            ability4.effects[1]._entryVariable = 15;
            ability4.effects[3]._entryVariable = 15;
            Ability ability5 = new Ability();
            ability5.name = "Prevent Fun";
            ability5.description = "Deal 6 damage to the opposing enemy. If the opposing enemy has Skittish, Slippery, or Masochism, apply 2 Ruptured.";
            ability5.cost = new ManaColorSO[2]
            {
        Pigments.Blue,
        Pigments.Red
            };
            ability5.sprite = ResourceLoader.LoadSprite("NO FUN");
            ability5.effects = new Effect[4];
            ability5.effects[0] = new Effect((EffectSO)ScriptableObject.CreateInstance<DamageEffect>(), 6, new IntentType?(IntentType.Damage_3_6), Slots.Front);
            ability5.effects[1] = new Effect((EffectSO)instance13, 1, new IntentType?(), Slots.Front);
            ability5.effects[2] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 2, new IntentType?(IntentType.Status_Ruptured), Slots.Front, (EffectConditionSO)instance10);
            ability5.effects[3] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyScarsEffect>(), 0, new IntentType?(), Slots.Front, (EffectConditionSO)Conditions.Chance(0));
            ability5.visuals = LoadedAssetsHandler.GetEnemy("Voboola_EN").abilities[0].ability.visuals;
            ability5.animationTarget = Slots.Front;
            Ability ability6 = ability5.Duplicate();
            ability6.name = "Cease Fun";
            ability6.description = "Deal 8 damage to the opposing enemy. If the opposing enemy has Skittish, Slippery, or Masochism, apply 4 Ruptured and 1 Scar.";
            ability6.effects[0]._entryVariable = 8;
            ability6.effects[0]._intent = new IntentType?(IntentType.Damage_7_10);
            ability6.effects[2]._entryVariable = 4;
            ability6.effects[3]._entryVariable = 1;
            ability6.effects[3]._intent = new IntentType?(IntentType.Status_Scars);
            ability6.effects[3]._condition = (EffectConditionSO)instance10;
            Ability ability7 = ability6.Duplicate();
            ability7.name = "End Fun";
            ability7.description = "Deal 10 damage to the opposing enemy. If the opposing enemy has Skittish, Slippery, or Masochism, apply 6 Ruptured and 1 Scar.";
            ability7.effects[0]._entryVariable = 10;
            ability7.effects[2]._entryVariable = 6;
            ability7.effects[3]._entryVariable = 1;
            Ability ability8 = ability7.Duplicate();
            ability8.name = "Destroy Fun";
            ability8.description = "Deal 12 damage to the opposing enemy. If the opposing enemy has Skittish, Slippery, or Masochism, apply 8 Ruptured and 2 Scars.";
            ability8.effects[0]._entryVariable = 12;
            ability8.effects[0]._intent = new IntentType?(IntentType.Damage_11_15);
            ability8.effects[2]._entryVariable = 8;
            ability8.effects[3]._entryVariable = 2;
            Ability ability9 = new Ability();
            ability9.name = "Shut Up";
            ability9.description = "1% chance to instantly kill the opposing enemy. Deal 6 damage to the opposing enemy. If the opposing enemy has Forgetful, Confusion, Formless, or Obscured, apply 1 Frail.";
            ability9.cost = new ManaColorSO[2]
            {
        Pigments.Yellow,
        Pigments.Red
            };
            ability9.sprite = ResourceLoader.LoadSprite("SHUT UP");
            ability9.effects = new Effect[5];
            ability9.effects[0] = new Effect((EffectSO)ScriptableObject.CreateInstance<DirectDeathEffect>(), 1, new IntentType?(), Slots.Front, (EffectConditionSO)Conditions.Chance(2));
            ability9.effects[1] = new Effect((EffectSO)ScriptableObject.CreateInstance<DamageEffect>(), 6, new IntentType?(IntentType.Damage_3_6), Slots.Front);
            ability9.effects[2] = new Effect((EffectSO)instance14, 1, new IntentType?(), Slots.Front);
            ability9.effects[3] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyFrailEffect>(), 1, new IntentType?(IntentType.Status_Frail), Slots.Front, (EffectConditionSO)instance10);
            ability9.effects[4] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyCursedEffect>(), 1, new IntentType?(), Slots.Front, (EffectConditionSO)Conditions.Chance(0));
            ability9.visuals = LoadedAssetsHandler.GetCharcater("Anton_CH").rankedData[0].rankAbilities[2].ability.visuals;
            ability9.animationTarget = Slots.Front;
            Ability ability10 = ability9.Duplicate();
            ability10.name = "Shut the Hell Up";
            ability10.description = "1% chance to instantly kill the opposing enemy. Deal 8 damage to the opposing enemy. If the opposing enemy has Forgetful, Confusion, Formless, or Obscured, apply Cursed and 1 Frail.";
            ability10.effects[1]._entryVariable = 8;
            ability10.effects[1]._intent = new IntentType?(IntentType.Damage_7_10);
            ability10.effects[4]._intent = new IntentType?(IntentType.Status_Cursed);
            ability10.effects[4]._condition = (EffectConditionSO)instance10;
            Ability ability11 = ability10.Duplicate();
            ability11.name = "Shut the Fuck Up";
            ability11.description = "1% chance to instantly kill the opposing enemy. Deal 10 damage to the opposing enemy. If the opposing enemy has Forgetful, Confusion, Formless, or Obscured, apply Cursed and 2 Frail.";
            ability11.effects[1]._entryVariable = 10;
            ability11.effects[3]._entryVariable = 2;
            Ability ability12 = ability11.Duplicate();
            ability12.name = "SHUT THE FUCK UP";
            ability12.description = "1% chance to instantly kill the opposing enemy. Deal 12 damage to the opposing enemy. If the opposing enemy has Forgetful, Confusion, Formless, or Obscured, apply Cursed and 2 Frail.";
            ability12.effects[1]._entryVariable = 12;
            ability12.effects[1]._intent = new IntentType?(IntentType.Damage_11_15);
            character.AddLevel(7, new Ability[3]
            {
        ability1,
        ability5,
        ability9
            }, 0);
            character.AddLevel(9, new Ability[3]
            {
        ability2,
        ability6,
        ability10
            }, 1);
            character.AddLevel(10, new Ability[3]
            {
        ability3,
        ability7,
        ability11
            }, 2);
            character.AddLevel(11, new Ability[3]
            {
        ability4,
        ability8,
        ability12
            }, 3);
            _14_Infanticide.Chara = character;
            if (!Joyce.IncludeTheAbortion)
                return;
            character.AddCharacter();
        }
    }
}
