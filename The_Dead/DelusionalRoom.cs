// Decompiled with JetBrains decompiler
// Type: THE_DEAD.DelusionalRoom
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using BrutalAPI;
using System.Linq;
using Tools;
using UnityEngine;

namespace THE_DEAD
{
  public static class DelusionalRoom
  {
    private static GameObject Base;
    private static NPCRoomHandler Room;
    private static DialogueSO Dialogue;
    private static FreeFoolEncounterSO Free;
    private static SpeakerBundle bundle;
    private static SpeakerData speaker;

    private static string Name => "Roger";

    private static string Files => "Roger_CH";

    private static Character chara => _13_TheDelusional.Chara;

    private static int Zone => 0;

    private static bool Left => false;

    private static bool Center => false;

    public static Color32 Color => new Color32((byte) 195, (byte) 0, (byte) 0, byte.MaxValue);

    private static string roomName => DelusionalRoom.Name + "Room";

    private static string convoName => DelusionalRoom.Name + "Convo";

    private static string encounterName => DelusionalRoom.Name + "Encounter";

    private static Sprite Talk => DelusionalRoom.chara.frontSprite;

    private static Sprite Portal => DelusionalRoom.chara.overworldSprite;

    private static string Audio => DelusionalRoom.chara.dialogueSound;

    private static int ID => (int) DelusionalRoom.chara.entityID;

    public static void Setup()
    {
      BrutalAPI.BrutalAPI.AddSignType((SignType) DelusionalRoom.ID, DelusionalRoom.Portal);
      DelusionalRoom.Base = Backrooms.Assets.LoadAsset<GameObject>("Assets/Rooms/" + DelusionalRoom.Name + "Room.prefab");
      DelusionalRoom.Room = DelusionalRoom.Base.AddComponent<NPCRoomHandler>();
      DelusionalRoom.Room._npcSelectable = (BaseRoomItem) DelusionalRoom.Room.transform.GetChild(0).gameObject.AddComponent<BasicRoomItem>();
      DelusionalRoom.Room._npcSelectable._renderers = new SpriteRenderer[1]
      {
        DelusionalRoom.Room._npcSelectable.transform.GetChild(0).GetComponent<SpriteRenderer>()
      };
      DelusionalRoom.Room._npcSelectable._renderers[0].material = Backrooms.Mat;
      DialogueSO instance1 = ScriptableObject.CreateInstance<DialogueSO>();
      instance1.name = DelusionalRoom.convoName;
      instance1.dialog = Backrooms.Yarn;
      instance1.startNode = "Salt." + DelusionalRoom.Name + ".TryHire";
      DelusionalRoom.Dialogue = instance1;
      FreeFoolEncounterSO instance2 = ScriptableObject.CreateInstance<FreeFoolEncounterSO>();
      instance2.name = DelusionalRoom.encounterName;
      instance2._dialogue = DelusionalRoom.convoName;
      instance2.encounterRoom = DelusionalRoom.roomName;
      instance2._freeFool = DelusionalRoom.Files;
      instance2.signType = (SignType) DelusionalRoom.ID;
      instance2.npcEntityIDs = new EntityIDs[1]
      {
        (EntityIDs) DelusionalRoom.ID
      };
      DelusionalRoom.Free = instance2;
      DelusionalRoom.bundle = new SpeakerBundle()
      {
        dialogueSound = DelusionalRoom.Audio,
        portrait = DelusionalRoom.Talk,
        bundleTextColor = (UnityEngine.Color) DelusionalRoom.Color
      };
      SpeakerData instance3 = ScriptableObject.CreateInstance<SpeakerData>();
      instance3.speakerName = DelusionalRoom.Name + PathUtils.speakerDataSuffix;
      instance3.name = DelusionalRoom.Name + PathUtils.speakerDataSuffix;
      instance3._defaultBundle = DelusionalRoom.bundle;
      instance3.portraitLooksLeft = DelusionalRoom.Left;
      instance3.portraitLooksCenter = DelusionalRoom.Center;
      DelusionalRoom.speaker = instance3;
    }

    public static void Add()
    {
      if (!LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains<string>(PathUtils.encounterRoomsResPath + DelusionalRoom.roomName))
        LoadedAssetsHandler.LoadedRoomPrefabs.Add(PathUtils.encounterRoomsResPath + DelusionalRoom.roomName, (BaseRoomHandler) DelusionalRoom.Room);
      else
        LoadedAssetsHandler.LoadedRoomPrefabs[PathUtils.encounterRoomsResPath + DelusionalRoom.roomName] = (BaseRoomHandler) DelusionalRoom.Room;
      if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(DelusionalRoom.convoName))
        LoadedAssetsHandler.LoadedDialogues.Add(DelusionalRoom.convoName, DelusionalRoom.Dialogue);
      else
        LoadedAssetsHandler.LoadedDialogues[DelusionalRoom.convoName] = DelusionalRoom.Dialogue;
      if (!LoadedAssetsHandler.LoadedFreeFoolEncounters.Keys.Contains<string>(DelusionalRoom.encounterName))
        LoadedAssetsHandler.LoadedFreeFoolEncounters.Add(DelusionalRoom.encounterName, DelusionalRoom.Free);
      else
        LoadedAssetsHandler.LoadedFreeFoolEncounters[DelusionalRoom.encounterName] = DelusionalRoom.Free;
      Backrooms.AddPool(DelusionalRoom.encounterName, DelusionalRoom.Zone);
      if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains<string>(DelusionalRoom.speaker.speakerName))
        LoadedAssetsHandler.LoadedSpeakers.Add(DelusionalRoom.speaker.speakerName, DelusionalRoom.speaker);
      else
        LoadedAssetsHandler.LoadedSpeakers[DelusionalRoom.speaker.speakerName] = DelusionalRoom.speaker;
    }
  }
}
