// Decompiled with JetBrains decompiler
// Type: THE_DEAD.LostRoom
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using BrutalAPI;
using System.Linq;
using Tools;
using UnityEngine;

namespace THE_DEAD
{
  public static class LostRoom
  {
    private static GameObject Base;
    private static NPCRoomHandler Room;
    private static DialogueSO Dialogue;
    private static FreeFoolEncounterSO Free;
    private static SpeakerBundle bundle;
    private static SpeakerData speaker;

    private static string Name => "Kafka";

    private static string Files => "Kafka_CH";

    private static Character chara => _06_TheLost.Chara;

    private static int Zone => 0;

    private static bool Left => false;

    private static bool Center => false;

    public static Color32 Color => new Color32((byte) 162, (byte) 68, (byte) 198, byte.MaxValue);

    private static string roomName => LostRoom.Name + "Room";

    private static string convoName => LostRoom.Name + "Convo";

    private static string encounterName => LostRoom.Name + "Encounter";

    private static Sprite Talk => LostRoom.chara.frontSprite;

    private static Sprite Portal => LostRoom.chara.overworldSprite;

    private static string Audio => LostRoom.chara.dialogueSound;

    private static int ID => (int) LostRoom.chara.entityID;

    public static void Setup()
    {
      BrutalAPI.BrutalAPI.AddSignType((SignType) LostRoom.ID, LostRoom.Portal);
      LostRoom.Base = Backrooms.Assets.LoadAsset<GameObject>("Assets/Rooms/" + LostRoom.Name + "Room.prefab");
      LostRoom.Room = LostRoom.Base.AddComponent<NPCRoomHandler>();
      LostRoom.Room._npcSelectable = (BaseRoomItem) LostRoom.Room.transform.GetChild(0).gameObject.AddComponent<BasicRoomItem>();
      LostRoom.Room._npcSelectable._renderers = new SpriteRenderer[1]
      {
        LostRoom.Room._npcSelectable.transform.GetChild(0).GetComponent<SpriteRenderer>()
      };
      LostRoom.Room._npcSelectable._renderers[0].material = Backrooms.Mat;
      DialogueSO instance1 = ScriptableObject.CreateInstance<DialogueSO>();
      instance1.name = LostRoom.convoName;
      instance1.dialog = Backrooms.Yarn;
      instance1.startNode = "Salt." + LostRoom.Name + ".TryHire";
      LostRoom.Dialogue = instance1;
      FreeFoolEncounterSO instance2 = ScriptableObject.CreateInstance<FreeFoolEncounterSO>();
      instance2.name = LostRoom.encounterName;
      instance2._dialogue = LostRoom.convoName;
      instance2.encounterRoom = LostRoom.roomName;
      instance2._freeFool = LostRoom.Files;
      instance2.signType = (SignType) LostRoom.ID;
      instance2.npcEntityIDs = new EntityIDs[1]
      {
        (EntityIDs) LostRoom.ID
      };
      LostRoom.Free = instance2;
      LostRoom.bundle = new SpeakerBundle()
      {
        dialogueSound = LostRoom.Audio,
        portrait = LostRoom.Talk,
        bundleTextColor = (UnityEngine.Color) LostRoom.Color
      };
      SpeakerData instance3 = ScriptableObject.CreateInstance<SpeakerData>();
      instance3.speakerName = LostRoom.Name + PathUtils.speakerDataSuffix;
      instance3.name = LostRoom.Name + PathUtils.speakerDataSuffix;
      instance3._defaultBundle = LostRoom.bundle;
      instance3.portraitLooksLeft = LostRoom.Left;
      instance3.portraitLooksCenter = LostRoom.Center;
      LostRoom.speaker = instance3;
    }

    public static void Add()
    {
      if (!LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains<string>(PathUtils.encounterRoomsResPath + LostRoom.roomName))
        LoadedAssetsHandler.LoadedRoomPrefabs.Add(PathUtils.encounterRoomsResPath + LostRoom.roomName, (BaseRoomHandler) LostRoom.Room);
      else
        LoadedAssetsHandler.LoadedRoomPrefabs[PathUtils.encounterRoomsResPath + LostRoom.roomName] = (BaseRoomHandler) LostRoom.Room;
      if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(LostRoom.convoName))
        LoadedAssetsHandler.LoadedDialogues.Add(LostRoom.convoName, LostRoom.Dialogue);
      else
        LoadedAssetsHandler.LoadedDialogues[LostRoom.convoName] = LostRoom.Dialogue;
      if (!LoadedAssetsHandler.LoadedFreeFoolEncounters.Keys.Contains<string>(LostRoom.encounterName))
        LoadedAssetsHandler.LoadedFreeFoolEncounters.Add(LostRoom.encounterName, LostRoom.Free);
      else
        LoadedAssetsHandler.LoadedFreeFoolEncounters[LostRoom.encounterName] = LostRoom.Free;
      Backrooms.AddPool(LostRoom.encounterName, LostRoom.Zone);
      if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains<string>(LostRoom.speaker.speakerName))
        LoadedAssetsHandler.LoadedSpeakers.Add(LostRoom.speaker.speakerName, LostRoom.speaker);
      else
        LoadedAssetsHandler.LoadedSpeakers[LostRoom.speaker.speakerName] = LostRoom.speaker;
    }
  }
}
