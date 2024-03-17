// Decompiled with JetBrains decompiler
// Type: THE_DEAD.NoiseRoom
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using BrutalAPI;
using System.Linq;
using Tools;
using UnityEngine;

namespace THE_DEAD
{
  public static class NoiseRoom
  {
    private static GameObject Base;
    private static NPCRoomHandler Room;
    private static DialogueSO Dialogue;
    private static FreeFoolEncounterSO Free;
    private static SpeakerBundle bundle;
    private static SpeakerData speaker;

    private static string Name => "Maru";

    private static string Files => "MarunouchiSadistic_CH";

    private static Character chara => _03_TheNoise.Chara;

    private static int Zone => 2;

    private static bool Left => false;

    private static bool Center => true;

    public static Color32 Color => new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);

    private static string roomName => NoiseRoom.Name + "Room";

    private static string convoName => NoiseRoom.Name + "Convo";

    private static string encounterName => NoiseRoom.Name + "Encounter";

    private static Sprite Talk => NoiseRoom.chara.frontSprite;

    private static Sprite Portal => NoiseRoom.chara.overworldSprite;

    private static string Audio => NoiseRoom.chara.dialogueSound;

    private static int ID => (int) NoiseRoom.chara.entityID;

    public static void Setup()
    {
      BrutalAPI.BrutalAPI.AddSignType((SignType) NoiseRoom.ID, NoiseRoom.Portal);
      NoiseRoom.Base = Backrooms.Assets.LoadAsset<GameObject>("Assets/Rooms/" + NoiseRoom.Name + "Room.prefab");
      NoiseRoom.Room = NoiseRoom.Base.AddComponent<NPCRoomHandler>();
      NoiseRoom.Room._npcSelectable = (BaseRoomItem) NoiseRoom.Room.transform.GetChild(0).gameObject.AddComponent<BasicRoomItem>();
      NoiseRoom.Room._npcSelectable._renderers = new SpriteRenderer[1]
      {
        NoiseRoom.Room._npcSelectable.transform.GetChild(0).GetComponent<SpriteRenderer>()
      };
      NoiseRoom.Room._npcSelectable._renderers[0].material = Backrooms.Mat;
      DialogueSO instance1 = ScriptableObject.CreateInstance<DialogueSO>();
      instance1.name = NoiseRoom.convoName;
      instance1.dialog = Backrooms.Yarn;
      instance1.startNode = "Salt." + NoiseRoom.Name + ".TryHire";
      NoiseRoom.Dialogue = instance1;
      FreeFoolEncounterSO instance2 = ScriptableObject.CreateInstance<FreeFoolEncounterSO>();
      instance2.name = NoiseRoom.encounterName;
      instance2._dialogue = NoiseRoom.convoName;
      instance2.encounterRoom = NoiseRoom.roomName;
      instance2._freeFool = NoiseRoom.Files;
      instance2.signType = (SignType) NoiseRoom.ID;
      instance2.npcEntityIDs = new EntityIDs[1]
      {
        (EntityIDs) NoiseRoom.ID
      };
      NoiseRoom.Free = instance2;
      NoiseRoom.bundle = new SpeakerBundle()
      {
        dialogueSound = NoiseRoom.Audio,
        portrait = NoiseRoom.Talk,
        bundleTextColor = (UnityEngine.Color) NoiseRoom.Color
      };
      SpeakerData instance3 = ScriptableObject.CreateInstance<SpeakerData>();
      instance3.speakerName = NoiseRoom.Name + PathUtils.speakerDataSuffix;
      instance3.name = NoiseRoom.Name + PathUtils.speakerDataSuffix;
      instance3._defaultBundle = NoiseRoom.bundle;
      instance3.portraitLooksLeft = NoiseRoom.Left;
      instance3.portraitLooksCenter = NoiseRoom.Center;
      NoiseRoom.speaker = instance3;
    }

    public static void Add()
    {
      if (!LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains<string>(PathUtils.encounterRoomsResPath + NoiseRoom.roomName))
        LoadedAssetsHandler.LoadedRoomPrefabs.Add(PathUtils.encounterRoomsResPath + NoiseRoom.roomName, (BaseRoomHandler) NoiseRoom.Room);
      else
        LoadedAssetsHandler.LoadedRoomPrefabs[PathUtils.encounterRoomsResPath + NoiseRoom.roomName] = (BaseRoomHandler) NoiseRoom.Room;
      if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(NoiseRoom.convoName))
        LoadedAssetsHandler.LoadedDialogues.Add(NoiseRoom.convoName, NoiseRoom.Dialogue);
      else
        LoadedAssetsHandler.LoadedDialogues[NoiseRoom.convoName] = NoiseRoom.Dialogue;
      if (!LoadedAssetsHandler.LoadedFreeFoolEncounters.Keys.Contains<string>(NoiseRoom.encounterName))
        LoadedAssetsHandler.LoadedFreeFoolEncounters.Add(NoiseRoom.encounterName, NoiseRoom.Free);
      else
        LoadedAssetsHandler.LoadedFreeFoolEncounters[NoiseRoom.encounterName] = NoiseRoom.Free;
      Backrooms.AddPool(NoiseRoom.encounterName, NoiseRoom.Zone);
      if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains<string>(NoiseRoom.speaker.speakerName))
        LoadedAssetsHandler.LoadedSpeakers.Add(NoiseRoom.speaker.speakerName, NoiseRoom.speaker);
      else
        LoadedAssetsHandler.LoadedSpeakers[NoiseRoom.speaker.speakerName] = NoiseRoom.speaker;
    }
  }
}
