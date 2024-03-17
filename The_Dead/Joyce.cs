// Decompiled with JetBrains decompiler
// Type: THE_DEAD.Joyce
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using BepInEx;
using MonoMod.RuntimeDetour;
using System;
using System.Reflection;
using UnityEngine;

namespace THE_DEAD
{
    [BepInPlugin("Salt.JamesJoyce", "I Hate James Joyce", "1.10.2")]
    [BepInDependency("Bones404.BrutalAPI", BepInDependency.DependencyFlags.HardDependency)]
    public class Joyce : BaseUnityPlugin
    {
        public static bool IncludeTheDead = true;
        public static bool IncludeTheFree = true;
        public static bool IncludeTheNoise = false;
        public static bool IncludeTheParanoid = true;
        public static bool IncludeTheLost = true;
        public static bool IncludeTheLiving = true;
        public static bool IncludeTheRemnant = true;
        public static bool IncludeTheDelusional = true;
        public static bool IncludeVinceVersion = false;
        public static bool IncludeTheAbortion = false;
        public static bool IncludeTheToasted = false;
        public static bool IncludeTheBlooming = true;
        public static StatusEffectInfoSO anesthetics = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
        public static StatusEffectInfoSO gloom = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
        public static StatusEffectInfoSO determined = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
        public static StatusEffectInfoSO power = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
        public static StatusEffectInfoSO funStatus = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
        public static StatusEffectInfoSO spores = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
        public static IntentInfo anestheticsIntent = (IntentInfo)new IntentInfoBasic();
        public static IntentInfo gloomIntent = (IntentInfo)new IntentInfoBasic();
        public static IntentInfo determinedIntent = (IntentInfo)new IntentInfoBasic();
        public static IntentInfo powerIntent = (IntentInfo)new IntentInfoBasic();
        public static IntentInfo funIntent = (IntentInfo)new IntentInfoBasic();
        public static IntentInfo guttedIntent = (IntentInfo)new IntentInfoBasic();
        public static IntentInfo sporesIntent = (IntentInfo)new IntentInfoBasic();
        public static bool paranoidTimer_InPause = false;
        public static bool paranoidTimer_InCombat = false;
        public static bool paranoidTimer_InTurn = false;
        public static bool paranoidTimer_ThreadStarted = false;
        public static bool paranoidTimer_PauseThreadStarted = false;
        public static bool paranoidTimer_Increased = false;
        public static bool paranoidTimer_UnPaused = false;
        public static int paranoidWorldTimer = 0;

        public static bool IncludeTheIndividual => Hi.AddSlop;

        public static bool IncludeTheHypocrite => Hi.AddSlop;

        public static bool IncludeTheMerciful => Hi.AddSlop;

        public static bool IncludeThePeaceful => Hi.AddSlop;

        public void Awake()
        {
            EZExtensions.PCall(new Action(Hi.HelloWorld), "Hello World");
            EZExtensions.PCall(new Action(Joyce.Add), "main joyce hooks");
            EZExtensions.PCall(new Action(_00_TheDead.Add), "00");
            EZExtensions.PCall(new Action(_01_TheIndividual.Add), "01");
            EZExtensions.PCall(new Action(_02_TheFree.Add), "02");
            EZExtensions.PCall(new Action(_03_TheNoise.Add), "03");
            EZExtensions.PCall(new Action(_04_TheParanoid.Add), "04");
            EZExtensions.PCall(new Action(_05_TheHypocrite.Add), "05");
            EZExtensions.PCall(new Action(_06_TheLost.Add), "06");
            EZExtensions.PCall(new Action(_07_TheLiving.Add), "07");
            EZExtensions.PCall(new Action(_08_TheRemnant.Add), "08");
            EZExtensions.PCall(new Action(_09_TheToasted.Add), "09");
            EZExtensions.PCall(new Action(_10_TheMerciful.Add), "10");
            EZExtensions.PCall(new Action(_12_ThePeaceful.Add), "12");
            EZExtensions.PCall(new Action(_13_TheDelusional.Add), "13");
            EZExtensions.PCall(new Action(_14_Infanticide.Add), "14");
            EZExtensions.PCall(new Action(_15_TheBlooming.Add), "15");
            EZExtensions.PCall(new Action(Hi.GoodbyeWorld), "goodbye world");
            this.Logger.LogInfo((object)"Salt.JamesJoyce loaded successfully!");
        }

