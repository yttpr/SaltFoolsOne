// Decompiled with JetBrains decompiler
// Type: THE_DEAD._07_TheLiving
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using BrutalAPI;
using UnityEngine;

namespace THE_DEAD
{
    public static class _07_TheLiving
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
            PreviousEffectCondition instance7 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            instance7.wasSuccessful = true;
            ScriptableObject.CreateInstance<PreviousEffectCondition>().wasSuccessful = false;
            ScriptableObject.CreateInstance<RemoveStatusEffectEffect>()._statusToRemove = StatusEffectType.Scars;
            ScriptableObject.CreateInstance<RemoveStatusEffectEffect>()._statusToRemove = StatusEffectType.Frail;
            ScriptableObject.CreateInstance<SetCasterExtraSpritesEffect>()._spriteType = (ExtraSpriteType)667;
            PerformEffectPassiveAbility instance8 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            instance8._passiveName = "Battle Junkie";
            instance8.passiveIcon = ResourceLoader.LoadSprite("AlivePassiveBattleJunkie");
            instance8.type = (PassiveAbilityTypes)456654;
            instance8._enemyDescription = "I have no idea what this will do";
            instance8._characterDescription = "Taking or dealing any damage has a 15% chance to apply 1 Power to this character.";
            PercentageEffectorCondition instance9 = ScriptableObject.CreateInstance<PercentageEffectorCondition>();
            instance9.triggerPercentage = 15;
            instance8.conditions = new EffectorConditionSO[1]
            {
        (EffectorConditionSO) instance9
            };
            instance8.effects = ExtensionMethods.ToEffectInfoArray(new Effect[2]
            {
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyPowerEffect>(), 1, new IntentType?(), Slots.Self),
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyPowerEffect>(), 1, new IntentType?(), Slots.Front, (EffectConditionSO) Conditions.Chance(0))
            });
            instance8._triggerOn = new TriggerCalls[2]
            {
        TriggerCalls.OnBeingDamaged,
        TriggerCalls.OnWillApplyDamage
            };
            CasterStoredValueChangeEffect instance10 = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
            instance10._minimumValue = 0;
            instance10._valueName = (UnitStoredValueNames)456765;
            instance10._increase = true;
            SetCasterExtraSpritesEffect instance11 = ScriptableObject.CreateInstance<SetCasterExtraSpritesEffect>();
            instance11._spriteType = (ExtraSpriteType)456654;
            PerformEffectPassiveAbility instance12 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            instance12._passiveName = "Serial Killer";
            instance12.passiveIcon = ResourceLoader.LoadSprite("AlivePassiveSerialKiller");
            instance12.type = (PassiveAbilityTypes)456765;
            instance12._enemyDescription = "I have no idea what this will do";
            instance12._characterDescription = "Upon killing anything, refresh this character and take 2 damage not from self.";
            instance12.effects = ExtensionMethods.ToEffectInfoArray(new Effect[4]
            {
        new Effect((EffectSO) ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, new IntentType?(), Slots.Self),
        new Effect((EffectSO) instance10, 1, new IntentType?(), Slots.Self),
        new Effect((EffectSO) ScriptableObject.CreateInstance<DamageFromNobodyEffect>(), 2, new IntentType?(), Slots.Self),
        new Effect((EffectSO) instance11, 1, new IntentType?(), Slots.Self)
            });
            instance12._triggerOn = new TriggerCalls[1]
            {
        TriggerCalls.OnKill
            };
            ExtraCCSprites_ArraySO instance13 = ScriptableObject.CreateInstance<ExtraCCSprites_ArraySO>();
            instance13._useDefault = ExtraSpriteType.None;
            instance13._doesLoop = false;
            instance13._useSpecial = (ExtraSpriteType)456654;
            instance13._frontSprite = new Sprite[1]
            {
        ResourceLoader.LoadSprite("AliveFrontBloody")
            };
            instance13._backSprite = new Sprite[1]
            {
        ResourceLoader.LoadSprite("AliveBackBloody")
            };
            CasterCheckStoredValueAboveCondition instance14 = ScriptableObject.CreateInstance<CasterCheckStoredValueAboveCondition>();
            instance14._valueName = (UnitStoredValueNames)456765;
            PerformEffectPassiveAbility instance15 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            instance15._passiveName = "Sadist";
            instance15.passiveIcon = ResourceLoader.LoadSprite("AlivePassiveSacrifice");
            instance15.type = (PassiveAbilityTypes)456543;
            instance15._enemyDescription = "I have no idea what this will do";
            instance15._characterDescription = "If this character does not kill anything by the end of battle, it kill's itself.";
            instance15.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
            {
        new Effect((EffectSO) ScriptableObject.CreateInstance<DirectDeathEffect>(), 1, new IntentType?(), Slots.Self, (EffectConditionSO) instance14)
            });
            instance15._triggerOn = new TriggerCalls[1]
            {
        TriggerCalls.OnCombatEnd
            };
            Character character = new Character();
            character.name = "Rose";
            character.healthColor = Pigments.Red;
            character.entityID = (EntityIDs)456654567;
            character.overworldSprite = ResourceLoader.LoadSprite("AliveOverworld", pivot: new Vector2?(new Vector2(0.5f, 0.0f)));
            character.frontSprite = ResourceLoader.LoadSprite("AliveFront");
            character.backSprite = ResourceLoader.LoadSprite("AliveBack");
            character.lockedSprite = ResourceLoader.LoadSprite("AliveLocked");
            character.unlockedSprite = ResourceLoader.LoadSprite("AliveMenu");
            character.extraSprites = (ExtraCharacterCombatSpritesSO)instance13;
            character.menuChar = true;
            character.isSupport = false;
            character.walksInOverworld = true;
            character.hurtSound = LoadedAssetsHandler.GetCharcater("Bimini_CH").damageSound;
            character.deathSound = LoadedAssetsHandler.GetCharcater("Bimini_CH").deathSound;
            character.dialogueSound = LoadedAssetsHandler.GetCharcater("Bimini_CH").dxSound;
            character.passives = new BasePassiveAbilitySO[2]
            {
        (BasePassiveAbilitySO) instance8,
        (BasePassiveAbilitySO) instance12
            };
            Ability ability1 = new Ability();
            ability1.name = "Gross Mutilate";
            ability1.description = "Hit the opposing enemy for 2 and then 3 damage. If this kills, apply 1-2 Power to self.";
            ability1.cost = new ManaColorSO[2]
            {
        Pigments.Red,
        Pigments.Red
            };
            ability1.sprite = ResourceLoader.LoadSprite("AliveIconMutilate");
            ability1.effects = new Effect[4];
            ability1.effects[0] = new Effect((EffectSO)ScriptableObject.CreateInstance<DamageEffect>(), 2, new IntentType?(IntentType.Damage_1_2), Slots.Front);
            ((DamageEffect)ability1.effects[0]._effect)._returnKillAsSuccess = true;
            ability1.effects[1] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyPowerRangePlusOneEffect>(), 1, new IntentType?(), Slots.Self, (EffectConditionSO)instance7);
            ability1.effects[2] = new Effect((EffectSO)ScriptableObject.CreateInstance<DamageEffect>(), 3, new IntentType?(IntentType.Damage_3_6), Slots.Front);
            ((DamageEffect)ability1.effects[2]._effect)._returnKillAsSuccess = true;
            ability1.effects[3] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyPowerRangePlusOneEffect>(), 1, new IntentType?((IntentType)987895), Slots.Self, (EffectConditionSO)instance7);
            ability1.visuals = LoadedAssetsHandler.GetCharacterAbility("Purify_1_A").visuals;
            ability1.animationTarget = Slots.Front;
            Ability ability2 = ability1.Duplicate();
            ability2.name = "Vile Mutilate";
            ability2.description = "Hit the opposing enemy for 3 and then 4 damage. If this kills, apply 1-2 Power to self.";
            ability2.effects[0]._entryVariable = 3;
            ability2.effects[0]._intent = new IntentType?(IntentType.Damage_3_6);
            ability2.effects[2]._entryVariable = 4;
            ability2.effects[2]._intent = new IntentType?(IntentType.Damage_3_6);
            Ability ability3 = ability2.Duplicate();
            ability3.name = "Disgusting Mutilate";
            ability3.description = "Hit the opposing enemy for 4 and then 5 damage. If this kills, apply 1-2 Power to self.";
            ability3.effects[0]._entryVariable = 4;
            ability3.effects[2]._entryVariable = 5;
            Ability ability4 = ability3.Duplicate();
            ability4.name = "Unfathomable Mutilate";
            ability4.description = "Hit the opposing enemy for 5 and then 6 damage. If this kills, apply 1-2 Power to self.";
            ability4.effects[0]._entryVariable = 5;
            ability4.effects[2]._entryVariable = 6;
            RoseMultiHitEffect instance16 = ScriptableObject.CreateInstance<RoseMultiHitEffect>();
            instance16._visuals = LoadedAssetsHandler.GetCharacterAbility("Expire_1_A").visuals;
            instance16._returnKillAsSuccess = true;
            Ability ability5 = new Ability();
            ability5.name = "Careless Cleave";
            ability5.description = "Hit the Opposing and either the Left or Right enemy for 5 damage. If this kills, apply 1 Power to self.";
            ability5.cost = new ManaColorSO[3]
            {
        Pigments.Red,
        Pigments.Red,
        Pigments.Red
            };
            ability5.sprite = ResourceLoader.LoadSprite("AliveIconCleave");
            ability5.effects = new Effect[3];
            ability5.effects[0] = new Effect((EffectSO)ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 0, new IntentType?(IntentType.Damage_3_6), Slots.FrontLeftRight);
            ability5.effects[1] = new Effect((EffectSO)instance16, 5, new IntentType?(), (BaseCombatTargettingSO)MultiTargetting.Create(Slots.Front, (BaseCombatTargettingSO)TargettingRandomFromSelection.Create(Slots.LeftRight)));
            ability5.effects[2] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyPowerEffect>(), 1, new IntentType?((IntentType)987895), Slots.Self, (EffectConditionSO)instance7);
            ability5.visuals = (AttackVisualsSO)null;
            ability5.animationTarget = Slots.Self;
            Ability ability6 = ability5.Duplicate();
            ability6.name = "Quick Cleave";
            ability6.description = "Hit the Opposing and either the Left or Right enemy for 8 damage. If this kills, apply 1 Power to self.";
            ability6.effects[1]._entryVariable = 8;
            ability6.effects[0]._intent = new IntentType?(IntentType.Damage_7_10);
            Ability ability7 = ability6.Duplicate();
            ability7.name = "Bloody Cleave";
            ability7.description = "Hit the Opposing and either the Left or Right enemy for 10 damage. If this kills, apply 1 Power to self.";
            ability7.effects[1]._entryVariable = 10;
            Ability ability8 = ability7.Duplicate();
            ability8.name = "Violent Cleave";
            ability8.description = "Hit the Opposing, Left, and Right enemies for 10 damage. If this kills, apply 1 Power to self.";
            ability8.effects[1]._target = Slots.FrontLeftRight;
            Ability ability9 = new Ability();
            ability9.name = "Rough Stab";
            ability9.description = "Hit the opposing enemy for 5 damage. 50% chance to refresh, 50% chance to apply 1 Power to self. If this kills, apply another Power.";
            ability9.cost = new ManaColorSO[2]
            {
        Pigments.Yellow,
        Pigments.Red
            };
            ability9.sprite = ResourceLoader.LoadSprite("AliveIconStab");
            ability9.effects = new Effect[4];
            ability9.effects[0] = new Effect((EffectSO)ScriptableObject.CreateInstance<DamageEffect>(), 5, new IntentType?(IntentType.Damage_3_6), Slots.Front);
            ((DamageEffect)ability9.effects[0]._effect)._returnKillAsSuccess = true;
            ability9.effects[1] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyPowerEffect>(), 1, new IntentType?((IntentType)987895), Slots.Self, (EffectConditionSO)instance7);
            ability9.effects[2] = new Effect((EffectSO)ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, new IntentType?(IntentType.Other_Refresh), Slots.Self, (EffectConditionSO)Conditions.Chance(50));
            ability9.effects[3] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyPowerEffect>(), 1, new IntentType?((IntentType)987895), Slots.Self, (EffectConditionSO)Conditions.Chance(50));
            ability9.visuals = LoadedAssetsHandler.GetCharacterAbility("Cacophony_1_A").visuals;
            ability9.animationTarget = Slots.Front;
            Ability ability10 = ability9.Duplicate();
            ability10.name = "Nasty Stab";
            ability10.description = "Hit the opposing enemy for 5 damage. 55% chance to refresh, 60% chance to apply 1 Power to self. If this kills, apply another Power.";
            ability10.effects[0]._entryVariable = 5;
            ability10.effects[2]._condition = (EffectConditionSO)Conditions.Chance(55);
            ability10.effects[3]._condition = (EffectConditionSO)Conditions.Chance(60);
            Ability ability11 = ability10.Duplicate();
            ability11.name = "Torturous Stab";
            ability11.description = "Hit the opposing enemy for 6 damage. 60% chance to refresh, 70% chance to apply 1 Power to self. If this kills, apply another Power.";
            ability11.effects[0]._entryVariable = 6;
            ability11.effects[2]._condition = (EffectConditionSO)Conditions.Chance(60);
            ability11.effects[3]._condition = (EffectConditionSO)Conditions.Chance(70);
            Ability ability12 = ability11.Duplicate();
            ability12.name = "Lethal Stab";
            ability12.description = "Hit the opposing enemy for 7 damage. 65% chance to refresh, 75% chance to apply 1 Power to self. If this kills, apply another Power.";
            ability12.effects[0]._entryVariable = 7;
            ability12.effects[0]._intent = new IntentType?(IntentType.Damage_7_10);
            ability12.effects[2]._condition = (EffectConditionSO)Conditions.Chance(65);
            ability12.effects[3]._condition = (EffectConditionSO)Conditions.Chance(75);
            character.AddLevel(12, new Ability[3]
            {
        ability1,
        ability5,
        ability9
            }, 0);
            character.AddLevel(16, new Ability[3]
            {
        ability2,
        ability6,
        ability10
            }, 1);
            character.AddLevel(20, new Ability[3]
            {
        ability3,
        ability7,
        ability11
            }, 2);
            character.AddLevel(24, new Ability[3]
            {
        ability4,
        ability8,
        ability12
            }, 3);
            _07_TheLiving.Chara = character;
            if (!Joyce.IncludeTheLiving)
                return;
            character.AddCharacter();
        }
    }
}
