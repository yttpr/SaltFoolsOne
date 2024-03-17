// Decompiled with JetBrains decompiler
// Type: THE_DEAD._03_TheNoise
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using BrutalAPI;
using UnityEngine;

namespace THE_DEAD
{
    public static class _03_TheNoise
    {
        public static Character Chara;

        public static void Add()
        {
            Character character = new Character();
            character.name = "MarunouchiSadistic";
            character.healthColor = Pigments.Purple;
            character.entityID = (EntityIDs)864841;
            character.overworldSprite = ResourceLoader.LoadSprite("MaruSadisticOverworld", pivot: new Vector2?(new Vector2(0.5f, 0.0f)));
            character.frontSprite = ResourceLoader.LoadSprite("MaruSadisticBattleSprite");
            character.backSprite = ResourceLoader.LoadSprite("MaruSadisticBattleSprite");
            character.lockedSprite = ResourceLoader.LoadSprite("MaruSadisticLocked");
            character.unlockedSprite = ResourceLoader.LoadSprite("MaruSadisticUnlocked");
            character.menuChar = true;
            character.isSupport = false;
            character.walksInOverworld = true;
            character.hurtSound = LoadedAssetsHandler.GetCharcater("Bimini_CH").damageSound;
            character.deathSound = LoadedAssetsHandler.GetCharcater("Bimini_CH").deathSound;
            character.dialogueSound = LoadedAssetsHandler.GetCharcater("Bimini_CH").dxSound;
            DirectPlusStoredValueEffect instance1 = ScriptableObject.CreateInstance<DirectPlusStoredValueEffect>();
            instance1._valueName = (UnitStoredValueNames)59998;
            CasterStoredValueChangeEffect instance2 = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
            instance2._minimumValue = 0;
            instance2._valueName = (UnitStoredValueNames)59998;
            instance2._increase = true;
            Ability ability1 = new Ability();
            ability1.name = "Marunouchi Mean";
            ability1.description = "Deal 10 damage to the opposing enemy and deal 0 direct damage to self. 70% chance to increase self damage.";
            ability1.cost = new ManaColorSO[2]
            {
        Pigments.Red,
        Pigments.Red
            };
            ability1.sprite = ResourceLoader.LoadSprite("MaruSadisticSadismIcon");
            ability1.effects = new Effect[3];
            ability1.effects[0] = new Effect((EffectSO)ScriptableObject.CreateInstance<DamageEffect>(), 10, new IntentType?(IntentType.Damage_7_10), Slots.Front);
            ability1.effects[1] = new Effect((EffectSO)instance1, 0, new IntentType?(IntentType.Damage_1_2), Slots.Self);
            ability1.effects[2] = new Effect((EffectSO)instance2, 1, new IntentType?(), Slots.Self, (EffectConditionSO)Conditions.Chance(70));
            ability1.visuals = LoadedAssetsHandler.GetEnemy("Psaltery_EN").abilities[0].ability.visuals;
            ability1.animationTarget = Slots.Front;
            CasterStoredValueChangeEffect instance3 = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
            instance3._valueName = (UnitStoredValueNames)59997;
            instance3._increase = true;
            Ability ability2 = new Ability();
            ability2.name = "Strawberry Flavor";
            ability2.description = "Apply 2 Shield and 2 Anesthetics to self. Increase Noise value by 1.";
            ability2.cost = new ManaColorSO[2]
            {
        Pigments.Blue,
        Pigments.Blue
            };
            ability2.sprite = ResourceLoader.LoadSprite("MaruSadisticDrugsIcon");
            ability2.effects = new Effect[3];
            ability2.effects[0] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 2, new IntentType?(IntentType.Field_Shield), Slots.Self);
            ability2.effects[1] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyAnestheticsEffect>(), 2, new IntentType?((IntentType)987898), Slots.Self);
            ability2.effects[2] = new Effect((EffectSO)instance3, 1, new IntentType?(IntentType.Misc), Slots.Self);
            ability2.visuals = LoadedAssetsHandler.GetEnemy("Flarb_EN").abilities[1].ability.visuals;
            ability2.animationTarget = Slots.Self;
            IndirectPlusStoredValueEffect instance4 = ScriptableObject.CreateInstance<IndirectPlusStoredValueEffect>();
            instance4._valueName = (UnitStoredValueNames)59997;
            NoiseBothValuesChangeEffect instance5 = ScriptableObject.CreateInstance<NoiseBothValuesChangeEffect>();
            instance5._minimumValue = 0;
            instance5._valueName = (UnitStoredValueNames)59997;
            instance5._increase = true;
            Ability ability3 = new Ability();
            ability3.name = "Background Noise";
            ability3.description = "Deal 2 indirect damage to all enemies. This move has a 40% chance to increase damage by 1. If successful, the percent chance decreases by 5.";
            ability3.cost = new ManaColorSO[2]
            {
        Pigments.Yellow,
        Pigments.Purple
            };
            ability3.sprite = ResourceLoader.LoadSprite("MaruSadisticNoiseIcon");
            ability3.effects = new Effect[2];
            ability3.effects[0] = new Effect((EffectSO)instance4, 2, new IntentType?(IntentType.Damage_1_2), Slots.SlotTarget(new int[9]
            {
        4,
        3,
        2,
        1,
        0,
        -1,
        -2,
        -3,
        -4
            }));
            ability3.effects[1] = new Effect((EffectSO)instance5, 1, new IntentType?(), Slots.Self);
            ability3.visuals = LoadedAssetsHandler.GetEnemy("Charcarrion_Alive_BOSS").abilities[2].ability.visuals;
            ability3.animationTarget = Slots.SlotTarget(new int[9]
            {
        4,
        3,
        2,
        1,
        0,
        -1,
        -2,
        -3,
        -4
            });
            Ability ability4 = ability1.Duplicate();
            ability4.name = "Marunouchi Bully";
            ability4.description = "Deal 12 damage to the opposing enemy and deal 0 direct damage to self. 60% chance to increase self damage.";
            ability4.effects[0]._entryVariable = 12;
            ability4.effects[0]._intent = new IntentType?(IntentType.Damage_11_15);
            ability4.effects[2]._condition = (EffectConditionSO)Conditions.Chance(60);
            Ability ability5 = ability2.Duplicate();
            ability5.name = "Blueberry Flavor";
            ability5.description = "Apply 4 Shield and 2 Anesthetics to self. Increase Noise value by 1.";
            ability5.effects[0]._entryVariable = 4;
            ability5.effects[1]._entryVariable = 2;
            Ability ability6 = ability3.Duplicate();
            ability6.name = "Violent Noise";
            ability6.description = "Deal 3 indirect damage to all enemies. This move has a 50% chance to increase damage by 1. If successful, the percent chance decreases by 10s.";
            ability6.effects[0]._entryVariable = 3;
            ability6.effects[1]._entryVariable = 2;
            ability6.cost = new ManaColorSO[1] { Pigments.Purple };
            Ability ability7 = ability4.Duplicate();
            ability7.name = "Marunouchi Cruel";
            ability7.description = "Deal 14 damage to the opposing enemy and deal 0 direct damage to self. 50% chance to increase self damage.";
            ability7.effects[0]._entryVariable = 14;
            ability7.effects[2]._condition = (EffectConditionSO)Conditions.Chance(50);
            Ability ability8 = ability5.Duplicate();
            ability8.name = "Raspberry Flavor";
            ability8.description = "Apply 5 Shield and 3 Anesthetics to self. Increase Noise value by 1.";
            ability8.cost = new ManaColorSO[2]
            {
        Pigments.Blue,
        Pigments.SplitPigment(Pigments.Blue, Pigments.Yellow)
            };
            ability8.effects[0]._entryVariable = 5;
            ability8.effects[1]._entryVariable = 3;
            ability8.cost = new ManaColorSO[2]
            {
        Pigments.Blue,
        Pigments.SplitPigment(Pigments.Blue, Pigments.Yellow)
            };
            Ability ability9 = ability6.Duplicate();
            ability9.name = "Violent Noise";
            ability9.description = "Deal 4 indirect damage to all enemies. This move has a 60% chance to increase damage by 1. If successful, the percent chance decreases by 15.";
            ability9.effects[0]._entryVariable = 4;
            ability9.effects[1]._entryVariable = 3;
            ability9.cost = new ManaColorSO[1]
            {
        Pigments.SplitPigment(Pigments.Purple, Pigments.Red)
            };
            Ability ability10 = ability7.Duplicate();
            ability10.name = "Marunouchi Sadistic";
            ability10.description = "Deal 16 damage to the opposing enemy and deal 0 direct damage to self. 40% chance to increase self damage.";
            ability10.effects[0]._entryVariable = 16;
            ability10.effects[0]._intent = new IntentType?(IntentType.Damage_16_20);
            ability10.effects[2]._condition = (EffectConditionSO)Conditions.Chance(40);
            Ability ability11 = ability8.Duplicate();
            ability11.name = "Cherry Flavor";
            ability11.description = "Apply 6 Shield and 4 Anesthetics to self. Increase Noise value by 1.";
            ability11.effects[0]._entryVariable = 6;
            ability11.effects[1]._entryVariable = 4;
            Ability ability12 = ability9.Duplicate();
            ability12.name = "Radiant Noise";
            ability12.description = "Deal 5 indirect damage to all enemies. This move has a 70% chance to increase damage by 1. If successful, the percent chance decreases by 20.";
            ability12.effects[0]._entryVariable = 5;
            ability12.effects[1]._entryVariable = 4;
            character.AddLevel(10, new Ability[3]
            {
        ability1,
        ability2,
        ability3
            }, 0);
            character.AddLevel(13, new Ability[3]
            {
        ability4,
        ability5,
        ability6
            }, 1);
            character.AddLevel(16, new Ability[3]
            {
        ability7,
        ability8,
        ability9
            }, 2);
            character.AddLevel(18, new Ability[3]
            {
        ability10,
        ability11,
        ability12
            }, 3);
            _03_TheNoise.Chara = character;
            if (!Joyce.IncludeTheNoise)
                return;
            character.AddCharacter();
            LoadedAssetsHandler.GetCharcater("MarunouchiSadistic_CH")._characterName = "Marunouchi Sadistic";
        }
    }
}
