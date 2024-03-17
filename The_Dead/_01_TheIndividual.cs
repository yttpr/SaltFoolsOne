// Decompiled with JetBrains decompiler
// Type: THE_DEAD._01_TheIndividual
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using BrutalAPI;
using UnityEngine;

namespace THE_DEAD
{
    public static class _01_TheIndividual
    {
        public static void Add()
        {
            Character character = new Character();
            character.name = "PlaceholderName";
            character.healthColor = Pigments.Gray;
            character.entityID = (EntityIDs)98788;
            character.overworldSprite = ResourceLoader.LoadSprite("Placeholder Overworld", pivot: new Vector2?(new Vector2(0.5f, 0.0f)));
            character.frontSprite = ResourceLoader.LoadSprite("Placeholder Front");
            character.backSprite = ResourceLoader.LoadSprite("Placeholder Back");
            character.lockedSprite = ResourceLoader.LoadSprite("Placeholder Locked");
            character.unlockedSprite = ResourceLoader.LoadSprite("Placeholder Scribble");
            character.menuChar = true;
            character.isSupport = false;
            character.usesBaseAbility = false;
            character.usesAllAbilities = true;
            character.walksInOverworld = true;
            character.hurtSound = LoadedAssetsHandler.GetCharcater("Doll_CH").damageSound;
            character.deathSound = LoadedAssetsHandler.GetCharcater("Doll_CH").deathSound;
            character.dialogueSound = LoadedAssetsHandler.GetCharcater("Doll_CH").dxSound;
            Ability ability1 = new Ability();
            ability1.name = "Move 1 Lv 0";
            ability1.description = "Heal 1 and shield 2 self.";
            ability1.cost = new ManaColorSO[1] { Pigments.Gray };
            ability1.sprite = ResourceLoader.LoadSprite("Gray 1");
            ability1.effects = new Effect[3];
            ability1.effects[0] = new Effect((EffectSO)ScriptableObject.CreateInstance<HealEffect>(), 1, new IntentType?(IntentType.Heal_1_4), Slots.Self);
            ability1.effects[1] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 2, new IntentType?(IntentType.Field_Shield), Slots.Self);
            ability1.effects[2] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyFocusedEffect>(), 1, new IntentType?(), Slots.Self, (EffectConditionSO)Conditions.Chance(1));
            ability1.visuals = LoadedAssetsHandler.GetCharcater("Hans_CH").rankedData[1].rankAbilities[0].ability.visuals;
            ability1.animationTarget = Slots.Self;
            Ability ability2 = ability1.Duplicate();
            ability2.name = "Move 1 Lv 1";
            ability2.description = "Heal 2 and shield 2 self.";
            ability2.effects[0]._entryVariable = 2;
            Ability ability3 = ability2.Duplicate();
            ability3.name = "Move 1 Lv 2";
            ability3.description = "Heal 2 and shield 4 self";
            ability3.effects[1]._entryVariable = 4;
            Ability ability4 = ability3.Duplicate();
            ability4.name = "Move 1 Lv 3";
            ability4.description = "Heal 3 and shield 5 self.";
            ability4.effects[0]._entryVariable = 3;
            ability4.effects[1]._entryVariable = 5;
            Ability ability5 = new Ability();
            ability5.name = "Move 2 Lv 0";
            ability5.description = "Deal 4 damage to the opposing enemy.";
            ability5.cost = new ManaColorSO[2]
            {
        Pigments.Gray,
        Pigments.Gray
            };
            ability5.sprite = ResourceLoader.LoadSprite("Gray 2");
            ability5.effects = new Effect[2];
            ability5.effects[0] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyFocusedEffect>(), 1, new IntentType?(), Slots.Self, (EffectConditionSO)Conditions.Chance(1));
            ability5.effects[1] = new Effect((EffectSO)ScriptableObject.CreateInstance<DamageEffect>(), 4, new IntentType?(IntentType.Damage_3_6), Slots.Front);
            ability5.visuals = LoadedAssetsHandler.GetCharcater("Kleiver_CH").rankedData[0].rankAbilities[0].ability.visuals;
            ability5.animationTarget = Slots.Front;
            Ability ability6 = ability5.Duplicate();
            ability6.name = "Move 2 Lv 1";
            ability6.description = "Deal 6 damage to the opposing enemy.";
            ability6.effects[1]._entryVariable = 6;
            Ability ability7 = ability6.Duplicate();
            ability7.name = "Move 2 Lv 2";
            ability7.description = "Deal 8 damage to the opposing enemy.";
            ability7.effects[1]._entryVariable = 8;
            ability7.effects[1]._intent = new IntentType?(IntentType.Damage_7_10);
            Ability ability8 = ability7.Duplicate();
            ability8.name = "Move 2 Lv 3";
            ability8.description = "Deal 10 damage to the opposing enemy.";
            ability8.effects[1]._entryVariable = 10;
            Ability ability9 = new Ability();
            ability9.name = "Move 3 Lv 0";
            ability9.description = "Deal 3 damage to the left and right enemies.";
            ability9.cost = new ManaColorSO[3]
            {
        Pigments.Gray,
        Pigments.Gray,
        Pigments.Gray
            };
            ability9.sprite = ResourceLoader.LoadSprite("Gray 3");
            ability9.effects = new Effect[2];
            ability9.effects[0] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyFocusedEffect>(), 1, new IntentType?(), Slots.Self, (EffectConditionSO)Conditions.Chance(1));
            ability9.effects[1] = new Effect((EffectSO)ScriptableObject.CreateInstance<DamageEffect>(), 3, new IntentType?(IntentType.Damage_3_6), Slots.LeftRight);
            ability9.visuals = LoadedAssetsHandler.GetCharcater("Boyle_CH").rankedData[0].rankAbilities[0].ability.visuals;
            ability9.animationTarget = Slots.LeftRight;
            Ability ability10 = ability9.Duplicate();
            ability10.name = "Move 3 Lv 1";
            ability10.description = "Deal 4 damage to the left and right enemies.";
            ability10.effects[1]._entryVariable = 4;
            Ability ability11 = ability10.Duplicate();
            ability11.name = "Move 3 Lv 2";
            ability11.description = "Deal 6 damage to the left and right enemies";
            ability11.effects[1]._entryVariable = 6;
            Ability ability12 = ability11.Duplicate();
            ability12.name = "Move 3 Lv 3";
            ability12.description = "Deal 8 damage to the left, right, and opposing enemies.";
            ability12.effects[1]._entryVariable = 8;
            ability12.effects[1]._intent = new IntentType?(IntentType.Damage_7_10);
            ability12.effects[1]._target = Slots.FrontLeftRight;
            ability12.animationTarget = Slots.FrontLeftRight;
            character.AddLevel(8, new Ability[3]
            {
        ability1,
        ability5,
        ability9
            }, 0);
            character.AddLevel(12, new Ability[3]
            {
        ability2,
        ability6,
        ability10
            }, 1);
            character.AddLevel(16, new Ability[3]
            {
        ability3,
        ability7,
        ability11
            }, 2);
            character.AddLevel(20, new Ability[3]
            {
        ability4,
        ability8,
        ability12
            }, 3);
            if (!Joyce.IncludeTheIndividual)
                return;
            character.AddCharacter();
        }
    }
}
