// Decompiled with JetBrains decompiler
// Type: THE_DEAD._12_ThePeaceful
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using BrutalAPI;
using UnityEngine;

namespace THE_DEAD
{
    public static class _12_ThePeaceful
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
            Character character = new Character();
            character.name = "May";
            character.healthColor = Pigments.Purple;
            character.entityID = (EntityIDs)87300;
            character.overworldSprite = ResourceLoader.LoadSprite("MayOverworld", pivot: new Vector2?(new Vector2(0.5f, 0.0f)));
            character.frontSprite = ResourceLoader.LoadSprite("MayFront");
            character.backSprite = ResourceLoader.LoadSprite("MayBack");
            character.lockedSprite = ResourceLoader.LoadSprite("MayLocked");
            character.unlockedSprite = ResourceLoader.LoadSprite("MayUnlocked");
            character.menuChar = true;
            character.isSupport = true;
            character.walksInOverworld = false;
            character.hurtSound = LoadedAssetsHandler.GetCharcater("Bimini_CH").damageSound;
            character.deathSound = LoadedAssetsHandler.GetCharcater("Bimini_CH").deathSound;
            character.dialogueSound = LoadedAssetsHandler.GetCharcater("Bimini_CH").dxSound;
            character.passives = new BasePassiveAbilitySO[1]
            {
        Passives.Delicate
            };
            Ability ability1 = new Ability();
            ability1.name = "Tear Ducts";
            ability1.description = "Produce 2 blue pigment.";
            ability1.cost = new ManaColorSO[1] { Pigments.Yellow };
            ability1.sprite = ResourceLoader.LoadSprite("MayTears");
            ability1.effects = new Effect[1];
            ability1.effects[0] = new Effect((EffectSO)ScriptableObject.CreateInstance<GenerateBlueManaEffect>(), 2, new IntentType?(IntentType.Mana_Generate), Slots.Self);
            ability1.visuals = LoadedAssetsHandler.GetEnemy("MusicMan_EN").abilities[2].ability.visuals;
            ability1.animationTarget = Slots.Self;
            character.baseAbility = ability1;
            HealEffect instance8 = ScriptableObject.CreateInstance<HealEffect>();
            instance8.usePreviousExitValue = true;
            Ability ability2 = new Ability();
            ability2.name = "Smile through Pain";
            ability2.description = "Heal this character 4 health. Heal the left and right allies health equal to the lost health this character healed.";
            ability2.cost = new ManaColorSO[3]
            {
        Pigments.Yellow,
        Pigments.Blue,
        Pigments.Blue
            };
            ability2.sprite = ResourceLoader.LoadSprite("MaySmile");
            ability2.effects = new Effect[2];
            ability2.effects[0] = new Effect((EffectSO)ScriptableObject.CreateInstance<HealEffect>(), 4, new IntentType?(IntentType.Heal_1_4), Slots.Self);
            ability2.effects[1] = new Effect((EffectSO)instance8, 1, new IntentType?(IntentType.Heal_1_4), Slots.SlotTarget(new int[2]
            {
        -1,
        1
            }, true));
            ability2.visuals = LoadedAssetsHandler.GetCharcater("Hans_CH").rankedData[0].rankAbilities[2].ability.visuals;
            ability2.animationTarget = Slots.SlotTarget(new int[2]
            {
        -1,
        1
            }, true);
            Ability ability3 = ability2.Duplicate();
            ability3.name = "Smile in Sorrow";
            ability3.description = "Heal this character 6 health. Heal the left and right allies health equal to the lost health this character healed.";
            ability3.effects[0]._entryVariable = 6;
            ability3.effects[0]._intent = new IntentType?(IntentType.Heal_5_10);
            ability3.effects[1]._intent = new IntentType?(IntentType.Heal_5_10);
            Ability ability4 = ability3.Duplicate();
            ability4.name = "Smile in Sadness";
            ability4.description = "Heal this character 8 health. Heal the left and right allies health equal to the lost health this character healed.";
            ability4.cost = new ManaColorSO[2]
            {
        Pigments.Blue,
        Pigments.Blue
            };
            ability4.effects[0]._entryVariable = 8;
            Ability ability5 = ability4.Duplicate();
            ability5.name = "Smile Always";
            ability5.description = "Heal this character 10 health. Heal the left and right allies health equal to the lost health this character healed.";
            ability5.effects[0]._entryVariable = 10;
            RemoveStatusEffectEffect instance9 = ScriptableObject.CreateInstance<RemoveStatusEffectEffect>();
            instance9._statusToRemove = StatusEffectType.Cursed;
            Ability ability6 = new Ability();
            ability6.name = "A Quiet Death";
            ability6.description = "Remove Curse from this character.";
            ability6.cost = new ManaColorSO[1] { Pigments.Blue };
            ability6.sprite = ResourceLoader.LoadSprite("MayDeath");
            ability6.effects = new Effect[2];
            ability6.effects[0] = new Effect((EffectSO)instance9, 1, new IntentType?(IntentType.Rem_Status_Cursed), Slots.Self);
            ability6.effects[1] = new Effect((EffectSO)ScriptableObject.CreateInstance<HealEffect>(), 2, new IntentType?(), Slots.Self, (EffectConditionSO)Conditions.Chance(0));
            ability6.visuals = LoadedAssetsHandler.GetEnemy("Jumbleguts_Flummoxing_EN").abilities[2].ability.visuals;
            ability6.animationTarget = Slots.Self;
            Ability ability7 = ability6.Duplicate();
            ability7.name = "A Calm Death";
            ability7.description = "Remove Curse from this character. Heal self 2 health.";
            ability7.effects[1]._intent = new IntentType?(IntentType.Heal_1_4);
            ability7.effects[1]._condition = (EffectConditionSO)null;
            Ability ability8 = ability7.Duplicate();
            ability8.name = "A Gentle Death";
            ability8.description = "Remove Curse from this character. Heal self 3 health.";
            ability8.effects[1]._entryVariable = 3;
            Ability ability9 = ability8.Duplicate();
            ability9.name = "A Happy Death";
            ability9.description = "Remove Curse from this character. Heal self 5 health.";
            ability8.effects[1]._entryVariable = 5;
            ability8.effects[1]._intent = new IntentType?(IntentType.Heal_5_10);
            ScriptableObject.CreateInstance<ChangeMaxHealthEffect>()._increase = false;
            Ability ability10 = new Ability();
            ability10.name = "Less Despair";
            ability10.description = "Heal 4 health to self. Apply 2 Shield to the left and right ally positions. 50% chance to refresh this character. 10% chance to Curse this character.";
            ability10.cost = new ManaColorSO[2]
            {
        Pigments.Blue,
        Pigments.Purple
            };
            ability10.sprite = ResourceLoader.LoadSprite("MayDespair");
            ability10.effects = new Effect[4];
            ability10.effects[0] = new Effect((EffectSO)ScriptableObject.CreateInstance<HealEffect>(), 4, new IntentType?(IntentType.Heal_1_4), Slots.Self);
            ability10.effects[1] = new Effect((EffectSO)ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, new IntentType?(IntentType.Other_Refresh), Slots.Self, (EffectConditionSO)Conditions.Chance(50));
            ability10.effects[2] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 2, new IntentType?(IntentType.Field_Shield), Slots.Sides);
            ability10.effects[3] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyCursedEffect>(), 1, new IntentType?(IntentType.Status_Cursed), Slots.Self, (EffectConditionSO)Conditions.Chance(10));
            ability10.visuals = LoadedAssetsHandler.GetEnemyAbility("InhumanRoar_A").visuals;
            ability10.animationTarget = Slots.Self;
            Ability ability11 = ability10.Duplicate();
            ability11.name = "Avoid Despair";
            ability11.description = "Heal 5 health to self. Apply 2 Shield to the left and right ally positions. 60% chance to refresh this character. 10% chance to Curse this character.";
            ability11.effects[0]._entryVariable = 5;
            ability11.effects[0]._intent = new IntentType?(IntentType.Heal_5_10);
            ability11.effects[1]._condition = (EffectConditionSO)Conditions.Chance(60);
            ability11.effects[2]._entryVariable = 2;
            Ability ability12 = ability11.Duplicate();
            ability12.name = "Supress Despair";
            ability12.description = "Heal 6 health to self. Apply 3 Shield to the left and right ally positions. 70% chance to refresh this character. 10% chance to Curse this character.";
            ability12.effects[0]._entryVariable = 6;
            ability12.effects[1]._condition = (EffectConditionSO)Conditions.Chance(70);
            ability12.effects[2]._entryVariable = 3;
            Ability ability13 = ability12.Duplicate();
            ability13.name = "End Despair";
            ability13.description = "Heal 7 health to self. Apply 3 Shield to the left and right ally positions. 80% chance to refresh this character. 10% chance to Curse this character.";
            ability13.effects[0]._entryVariable = 7;
            ability13.effects[1]._condition = (EffectConditionSO)Conditions.Chance(80);
            character.AddLevel(16, new Ability[3]
            {
        ability2,
        ability6,
        ability10
            }, 0);
            character.AddLevel(21, new Ability[3]
            {
        ability3,
        ability7,
        ability11
            }, 1);
            character.AddLevel(25, new Ability[3]
            {
        ability4,
        ability8,
        ability12
            }, 2);
            character.AddLevel(28, new Ability[3]
            {
        ability5,
        ability9,
        ability13
            }, 3);
            if (!Joyce.IncludeThePeaceful)
                return;
            character.AddCharacter();
        }
    }
}
