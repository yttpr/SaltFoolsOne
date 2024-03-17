// Decompiled with JetBrains decompiler
// Type: THE_DEAD.PigmentUsedCollector
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace THE_DEAD
{
  public static class PigmentUsedCollector
  {
    public static List<ManaColorSO> lastUsed;
    public static int ID;

    public static void UseAbility(
      Action<CharacterCombat, int, FilledManaCost[]> orig,
      CharacterCombat self,
      int abilityID,
      FilledManaCost[] filledCost)
    {
      if (PigmentUsedCollector.lastUsed == null)
        PigmentUsedCollector.lastUsed = new List<ManaColorSO>();
      PigmentUsedCollector.lastUsed.Clear();
      PigmentUsedCollector.ID = self.ID;
      foreach (FilledManaCost filledManaCost in filledCost)
        PigmentUsedCollector.lastUsed.Add(filledManaCost.Mana);
      orig(self, abilityID, filledCost);
    }

    public static void FinalizeAbilityActions(Action<CharacterCombat> orig, CharacterCombat self)
    {
      orig(self);
      PigmentUsedCollector.ID = -1;
      PigmentUsedCollector.lastUsed.Clear();
    }

    public static void Setup()
    {
      PigmentUsedCollector.lastUsed = new List<ManaColorSO>();
      IDetour detour1 = (IDetour) new Hook((MethodBase) typeof (CharacterCombat).GetMethod("UseAbility", ~BindingFlags.Default), typeof (PigmentUsedCollector).GetMethod("UseAbility", ~BindingFlags.Default));
      IDetour detour2 = (IDetour) new Hook((MethodBase) typeof (CharacterCombat).GetMethod("FinalizeAbilityActions", ~BindingFlags.Default), typeof (PigmentUsedCollector).GetMethod("FinalizeAbilityActions", ~BindingFlags.Default));
    }
  }
}
