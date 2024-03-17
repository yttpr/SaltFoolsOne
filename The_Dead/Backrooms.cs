// Decompiled with JetBrains decompiler
// Type: THE_DEAD.Backrooms
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace THE_DEAD
{
  public static class Backrooms
  {
    public static AssetBundle Assets;
    public static YarnProgram Yarn;
    public static Material Mat;
    public const string Path = "Assets/Rooms/";
    public static string[] Hard = new string[3]
    {
      "ZoneDB_Hard_01",
      "ZoneDB_Hard_02",
      "ZoneDB_Hard_03"
    };
    public static string[] Easy = new string[3]
    {
      "ZoneDB_01",
      "ZoneDB_02",
      "ZoneDB_03"
    };

    public static void Setup()
    {
      IDetour detour1 = (IDetour) new Hook((MethodBase) typeof (MainMenuController).GetMethod("LoadOldRun", ~BindingFlags.Default), typeof (Backrooms).GetMethod("LoadOldRun", ~BindingFlags.Default));
      IDetour detour2 = (IDetour) new Hook((MethodBase) typeof (MainMenuController).GetMethod("OnEmbarkPressed", ~BindingFlags.Default), typeof (Backrooms).GetMethod("LoadOldRun", ~BindingFlags.Default));
      Backrooms.Assets = AssetBundle.LoadFromMemory(ResourceLoader.ResourceBinary("AssetBundle.thedead"));
      Backrooms.Yarn = Backrooms.Assets.LoadAsset<YarnProgram>("Assets/Rooms/TheDead.yarn");
      Backrooms.Mat = ((LoadedAssetsHandler.GetRoomPrefab(CardType.Flavour, LoadedAssetsHandler.GetBasicEncounter("PervertMessiah_Flavour").encounterRoom) as NPCRoomHandler)._npcSelectable as BasicRoomItem)._renderers[0].material;
      Backrooms.Calibrate();
      Backrooms.Add();
    }

    public static void LoadOldRun(Action<MainMenuController> orig, MainMenuController self)
    {
      orig(self);
      Backrooms.Add();
    }

    public static void Calibrate()
    {
      if (Joyce.IncludeTheDead)
      {
        try
        {
          DeadRoom.Setup();
        }
        catch
        {
          Debug.LogError((object) "00 freefool fail setup");
        }
      }
      if (Joyce.IncludeTheFree)
      {
        try
        {
          FreeRoom.Setup();
        }
        catch
        {
          Debug.LogError((object) "02 freefool fail setup");
        }
      }
      if (Joyce.IncludeTheNoise)
      {
        try
        {
          NoiseRoom.Setup();
        }
        catch
        {
          Debug.LogError((object) "03 freefool fail setup");
        }
      }
      if (Joyce.IncludeTheParanoid)
      {
        try
        {
          ParanoidRoom.Setup();
        }
        catch
        {
          Debug.LogError((object) "04 freefool fail setup");
        }
      }
      if (Joyce.IncludeTheLost)
      {
        try
        {
          LostRoom.Setup();
        }
        catch
        {
          Debug.LogError((object) "06 freefool fail setup");
        }
      }
      if (Joyce.IncludeTheLiving)
      {
        try
        {
          LivingRoom.Setup();
        }
        catch
        {
          Debug.LogError((object) "07 freefool fail setup");
        }
      }
      if (Joyce.IncludeTheRemnant)
      {
        try
        {
          RemnantRoom.Setup();
        }
        catch
        {
          Debug.LogError((object) "08 freefool fail setup");
        }
      }
      if (Joyce.IncludeTheToasted)
      {
        try
        {
          ToastRoom.Setup();
        }
        catch
        {
          Debug.LogError((object) "09 freefool fail setup");
        }
      }
      if (Joyce.IncludeTheDelusional)
      {
        try
        {
          DelusionalRoom.Setup();
        }
        catch
        {
          Debug.LogError((object) "13 freefool fail setup");
        }
      }
      if (Joyce.IncludeTheAbortion)
      {
        try
        {
          KILLBILLIONSRoom.Setup();
        }
        catch
        {
          Debug.LogError((object) "14 freefool fail setup");
        }
      }
      if (!Joyce.IncludeTheBlooming)
        return;
      try
      {
        BloomingRoom.Setup();
      }
      catch
      {
        Debug.LogError((object) "15 freefool fail setup");
      }
    }

    public static void Add()
    {
      if (Joyce.IncludeTheDead)
      {
        try
        {
          DeadRoom.Add();
        }
        catch
        {
          Debug.LogError((object) "00 freefool fail add");
        }
      }
      if (Joyce.IncludeTheFree)
      {
        try
        {
          FreeRoom.Add();
        }
        catch
        {
          Debug.LogError((object) "02 freefool fail add");
        }
      }
      if (Joyce.IncludeTheNoise)
      {
        try
        {
          NoiseRoom.Add();
        }
        catch
        {
          Debug.LogError((object) "03 freefool fail add");
        }
      }
      if (Joyce.IncludeTheParanoid)
      {
        try
        {
          ParanoidRoom.Add();
        }
        catch
        {
          Debug.LogError((object) "04 freefool fail add");
        }
      }
      if (Joyce.IncludeTheLost)
      {
        try
        {
          LostRoom.Add();
        }
        catch
        {
          Debug.LogError((object) "06 freefool fail add");
        }
      }
      if (Joyce.IncludeTheLiving)
      {
        try
        {
          LivingRoom.Add();
        }
        catch
        {
          Debug.LogError((object) "07 freefool fail add");
        }
      }
      if (Joyce.IncludeTheRemnant)
      {
        try
        {
          RemnantRoom.Add();
        }
        catch
        {
          Debug.LogError((object) "08 freefool fail add");
        }
      }
      if (Joyce.IncludeTheToasted)
      {
        try
        {
          ToastRoom.Add();
        }
        catch
        {
          Debug.LogError((object) "09 freefool fail add");
        }
      }
      if (Joyce.IncludeTheDelusional)
      {
        try
        {
          DelusionalRoom.Add();
        }
        catch
        {
          Debug.LogError((object) "13 freefool fail add");
        }
      }
      if (Joyce.IncludeTheAbortion)
      {
        try
        {
          KILLBILLIONSRoom.Add();
        }
        catch
        {
          Debug.LogError((object) "14 freefool fail add");
        }
      }
      if (!Joyce.IncludeTheBlooming)
        return;
      try
      {
        BloomingRoom.Add();
      }
      catch
      {
        Debug.LogError((object) "15 freefool fail add");
      }
    }

    public static void AddPool(string name, int zone)
    {
      ZoneBGDataBaseSO zoneDb1 = LoadedAssetsHandler.GetZoneDB(Backrooms.Easy[zone]) as ZoneBGDataBaseSO;
      ZoneBGDataBaseSO zoneDb2 = LoadedAssetsHandler.GetZoneDB(Backrooms.Hard[zone]) as ZoneBGDataBaseSO;
      if (!((IEnumerable<string>) zoneDb2._FreeFoolsPool).Contains<string>(name))
        zoneDb2._FreeFoolsPool = new List<string>((IEnumerable<string>) zoneDb2._FreeFoolsPool)
        {
          name
        }.ToArray();
      if (((IEnumerable<string>) zoneDb1._FreeFoolsPool).Contains<string>(name))
        return;
      zoneDb1._FreeFoolsPool = new List<string>((IEnumerable<string>) zoneDb1._FreeFoolsPool)
      {
        name
      }.ToArray();
    }

    public static void MoreFool(string zone)
    {
      CardTypeInfo cardTypeInfo = new CardTypeInfo();
      cardTypeInfo._cardInfo = new CardInfo()
      {
        cardType = CardType.EventFreeFool,
        pilePosition = PilePositionType.First
      };
      cardTypeInfo._minimumAmount = 40;
      cardTypeInfo._maximumAmount = 40;
      ZoneBGDataBaseSO zoneDb = LoadedAssetsHandler.GetZoneDB(zone) as ZoneBGDataBaseSO;
      List<CardTypeInfo> cardTypeInfoList = new List<CardTypeInfo>((IEnumerable<CardTypeInfo>) zoneDb._deckInfo._possibleCards)
      {
        cardTypeInfo
      };
      zoneDb._deckInfo._possibleCards = cardTypeInfoList.ToArray();
    }

    public static void MoreFoolAll()
    {
      for (int index = 0; index < 3; ++index)
      {
        Backrooms.MoreFool(Backrooms.Hard[index]);
        Backrooms.MoreFool(Backrooms.Easy[index]);
      }
    }
  }
}
