// Decompiled with JetBrains decompiler
// Type: THE_DEAD._13_TheDelusional
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using BrutalAPI;
using UnityEngine;

namespace THE_DEAD
{
    public static class _13_TheDelusional
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
            Character character = new Character();
            character.name = "Roger";
            character.healthColor = Pigments.Red;
            character.entityID = (EntityIDs)2233456;
            character.overworldSprite = ResourceLoader.LoadSprite("Roger Overworld", pivot: new Vector2?(new Vector2(0.5f, 0.0f)));
            character.frontSprite = ResourceLoader.LoadSprite("Roger Front");
            character.backSprite = ResourceLoader.LoadSprite("Roger Back");
            character.lockedSprite = ResourceLoader.LoadSprite("Roger Locked");
            character.unlockedSprite = ResourceLoader.LoadSprite("Roger Unlocked");
            character.menuChar = true;
            character.isSupport = false;
            character.walksInOverworld = true;
            character.hurtSound = LoadedAssetsHandler.GetCharcater("Anton_CH").damageSound;
            character.deathSound = LoadedAssetsHandler.GetCharcater("Anton_CH").deathSound;
            character.dialogueSound = LoadedAssetsHandler.GetCharcater("Anton_CH").dxSound;
            if (Joyce.IncludeVinceVersion)
            {
                character.overworldSprite = ResourceLoader.LoadSprite("Vince Overworld", pivot: new Vector2?(new Vector2(0.5f, 0.0f)));
                character.frontSprite = ResourceLoader.LoadSprite("Vince Front");
                character.backSprite = ResourceLoader.LoadSprite("Vince Back");
                character.lockedSprite = ResourceLoader.LoadSprite("Vince Locked");
                character.unlockedSprite = ResourceLoader.LoadSprite("Vince Unlocked");
            }
            CasterStoredValueSetEffect instance8 = ScriptableObject.CreateInstance<CasterStoredValueSetEffect>();
            instance8._minimumValue = 0;
            instance8._valueName = (UnitStoredValueNames)2233456;
            ScriptableObject.CreateInstance<PreviousEffectCondition>().wasSuccessful = false;
            ScriptableObject.CreateInstance<PreviousEffectCondition>().wasSuccessful = true;
            Ability ability1 = new Ability();
            ability1.name = "Point Blank Shot";
            ability1.description = "Deal 1-6 damage to the opposing enemy twice. The first hit cascades either left or right, and the second cascades down the other direction.";
            ability1.cost = new ManaColorSO[2]
            {
        Pigments.Red,
        Pigments.Red
            };
            ability1.sprite = ResourceLoader.LoadSprite("PointBlank Icon");
            ability1.effects = new Effect[2];
            ability1.effects[0] = new Effect((EffectSO)instance8, 1, new IntentType?(IntentType.Damage_3_6), Slots.Front);
            ability1.effects[1] = new Effect((EffectSO)ScriptableObject.CreateInstance<RogerShootingEffect>(), 6, new IntentType?(IntentType.Damage_3_6), Slots.Front);
            ability1.visuals = LoadedAssetsHandler.GetCharcater("Anton_CH").rankedData[0].rankAbilities[0].ability.visuals;
            ability1.animationTarget = Slots.Front;
            Ability ability2 = ability1.Duplicate();
            ability2.name = "Point Blank Blow";
            ability2.description = "Deal 2-10 damage to the opposing enemy twice. The first hit cascades either left or right, and the second cascades down the other direction.";
            ability2.effects[0]._entryVariable = 2;
            ability2.effects[0]._intent = new IntentType?(IntentType.Damage_7_10);
            ability2.effects[1]._entryVariable = 10;
            ability2.effects[1]._intent = new IntentType?(IntentType.Damage_7_10);
            Ability ability3 = ability2.Duplicate();
            ability3.name = "Point Blank Burst";
            ability3.description = "Deal 3-12 damage to the opposing enemy twice. The first hit cascades either left or right, and the second cascades down the other direction.";
            ability3.effects[0]._entryVariable = 3;
            ability3.effects[0]._intent = new IntentType?(IntentType.Damage_11_15);
            ability3.effects[1]._entryVariable = 12;
            ability3.effects[1]._intent = new IntentType?(IntentType.Damage_11_15);
            Ability ability4 = ability3.Duplicate();
            ability4.name = "Point Blank Blast";
            ability4.description = "Deal 4-16 damage to the opposing enemy twice. The first hit cascades either left or right, and the second cascades down the other direction.";
            ability4.effects[0]._entryVariable = 4;
            ability4.effects[0]._intent = new IntentType?(IntentType.Damage_16_20);
            ability4.effects[1]._entryVariable = 16;
            ability4.effects[1]._intent = new IntentType?(IntentType.Damage_16_20);
            RogerShootingEffect instance9 = ScriptableObject.CreateInstance<RogerShootingEffect>();
            instance9.leftShot = Slots.SlotTarget(new int[6]
            {
        -1,
        0,
        1,
        2,
        3,
        4
            });
            instance9.rightShot = Slots.SlotTarget(new int[6]
            {
        1,
        0,
        -1,
        -2,
        -3,
        -4
            });
            Ability ability5 = new Ability();
            ability5.name = "Dual Shot";
            ability5.description = "Deal 1-8 damage to the left and right enemies. Both moves cascade into the center.";
            ability5.cost = new ManaColorSO[3]
            {
        Pigments.Red,
        Pigments.Red,
        Pigments.Red
            };
            ability5.sprite = ResourceLoader.LoadSprite("Dual Icon");
            ability5.effects = new Effect[2];
            ability5.effects[0] = new Effect((EffectSO)instance8, 1, new IntentType?(), Slots.Self);
            ability5.effects[1] = new Effect((EffectSO)instance9, 8, new IntentType?(IntentType.Damage_7_10), Slots.LeftRight);
            ability5.visuals = LoadedAssetsHandler.GetEnemy("Voboola_EN").abilities[0].ability.visuals;
            ability5.animationTarget = Slots.LeftRight;
            Ability ability6 = ability5.Duplicate();
            ability6.name = "Dual Burst";
            ability6.description = "Deal 1-11 damage to the left and right enemies. Both moves cascade into the center.";
            ability6.effects[0]._entryVariable = 1;
            ability6.effects[1]._entryVariable = 11;
            ability6.effects[1]._intent = new IntentType?(IntentType.Damage_11_15);
            Ability ability7 = ability6.Duplicate();
            ability7.name = "Dual Spray";
            ability7.description = "Deal 2-14 damage to the left and right enemies. Both moves cascade into the center.";
            ability7.effects[0]._entryVariable = 2;
            ability7.effects[1]._entryVariable = 14;
            Ability ability8 = ability7.Duplicate();
            ability8.name = "Dual Blast";
            ability8.description = "Deal 2-18 damage to the left and right enemies. Both moves cascade into the center.";
            ability8.effects[0]._entryVariable = 2;
            ability8.effects[1]._entryVariable = 18;
            ability8.effects[1]._intent = new IntentType?(IntentType.Damage_16_20);
            RogerShootingEffect instance10 = ScriptableObject.CreateInstance<RogerShootingEffect>();
            instance10.leftShot = Slots.SlotTarget(new int[9]
            {
        -2,
        -3,
        -4,
        -1,
        0,
        1,
        2,
        3,
        4
            });
            instance10.rightShot = Slots.SlotTarget(new int[9]
            {
        2,
        3,
        4,
        1,
        0,
        -1,
        -2,
        -3,
        -4
            });
            Ability ability9 = new Ability();
            ability9.name = "Out of Range Shot";
            ability9.description = "Deal 0-12 damage to the far left and far right enemies. Both hits cascade in both directions.";
            ability9.cost = new ManaColorSO[3]
            {
        Pigments.Yellow,
        Pigments.Red,
        Pigments.Red
            };
            ability9.sprite = ResourceLoader.LoadSprite("OutOfRange Icon");
            ability9.effects = new Effect[2];
            ability9.effects[0] = new Effect((EffectSO)instance8, 0, new IntentType?(), Slots.Self);
            ability9.effects[1] = new Effect((EffectSO)instance10, 12, new IntentType?(IntentType.Damage_11_15), Slots.SlotTarget(new int[2]
            {
        -2,
        2
            }));
            ability9.visuals = LoadedAssetsHandler.GetEnemy("Voboola_EN").abilities[0].ability.visuals;
            ability9.animationTarget = Slots.SlotTarget(new int[2]
            {
        2,
        -2
            });
            Ability ability10 = ability9.Duplicate();
            ability10.name = "Out of Range Spray";
            ability10.description = "Deal 0-16 damage to the far left and far right enemies. Both hits cascade in both directions.";
            ability10.effects[1]._entryVariable = 16;
            ability10.effects[1]._intent = new IntentType?(IntentType.Damage_16_20);
            Ability ability11 = ability10.Duplicate();
            ability11.name = "Out of Range Burst";
            ability11.description = "Deal 0-20 damage to the far left and far right enemies. Both hits cascade in both directions.";
            ability11.effects[1]._entryVariable = 20;
            Ability ability12 = ability11.Duplicate();
            ability12.name = "Out of Range Blast";
            ability12.description = "Deal 0-25 damage to the far left and far right enemies. Both hits cascade in both directions.";
            ability12.effects[1]._entryVariable = 25;
            ability12.effects[1]._intent = new IntentType?(IntentType.Damage_21);
            character.AddLevel(12, new Ability[3]
            {
        ability1,
        ability5,
        ability9
            }, 0);
            character.AddLevel(15, new Ability[3]
            {
        ability2,
        ability6,
        ability10
            }, 1);
            character.AddLevel(17, new Ability[3]
            {
        ability3,
        ability7,
        ability11
            }, 2);
            character.AddLevel(19, new Ability[3]
            {
        ability4,
        ability8,
        ability12
            }, 3);
            _13_TheDelusional.Chara = character;
            if (!Joyce.IncludeTheDelusional)
                return;
            character.AddCharacter();
            if (Joyce.IncludeVinceVersion)
                LoadedAssetsHandler.GetCharcater("Roger_CH")._characterName = "VinceFish";
        }
    }
}
