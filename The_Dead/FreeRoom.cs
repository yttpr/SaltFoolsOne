// Decompiled with JetBrains decompiler
// Type: THE_DEAD.FreeRoom
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using BrutalAPI;
using System.Linq;
using Tools;
using UnityEngine;

namespace THE_DEAD
{
  public static class FreeRoom
  {
    private static GameObject Base;
    private static NPCRoomHandler Room;
    private static DialogueSO Dialogue;
    private static FreeFoolEncounterSO Free;
    private static SpeakerBundle bundle;
    private static SpeakerData speaker;

    private static string Name => "Verne";

    private static string Files => "Verne_CH";

    private static Character chara => _02_TheFree.Chara;

    private static int Zone => 1;

    private static bool Left => true;

    private static bool Center => false;

    public static Color32 Color => new Color32((byte) 114, (byte) 231, byte.MaxValue, byte.MaxValue);

    private static string roomName => FreeRoom.Name + "Room";

    private static string convoName => FreeRoom.Name + "Convo";

    private static string encounterName => FreeRoom.Name + "Encounter";

    private static Sprite Talk => FreeRoom.chara.frontSprite;

    private static Sprite Portal => FreeRoom.chara.overworldSprite;

    private static string Audio => FreeRoom.chara.dialogueSound;

    private static int ID => (int) FreeRoom.chara.entityID;

    public static void Setup()
    {
      BrutalAPI.BrutalAPI.AddSignType((SignType) FreeRoom.ID, FreeRoom.Portal);
      FreeRoom.Base = Backrooms.Assets.LoadAsset<GameObject>("Assets/Rooms/" + FreeRoom.Name + "Room.prefab");
      FreeRoom.Room = FreeRoom.Base.AddComponent<NPCRoomHandler>();
      FreeRoom.Room._npcSelectable = (BaseRoomItem) FreeRoom.Room.transform.GetChild(0).gameObject.AddComponent<BasicRoomItem>();
      FreeRoom.Room._npcSelectable._renderers = new SpriteRenderer[1]
      {
        FreeRoom.Room._npcSelectable.transform.GetChild(0).GetComponent<SpriteRenderer>()
      };
      FreeRoom.Room._npcSelectable._renderers[0].material = Backrooms.Mat;
      DialogueSO instance1 = ScriptableObject.CreateInstance<DialogueSO>();
      instance1.name = FreeRoom.convoName;
      instance1.dialog = Backrooms.Yarn;
      instance1.startNode = "Salt." + FreeRoom.Name + ".TryHire";
      FreeRoom.Dialogue = instance1;
      FreeFoolEncounterSO instance2 = ScriptableObject.CreateInstance<FreeFoolEncounterSO>();
      instance2.name = FreeRoom.encounterName;
      instance2._dialogue = FreeRoom.convoName;
      instance2.encounterRoom = FreeRoom.roomName;
      instance2._freeFool = FreeRoom.Files;
      instance2.signType = (SignType) FreeRoom.ID;
      instance2.npcEntityIDs = new EntityIDs[1]
      {
        (EntityIDs) FreeRoom.ID
      };
      FreeRoom.Free = instance2;
      FreeRoom.bundle = new SpeakerBundle()
      {
        dialogueSound = FreeRoom.Audio,
        portrait = FreeRoom.Talk,
        bundleTextColor = (UnityEngine.Color) FreeRoom.Color
      };
      SpeakerData instance3 = ScriptableObject.CreateInstance<SpeakerData>();
      instance3.speakerName = FreeRoom.Name + PathUtils.speakerDataSuffix;
      instance3.name = FreeRoom.Name + PathUtils.speakerDataSuffix;
      instance3._defaultBundle = FreeRoom.bundle;
      instance3.portraitLooksLeft = FreeRoom.Left;
      instance3.portraitLooksCenter = FreeRoom.Center;
      FreeRoom.speaker = instance3;
    }

    public static void Add()
    {
      if (!LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains<string>(PathUtils.encounterRoomsResPath + FreeRoom.roomName))
        LoadedAssetsHandler.LoadedRoomPrefabs.Add(PathUtils.encounterRoomsResPath + FreeRoom.roomName, (BaseRoomHandler) FreeRoom.Room);
      else
        LoadedAssetsHandler.LoadedRoomPrefabs[PathUtils.encounterRoomsResPath + FreeRoom.roomName] = (BaseRoomHandler) FreeRoom.Room;
      if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(FreeRoom.convoName))
        LoadedAssetsHandler.LoadedDialogues.Add(FreeRoom.convoName, FreeRoom.Dialogue);
      else
        LoadedAssetsHandler.LoadedDialogues[FreeRoom.convoName] = FreeRoom.Dialogue;
      if (!LoadedAssetsHandler.LoadedFreeFoolEncounters.Keys.Contains<string>(FreeRoom.encounterName))
        LoadedAssetsHandler.LoadedFreeFoolEncounters.Add(FreeRoom.encounterName, FreeRoom.Free);
      else
        LoadedAssetsHandler.LoadedFreeFoolEncounters[FreeRoom.encounterName] = FreeRoom.Free;
      Backrooms.AddPool(FreeRoom.encounterName, FreeRoom.Zone);
      if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains<string>(FreeRoom.speaker.speakerName))
        LoadedAssetsHandler.LoadedSpeakers.Add(FreeRoom.speaker.speakerName, FreeRoom.speaker);
      else
        LoadedAssetsHandler.LoadedSpeakers[FreeRoom.speaker.speakerName] = FreeRoom.speaker;
    }
  }
}