        private static void AddAnestheticsStatusEffect(Action<CombatManager> orig, CombatManager self)
        {
            orig(self);
            Joyce.anesthetics.name = "Anesthetics";
            Joyce.anesthetics.icon = ResourceLoader.LoadSprite("anesthetics2");
            Joyce.anesthetics._statusName = "Anesthetics";
            Joyce.anesthetics.statusEffectType = (StatusEffectType)204308;
            Joyce.anesthetics._description = "All damage received will be decreased by 1 for each Anesthetic, this applies to both direct and indirect damage. This effect cannot decrease damage to levels below zero. Decreases by 1 at the start of each turn.";
            Joyce.anesthetics._applied_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Scars].AppliedSoundEvent;
            Joyce.anesthetics._updated_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Scars].UpdatedSoundEvent;
            Joyce.anesthetics._removed_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Scars].RemovedSoundEvent;
            StatusEffectInfoSO statusEffectInfoSo;
            self._stats.statusEffectDataBase.TryGetValue((StatusEffectType)204308, out statusEffectInfoSo);
            if (!((UnityEngine.Object)statusEffectInfoSo == (UnityEngine.Object)null))
                return;
            self._stats.statusEffectDataBase.Add((StatusEffectType)204308, Joyce.anesthetics);
        }

        private static void AddGloomStatusEffect(Action<CombatManager> orig, CombatManager self)
        {
            orig(self);
            Joyce.gloom.name = "Gloom";
            Joyce.gloom.icon = ResourceLoader.LoadSprite("GloomSprite");
            Joyce.gloom._statusName = "Gloom";
            Joyce.gloom.statusEffectType = (StatusEffectType)666667;
            Joyce.gloom._description = "Increase direct damage taken by 1% for each stack of gloom. Increase stacks by 1 for each direct damage taken. If gloom is 7 or higher and if cursed, recieve 7-13 indirect damage after taking direct damage. Reduce by half at the end of turn.";
            Joyce.gloom._applied_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Cursed].AppliedSoundEvent;
            Joyce.gloom._updated_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Ruptured].UpdatedSoundEvent;
            Joyce.gloom._removed_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Ruptured].RemovedSoundEvent;
            StatusEffectInfoSO statusEffectInfoSo;
            self._stats.statusEffectDataBase.TryGetValue((StatusEffectType)666667, out statusEffectInfoSo);
            if (!((UnityEngine.Object)statusEffectInfoSo == (UnityEngine.Object)null))
                return;
            self._stats.statusEffectDataBase.Add((StatusEffectType)666667, Joyce.gloom);
        }

        private static void AddDeterminedStatusEffect(Action<CombatManager> orig, CombatManager self)
        {
            orig(self);
            Joyce.determined.name = "Determined";
            Joyce.determined.icon = ResourceLoader.LoadSprite("Determined");
            Joyce.determined._statusName = "Determined";
            Joyce.determined.statusEffectType = (StatusEffectType)555556;
            Joyce.determined._description = "Upon dying, prevent death and heal this character however many stacks of Determined they have. Remove all Determined. Decreases by 1 at the start of each turn. Does not work on Cursed, Dying, or Inanimate units.";
            Joyce.determined._applied_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Linked].AppliedSoundEvent;
            Joyce.determined._updated_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Linked].UpdatedSoundEvent;
            Joyce.determined._removed_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Linked].RemovedSoundEvent;
            StatusEffectInfoSO statusEffectInfoSo;
            self._stats.statusEffectDataBase.TryGetValue((StatusEffectType)555556, out statusEffectInfoSo);
            if (!((UnityEngine.Object)statusEffectInfoSo == (UnityEngine.Object)null))
                return;
            self._stats.statusEffectDataBase.Add((StatusEffectType)555556, Joyce.determined);
        }

        private static void AddPowerStatusEffect(Action<CombatManager> orig, CombatManager self)
        {
            orig(self);
            Joyce.power.name = "Power";
            Joyce.power.icon = ResourceLoader.LoadSprite("StatusPower");
            Joyce.power._statusName = "Power";
            Joyce.power.statusEffectType = (StatusEffectType)456789;
            Joyce.power._description = "Increase damage dealt by this character by 1 for each stack. Upon dealing damage, 50% chance to reduce Power by 1. If Power reduces, 33% chance to reduce Power by 1 again.";
            Joyce.power._applied_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Focused].AppliedSoundEvent;
            Joyce.power._updated_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Focused].UpdatedSoundEvent;
            Joyce.power._removed_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Focused].RemovedSoundEvent;
            StatusEffectInfoSO statusEffectInfoSo;
            self._stats.statusEffectDataBase.TryGetValue((StatusEffectType)456789, out statusEffectInfoSo);
            if (!((UnityEngine.Object)statusEffectInfoSo == (UnityEngine.Object)null))
                return;
            self._stats.statusEffectDataBase.Add((StatusEffectType)456789, Joyce.power);
        }

        private static void AddFunStatusEffect(Action<CombatManager> orig, CombatManager self)
        {
            orig(self);
            Joyce.funStatus.name = "Fun";
            Joyce.funStatus.icon = ResourceLoader.LoadSprite("FunStatus");
            Joyce.funStatus._statusName = "'Fun'";
            Joyce.funStatus.statusEffectType = (StatusEffectType)422442;
            Joyce.funStatus._description = "Randomly multiply all damage dealt and received.";
            Joyce.funStatus._applied_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Spotlight].AppliedSoundEvent;
            Joyce.funStatus._updated_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Ruptured].UpdatedSoundEvent;
            Joyce.funStatus._removed_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Ruptured].RemovedSoundEvent;
            StatusEffectInfoSO statusEffectInfoSo;
            self._stats.statusEffectDataBase.TryGetValue((StatusEffectType)422442, out statusEffectInfoSo);
            if (!((UnityEngine.Object)statusEffectInfoSo == (UnityEngine.Object)null))
                return;
            self._stats.statusEffectDataBase.Add((StatusEffectType)422442, Joyce.funStatus);
        }

        private static void AddSporesStatusEffect(Action<CombatManager> orig, CombatManager self)
        {
            orig(self);
            Joyce.spores.name = "Spores";
            Joyce.spores.icon = ResourceLoader.LoadSprite("VenusSpores");
            Joyce.spores._statusName = "Spores";
            Joyce.spores.statusEffectType = (StatusEffectType)202303;
            Joyce.spores._description = "Deal 1-3 indirect pigment damage for every 3 stacks of this effect at the end of each turn and decrease by half.";
            Joyce.spores._applied_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Ruptured].AppliedSoundEvent;
            Joyce.spores._updated_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Ruptured].UpdatedSoundEvent;
            Joyce.spores._removed_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Ruptured].RemovedSoundEvent;
            StatusEffectInfoSO statusEffectInfoSo;
            self._stats.statusEffectDataBase.TryGetValue((StatusEffectType)202303, out statusEffectInfoSo);
            if (!((UnityEngine.Object)statusEffectInfoSo == (UnityEngine.Object)null))
                return;
            self._stats.statusEffectDataBase.Add((StatusEffectType)202303, Joyce.spores);
        }

        private static void AnestheticsIntent(Action<IntentHandlerSO> orig, IntentHandlerSO self)
        {
            orig(self);
            Joyce.anestheticsIntent._type = (IntentType)987898;
            Joyce.anestheticsIntent._sprite = ResourceLoader.LoadSprite("anesthetics2");
            Joyce.anestheticsIntent._color = Color.white;
            Joyce.anestheticsIntent._sound = self._intentDB[IntentType.Status_Scars]._sound;
            IntentInfo intentInfo;
            self._intentDB.TryGetValue((IntentType)987898, out intentInfo);
            if (intentInfo != null)
                return;
            self._intentDB.Add((IntentType)987898, Joyce.anestheticsIntent);
        }

        private static void GloomIntent(Action<IntentHandlerSO> orig, IntentHandlerSO self)
        {
            orig(self);
            Joyce.gloomIntent._type = (IntentType)987897;
            Joyce.gloomIntent._sprite = ResourceLoader.LoadSprite("GloomSprite");
            Joyce.gloomIntent._color = Color.white;
            Joyce.gloomIntent._sound = self._intentDB[IntentType.Status_Scars]._sound;
            IntentInfo intentInfo;
            self._intentDB.TryGetValue((IntentType)987897, out intentInfo);
            if (intentInfo != null)
                return;
            self._intentDB.Add((IntentType)987897, Joyce.gloomIntent);
        }

        private static void DeterminedIntent(Action<IntentHandlerSO> orig, IntentHandlerSO self)
        {
            orig(self);
            Joyce.determinedIntent._type = (IntentType)987896;
            Joyce.determinedIntent._sprite = ResourceLoader.LoadSprite("Determined");
            Joyce.determinedIntent._color = Color.white;
            Joyce.determinedIntent._sound = self._intentDB[IntentType.Status_Scars]._sound;
            IntentInfo intentInfo;
            self._intentDB.TryGetValue((IntentType)987896, out intentInfo);
            if (intentInfo != null)
                return;
            self._intentDB.Add((IntentType)987896, Joyce.determinedIntent);
        }

        private static void PowerIntent(Action<IntentHandlerSO> orig, IntentHandlerSO self)
        {
            orig(self);
            Joyce.powerIntent._type = (IntentType)987895;
            Joyce.powerIntent._sprite = ResourceLoader.LoadSprite("StatusPower");
            Joyce.powerIntent._color = Color.white;
            Joyce.powerIntent._sound = self._intentDB[IntentType.Status_Scars]._sound;
            IntentInfo intentInfo;
            self._intentDB.TryGetValue((IntentType)987895, out intentInfo);
            if (intentInfo != null)
                return;
            self._intentDB.Add((IntentType)987895, Joyce.powerIntent);
        }

        private static void FunIntent(Action<IntentHandlerSO> orig, IntentHandlerSO self)
        {
            orig(self);
            Joyce.funIntent._type = (IntentType)987894;
            Joyce.funIntent._sprite = ResourceLoader.LoadSprite("FunStatus");
            Joyce.funIntent._color = Color.white;
            Joyce.funIntent._sound = self._intentDB[IntentType.Status_Scars]._sound;
            IntentInfo intentInfo;
            self._intentDB.TryGetValue((IntentType)987894, out intentInfo);
            if (intentInfo != null)
                return;
            self._intentDB.Add((IntentType)987894, Joyce.funIntent);
        }

        private static void GuttedIntent(Action<IntentHandlerSO> orig, IntentHandlerSO self)
        {
            orig(self);
            Joyce.guttedIntent._type = (IntentType)987893;
            Joyce.guttedIntent._sprite = ResourceLoader.LoadSprite("GuttedIcon");
            Joyce.guttedIntent._color = Color.white;
            Joyce.guttedIntent._sound = self._intentDB[IntentType.Status_Scars]._sound;
            IntentInfo intentInfo;
            self._intentDB.TryGetValue((IntentType)987893, out intentInfo);
            if (intentInfo != null)
                return;
            self._intentDB.Add((IntentType)987893, Joyce.guttedIntent);
        }

        private static void SporesIntent(Action<IntentHandlerSO> orig, IntentHandlerSO self)
        {
            orig(self);
            Joyce.sporesIntent._type = (IntentType)987892;
            Joyce.sporesIntent._sprite = ResourceLoader.LoadSprite("VenusSpores");
            Joyce.sporesIntent._color = Color.white;
            Joyce.sporesIntent._sound = self._intentDB[IntentType.Status_Ruptured]._sound;
            IntentInfo intentInfo;
            self._intentDB.TryGetValue((IntentType)987892, out intentInfo);
            if (intentInfo != null)
                return;
            self._intentDB.Add((IntentType)987892, Joyce.sporesIntent);
        }

        private static void Add()
        {
            IDetour detour1 = (IDetour)new Hook((MethodBase)typeof(CombatManager).GetMethod("InitializeCombat", ~BindingFlags.Default), typeof(Joyce).GetMethod("AddAnestheticsStatusEffect", ~BindingFlags.Default));
            IDetour detour2 = (IDetour)new Hook((MethodBase)typeof(CombatManager).GetMethod("InitializeCombat", ~BindingFlags.Default), typeof(Joyce).GetMethod("AddGloomStatusEffect", ~BindingFlags.Default));
            IDetour detour3 = (IDetour)new Hook((MethodBase)typeof(CombatManager).GetMethod("InitializeCombat", ~BindingFlags.Default), typeof(Joyce).GetMethod("AddDeterminedStatusEffect", ~BindingFlags.Default));
            IDetour detour4 = (IDetour)new Hook((MethodBase)typeof(CombatManager).GetMethod("InitializeCombat", ~BindingFlags.Default), typeof(Joyce).GetMethod("AddPowerStatusEffect", ~BindingFlags.Default));
            IDetour detour5 = (IDetour)new Hook((MethodBase)typeof(CombatManager).GetMethod("InitializeCombat", ~BindingFlags.Default), typeof(Joyce).GetMethod("AddFunStatusEffect", ~BindingFlags.Default));
            IDetour detour6 = (IDetour)new Hook((MethodBase)typeof(CombatManager).GetMethod("InitializeCombat", ~BindingFlags.Default), typeof(Joyce).GetMethod("AddSporesStatusEffect", ~BindingFlags.Default));
            IDetour detour7 = (IDetour)new Hook((MethodBase)typeof(IntentHandlerSO).GetMethod("Initialize", ~BindingFlags.Default), typeof(Joyce).GetMethod("AnestheticsIntent", ~BindingFlags.Default));
            IDetour detour8 = (IDetour)new Hook((MethodBase)typeof(IntentHandlerSO).GetMethod("Initialize", ~BindingFlags.Default), typeof(Joyce).GetMethod("GloomIntent", ~BindingFlags.Default));
            IDetour detour9 = (IDetour)new Hook((MethodBase)typeof(IntentHandlerSO).GetMethod("Initialize", ~BindingFlags.Default), typeof(Joyce).GetMethod("DeterminedIntent", ~BindingFlags.Default));
            IDetour detour10 = (IDetour)new Hook((MethodBase)typeof(IntentHandlerSO).GetMethod("Initialize", ~BindingFlags.Default), typeof(Joyce).GetMethod("PowerIntent", ~BindingFlags.Default));
            IDetour detour11 = (IDetour)new Hook((MethodBase)typeof(IntentHandlerSO).GetMethod("Initialize", ~BindingFlags.Default), typeof(Joyce).GetMethod("FunIntent", ~BindingFlags.Default));
            IDetour detour12 = (IDetour)new Hook((MethodBase)typeof(IntentHandlerSO).GetMethod("Initialize", ~BindingFlags.Default), typeof(Joyce).GetMethod("GuttedIntent", ~BindingFlags.Default));
            IDetour detour13 = (IDetour)new Hook((MethodBase)typeof(IntentHandlerSO).GetMethod("Initialize", ~BindingFlags.Default), typeof(Joyce).GetMethod("SporesIntent", ~BindingFlags.Default));
            IDetour detour14 = (IDetour)new Hook((MethodBase)typeof(TooltipTextHandlerSO).GetMethod("ProcessStoredValue", ~BindingFlags.Default), typeof(Joyce).GetMethod("AddStoredValueName", ~BindingFlags.Default));
            IDetour detour15 = (IDetour)new Hook((MethodBase)typeof(TooltipTextHandlerSO).GetMethod("ProcessStoredValue", ~BindingFlags.Default), typeof(Joyce).GetMethod("AddStoredValueName1", ~BindingFlags.Default));
            IDetour detour16 = (IDetour)new Hook((MethodBase)typeof(TooltipTextHandlerSO).GetMethod("ProcessStoredValue", ~BindingFlags.Default), typeof(Joyce).GetMethod("AddStoredValueName10", ~BindingFlags.Default));
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
            CasterStoredValueSetEffect instance8 = ScriptableObject.CreateInstance<CasterStoredValueSetEffect>();
            instance8._minimumValue = 0;
            instance8._valueName = (UnitStoredValueNames)2233456;
            ScriptableObject.CreateInstance<PreviousEffectCondition>().wasSuccessful = false;
            ScriptableObject.CreateInstance<PreviousEffectCondition>().wasSuccessful = true;
            CheckTwoPassiveAbilityEffect instance9 = ScriptableObject.CreateInstance<CheckTwoPassiveAbilityEffect>();
            instance9._type = PassiveAbilityTypes.Infantile;
            instance9._type1 = PassiveAbilityTypes.Infestation;
            CheckThreePassiveAbilityEffect instance10 = ScriptableObject.CreateInstance<CheckThreePassiveAbilityEffect>();
            instance10._type = PassiveAbilityTypes.Skittish;
            instance10._type1 = PassiveAbilityTypes.Slippery;
            instance10._type2 = PassiveAbilityTypes.Masochism;
            CheckFourPassiveAbilityEffect instance11 = ScriptableObject.CreateInstance<CheckFourPassiveAbilityEffect>();
            instance11._type = PassiveAbilityTypes.Obscure;
            instance11._type1 = PassiveAbilityTypes.Confusion;
            instance11._type2 = PassiveAbilityTypes.Forgetful;
            instance11._type3 = PassiveAbilityTypes.Formless;
            ScriptableObject.CreateInstance<DamageEffect>()._usePreviousExitValue = true;
            CasterStoredValueChangeEffect instance12 = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
            instance12._valueName = (UnitStoredValueNames)202300;
            instance12._increase = true;
            ScriptableObject.CreateInstance<CasterSeedBankSpendEffect>()._valueName = (UnitStoredValueNames)202300;
            CasterCheckStoredValueAboveCondition instance13 = ScriptableObject.CreateInstance<CasterCheckStoredValueAboveCondition>();
            instance13._valueName = (UnitStoredValueNames)202302;
            instance13._checkValue = 0;
            ScriptableObject.CreateInstance<CasterStoredValueSetEffect>()._valueName = (UnitStoredValueNames)202302;
            ScriptableObject.CreateInstance<PercentageEffectorCondition>().triggerPercentage = 10;
            ScriptableObject.CreateInstance<CheckPassiveAbilityEffect>()._type = (PassiveAbilityTypes)200333;
            CustomPreviousEffectCondition instance14 = ScriptableObject.CreateInstance<CustomPreviousEffectCondition>();
            instance14._valueName = (UnitStoredValueNames)200300;
            instance14._checkValue = 10;
            CasterCheckStoredValueAboveCondition instance15 = ScriptableObject.CreateInstance<CasterCheckStoredValueAboveCondition>();
            instance15._valueName = (UnitStoredValueNames)200300;
            instance15._checkValue = 0;
            ScriptableObject.CreateInstance<CasterStoredValueSetEffect>()._valueName = (UnitStoredValueNames)200300;
            Targetting_ByUnit_Side instance16 = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            instance16.getAllies = false;
            instance16.getAllUnitSlots = false;
            ScriptableObject.CreateInstance<HealEffect>().usePreviousExitValue = true;
        }

        public static string AddStoredValueName10(
          Func<TooltipTextHandlerSO, UnitStoredValueNames, int, string> orig,
          TooltipTextHandlerSO self,
          UnitStoredValueNames storedValue,
          int value)
        {
            Color red = Color.red;
            string str1;
            if (storedValue == (UnitStoredValueNames)98789)
            {
                if (value <= 0)
                {
                    str1 = "";
                }
                else
                {
                    string str2 = "Not True" + string.Format(" +{0}", (object)value);
                    string str3 = "<color=#" + ColorUtility.ToHtmlStringRGB(self._negativeSTColor) + ">";
                    string str4 = "</color>";
                    str1 = str3 + str2 + str4;
                }
            }
            else
                str1 = orig(self, storedValue, value);
            return str1;
        }

        public static string AddStoredValueName11(
          Func<TooltipTextHandlerSO, UnitStoredValueNames, int, string> orig,
          TooltipTextHandlerSO self,
          UnitStoredValueNames storedValue,
          int value)
        {
            Color magenta = Color.magenta;
            string str1;
            if (storedValue == (UnitStoredValueNames)98788)
            {
                if (value <= 0)
                {
                    str1 = "";
                }
                else
                {
                    string str2 = "Machine Guns" + string.Format(" x{0}", (object)value);
                    string str3 = "<color=#" + ColorUtility.ToHtmlStringRGB(self._negativeSTColor) + ">";
                    string str4 = "</color>";
                    str1 = str3 + str2 + str4;
                }
            }
            else
                str1 = orig(self, storedValue, value);
            return str1;
        }

        public static string AddStoredValueName(
          Func<TooltipTextHandlerSO, UnitStoredValueNames, int, string> orig,
          TooltipTextHandlerSO self,
          UnitStoredValueNames storedValue,
          int value)
        {
            Color red = Color.red;
            string str1;
            if (storedValue == (UnitStoredValueNames)59998)
            {
                if (value <= 0)
                {
                    str1 = "";
                }
                else
                {
                    string str2 = "Marunouchi" + string.Format(" +{0}", (object)value);
                    string str3 = "<color=#" + ColorUtility.ToHtmlStringRGB(self._negativeSTColor) + ">";
                    string str4 = "</color>";
                    str1 = str3 + str2 + str4;
                }
            }
            else
                str1 = orig(self, storedValue, value);
            return str1;
        }

        public static string AddStoredValueName1(
          Func<TooltipTextHandlerSO, UnitStoredValueNames, int, string> orig,
          TooltipTextHandlerSO self,
          UnitStoredValueNames storedValue,
          int value)
        {
            Color magenta = Color.magenta;
            string str1;
            if (storedValue == (UnitStoredValueNames)59997)
            {
                if (value <= 0)
                {
                    str1 = "";
                }
                else
                {
                    string str2 = "Noise" + string.Format(" +{0}", (object)value);
                    string str3 = "<color=#" + ColorUtility.ToHtmlStringRGB(self._negativeSTColor) + ">";
                    string str4 = "</color>";
                    str1 = str3 + str2 + str4;
                }
            }
            else
                str1 = orig(self, storedValue, value);
            return str1;
        }

        public static string AddStoredValueName2(
          Func<TooltipTextHandlerSO, UnitStoredValueNames, int, string> orig,
          TooltipTextHandlerSO self,
          UnitStoredValueNames storedValue,
          int value)
        {
            Color red = Color.red;
            string str1;
            if (storedValue == (UnitStoredValueNames)59996)
            {
                if (value <= 0)
                {
                    str1 = "";
                }
                else
                {
                    string str2 = "Noise Raise" + string.Format(" -{0}", (object)value);
                    string str3 = "<color=#" + ColorUtility.ToHtmlStringRGB(self._negativeSTColor) + ">";
                    string str4 = "</color>";
                    str1 = str3 + str2 + str4;
                }
            }
            else
                str1 = orig(self, storedValue, value);
            return str1;
        }

        public static string AddStoredValueName3(
          Func<TooltipTextHandlerSO, UnitStoredValueNames, int, string> orig,
          TooltipTextHandlerSO self,
          UnitStoredValueNames storedValue,
          int value)
        {
            Color red = Color.red;
            string str1;
            if (storedValue == (UnitStoredValueNames)59995)
            {
                if (value <= 0)
                {
                    str1 = "";
                }
                else
                {
                    string str2 = "Drugs State" + string.Format(" = {0}", (object)value);
                    string str3 = "<color=#" + ColorUtility.ToHtmlStringRGB(self._negativeSTColor) + ">";
                    string str4 = "</color>";
                    str1 = str3 + str2 + str4;
                }
            }
            else
                str1 = orig(self, storedValue, value);
            return str1;
        }

        public static string AddStoredValueName45(
          Func<TooltipTextHandlerSO, UnitStoredValueNames, int, string> orig,
          TooltipTextHandlerSO self,
          UnitStoredValueNames storedValue,
          int value)
        {
            Color red = Color.red;
            string str1;
            if (storedValue == (UnitStoredValueNames)222223333)
            {
                if (value <= 0)
                {
                    str1 = "";
                }
                else
                {
                    string str2 = "Time left: " + string.Format(" {0}", (object)Math.Max(0, 45 - PynchonHandler.TryGetTime()));
                    string str3 = "<color=#" + ColorUtility.ToHtmlStringRGB(Color.green) + ">";
                    string str4 = "</color>";
                    str1 = str3 + str2 + str4;
                }
            }
            else
                str1 = orig(self, storedValue, value);
            return str1;
        }

        public static string AddStoredValueName77(
          Func<TooltipTextHandlerSO, UnitStoredValueNames, int, string> orig,
          TooltipTextHandlerSO self,
          UnitStoredValueNames storedValue,
          int value)
        {
            Color red = Color.red;
            string str1;
            if (storedValue == (UnitStoredValueNames)12334566)
            {
                if (value <= 0)
                {
                    str1 = "";
                }
                else
                {
                    string str2 = "In Game Minutes: " + string.Format(" {0}", (object)value);
                    string str3 = "<color=#" + ColorUtility.ToHtmlStringRGB(self._positiveSTColor) + ">";
                    string str4 = "</color>";
                    str1 = str3 + str2 + str4;
                }
            }
            else
                str1 = orig(self, storedValue, value);
            return str1;
        }

        public static string AddStoredValueName6969(
          Func<TooltipTextHandlerSO, UnitStoredValueNames, int, string> orig,
          TooltipTextHandlerSO self,
          UnitStoredValueNames storedValue,
          int value)
        {
            Color red = Color.red;
            string str1;
            if (storedValue == (UnitStoredValueNames)69696969)
            {
                if (value == 0)
                {
                    str1 = "";
                }
                else
                {
                    string str2 = "Impatience +" + string.Format(" {0}", (object)value);
                    string str3 = "<color=#" + ColorUtility.ToHtmlStringRGB(self._negativeSTColor) + ">";
                    string str4 = "</color>";
                    str1 = str3 + str2 + str4;
                }
            }
            else
                str1 = orig(self, storedValue, value);
            return str1;
        }

        public static string AddStoredValueName202300(
          Func<TooltipTextHandlerSO, UnitStoredValueNames, int, string> orig,
          TooltipTextHandlerSO self,
          UnitStoredValueNames storedValue,
          int value)
        {
            Color red = Color.red;
            string str1;
            if (storedValue == (UnitStoredValueNames)202300)
            {
                if (value <= 0)
                {
                    str1 = "";
                }
                else
                {
                    string str2 = "Seed Bank:" + string.Format(" {0}", (object)value);
                    string str3 = "<color=#" + ColorUtility.ToHtmlStringRGB(Color.green) + ">";
                    string str4 = "</color>";
                    str1 = str3 + str2 + str4;
                }
            }
            else
                str1 = orig(self, storedValue, value);
            return str1;
        }

        public static string AddStoredValueNameCycleBought(
          Func<TooltipTextHandlerSO, UnitStoredValueNames, int, string> orig,
          TooltipTextHandlerSO self,
          UnitStoredValueNames storedValue,
          int value)
        {
            Color red = Color.red;
            string str1;
            if (storedValue == (UnitStoredValueNames)200300)
            {
                if (value <= 0)
                {
                    str1 = "";
                }
                else
                {
                    string str2 = "Cycle Bought:" + string.Format(" {0}", (object)value);
                    string str3 = "<color=#" + ColorUtility.ToHtmlStringRGB(Color.green) + ">";
                    string str4 = "</color>";
                    str1 = str3 + str2 + str4;
                }
            }
            else
                str1 = orig(self, storedValue, value);
            return str1;
        }
    }
}
