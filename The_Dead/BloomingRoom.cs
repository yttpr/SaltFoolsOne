// Decompiled with JetBrains decompiler
// Type: THE_DEAD.BloomingRoom
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using BrutalAPI;
using System.Linq;
using Tools;
using UnityEngine;

namespace THE_DEAD
{
  public static class BloomingRoom
  {
    private static GameObject Base;
    private static NPCRoomHandler Room;
    private static DialogueSO Dialogue;
    private static FreeFoolEncounterSO Free;
    private static SpeakerBundle bundle;
    private static SpeakerData speaker;

    private static string Name => "Venus";

    private static string Files => "Venus_CH";

    private static Character chara => _15_TheBlooming.Chara;

    private static int Zone => 0;

    private static bool Left => false;

    private static bool Center => false;

    public static Color32 Color => new Color32((byte) 0, (byte) 215, byte.MaxValue, byte.MaxValue);

    private static string roomName => BloomingRoom.Name + "Room";

    private static string convoName => BloomingRoom.Name + "Convo";

    private static string encounterName => BloomingRoom.Name + "Encounter";

    private static Sprite Talk => ResourceLoader.LoadSprite("VenusFrontBloom");

    private static Sprite Portal => BloomingRoom.chara.overworldSprite;

    private static string Audio => BloomingRoom.chara.dialogueSound;

    private static int ID => (int) BloomingRoom.chara.entityID;

    public static void Setup()
    {
      BrutalAPI.BrutalAPI.AddSignType((SignType) BloomingRoom.ID, BloomingRoom.Portal);
      BloomingRoom.Base = Backrooms.Assets.LoadAsset<GameObject>("Assets/Rooms/" + BloomingRoom.Name + "Room.prefab");
      BloomingRoom.Room = BloomingRoom.Base.AddComponent<NPCRoomHandler>();
      BloomingRoom.Room._npcSelectable = (BaseRoomItem) BloomingRoom.Room.transform.GetChild(0).gameObject.AddComponent<BasicRoomItem>();
      BloomingRoom.Room._npcSelectable._renderers = new SpriteRenderer[1]
      {
        BloomingRoom.Room._npcSelectable.transform.GetChild(0).GetComponent<SpriteRenderer>()
      };
      BloomingRoom.Room._npcSelectable._renderers[0].material = Backrooms.Mat;
      DialogueSO instance1 = ScriptableObject.CreateInstance<DialogueSO>();
      instance1.name = BloomingRoom.convoName;
      instance1.dialog = Backrooms.Yarn;
      instance1.startNode = "Salt." + BloomingRoom.Name + ".TryHire";
      BloomingRoom.Dialogue = instance1;
      FreeFoolEncounterSO instance2 = ScriptableObject.CreateInstance<FreeFoolEncounterSO>();
      instance2.name = BloomingRoom.encounterName;
      instance2._dialogue = BloomingRoom.convoName;
      instance2.encounterRoom = BloomingRoom.roomName;
      instance2._freeFool = BloomingRoom.Files;
      instance2.signType = (SignType) BloomingRoom.ID;
      instance2.npcEntityIDs = new EntityIDs[1]
      {
        (EntityIDs) BloomingRoom.ID
      };
      BloomingRoom.Free = instance2;
      BloomingRoom.bundle = new SpeakerBundle()
      {
        dialogueSound = BloomingRoom.Audio,
        portrait = BloomingRoom.Talk,
        bundleTextColor = (UnityEngine.Color) BloomingRoom.Color
      };
      SpeakerData instance3 = ScriptableObject.CreateInstance<SpeakerData>();
      instance3.speakerName = BloomingRoom.Name + PathUtils.speakerDataSuffix;
      instance3.name = BloomingRoom.Name + PathUtils.speakerDataSuffix;
      instance3._defaultBundle = BloomingRoom.bundle;
      instance3.portraitLooksLeft = BloomingRoom.Left;
      instance3.portraitLooksCenter = BloomingRoom.Center;
      BloomingRoom.speaker = instance3;
    }

    public static void Add()
    {
      if (!LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains<string>(PathUtils.encounterRoomsResPath + BloomingRoom.roomName))
        LoadedAssetsHandler.LoadedRoomPrefabs.Add(PathUtils.encounterRoomsResPath + BloomingRoom.roomName, (BaseRoomHandler) BloomingRoom.Room);
      else
        LoadedAssetsHandler.LoadedRoomPrefabs[PathUtils.encounterRoomsResPath + BloomingRoom.roomName] = (BaseRoomHandler) BloomingRoom.Room;
      if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(BloomingRoom.convoName))
        LoadedAssetsHandler.LoadedDialogues.Add(BloomingRoom.convoName, BloomingRoom.Dialogue);
      else
        LoadedAssetsHandler.LoadedDialogues[BloomingRoom.convoName] = BloomingRoom.Dialogue;
      if (!LoadedAssetsHandler.LoadedFreeFoolEncounters.Keys.Contains<string>(BloomingRoom.encounterName))
        LoadedAssetsHandler.LoadedFreeFoolEncounters.Add(BloomingRoom.encounterName, BloomingRoom.Free);
      else
        LoadedAssetsHandler.LoadedFreeFoolEncounters[BloomingRoom.encounterName] = BloomingRoom.Free;
      Backrooms.AddPool(BloomingRoom.encounterName, BloomingRoom.Zone);
      if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains<string>(BloomingRoom.speaker.speakerName))
        LoadedAssetsHandler.LoadedSpeakers.Add(BloomingRoom.speaker.speakerName, BloomingRoom.speaker);
      else
        LoadedAssetsHandler.LoadedSpeakers[BloomingRoom.speaker.speakerName] = BloomingRoom.speaker;
    }
  }
}
