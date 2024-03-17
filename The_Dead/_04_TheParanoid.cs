// Decompiled with JetBrains decompiler
// Type: THE_DEAD._04_TheParanoid
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using BrutalAPI;
using MonoMod.RuntimeDetour;
using System.Reflection;
using System.Threading;
using UnityEngine;

namespace THE_DEAD
{
    public static class _04_TheParanoid
    {
        public static Character Chara;
        public static Thread PynchonTimerThread = new Thread(new ThreadStart(_04_TheParanoid.paranoidTimer45));

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
            instance4._minimumValue = -100;
            instance4._valueName = (UnitStoredValueNames)69696969;
            instance4._increase = true;
            CasterStoredValueChangeEffect instance5 = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
            instance5._minimumValue = -100;
            instance5._valueName = (UnitStoredValueNames)69696969;
            instance5._increase = false;
            CasterStoredValueChangeEffect instance6 = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
            instance6._minimumValue = 0;
            instance6._valueName = (UnitStoredValueNames)222223333;
            instance6._increase = true;
            CasterStoredValueChangeEffect instance7 = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
            instance7._minimumValue = 0;
            instance7._valueName = (UnitStoredValueNames)222223333;
            instance7._increase = false;
            ScriptableObject.CreateInstance<CasterStoreValueCheckEffect>()._valueName = (UnitStoredValueNames)50334;
            PerformEffectPassiveAbility instance8 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            instance8._passiveName = "Impatience";
            instance8.passiveIcon = ResourceLoader.LoadSprite("ParanoidImpatience");
            instance8.type = (PassiveAbilityTypes)9878771;
            instance8._enemyDescription = "FUUUUUUUUUUUCK";
            instance8._characterDescription = "Increase damage by 1-2 at the end of every turn.";
            instance8.specialStoredValue = (UnitStoredValueNames)69696969;
            instance8.effects = ExtensionMethods.ToEffectInfoArray(new Effect[2]
            {
        new Effect((EffectSO) instance4, 1, new IntentType?(), Slots.Self),
        new Effect((EffectSO) instance4, 1, new IntentType?(), Slots.Self, (EffectConditionSO) Conditions.Chance(50))
            });
            instance8.conditions = new EffectorConditionSO[1]
            {
        (EffectorConditionSO) ScriptableObject.CreateInstance<ImpatienceCondition>()
            };
            instance8._triggerOn = new TriggerCalls[2]
            {
        TriggerCalls.OnTurnFinished,
        TriggerCalls.OnWillApplyDamage
            };
            ScriptableObject.CreateInstance<CasterStoredValueSetEffect>()._valueName = (UnitStoredValueNames)452975;
            ScriptableObject.CreateInstance<StoredValueSetEffectorCondition>()._storeValue = (UnitStoredValueNames)452975;
            Connection_PerformEffectPassiveAbility instance9 = ScriptableObject.CreateInstance<Connection_PerformEffectPassiveAbility>();
            instance9._passiveName = "Panic";
            instance9.passiveIcon = ResourceLoader.LoadSprite("ParanoidPanic");
            instance9.type = (PassiveAbilityTypes)9878772;
            instance9._enemyDescription = "Shouldnt be on enemy";
            instance9._characterDescription = "Every minute past an hour in the in-game timer adds a 5% chance to instantly kill this character, 5% chance to perform a random ability, and 10% chance to increase impatience by 1 on turn start.";
            instance9.conditions = new EffectorConditionSO[0];
            instance9.connectionEffects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
            {
        new Effect((EffectSO) ScriptableObject.CreateInstance<ParanoidPanicThreadStartEffect>(), 1, new IntentType?(), Slots.Self)
            });
            instance9.disconnectionEffects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
            {
        new Effect((EffectSO) ScriptableObject.CreateInstance<ExitValueSetterEffect>(), 1, new IntentType?(), Slots.Self)
            });
            instance9._triggerOn = new TriggerCalls[1]
            {
        TriggerCalls.Count
            };
            PynchonOnPausePassiveAbility instance10 = ScriptableObject.CreateInstance<PynchonOnPausePassiveAbility>();
            instance10._passiveName = "No Escape";
            instance10.passiveIcon = ResourceLoader.LoadSprite("ParanoidEscape");
            instance10.type = (PassiveAbilityTypes)9878773;
            instance10._enemyDescription = "Shouldnt be on enemy";
            instance10._characterDescription = "Pausing will be punished appropriately.";
            instance10._triggerOn = new TriggerCalls[1]
            {
        TriggerCalls.Count
            };
            PerformEffectPassiveAbility instance11 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            instance11._passiveName = "Acceleration";
            instance11.passiveIcon = ResourceLoader.LoadSprite("ParanoidSpeed");
            instance11.type = (PassiveAbilityTypes)9878774;
            instance11._enemyDescription = "might be breaking the game...";
            instance11._characterDescription = "Taking more than 45 seconds per turn will instantly kill this character at the end of the turn.";
            instance11.specialStoredValue = (UnitStoredValueNames)222223333;
            instance11.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
            {
        new Effect((EffectSO) ScriptableObject.CreateInstance<Speed45DeathEffect>(), 1, new IntentType?(), Slots.Self)
            });
            instance11._triggerOn = new TriggerCalls[1]
            {
        TriggerCalls.OnTurnFinished
            };
            PerformEffectPassiveAbility instance12 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            instance12._passiveName = "Paranoia";
            instance12.passiveIcon = ResourceLoader.LoadSprite("ParanoidParanoia");
            instance12.type = (PassiveAbilityTypes)9878775;
            instance12._enemyDescription = "I have no idea what this will do";
            instance12._characterDescription = "If the battle takes more than 5 turns, this character has a low chance to instantly die at the start of the turn.";
            instance12.effects = ExtensionMethods.ToEffectInfoArray(new Effect[2]
            {
        new Effect((EffectSO) ScriptableObject.CreateInstance<PanicDeathEffect>(), 1, new IntentType?(), Slots.Self),
        new Effect((EffectSO) ScriptableObject.CreateInstance<ParanoiaDeathEffect>(), 1, new IntentType?(), Slots.Self)
            });
            instance12._triggerOn = new TriggerCalls[1]
            {
        TriggerCalls.OnTurnStart
            };
            Connection_PerformEffectPassiveAbility instance13 = ScriptableObject.CreateInstance<Connection_PerformEffectPassiveAbility>();
            instance13._passiveName = "Futility";
            instance13.passiveIcon = ResourceLoader.LoadSprite("ParanoidFutile");
            instance13.type = (PassiveAbilityTypes)9878776;
            instance13._enemyDescription = "shouldnt be on enemy";
            instance13._characterDescription = "Upon this character's death, do nothing.";
            instance13.connectionEffects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
            {
        new Effect((EffectSO) ScriptableObject.CreateInstance<ExitValueSetterEffect>(), 0, new IntentType?(), Slots.Self)
            });
            instance13.disconnectionEffects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
            {
        new Effect((EffectSO) ScriptableObject.CreateInstance<PynchonDeathEffect>(), 1, new IntentType?(), Slots.SlotTarget(new int[8]
        {
          -4,
          -3,
          -2,
          -1,
          1,
          2,
          3,
          4
        }, true))
            });
            instance13._triggerOn = new TriggerCalls[1]
            {
        TriggerCalls.Count
            };
            PerformEffectPassiveAbility instance14 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            instance14._passiveName = "Anxiety";
            instance14.passiveIcon = ResourceLoader.LoadSprite("ParanoidAnxiety");
            instance14.type = (PassiveAbilityTypes)9878777;
            instance14._enemyDescription = "H";
            instance14._characterDescription = "Upon combat end, 1% chance to deal 1 indirect damage to this character.";
            instance14.effects = ExtensionMethods.ToEffectInfoArray(new Effect[2]
            {
        new Effect((EffectSO) ScriptableObject.CreateInstance<AnxietyFinishBattleEffect>(), 1, new IntentType?(), Slots.Self),
        new Effect((EffectSO) ScriptableObject.CreateInstance<IndirectDamageEffect>(), 1, new IntentType?(), Slots.Self, (EffectConditionSO) Conditions.Chance(1))
            });
            instance14._triggerOn = new TriggerCalls[1]
            {
        TriggerCalls.OnCombatEnd
            };
            IDetour detour1 = (IDetour)new Hook((MethodBase)typeof(TooltipTextHandlerSO).GetMethod("ProcessStoredValue", ~BindingFlags.Default), typeof(Joyce).GetMethod("AddStoredValueName45", ~BindingFlags.Default));
            IDetour detour2 = (IDetour)new Hook((MethodBase)typeof(TooltipTextHandlerSO).GetMethod("ProcessStoredValue", ~BindingFlags.Default), typeof(Joyce).GetMethod("AddStoredValueName6969", ~BindingFlags.Default));
            ScriptableObject.CreateInstance<PreviousEffectCondition>().wasSuccessful = true;
            ScriptableObject.CreateInstance<PreviousEffectCondition>().wasSuccessful = false;
            Character character = new Character();
            character.name = "Pynchon";
            character.healthColor = Pigments.Purple;
            character.entityID = (EntityIDs)9878770;
            character.overworldSprite = ResourceLoader.LoadSprite("ParanoidOverworld", pivot: new Vector2?(new Vector2(0.5f, 0.0f)));
            character.frontSprite = ResourceLoader.LoadSprite("ParanoidFront");
            character.backSprite = ResourceLoader.LoadSprite("ParanoidBack");
            character.lockedSprite = ResourceLoader.LoadSprite("ParanoidLocked");
            character.unlockedSprite = ResourceLoader.LoadSprite("ParanoidMenu");
            character.menuChar = true;
            character.isSupport = false;
            character.walksInOverworld = false;
            character.hurtSound = LoadedAssetsHandler.GetCharcater("Griffin_CH").damageSound;
            character.deathSound = LoadedAssetsHandler.GetCharcater("Griffin_CH").deathSound;
            character.dialogueSound = LoadedAssetsHandler.GetCharcater("Griffin_CH").dxSound;
            character.passives = new BasePassiveAbilitySO[7]
            {
        (BasePassiveAbilitySO) instance8,
        (BasePassiveAbilitySO) instance9,
        (BasePassiveAbilitySO) instance10,
        (BasePassiveAbilitySO) instance11,
        (BasePassiveAbilitySO) instance12,
        (BasePassiveAbilitySO) instance13,
        (BasePassiveAbilitySO) instance14
            };
            Ability ability1 = new Ability();
            ability1.name = "Un-Slap";
            ability1.description = "Deal 1 damage to the opposing enemy. Increase time left for this character by 3 seconds.";
            ability1.cost = new ManaColorSO[1]
            {
        Pigments.SplitPigment(Pigments.Yellow, Pigments.Green)
            };
            ability1.sprite = ResourceLoader.LoadSprite("ParanoidUnSlap");
            ability1.effects = new Effect[2];
            ability1.effects[0] = new Effect((EffectSO)ScriptableObject.CreateInstance<DamagePlusStoredValueEffect>(), 1, new IntentType?(IntentType.Damage_1_2), Slots.Front);
            ability1.effects[1] = new Effect((EffectSO)instance7, 3, new IntentType?(), Slots.Self);
            ability1.visuals = LoadedAssetsHandler.GetCharacterAbility("Quills_1_A").visuals;
            ability1.animationTarget = Slots.Self;
            Ability ability2 = new Ability();
            ability2.name = "Risky Maneuver";
            ability2.description = "Deal 10 damage to the Opposing enemy. Inflict 1 Constricted on this party member and decrease Impatience by 3. \nIf animations are disabled, decrease Impatience by another 3.";
            ability2.cost = new ManaColorSO[3]
            {
        Pigments.Yellow,
        Pigments.Red,
        Pigments.Red
            };
            ability2.sprite = ResourceLoader.LoadSprite("ParanoidDetour");
            ability2.effects = new Effect[5];
            ability2.effects[0] = new Effect((EffectSO)EZEffects.GetVisuals<AnimationVisualsEffect>("Bash_A", false, Slots.Front), 1, new IntentType?(), Slots.Front);
            ability2.effects[1] = new Effect((EffectSO)ScriptableObject.CreateInstance<DamageEffect>(), 10, new IntentType?(IntentType.Damage_7_10), Slots.Front);
            ability2.effects[2] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyConstrictedSlotEffect>(), 1, new IntentType?(IntentType.Field_Constricted), Slots.Self);
            ability2.effects[3] = new Effect((EffectSO)instance5, 3, new IntentType?(IntentType.Misc), Slots.Self);
            ability2.effects[4] = new Effect((EffectSO)instance5, 3, new IntentType?(), Slots.Self, (EffectConditionSO)ScriptableObject.CreateInstance<IfAbilitiesOffCondition>());
            ability2.visuals = LoadedAssetsHandler.GetEnemyAbility("UglyOnTheInside_A").visuals;
            ability2.animationTarget = Slots.Front;
            Ability ability3 = ability2.Duplicate();
            ability3.name = "Dangerous Maneuver";
            ability3.description = "Deal 13 damage to the Opposing enemy. Inflict 1 Constricted on this party member and decrease Impatience by 3. \nIf animations are disabled, decrease Impatience by another 3.";
            ability3.effects[1]._entryVariable = 13;
            ability3.effects[1]._intent = new IntentType?(IntentType.Damage_11_15);
            Ability ability4 = ability3.Duplicate();
            ability4.name = "Harmful Maneuver";
            ability4.description = "Deal 18 damage to the Opposing enemy. Inflict 1 Constricted on this party member and decrease Impatience by 3. \nIf animations are disabled, decrease Impatience by another 3.";
            ability4.effects[1]._entryVariable = 18;
            ability4.effects[1]._intent = new IntentType?(IntentType.Damage_16_20);
            Ability ability5 = ability4.Duplicate();
            ability5.name = "Fatal Maneuver";
            ability5.description = "Deal 25 damage to the Opposing enemy. Inflict 1 Constricted on this party member and decrease Impatience by 3. \nIf animations are disabled, decrease Impatience by another 3.";
            ability5.effects[1]._entryVariable = 25;
            ability5.effects[1]._intent = new IntentType?(IntentType.Damage_21);
            Ability ability6 = new Ability();
            ability6.name = "Fearful Surprise Attack";
            ability6.description = "Deal 6 damage to the Opposing enemy. Refresh this character's movement and abilities, and apply 1 Scar to this character. \nIf animations are disabled, give the Opposing enemy another action.";
            ability6.cost = new ManaColorSO[3]
            {
        Pigments.Blue,
        Pigments.Red,
        Pigments.Yellow
            };
            ability6.sprite = ResourceLoader.LoadSprite("ParanoidSuprise");
            ability6.effects = new Effect[6];
            ability6.effects[0] = new Effect((EffectSO)ScriptableObject.CreateInstance<DamageEffect>(), 6, new IntentType?(IntentType.Damage_3_6), Slots.Front);
            ability6.effects[1] = new Effect((EffectSO)EZEffects.GetVisuals<AnimationVisualsEffect>("Scald_A", false, Slots.Self), 0, new IntentType?(), Slots.Self);
            ability6.effects[2] = new Effect((EffectSO)ScriptableObject.CreateInstance<RestoreSwapUseEffect>(), 1, new IntentType?(IntentType.Other_RestoreMovement), Slots.Self);
            ability6.effects[3] = new Effect((EffectSO)ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, new IntentType?(IntentType.Other_Refresh), Slots.Self);
            ability6.effects[4] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyScarsEffect>(), 1, new IntentType?(IntentType.Status_Scars), Slots.Self);
            ability6.effects[5] = new Effect((EffectSO)ScriptableObject.CreateInstance<AddTurnTargetToTimelineEffect>(), 1, new IntentType?(IntentType.Misc), Slots.Front, (EffectConditionSO)ScriptableObject.CreateInstance<IfAbilitiesOffCondition>());
            ability6.visuals = LoadedAssetsHandler.GetCharacterAbility("Decimation_1_A").visuals;
            ability6.animationTarget = Slots.Front;
            Ability ability7 = ability6.Duplicate();
            ability7.name = "Anxious Surprise Attack";
            ability7.description = "Deal 8 damage to the Opposing enemy. Refresh this character's movement and abilities, and apply 1 Scar to this character. \nIf animations are disabled, give the Opposing enemy another action.";
            ability7.effects[0]._entryVariable = 8;
            ability7.effects[0]._intent = new IntentType?(IntentType.Damage_7_10);
            Ability ability8 = ability7.Duplicate();
            ability8.name = "Cautious Surprise Attack";
            ability8.description = "Deal 10 damage to the Opposing enemy. Refresh this character's movement and abilities, and apply 1 Scar to this character. \nIf animations are disabled, give the Opposing enemy another action.";
            ability8.effects[0]._entryVariable = 10;
            Ability ability9 = ability8.Duplicate();
            ability9.name = "Prepared Surprise Attack";
            ability9.description = "Deal 12 damage to the Opposing enemy. Refresh this character's movement and abilities, and apply 1 Scar to this character. \nIf animations are disabled, give the Opposing enemy another action.";
            ability9.effects[0]._entryVariable = 12;
            ability9.effects[0]._intent = new IntentType?(IntentType.Damage_11_15);
            Ability ability10 = new Ability();
            ability10.name = "Quick Skip";
            ability10.description = "Remove an action and inflict 1 Constricted on the Opposing enemy. \nIf animations are disabled, deal 2 indirect damage to this party member.";
            ability10.cost = new ManaColorSO[3]
            {
        Pigments.Yellow,
        Pigments.Blue,
        Pigments.Blue
            };
            ability10.sprite = ResourceLoader.LoadSprite("ParanoidHurry");
            ability10.effects = new Effect[4];
            ability10.effects[0] = new Effect((EffectSO)EZEffects.GetVisuals<AnimationVisualsEffect>("Entwined_1_A", true, Slots.Front), 1, new IntentType?(IntentType.Misc), Slots.Front);
            ability10.effects[1] = new Effect((EffectSO)ScriptableObject.CreateInstance<RemoveTargetTimelineAbilityEffect>(), 1, new IntentType?(), Slots.Front);
            ability10.effects[2] = new Effect((EffectSO)ScriptableObject.CreateInstance<ApplyConstrictedSlotEffect>(), 1, new IntentType?(IntentType.Field_Constricted), Slots.Front);
            ability10.effects[3] = new Effect((EffectSO)ScriptableObject.CreateInstance<IndirectDamageEffect>(), 2, new IntentType?(IntentType.Damage_1_2), Slots.Self, (EffectConditionSO)ScriptableObject.CreateInstance<IfAbilitiesOffCondition>());
            ability10.visuals = LoadedAssetsHandler.GetEnemyAbility("InhumanRoar_A").visuals;
            ability10.animationTarget = Slots.Front;
            Ability ability11 = ability10.Duplicate();
            ability11.name = "Hurried Skip";
            ability11.description = "Remove an action and inflict 1 Constricted on the Opposing enemy. \nIf animations are disabled, deal 2 indirect damage to this party member.";
            ability11.cost = new ManaColorSO[3]
            {
        Pigments.Yellow,
        Pigments.SplitPigment(Pigments.Red, Pigments.Blue),
        Pigments.Blue
            };
            Ability ability12 = ability11.Duplicate();
            ability12.name = "Rushed Skip";
            ability12.cost = new ManaColorSO[2]
            {
        Pigments.Yellow,
        Pigments.Blue
            };
            ability12.description = "Remove an action and inflict 1 Constricted on the Opposing enemy. \nIf animations are disabled, deal 1 indirect damage to this party member.";
            ability12.effects[3]._entryVariable = 1;
            Ability ability13 = ability12.Duplicate();
            ability13.name = "Rapid Skip";
            ability13.description = "Remove an action and inflict 1 Constricted on the Opposing enemy. \nIf animations are disabled, deal 1 indirect damage to this party member.";
            ability13.cost = new ManaColorSO[2]
            {
        Pigments.SplitPigment(Pigments.Red, Pigments.Blue),
        Pigments.Blue
            };
            character.AddLevel(12, new Ability[3]
            {
        ability2,
        ability6,
        ability10
            }, 0);
            character.AddLevel(15, new Ability[3]
            {
        ability3,
        ability7,
        ability11
            }, 1);
            character.AddLevel(18, new Ability[3]
            {
        ability4,
        ability8,
        ability12
            }, 2);
            character.AddLevel(19, new Ability[3]
            {
        ability5,
        ability9,
        ability13
            }, 3);
            _04_TheParanoid.Chara = character;
            if (!Joyce.IncludeTheParanoid)
                return;
            character.AddCharacter();
        }

        public static void paranoidTimer45()
        {
            Thread.Sleep(1000);
            Thread.Sleep(UnityEngine.Random.Range(0, 2000));
            while ((Object)CombatManager.Instance != (Object)null && !((object)CombatManager.Instance).Equals((object)null) && CombatManager.Instance._stats.CharactersAlive)
            {
                Thread.Sleep(3000);
                Targetting_ByUnit_Side instance = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
                instance.getAllies = true;
                Effect effect = new Effect((EffectSO)ScriptableObject.CreateInstance<ParanoidTimerIncrease>(), 1, new IntentType?(), (BaseCombatTargettingSO)instance);
            }
        }
    }
}
