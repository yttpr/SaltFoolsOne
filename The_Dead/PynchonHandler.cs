// Decompiled with JetBrains decompiler
// Type: THE_DEAD.PynchonHandler
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using MonoMod.RuntimeDetour;
using System;
using System.Reflection;
using UnityEngine;

namespace THE_DEAD
{
  public class PynchonHandler : MonoBehaviour
  {
    public static int TimeLeft = 45 - PynchonHandler.TimePassed;
    public static int TimePassed;
    public static PynchonHandler Instance;
    public int SelfTime;
    public static float second = 1f;
    public float measure = 0.0f;

    public static void TryReset()
    {
      if (!((UnityEngine.Object) PynchonHandler.Instance != (UnityEngine.Object) null) || ((object) PynchonHandler.Instance).Equals((object) null))
        return;
      PynchonHandler.Instance.Reset();
    }

    public static int TryGetTime()
    {
      try
      {
        return PynchonHandler.Instance.SelfTime;
      }
      catch
      {
        return 0;
      }
    }

    public void Reset() => this.SelfTime = 0;

    public void FixedUpdate()
    {
      if (!CombatManager.Instance._stats.IsPlayerTurn)
        return;
      this.measure += Time.deltaTime;
      if ((double) this.measure < (double) PynchonHandler.second)
        return;
      this.measure = 0.0f;
      ++this.SelfTime;
      PynchonHandler.TimePassed = this.SelfTime;
    }

    public static int GetStoredValue(
      Func<IUnit, UnitStoredValueNames, int> orig,
      IUnit self,
      UnitStoredValueNames valueName)
    {
      int num = orig(self, valueName);
      return num > 0 && valueName == (UnitStoredValueNames) 222223333 ? PynchonHandler.TimePassed : num;
    }

    public static void Setup()
    {
      IDetour detour1 = (IDetour) new Hook((MethodBase) typeof (CharacterCombat).GetMethod("GetStoredValue", ~BindingFlags.Default), typeof (PynchonHandler).GetMethod("GetStoredValue", ~BindingFlags.Default));
      IDetour detour2 = (IDetour) new Hook((MethodBase) typeof (EnemyCombat).GetMethod("GetStoredValue", ~BindingFlags.Default), typeof (PynchonHandler).GetMethod("GetStoredValue", ~BindingFlags.Default));
    }
  }
}
