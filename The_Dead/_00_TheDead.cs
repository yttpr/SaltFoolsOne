// Decompiled with JetBrains decompiler
// Type: THE_DEAD._00_TheDead
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using BrutalAPI;
using UnityEngine;

namespace THE_DEAD
{
    public static class _00_TheDead
    {
        public static Character Chara;

        public static void Add()
        {
            Character character = new Character()
            {
                name = "Didion",
                healthColor = Pigments.Purple,
                entityID = (EntityIDs)98789,
                overworldSprite = ResourceLoader.LoadSprite("Dead Overworld", pivot: new Vector2?(new Vector2(0.5f, 0.0f))),
                frontSprite = ResourceLoader.LoadSprite("Dead Front"),
                backSprite = ResourceLoader.LoadSprite("Dead Back"),
                lockedSprite = ResourceLoader.LoadSprite("Dead Locked"),
                unlockedSprite = ResourceLoader.LoadSprite("Dead Unlocked"),
                menuChar = true,
                isSupport = true,
                walksInOverworld = true,
                hurtSound = LoadedAssetsHandler.GetEnemy("Sepulchre_EN").damageSound,
                deathSound = LoadedAssetsHandler.GetEnemy("Sepulchre_EN").deathSound
            };
            character.dialogueSound = character.hurtSound;
            character.passives = new BasePassiveAbilitySO[2]
            {
        Passives.Skittish,
        Passives.Withering
            };
            ScriptableObject.CreateInstance<ChangeMaxHealthEffect>()._increase = false;
            Ability ability1 = new Ability();
            ability1.name = "It Can Never Be True";
            ability1.description = "If the Opposing enemy has less health than this party member, apply Withering as a passive to them.";
            ability1.cost = new ManaColorSO[1]
            {
        Pigments.SplitPigment(Pigments.Purple, Pigments.Yellow)
            };
            ability1.sprite = ResourceLoader.LoadSprite("Dead Not True");
            ability1.effects = new Effect[1];
            CustomIntentInfo customIntentInfo = new CustomIntentInfo("Withering", (IntentType)731905, Passives.Withering.passiveIcon, IntentType.Damage_Death);
            ability1.effects[0] = new Effect((EffectSO)ScriptableObject.CreateInstance<WitherIfLessHealthEffect>(), 5, new IntentType?(CustomIntentIconSystem.GetIntent("Withering")), Slots.Front);
            ability1.visuals = LoadedAssetsHandler.GetEnemyAbility("Sob_A").visuals;
            ability1.animationTarget = (BaseCombatTargettingSO)MultiTargetting.Create(Slots.Self, Slots.Front);
            character.baseAbility = ability1;
            Ability ability2 = new Ability();
            ability2.name = "False Joy";
            ability2.description = "Apply 2 Shield to the Left and Right allies and heal them for this party member's missing health. Inflict 2 frail on self.";
            ability2.cost = new ManaColorSO[3]
            {
        Pigments.Yellow,
        Pigments.Blue,
        Pigments.Blue
            };
            ability2.sprite = ResourceLoader.LoadSprite("Dead False");
            ability2.effects = new Effect[3];
            ability2.effects[0] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 2, new IntentType?(IntentType.Field_Shield), Slots.SlotTarget(new int[2]
            {
        -1,
        1
            }, true));
            ability2.effects[1] = new Effect((EffectSO)ScriptableObject.CreateInstance<HealMissingHealthEffect>(), 2, new IntentType?(IntentType.Heal_1_4), Slots.SlotTarget(new int[2]
            {
        -1,
        1
            }, true));
            ability2.effects[2] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyFrailEffect>(), 2, new IntentType?(IntentType.Status_Frail), Slots.Self, (EffectConditionSO)Conditions.Chance(100));
            ability2.visuals = LoadedAssetsHandler.GetEnemy("Visage_Mother_EN").abilities[0].ability.visuals;
            ability2.animationTarget = Slots.Self;
            Ability ability3 = ability2.Duplicate();
            ability3.name = "False Fulfillment";
            ability3.description = "Apply 4 Shield to the Left and Right allies and heal them for this party member's missing health. Inflict 2 frail on self.";
            ability3.cost = new ManaColorSO[2]
            {
        Pigments.Blue,
        Pigments.Blue
            };
            ability3.effects[0]._entryVariable = 4;
            ability3.effects[2]._entryVariable = 1;
            Ability ability4 = ability3.Duplicate();
            ability4.name = "False Life";
            ability4.description = "Apply 5 Shield to the Left and Right allies and heal them for this party member's missing health. Inflict 2 frail on self.";
            ability4.cost = new ManaColorSO[2]
            {
        Pigments.SplitPigment(Pigments.Blue, Pigments.Yellow),
        Pigments.Blue
            };
            ability4.effects[0]._entryVariable = 5;
            ability4.effects[1]._entryVariable = 3;
            ability4.effects[2]._entryVariable = 2;
            Ability ability5 = ability4.Duplicate();
            ability5.name = "False Existence";
            ability5.description = "Apply 7 Shield to the Left and Right allies and heal them for this party member's missing health. Inflict 2 frail on self.";
            ability5.cost = new ManaColorSO[2]
            {
        Pigments.SplitPigment(Pigments.Blue, Pigments.Yellow),
        Pigments.SplitPigment(Pigments.Blue, Pigments.Yellow)
            };
            ability5.effects[0]._entryVariable = 7;
            Ability ability6 = new Ability();
            ability6.name = "Somewhere Nice";
            ability6.description = "Consume 1 blue pigment if possible. Apply 7 Shield on the Left and Right ally positions.\nRemove all Constricted from self.";
            ability6.cost = new ManaColorSO[2]
            {
        Pigments.Blue,
        Pigments.Yellow
            };
            ability6.sprite = ResourceLoader.LoadSprite("Dead Anywhere");
            ability6.effects = new Effect[3];
            ability6.effects[0] = new Effect((EffectSO)ScriptableObject.CreateInstance<ConsumeBlueManaEffect>(), 1, new IntentType?(IntentType.Mana_Consume), Slots.Self);
            ability6.effects[1] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 7, new IntentType?(IntentType.Field_Shield), Slots.Sides);
            ability6.effects[2] = new Effect((EffectSO)ScriptableObject.CreateInstance<RemoveConstrictedEffect>(), 1, new IntentType?(IntentType.Rem_Field_Constricted), Slots.Self);
            ability6.visuals = LoadedAssetsHandler.GetEnemy("TriggerFingers_BOSS").abilities[0].ability.visuals;
            ability6.animationTarget = Slots.Self;
            Ability ability7 = ability6.Duplicate();
            ability7.name = "Somewhere Better";
            ability7.description = "Consume 1 blue pigment if possible. Apply 8 Shield on the Left and Right ally positions.\nRemove all Constricted from self.";
            ability7.cost = new ManaColorSO[1] { Pigments.Blue };
            ability7.effects[1]._entryVariable = 8;
            Ability ability8 = ability7.Duplicate();
            ability8.name = "Somewhere Better Than Here";
            ability8.description = "Consume 1 blue pigment if possible. Apply 10 Shield on the Left and Right ally positions.\nRemove all Constricted from self.";
            ability8.effects[1]._entryVariable = 10;
            Ability ability9 = ability8.Duplicate();
            ability9.name = "Somewhere Anywhere But Here";
            ability9.description = "Consume 1 blue pigment if possible. Apply 11 Shield on the Left and Right ally positions.\nRemove all Constricted from self.";
            ability9.effects[1]._entryVariable = 11;
            Ability ability10 = new Ability();
            ability10.name = "Hurried Escape";
            ability10.description = "Create 7 Shield on this party member's position. Move to a random position and heal the Left and Right allies 2 health.";
            ability10.cost = new ManaColorSO[2]
            {
        Pigments.Blue,
        Pigments.Blue
            };
            ability10.sprite = ResourceLoader.LoadSprite("escape");
            ability10.effects = new Effect[3];
            ability10.effects[0] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 7, new IntentType?(IntentType.Field_Shield), Slots.Self);
            ability10.effects[1] = new Effect((EffectSO)ScriptableObject.CreateInstance<CharacterSwapToRandomZoneEffect>(), 1, new IntentType?(IntentType.Swap_Mass), Slots.Self);
            ability10.effects[2] = new Effect((EffectSO)ScriptableObject.CreateInstance<HealEffect>(), 2, new IntentType?(IntentType.Heal_1_4), Slots.Sides);
            ability10.visuals = LoadedAssetsHandler.GetEnemyAbility("Weep_A").visuals;
            ability10.animationTarget = Slots.Self;
            Ability ability11 = ability10.Duplicate();
            ability11.name = "Panicked Escape";
            ability11.description = "Create 9 Shield on this party member's position. Move to a random position and heal the Left and Right allies 3 health.";
            ability11.effects[0]._entryVariable = 9;
            ability11.effects[2]._entryVariable = 3;
            Ability ability12 = ability11.Duplicate();
            ability12.name = "Frantic Escape";
            ability12.description = "Create 11 Shield on this party member's position. Move to a random position and heal the Left and Right allies 3 health.";
            ability12.effects[0]._entryVariable = 11;
            Ability ability13 = ability12.Duplicate();
            ability13.name = "Terrified Escape";
            ability13.description = "Create 13 Shield on this party member's position. Move to a random position and heal the Left and Right allies 4 health.";
            ability13.effects[0]._entryVariable = 13;
            ability13.effects[2]._entryVariable = 4;
            character.AddLevel(10, new Ability[3]
            {
        ability10,
        ability2,
        ability6
            }, 0);
            character.AddLevel(12, new Ability[3]
            {
        ability11,
        ability3,
        ability7
            }, 1);
            character.AddLevel(16, new Ability[3]
            {
        ability12,
        ability4,
        ability8
            }, 2);
            character.AddLevel(19, new Ability[3]
            {
        ability13,
        ability5,
        ability9
            }, 3);
            _00_TheDead.Chara = character;
            if (!Joyce.IncludeTheDead)
                return;
            character.AddCharacter();
        }
    }
}
