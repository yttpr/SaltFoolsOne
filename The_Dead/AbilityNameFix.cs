// Decompiled with JetBrains decompiler
// Type: THE_DEAD.AbilityNameFix
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using BrutalAPI;
using MonoMod.RuntimeDetour;
using System;
using System.Reflection;

namespace THE_DEAD
{
    public static class AbilityNameFix
    {
        public static global::CharacterAbility CharacterAbility(
          Func<Ability, global::CharacterAbility> orig,
          Ability self)
        {
            global::CharacterAbility characterAbility = orig(self);
            characterAbility.ability._abilityName = self.name;
            characterAbility.ability._description = self.description;
            characterAbility.ability.name = self.name;
            characterAbility.ability = AbilityNameFix.AttachValues(characterAbility.ability);
            return characterAbility;
        }

        public static EnemyAbilityInfo EnemyAbility(
          Func<Ability, EnemyAbilityInfo> orig,
          Ability self)
        {
            EnemyAbilityInfo enemyAbilityInfo = orig(self);
            enemyAbilityInfo.ability._abilityName = self.name;
            enemyAbilityInfo.ability._description = self.description;
            enemyAbilityInfo.ability.name = self.name;
            enemyAbilityInfo.ability = AbilityNameFix.AttachValues(enemyAbilityInfo.ability, false);
            return enemyAbilityInfo;
        }

        public static void Setup()
        {
            IDetour detour1 = (IDetour)new Hook((MethodBase)typeof(Ability).GetMethod("CharacterAbility", ~BindingFlags.Default), typeof(AbilityNameFix).GetMethod("CharacterAbility", ~BindingFlags.Default));
            IDetour detour2 = (IDetour)new Hook((MethodBase)typeof(Ability).GetMethod("EnemyAbility", ~BindingFlags.Default), typeof(AbilityNameFix).GetMethod("EnemyAbility", ~BindingFlags.Default));
        }

        public static AbilitySO AttachValues(AbilitySO ability, bool chara = true)
        {
            if (ability._abilityName.Contains("Noise") & chara)
                ability.specialStoredValue = (UnitStoredValueNames)59997;
            return ability;
        }
    }
}
