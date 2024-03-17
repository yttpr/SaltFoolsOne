// Decompiled with JetBrains decompiler
// Type: THE_DEAD._02_TheFree
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using BrutalAPI;
using UnityEngine;

namespace THE_DEAD
{
    public static class _02_TheFree
    {
        public static Character Chara;

        public static void Add()
        {
            Character character = new Character();
            character.name = "Verne";
            character.healthColor = Pigments.Purple;
            character.entityID = (EntityIDs)98787;
            character.overworldSprite = ResourceLoader.LoadSprite("Free Overworld", pivot: new Vector2?(new Vector2(0.5f, 0.0f)));
            character.frontSprite = ResourceLoader.LoadSprite("Free Front");
            character.backSprite = ResourceLoader.LoadSprite("Free Back");
            character.lockedSprite = ResourceLoader.LoadSprite("Free Locked");
            character.unlockedSprite = ResourceLoader.LoadSprite("Free Unlocked");
            character.passives = new BasePassiveAbilitySO[1]
            {
        Passives.Dying
            };
            character.menuChar = true;
            character.isSupport = false;
            character.walksInOverworld = true;
            character.hurtSound = "event:/Characters/NPC/Mordrake/CHR_NPC_Mordrake_Cracked_Dx";
            character.deathSound = LoadedAssetsHandler.GetCharcater("Gospel_CH").deathSound;
            character.dialogueSound = "event:/Characters/NPC/Mordrake/CHR_NPC_Mordrake_Cracked_Dx";
            Ability ability1 = new Ability();
            ability1.name = "Destructive Rockets";
            ability1.description = "Deal 4 damage to the opposing enemy, 30% chance to triple damage. Deal 4 indirect damage to the left and right enemies, 5 % chance to double damage.";
            ability1.cost = new ManaColorSO[5]
            {
        Pigments.Gray,
        Pigments.Gray,
        Pigments.Gray,
        Pigments.Gray,
        Pigments.Gray
            };
            ability1.sprite = ResourceLoader.LoadSprite("Free Combat Rocket");
            ability1.effects = new Effect[7];
            ability1.effects[0] = new Effect((EffectSO)ScriptableObject.CreateInstance<ExitValueSetterEffect>(), 30, new IntentType?(), Slots.Self);
            ability1.effects[1] = new Effect((EffectSO)ScriptableObject.CreateInstance<DamageMaybeTripleEffect>(), 4, new IntentType?(IntentType.Damage_3_6), Slots.Front);
            ability1.effects[2] = new Effect((EffectSO)ScriptableObject.CreateInstance<ExitValueSetterEffect>(), 5, new IntentType?(), Slots.Self);
            ability1.effects[3] = new Effect((EffectSO)ScriptableObject.CreateInstance<DamageMaybeDoubleEffect>(), 4, new IntentType?(IntentType.Damage_3_6), Slots.Right);
            ((DamageMaybeDoubleEffect)ability1.effects[3]._effect)._indirect = true;
            ability1.effects[4] = new Effect((EffectSO)ScriptableObject.CreateInstance<ExitValueSetterEffect>(), 5, new IntentType?(), Slots.Self);
            ability1.effects[5] = new Effect((EffectSO)ScriptableObject.CreateInstance<DamageMaybeDoubleEffect>(), 4, new IntentType?(IntentType.Damage_3_6), Slots.Left);
            ((DamageMaybeDoubleEffect)ability1.effects[5]._effect)._indirect = true;
            ability1.effects[6] = new Effect((EffectSO)ScriptableObject.CreateInstance<DamageEffect>(), 2, new IntentType?(IntentType.Damage_1_2), Slots.Self);
            ability1.visuals = LoadedAssetsHandler.GetEnemy("Voboola_EN").abilities[0].ability.visuals;
            ability1.animationTarget = Slots.FrontLeftRight;
            Ability ability2 = ability1.Duplicate();
            ability2.name = "Demolishing Rockets";
            ability2.description = "Deal 6 damage to the opposing enemy, 40% chance to triple damage. Deal 5 indirect damage to the left and right enemies, 15% chance to double damage.";
            ability2.effects[0]._entryVariable = 40;
            ability2.effects[1]._entryVariable = 6;
            ability2.effects[2]._entryVariable = 15;
            ability2.effects[3]._entryVariable = 5;
            ability2.effects[4]._entryVariable = 15;
            ability2.effects[5]._entryVariable = 5;
            Ability ability3 = ability2.Duplicate();
            ability3.name = "Obliterating Rockets";
            ability3.description = "Deal 8 damage to the opposing enemy, 50% chance to triple damage. Deal 6 indirect damage to the left and right enemies, 25% chance to double damage.";
            ability3.effects[0]._entryVariable = 50;
            ability3.effects[1]._entryVariable = 8;
            ability3.effects[1]._intent = new IntentType?(IntentType.Damage_7_10);
            ability3.effects[2]._entryVariable = 25;
            ability3.effects[3]._entryVariable = 6;
            ability3.effects[4]._entryVariable = 25;
            ability3.effects[5]._entryVariable = 6;
            Ability ability4 = ability3.Duplicate();
            ability4.name = "Apocalyptic Rockets";
            ability4.description = "Deal 12 damage to the opposing enemy, 55% chance to triple damage. Deal 8 indirect damage to the left and right enemies, 40% chance to double damage. Deal 2 direct damage to self.";
            ability4.cost = new ManaColorSO[3]
            {
        Pigments.Red,
        Pigments.Red,
        Pigments.Red
            };
            ability4.effects[0]._entryVariable = 55;
            ability4.effects[1]._entryVariable = 12;
            ability4.effects[2]._entryVariable = 40;
            ability4.effects[3]._entryVariable = 8;
            ability4.effects[3]._intent = new IntentType?(IntentType.Damage_7_10);
            ability4.effects[4]._entryVariable = 40;
            ability4.effects[5]._entryVariable = 8;
            ability4.effects[5]._intent = new IntentType?(IntentType.Damage_7_10);
            character.baseAbility = ability4;
            Ability ability5 = new Ability();
            ability5.name = "Painful Beam";
            ability5.description = "Deal 5 damage to the left enemy.";
            ability5.cost = new ManaColorSO[3]
            {
        Pigments.Yellow,
        Pigments.Red,
        Pigments.Blue
            };
            ability5.sprite = ResourceLoader.LoadSprite("Free Combat Laser Left");
            ability5.effects = new Effect[3];
            ability5.effects[0] = new Effect((EffectSO)ScriptableObject.CreateInstance<DamageEffect>(), 5, new IntentType?(IntentType.Damage_3_6), Slots.SlotTarget(new int[1]
            {
        -1
            }));
            ability5.effects[1] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), 1, new IntentType?(), Slots.Left, (EffectConditionSO)Conditions.Chance(0));
            ability5.effects[2] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), 1, new IntentType?(), Slots.Left, (EffectConditionSO)Conditions.Chance(0));
            ability5.visuals = LoadedAssetsHandler.GetEnemy("HeavensGatePurple_BOSS").abilities[1].ability.visuals;
            ability5.animationTarget = Slots.SlotTarget(new int[1]
            {
        -1
            });
            Ability ability6 = ability5.Duplicate();
            ability6.name = "Powerful Beam";
            ability6.description = "Deal 7 damage to the left and far left enemies";
            ability6.effects[0]._entryVariable = 7;
            ability6.effects[0]._intent = new IntentType?(IntentType.Damage_7_10);
            ability6.effects[0]._target = Slots.SlotTarget(new int[2]
            {
        -1,
        -2
            });
            ability6.animationTarget = Slots.SlotTarget(new int[2]
            {
        -1,
        -2
            });
            Ability ability7 = ability6.Duplicate();
            ability7.name = "Scorching Beam";
            ability7.description = "Deal 9 damage to the 3 enemies to the left. Inflict 1 fire to the left enemy.";
            ability7.cost = new ManaColorSO[4]
            {
        Pigments.Yellow,
        Pigments.Red,
        Pigments.Blue,
        Pigments.Gray
            };
            ability7.effects[0]._entryVariable = 9;
            ability7.effects[0]._target = Slots.SlotTarget(new int[3]
            {
        -1,
        -2,
        -3
            });
            ability7.effects[1]._intent = new IntentType?(IntentType.Field_Fire);
            ability7.effects[1]._condition = (EffectConditionSO)null;
            ability7.animationTarget = Slots.SlotTarget(new int[3]
            {
        -1,
        -2,
        -3
            });
            Ability ability8 = ability7.Duplicate();
            ability8.name = "Radioactive Beam";
            ability8.description = "Deal 10 damage to all enemies to the left. Inflict 1-2 fire to the left enemy.";
            ability8.effects[0]._entryVariable = 10;
            ability8.effects[0]._target = Slots.SlotTarget(new int[4]
            {
        -1,
        -2,
        -3,
        -4
            });
            ability8.effects[2]._condition = (EffectConditionSO)Conditions.Chance(50);
            ability8.animationTarget = Slots.SlotTarget(new int[4]
            {
        -1,
        -2,
        -3,
        -4
            });
            Ability ability9 = new Ability();
            ability9.name = "Painful Ray";
            ability9.description = "Deal 5 damage to the right enemy.";
            ability9.cost = new ManaColorSO[3]
            {
        Pigments.Yellow,
        Pigments.Blue,
        Pigments.Red
            };
            ability9.sprite = ResourceLoader.LoadSprite("Free Combat Laser Right");
            ability9.effects = new Effect[3];
            ability9.effects[0] = new Effect((EffectSO)ScriptableObject.CreateInstance<DamageEffect>(), 5, new IntentType?(IntentType.Damage_3_6), Slots.SlotTarget(new int[1]
            {
        1
            }));
            ability9.effects[1] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 1, new IntentType?(), Slots.Right, (EffectConditionSO)Conditions.Chance(0));
            ability9.effects[2] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyFrailEffect>(), 1, new IntentType?(), Slots.Right, (EffectConditionSO)Conditions.Chance(0));
            ability9.visuals = LoadedAssetsHandler.GetEnemy("HeavensGatePurple_BOSS").abilities[1].ability.visuals;
            ability9.animationTarget = Slots.SlotTarget(new int[1]
            {
        1
            });
            Ability ability10 = ability9.Duplicate();
            ability10.name = "Powerful Ray";
            ability10.description = "Deal 7 damage to the right and far right enemies";
            ability10.effects[0]._entryVariable = 7;
            ability10.effects[0]._intent = new IntentType?(IntentType.Damage_7_10);
            ability10.effects[0]._target = Slots.SlotTarget(new int[2]
            {
        1,
        2
            });
            ability10.animationTarget = Slots.SlotTarget(new int[2]
            {
        1,
        2
            });
            Ability ability11 = ability10.Duplicate();
            ability11.name = "Crippling Ray";
            ability11.description = "Deal 9 damage to the 3 enemies to the right. Inflict 1 ruptured to the right enemy.";
            ability11.cost = new ManaColorSO[4]
            {
        Pigments.Yellow,
        Pigments.Blue,
        Pigments.Red,
        Pigments.Gray
            };
            ability11.effects[0]._entryVariable = 9;
            ability11.effects[0]._target = Slots.SlotTarget(new int[3]
            {
        1,
        2,
        3
            });
            ability11.effects[1]._intent = new IntentType?(IntentType.Status_Ruptured);
            ability11.effects[1]._condition = (EffectConditionSO)null;
            ability11.animationTarget = Slots.SlotTarget(new int[3]
            {
        1,
        2,
        3
            });
            Ability ability12 = ability11.Duplicate();
            ability12.name = "Disintegrating Ray";
            ability12.description = "Deal 10 damage to all enemies to the right. Inflict 2 ruptured to the right enemy, 50% chance to inflict 1 frail as well.";
            ability12.effects[0]._entryVariable = 10;
            ability12.effects[0]._target = Slots.SlotTarget(new int[4]
            {
        1,
        2,
        3,
        4
            });
            ability12.effects[1]._entryVariable = 2;
            ability12.effects[2]._intent = new IntentType?(IntentType.Status_Frail);
            ability12.effects[2]._condition = (EffectConditionSO)Conditions.Chance(50);
            ability12.animationTarget = Slots.SlotTarget(new int[4]
            {
        1,
        2,
        3,
        4
            });
            Ability ability13 = new Ability();
            ability13.name = "Annoying Machine Guns";
            ability13.description = "Consume up to 4 pigment. Deal 3 damage to the opposing enemy for every 2 pigment consumed.";
            ability13.cost = new ManaColorSO[1] { Pigments.Yellow };
            ability13.sprite = ResourceLoader.LoadSprite("Free Combat Guns");
            ability13.effects = new Effect[12];
            ability13.effects[0] = new Effect((EffectSO)ScriptableObject.CreateInstance<ConsumeRandomManaEffect>(), 4, new IntentType?(IntentType.Mana_Consume), Slots.Self);
            ability13.effects[1] = new Effect((EffectSO)ScriptableObject.CreateInstance<MachineGunsValueSetEffect>(), 1, new IntentType?(), Slots.Self);
            ability13.effects[2] = new Effect((EffectSO)ScriptableObject.CreateInstance<ExitValueSetterEffect>(), 3, new IntentType?(), Slots.Self);
            ability13.effects[3] = new Effect((EffectSO)ScriptableObject.CreateInstance<MachineGunFirstHit>(), 3, new IntentType?(IntentType.Damage_3_6), Slots.Front);
            ((MachineGunFirstHit)ability13.effects[3]._effect)._randomBetweenPrevious = false;
            ability13.effects[4] = new Effect((EffectSO)ScriptableObject.CreateInstance<ExitValueSetterEffect>(), 3, new IntentType?(), Slots.Self);
            ability13.effects[5] = new Effect((EffectSO)ScriptableObject.CreateInstance<MachineGunSecondHit>(), 3, new IntentType?(IntentType.Damage_3_6), Slots.Front);
            ((MachineGunSecondHit)ability13.effects[5]._effect)._randomBetweenPrevious = false;
            ability13.effects[6] = new Effect((EffectSO)ScriptableObject.CreateInstance<ExitValueSetterEffect>(), 3, new IntentType?(), Slots.Self);
            ability13.effects[7] = new Effect((EffectSO)ScriptableObject.CreateInstance<MachineGunThirdHit>(), 3, new IntentType?(), Slots.Front);
            ((MachineGunThirdHit)ability13.effects[7]._effect)._randomBetweenPrevious = false;
            ability13.effects[8] = new Effect((EffectSO)ScriptableObject.CreateInstance<ExitValueSetterEffect>(), 3, new IntentType?(), Slots.Self);
            ability13.effects[9] = new Effect((EffectSO)ScriptableObject.CreateInstance<MachineGunFourthHit>(), 3, new IntentType?(), Slots.Front);
            ((MachineGunFourthHit)ability13.effects[9]._effect)._randomBetweenPrevious = false;
            ability13.effects[10] = new Effect((EffectSO)ScriptableObject.CreateInstance<ExitValueSetterEffect>(), 3, new IntentType?(), Slots.Self);
            ability13.effects[11] = new Effect((EffectSO)ScriptableObject.CreateInstance<MachineGunFifthHit>(), 3, new IntentType?(), Slots.Front);
            ((MachineGunFifthHit)ability13.effects[11]._effect)._randomBetweenPrevious = false;
            ability13.visuals = LoadedAssetsHandler.GetCharcater("Anton_CH").rankedData[0].rankAbilities[0].ability.visuals;
            ability13.animationTarget = Slots.Front;
            Ability ability14 = ability13.Duplicate();
            ability14.name = "Pestering Machine Guns.";
            ability14.description = "Consume up to 6 pigment. Deal 3-4 damage to the opposing enemy for every 2 pigment consumed.";
            ability14.effects[0]._entryVariable = 6;
            ability14.effects[2]._entryVariable = 3;
            ability14.effects[4]._entryVariable = 3;
            ability14.effects[6]._entryVariable = 3;
            ability14.effects[8]._entryVariable = 3;
            ability14.effects[10]._entryVariable = 3;
            ability14.effects[3]._entryVariable = 4;
            ((MachineGunFirstHit)ability14.effects[3]._effect)._randomBetweenPrevious = true;
            ability14.effects[5]._entryVariable = 4;
            ((MachineGunSecondHit)ability14.effects[5]._effect)._randomBetweenPrevious = true;
            ability14.effects[7]._entryVariable = 4;
            ((MachineGunThirdHit)ability14.effects[7]._effect)._randomBetweenPrevious = true;
            ability14.effects[9]._entryVariable = 4;
            ((MachineGunFourthHit)ability14.effects[9]._effect)._randomBetweenPrevious = true;
            ability14.effects[11]._entryVariable = 4;
            ((MachineGunFifthHit)ability14.effects[11]._effect)._randomBetweenPrevious = true;
            ability14.effects[7]._intent = new IntentType?(IntentType.Damage_3_6);
            Ability ability15 = ability14.Duplicate();
            ability15.name = "Harassing Machine Guns.";
            ability15.description = "Consume up to 8 pigment. Deal 2-5 damage to the opposing enemy for every 2 pigment consumed.";
            ability15.effects[0]._entryVariable = 8;
            ability15.effects[2]._entryVariable = 2;
            ability15.effects[4]._entryVariable = 2;
            ability15.effects[6]._entryVariable = 2;
            ability15.effects[8]._entryVariable = 2;
            ability15.effects[10]._entryVariable = 2;
            ability14.effects[3]._entryVariable = 5;
            ability14.effects[5]._entryVariable = 5;
            ability14.effects[7]._entryVariable = 5;
            ability14.effects[9]._entryVariable = 5;
            ability14.effects[11]._entryVariable = 5;
            ability15.effects[9]._intent = new IntentType?(IntentType.Damage_3_6);
            Ability ability16 = ability15.Duplicate();
            ability16.name = "Hounding Machine Guns.";
            ability16.description = "Consume up to 10 pigment. Deal 2-6 damage to the opposing enemy for every 2 pigment consumed.";
            ability16.effects[0]._entryVariable = 10;
            ability16.effects[3]._entryVariable = 6;
            ability16.effects[5]._entryVariable = 6;
            ability16.effects[7]._entryVariable = 6;
            ability16.effects[9]._entryVariable = 6;
            ability16.effects[11]._entryVariable = 6;
            ability16.effects[11]._intent = new IntentType?(IntentType.Damage_3_6);
            character.AddLevel(20, new Ability[3]
            {
        ability5,
        ability9,
        ability13
            }, 0);
            character.AddLevel(22, new Ability[3]
            {
        ability6,
        ability10,
        ability14
            }, 1);
            character.AddLevel(24, new Ability[3]
            {
        ability7,
        ability11,
        ability15
            }, 2);
            character.AddLevel(25, new Ability[3]
            {
        ability8,
        ability12,
        ability16
            }, 3);
            _02_TheFree.Chara = character;
            if (!Joyce.IncludeTheFree)
                return;
            character.AddCharacter();
        }
    }
}
