// Decompiled with JetBrains decompiler
// Type: THE_DEAD._05_TheHypocrite
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using BrutalAPI;
using UnityEngine;

namespace THE_DEAD
{
    public static class _05_TheHypocrite
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
            PreviousEffectCondition instance7 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            instance7.wasSuccessful = true;
            PreviousEffectCondition instance8 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            instance8.wasSuccessful = false;
            Character character = new Character();
            character.name = "Camus";
            character.healthColor = Pigments.Purple;
            character.entityID = (EntityIDs)20340800;
            character.overworldSprite = ResourceLoader.LoadSprite("DocOver", pivot: new Vector2?(new Vector2(0.5f, 0.0f)));
            character.frontSprite = ResourceLoader.LoadSprite("DocFront");
            character.backSprite = ResourceLoader.LoadSprite("DocBack");
            character.lockedSprite = ResourceLoader.LoadSprite("DocLocked");
            character.unlockedSprite = ResourceLoader.LoadSprite("DocMenu");
            character.menuChar = true;
            character.isSupport = true;
            character.walksInOverworld = true;
            character.hurtSound = LoadedAssetsHandler.GetCharcater("Splig_CH").damageSound;
            character.deathSound = LoadedAssetsHandler.GetCharcater("Splig_CH").deathSound;
            character.dialogueSound = LoadedAssetsHandler.GetCharcater("Splig_CH").dxSound;
            character.passives = new BasePassiveAbilitySO[1]
            {
        Passives.Enfeebled
            };
            Ability ability1 = new Ability();
            ability1.name = "Prick";
            ability1.description = "Random chance to apply 1 scar to the opposing enemy. Deal 1 damage and heal 1 health to the opposing enemy.";
            ability1.cost = new ManaColorSO[1] { Pigments.Yellow };
            ability1.sprite = ResourceLoader.LoadSprite("DocPrick");
            ability1.effects = new Effect[3];
            ability1.effects[0] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyScarsOnRandomPercentEffect>(), 1, new IntentType?(IntentType.Status_Scars), Slots.Front);
            ability1.effects[1] = new Effect((EffectSO)ScriptableObject.CreateInstance<DamageEffect>(), 1, new IntentType?(IntentType.Damage_1_2), Slots.Front);
            ability1.effects[2] = new Effect((EffectSO)ScriptableObject.CreateInstance<HealEffect>(), 1, new IntentType?(IntentType.Heal_1_4), Slots.Front);
            ability1.visuals = LoadedAssetsHandler.GetCharacterAbility("Quills_1_A").visuals;
            ability1.animationTarget = Slots.Front;
            Ability ability2 = new Ability();
            ability2.name = "Messy Transfusion";
            ability2.description = "Apply 1 Anesthetics, 1 Gutted, and deal 3 damage to the right ally. Apply 1 Gutted and heal 4 health to the left ally.";
            ability2.cost = new ManaColorSO[2]
            {
        Pigments.Blue,
        Pigments.Red
            };
            ability2.sprite = ResourceLoader.LoadSprite("DocTransfusion");
            ability2.effects = new Effect[5];
            ability2.effects[0] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyAnestheticsEffect>(), 1, new IntentType?((IntentType)987898), Slots.SlotTarget(new int[1]
            {
        1
            }, true));
            ability2.effects[2] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyGuttedEffect>(), 1, new IntentType?((IntentType)987893), Slots.SlotTarget(new int[1]
            {
        1
            }, true));
            ability2.effects[1] = new Effect((EffectSO)ScriptableObject.CreateInstance<DamageEffect>(), 3, new IntentType?(IntentType.Damage_3_6), Slots.SlotTarget(new int[1]
            {
        1
            }, true));
            ability2.effects[3] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyGuttedEffect>(), 1, new IntentType?((IntentType)987893), Slots.SlotTarget(new int[1]
            {
        -1
            }, true), (EffectConditionSO)instance7);
            ability2.effects[4] = new Effect((EffectSO)ScriptableObject.CreateInstance<HealEffect>(), 4, new IntentType?(IntentType.Heal_1_4), Slots.SlotTarget(new int[1]
            {
        -1
            }, true), (EffectConditionSO)instance7);
            ability2.visuals = LoadedAssetsHandler.GetCharacterAbility("Absolve_1_A").visuals;
            ability2.animationTarget = Slots.SlotTarget(new int[2]
            {
        -1,
        1
            }, true);
            Ability ability3 = ability2.Duplicate();
            ability3.name = "Clusmy Transfusion";
            ability3.description = "Apply 2 anesthetics, 1 Gutted, and deal 4 damage to the right ally. Apply 1 Gutted and heal 5 health to the left ally.";
            ability3.effects[0]._entryVariable = 2;
            ability3.effects[1]._entryVariable = 4;
            ability3.effects[4]._entryVariable = 5;
            ability3.effects[4]._intent = new IntentType?(IntentType.Heal_5_10);
            Ability ability4 = ability3.Duplicate();
            ability4.name = "Effective Transfusion";
            ability4.description = "Apply 3 anesthetics, 1 Gutted, and deal 5 damage to the right ally. Apply 1 Gutted and heal 6 health to the left ally.";
            ability4.effects[0]._entryVariable = 3;
            ability4.effects[1]._entryVariable = 5;
            ability4.effects[4]._entryVariable = 6;
            Ability ability5 = ability4.Duplicate();
            ability5.name = "Precise Transfusion";
            ability5.description = "Apply 4 anesthetics, 1 Gutted, and deal 6 damage to the right ally. Apply 1 Gutted and heal 7 health to the left ally.";
            ability5.effects[0]._entryVariable = 4;
            ability5.effects[1]._entryVariable = 6;
            ability5.effects[4]._entryVariable = 7;
            RemoveStatusEffectEffect instance9 = ScriptableObject.CreateInstance<RemoveStatusEffectEffect>();
            instance9._statusToRemove = StatusEffectType.Scars;
            Ability ability6 = new Ability();
            ability6.name = "Generous Organ Donor";
            ability6.description = "Apply 1-5 Anesthetics to the left ally and deal 4 damage to them. If this damage fails, deal 4 damage to Camus. \nHeal the right ally 5 health; this spreads to other right allies.";
            ability6.cost = new ManaColorSO[1] { Pigments.Blue };
            ability6.sprite = ResourceLoader.LoadSprite("DocDonor");
            ability6.effects = new Effect[6];
            ability6.effects[0] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyAnestheticsRangePlusFourEffect>(), 1, new IntentType?((IntentType)987898), Slots.SlotTarget(new int[1]
            {
        -1
            }, true));
            ability6.effects[1] = new Effect((EffectSO)instance9, 1, new IntentType?(), Slots.SlotTarget(new int[1]
            {
        -1
            }, true), (EffectConditionSO)Conditions.Chance(0));
            ability6.effects[2] = new Effect((EffectSO)ScriptableObject.CreateInstance<DamageEffect>(), 4, new IntentType?(IntentType.Damage_3_6), Slots.SlotTarget(new int[1]
            {
        -1
            }, true));
            ability6.effects[3] = new Effect((EffectSO)ScriptableObject.CreateInstance<DamageEffect>(), 4, new IntentType?(IntentType.Damage_3_6), Slots.Self, (EffectConditionSO)instance8);
            ability6.effects[4] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyGuttedEffect>(), 1, new IntentType?((IntentType)987893), Slots.SlotTarget(new int[1]
            {
        1
            }, true), (EffectConditionSO)Conditions.Chance(0));
            ability6.effects[5] = new Effect((EffectSO)ScriptableObject.CreateInstance<HealOnCascadeEffect>(), 5, new IntentType?(IntentType.Heal_5_10), Slots.SlotTarget(new int[4]
            {
        1,
        2,
        3,
        4
            }, true));
            ability6.visuals = LoadedAssetsHandler.GetCharacterAbility("Absolve_1_A").visuals;
            ability6.animationTarget = Slots.Sides;
            Ability ability7 = ability6.Duplicate();
            ability7.name = "Perfunctory Organ Donor";
            ability7.description = "Apply 2-6 Anesthetics and remove all Scars from the left ally and deal 5 damage to them. If this damage fails, deal 4 damage to Camus. \nHeal the right ally 7 health; this spreads to other right allies.";
            ability7.effects[0]._entryVariable = 2;
            ability7.effects[1]._intent = new IntentType?(IntentType.Rem_Status_Scars);
            ability7.effects[1]._condition = (EffectConditionSO)null;
            ability7.effects[2]._entryVariable = 5;
            ability7.effects[5]._entryVariable = 7;
            Ability ability8 = ability7.Duplicate();
            ability8.name = "Unwilling Organ Donor";
            ability8.description = "Apply 3-7 Anesthetics and remove all Scars from the left ally and deal 6 damage to them. If this damage fails, deal 4 damage to Camus. \nHeal the right ally 10 health; this spreads to other right allies.";
            ability8.cost = new ManaColorSO[1]
            {
        Pigments.SplitPigment(Pigments.Blue, Pigments.Purple)
            };
            ability8.effects[0]._entryVariable = 3;
            ability8.effects[2]._entryVariable = 6;
            ability8.effects[5]._entryVariable = 10;
            Ability ability9 = ability8.Duplicate();
            ability9.name = "Mandatory Organ Donor";
            ability9.description = "Apply 4-8 Anesthetics and remove all Scars from the left ally and deal 7 damage to them. If this damage fails, deal 4 damage to Camus. \nHeal the right ally 14 health; this spreads to other right allies.";
            ability9.effects[0]._entryVariable = 4;
            ability9.effects[2]._entryVariable = 7;
            ability9.effects[2]._intent = new IntentType?(IntentType.Damage_7_10);
            ability9.effects[5]._intent = new IntentType?(IntentType.Heal_11_20);
            ability9.effects[5]._entryVariable = 14;
            RemoveStatusEffectEffect instance10 = ScriptableObject.CreateInstance<RemoveStatusEffectEffect>();
            instance10._statusToRemove = StatusEffectType.Frail;
            Ability ability10 = new Ability();
            ability10.name = "Life-Threatening Surgery";
            ability10.description = "Remove all frail, apply 1 Anesthetic, and deal 3 damage to the left ally. 50% chance to heal 6 health.";
            ability10.cost = new ManaColorSO[2]
            {
        Pigments.Purple,
        Pigments.SplitPigment(Pigments.Red, Pigments.Blue)
            };
            ability10.sprite = ResourceLoader.LoadSprite("DocSurgery");
            ability10.effects = new Effect[5];
            ability10.effects[0] = new Effect((EffectSO)instance10, 1, new IntentType?(IntentType.Rem_Status_Frail), Slots.SlotTarget(new int[1]
            {
        -1
            }, true));
            ability10.effects[1] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyAnestheticsEffect>(), 1, new IntentType?((IntentType)987898), Slots.SlotTarget(new int[1]
            {
        -1
            }, true));
            ability10.effects[2] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyAnestheticsEffect>(), 1, new IntentType?(), Slots.SlotTarget(new int[1]
            {
        -1
            }, true), (EffectConditionSO)Conditions.Chance(0));
            ability10.effects[3] = new Effect((EffectSO)ScriptableObject.CreateInstance<DamageEffect>(), 3, new IntentType?(IntentType.Damage_3_6), Slots.SlotTarget(new int[1]
            {
        -1
            }, true));
            ability10.effects[4] = new Effect((EffectSO)ScriptableObject.CreateInstance<HealEffect>(), 6, new IntentType?(IntentType.Heal_5_10), Slots.SlotTarget(new int[1]
            {
        -1
            }, true), (EffectConditionSO)Conditions.Chance(50));
            ability10.visuals = LoadedAssetsHandler.GetEnemyAbility("UglyOnTheInside_A").visuals;
            ability10.animationTarget = Slots.SlotTarget(new int[1]
            {
        -1
            }, true);
            Ability ability11 = ability10.Duplicate();
            ability11.name = "Suddenly Religious Surgery";
            ability11.description = "Remove all frail, apply 2-3 Anesthetics, and deal 4 damage to the left ally. 60% chance to heal 8 health.";
            ability11.effects[1]._entryVariable = 2;
            ability11.effects[2]._condition = (EffectConditionSO)Conditions.Chance(50);
            ability11.effects[3]._entryVariable = 4;
            ability11.effects[4]._entryVariable = 8;
            ability11.effects[4]._condition = (EffectConditionSO)Conditions.Chance(60);
            Ability ability12 = ability11.Duplicate();
            ability12.name = "Barely Legal Surgery";
            ability12.description = "Remove all frail, apply 4 Anesthetics, and deal 5 damage to the left ally. 65% chance to heal 10 health.";
            ability12.effects[1]._entryVariable = 4;
            ability12.effects[2]._condition = (EffectConditionSO)Conditions.Chance(0);
            ability12.effects[3]._entryVariable = 5;
            ability12.effects[4]._entryVariable = 10;
            ability12.effects[4]._condition = (EffectConditionSO)Conditions.Chance(65);
            Ability ability13 = ability12.Duplicate();
            ability13.name = "Well-Intentioned Surgery";
            ability13.description = "Remove all frail, apply 5-6 Anesthetics, and deal 6 damage to the left ally. 70% chance to heal 12 health.";
            ability13.effects[1]._entryVariable = 5;
            ability13.effects[2]._condition = (EffectConditionSO)Conditions.Chance(50);
            ability13.effects[3]._entryVariable = 6;
            ability13.effects[4]._entryVariable = 12;
            ability13.effects[4]._intent = new IntentType?(IntentType.Heal_11_20);
            ability13.effects[4]._condition = (EffectConditionSO)Conditions.Chance(70);
            character.AddLevel(10, new Ability[3]
            {
        ability2,
        ability6,
        ability10
            }, 0);
            character.AddLevel(12, new Ability[3]
            {
        ability3,
        ability7,
        ability11
            }, 1);
            character.AddLevel(14, new Ability[3]
            {
        ability4,
        ability8,
        ability12
            }, 2);
            character.AddLevel(16, new Ability[3]
            {
        ability5,
        ability9,
        ability13
            }, 3);
            if (!Joyce.IncludeTheHypocrite)
                return;
            character.AddCharacter();
        }
    }
}
