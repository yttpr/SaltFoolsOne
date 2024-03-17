// Decompiled with JetBrains decompiler
// Type: THE_DEAD._09_TheToasted
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using BrutalAPI;
using UnityEngine;

namespace THE_DEAD
{
    public static class _09_TheToasted
    {
        public static Character AAAAAAAAAA;

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
            Character character = new Character();
            character.name = "TOAST";
            character.healthColor = Pigments.Red;
            character.entityID = (EntityIDs)676733;
            character.frontSprite = ResourceLoader.LoadSprite("TOAST Front");
            character.backSprite = ResourceLoader.LoadSprite("TOAST Back");
            character.overworldSprite = ResourceLoader.LoadSprite("TOAST Overworld", pivot: new Vector2?(new Vector2(0.5f, 0.0f)));
            character.lockedSprite = ResourceLoader.LoadSprite("TOAST Locked");
            character.unlockedSprite = ResourceLoader.LoadSprite("TOAST Unlocked");
            character.menuChar = true;
            character.isSupport = true;
            character.walksInOverworld = false;
            character.usesAllAbilities = true;
            character.usesBaseAbility = false;
            character.passives = new BasePassiveAbilitySO[1]
            {
        Passives.Dying
            };
            character.hurtSound = LoadedAssetsHandler.GetEnemy("Psaltery_EN").damageSound;
            character.deathSound = LoadedAssetsHandler.GetEnemy("Psaltery_EN").deathSound;
            character.dialogueSound = LoadedAssetsHandler.GetEnemy("Psaltery_EN").damageSound;
            Ability ability1 = new Ability();
            ability1.name = "Safety Hazard";
            ability1.description = "Apply 1-3 Fire to the entire enemy grid. Remove Divine Protection and deal 1 indirect damage to this character.";
            ability1.sprite = ResourceLoader.LoadSprite("TOAST Hazard");
            ability1.cost = new ManaColorSO[1] { Pigments.Red };
            ability1.effects = new Effect[7];
            ability1.effects[0] = new Effect((EffectSO)ScriptableObject.CreateInstance<FireUpToPlusTwoEffect>(), 1, new IntentType?(IntentType.Field_Fire), Slots.SlotTarget(new int[9]
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
            ability1.effects[1] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyFrailEffect>(), 0, new IntentType?(), Slots.SlotTarget(new int[9]
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
            }), (EffectConditionSO)Conditions.Chance(0));
            ability1.effects[2] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 0, new IntentType?(), Slots.SlotTarget(new int[9]
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
            }), (EffectConditionSO)Conditions.Chance(0));
            ability1.effects[3] = new Effect((EffectSO)ScriptableObject.CreateInstance<ExitValueSetterEffect>(), 0, new IntentType?(), Slots.Self);
            ability1.effects[4] = new Effect((EffectSO)ScriptableObject.CreateInstance<RandomDamageBetweenPreviousAndEntryEffect>(), 0, new IntentType?(), Slots.Front, (EffectConditionSO)Conditions.Chance(0));
            ((RandomDamageBetweenPreviousAndEntryEffect)ability1.effects[4]._effect)._indirect = true;
            RemoveStatusEffectEffect instance8 = ScriptableObject.CreateInstance<RemoveStatusEffectEffect>();
            instance8._statusToRemove = StatusEffectType.DivineProtection;
            ability1.effects[5] = new Effect((EffectSO)instance8, 1, new IntentType?(), Slots.Self);
            ability1.effects[6] = new Effect((EffectSO)ScriptableObject.CreateInstance<DamageEffect>(), 1, new IntentType?(IntentType.Damage_1_2), Slots.Self);
            ((DamageEffect)ability1.effects[6]._effect)._indirect = true;
            ability1.visuals = LoadedAssetsHandler.GetCharacterAbility("Torch_1_A").visuals;
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
            });
            Ability ability2 = ability1.Duplicate();
            ability2.name = "Fire Hazard";
            ability2.description = "Apply 2-4 Fire to the entire enemy grid. Remove Divine Protection and deal 1 indirect damage to this character.";
            ability2.effects[0]._entryVariable = 2;
            Ability ability3 = ability2.Duplicate();
            ability3.name = "Electrical Hazard";
            ability3.description = "Apply 2-4 Fire to the entire enemy grid. Apply 1 Frail and 1 Ruptured to all enemies. Remove Divine Protection and deal 1 indirect damage to this character.";
            ability3.effects[1]._entryVariable = 1;
            ability3.effects[1]._condition = (EffectConditionSO)Conditions.Chance(100);
            ability3.effects[1]._intent = new IntentType?(IntentType.Status_Frail);
            ability3.effects[2]._entryVariable = 1;
            ability3.effects[2]._condition = (EffectConditionSO)Conditions.Chance(100);
            ability3.effects[2]._intent = new IntentType?(IntentType.Status_Ruptured);
            Ability ability4 = ability3.Duplicate();
            ability4.name = "Suicide Hazard";
            ability4.description = "Apply 2-4 Fire to the entire enemy grid. Apply 1 Frail and 2 Ruptured to all enemies. Deal 50-70 indirect damage to the opposing enemy. Remove Divine Protection and deal 1 indirect damage to this character.";
            ability4.effects[2]._entryVariable = 2;
            ability4.effects[3]._entryVariable = 50;
            ability4.effects[4]._entryVariable = 70;
            ability4.effects[4]._intent = new IntentType?(IntentType.Damage_Death);
            ability4.effects[4]._condition = (EffectConditionSO)Conditions.Chance(100);
            Ability ability5 = new Ability();
            ability5.name = "Plain Snack";
            ability5.description = "Fully heal all party members. Remove Divine Protection and deal 1 indirect damage to this character.";
            ability5.sprite = ResourceLoader.LoadSprite("TOAST Snack");
            ability5.cost = new ManaColorSO[2]
            {
        Pigments.Red,
        Pigments.Blue
            };
            ability5.effects = new Effect[9];
            RemoveStatusEffectEffect instance9 = ScriptableObject.CreateInstance<RemoveStatusEffectEffect>();
            instance9._statusToRemove = StatusEffectType.Cursed;
            ability5.effects[0] = new Effect((EffectSO)instance9, 1, new IntentType?(), Slots.SlotTarget(new int[9]
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
            }, true), (EffectConditionSO)Conditions.Chance(0));
            RemoveStatusEffectEffect instance10 = ScriptableObject.CreateInstance<RemoveStatusEffectEffect>();
            instance10._statusToRemove = StatusEffectType.Frail;
            ability5.effects[1] = new Effect((EffectSO)instance10, 1, new IntentType?(), Slots.SlotTarget(new int[9]
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
            }, true), (EffectConditionSO)Conditions.Chance(0));
            RemoveStatusEffectEffect instance11 = ScriptableObject.CreateInstance<RemoveStatusEffectEffect>();
            instance11._statusToRemove = StatusEffectType.Ruptured;
            ability5.effects[2] = new Effect((EffectSO)instance11, 1, new IntentType?(), Slots.SlotTarget(new int[9]
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
            }, true), (EffectConditionSO)Conditions.Chance(0));
            RemoveStatusEffectEffect instance12 = ScriptableObject.CreateInstance<RemoveStatusEffectEffect>();
            instance12._statusToRemove = StatusEffectType.Linked;
            ability5.effects[3] = new Effect((EffectSO)instance12, 1, new IntentType?(), Slots.SlotTarget(new int[9]
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
            }, true), (EffectConditionSO)Conditions.Chance(0));
            RemoveStatusEffectEffect instance13 = ScriptableObject.CreateInstance<RemoveStatusEffectEffect>();
            instance13._statusToRemove = StatusEffectType.Scars;
            ability5.effects[4] = new Effect((EffectSO)instance13, 1, new IntentType?(), Slots.SlotTarget(new int[9]
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
            }, true), (EffectConditionSO)Conditions.Chance(0));
            ability5.effects[5] = new Effect((EffectSO)ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, new IntentType?(), Slots.SlotTarget(new int[8]
            {
        -4,
        -3,
        -2,
        -1,
        1,
        2,
        3,
        4
            }, true), (EffectConditionSO)Conditions.Chance(0));
            ability5.effects[6] = new Effect((EffectSO)ScriptableObject.CreateInstance<HealEffect>(), 999, new IntentType?(IntentType.Heal_11_20), Slots.SlotTarget(new int[8]
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
            ability5.effects[7] = new Effect((EffectSO)instance8, 1, new IntentType?(), Slots.Self);
            ability5.effects[8] = new Effect((EffectSO)ScriptableObject.CreateInstance<DamageEffect>(), 1, new IntentType?(IntentType.Damage_1_2), Slots.Self);
            ((DamageEffect)ability5.effects[8]._effect)._indirect = true;
            ability5.visuals = LoadedAssetsHandler.GetEnemyAbility("Gulp_A").visuals;
            ability5.animationTarget = Slots.SlotTarget(new int[8]
            {
        -4,
        -3,
        -2,
        -1,
        1,
        2,
        3,
        4
            }, true);
            Ability ability6 = ability5.Duplicate();
            ability6.name = "Normal Snack";
            ability6.description = "Remove Cursed and fully heal all party members. Remove Divine Protection and deal 1 indirect damage to this character.";
            ability6.effects[0]._intent = new IntentType?(IntentType.Rem_Status_Cursed);
            ability6.effects[0]._condition = (EffectConditionSO)Conditions.Chance(100);
            Ability ability7 = ability6.Duplicate();
            ability7.name = "Tasty Snack";
            ability7.description = "Remove Cursed, Frail, Ruptured, Linked, Scars, and fully heal all party members. Remove Divine Protection and deal 1 indirect damage to this character.";
            ability7.effects[1]._intent = new IntentType?(IntentType.Rem_Status_Frail);
            ability7.effects[1]._condition = (EffectConditionSO)Conditions.Chance(100);
            ability7.effects[2]._intent = new IntentType?(IntentType.Rem_Status_Ruptured);
            ability7.effects[2]._condition = (EffectConditionSO)Conditions.Chance(100);
            ability7.effects[3]._intent = new IntentType?(IntentType.Rem_Status_Linked);
            ability7.effects[3]._condition = (EffectConditionSO)Conditions.Chance(100);
            ability7.effects[4]._intent = new IntentType?(IntentType.Rem_Status_Scars);
            ability7.effects[4]._condition = (EffectConditionSO)Conditions.Chance(100);
            Ability ability8 = ability7.Duplicate();
            ability8.name = "Scrumptious Snack";
            ability8.description = "Remove Cursed, Frail, Ruptured, Linked, Scars, fully heal all party members, and then refresh ability usage for all other characters. Remove Divine Protection and deal 1 indirect damage to this character.";
            ability8.effects[5]._intent = new IntentType?(IntentType.Other_Refresh);
            ability8.effects[5]._condition = (EffectConditionSO)Conditions.Chance(100);
            Ability ability9 = new Ability();
            ability9.name = "Fake Butter";
            ability9.description = "Apply 1 Oil Slicked and 2 Ruptured to all enemies. move the opposing enemy left or right. Remove Divine Protection and deal 1 indirect damage to this character.";
            ability9.sprite = ResourceLoader.LoadSprite("TOAST Butter");
            ability9.cost = new ManaColorSO[1] { Pigments.Yellow };
            ability9.effects = new Effect[6];
            ability9.effects[0] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyOilSlickedEffect>(), 1, new IntentType?(IntentType.Status_OilSlicked), Slots.SlotTarget(new int[9]
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
            ability9.effects[1] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 2, new IntentType?(IntentType.Status_Ruptured), Slots.SlotTarget(new int[9]
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
            ability9.effects[2] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyScarsEffect>(), 0, new IntentType?(), Slots.SlotTarget(new int[9]
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
            }), (EffectConditionSO)Conditions.Chance(0));
            ability9.effects[3] = new Effect((EffectSO)ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, new IntentType?(IntentType.Swap_Sides), Slots.Front);
            ability9.effects[4] = new Effect((EffectSO)instance8, 1, new IntentType?(), Slots.Self);
            ability9.effects[5] = new Effect((EffectSO)ScriptableObject.CreateInstance<DamageEffect>(), 1, new IntentType?(IntentType.Damage_1_2), Slots.Self);
            ((DamageEffect)ability9.effects[5]._effect)._indirect = true;
            ability1.visuals = LoadedAssetsHandler.GetCharacterAbility("Purify_1_A").visuals;
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
            });
            Ability ability10 = ability9.Duplicate();
            ability10.name = "Imitation Butter";
            ability10.description = "Apply 2 Oil Slicked, 3 Ruptured, and 1 Scar to all enemies. Move the left and right enemies left or right. Remove Divine Protection and deal 1 indirect damage to this character.";
            ability10.effects[0]._entryVariable = 2;
            ability10.effects[1]._entryVariable = 3;
            ability10.effects[2]._entryVariable = 1;
            ability10.effects[2]._intent = new IntentType?(IntentType.Status_Scars);
            ability10.effects[2]._condition = (EffectConditionSO)Conditions.Chance(100);
            ability10.effects[3]._target = Slots.LeftRight;
            Ability ability11 = ability10.Duplicate();
            ability11.name = "I Cannot Believe It Is Not Butter";
            ability11.description = "Apply 3 Oil Slicked, 4-5 Ruptured, and 1-2 Scars to all enemies. Move the left, right, and opposing enemies left or right. Remove Divine Protection and deal 1 indirect damage to this character.";
            ability11.effects[0]._entryVariable = 3;
            ability11.effects[1]._entryVariable = 4;
            ability11.effects[1]._effect = (EffectSO)ScriptableObject.CreateInstance<RupturedUpToPlusOneEffect>();
            ability11.effects[2]._entryVariable = 1;
            ability11.effects[2]._effect = (EffectSO)ScriptableObject.CreateInstance<ScarsUpToPlusOneEffect>();
            ability11.effects[3]._target = Slots.FrontLeftRight;
            Ability ability12 = ability11.Duplicate();
            ability12.name = "Actually Just Butter";
            ability12.description = "Apply 4-5 Oil Slicked, 6-8 Ruptured, and 2-3 Scars to all enemies. Shuffle all enemy positions. Remove Divine Protection and deal 1 indirect damage to this character.";
            ability12.effects[0]._entryVariable = 4;
            ability12.effects[0]._effect = (EffectSO)ScriptableObject.CreateInstance<OilUpToPlusOneEffect>();
            ability12.effects[1]._entryVariable = 6;
            ability12.effects[1]._effect = (EffectSO)ScriptableObject.CreateInstance<RupturedUpToPlusTwoEffect>();
            ability12.effects[2]._entryVariable = 2;
            ability12.effects[3]._effect = (EffectSO)ScriptableObject.CreateInstance<MassSwapZoneEffect>();
            ability12.effects[3]._target = Slots.SlotTarget(new int[9]
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
            character.AddLevel(3, new Ability[3]
            {
        ability1,
        ability5,
        ability9
            }, 0);
            character.AddLevel(5, new Ability[3]
            {
        ability2,
        ability6,
        ability10
            }, 1);
            character.AddLevel(6, new Ability[3]
            {
        ability3,
        ability7,
        ability11
            }, 2);
            character.AddLevel(7, new Ability[3]
            {
        ability4,
        ability8,
        ability12
            }, 3);
            _09_TheToasted.AAAAAAAAAA = character;
            if (!Joyce.IncludeTheToasted)
                return;
            character.AddCharacter();
        }
    }
}
