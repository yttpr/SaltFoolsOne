// Decompiled with JetBrains decompiler
// Type: THE_DEAD.DeadRoom
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using BrutalAPI;
using System.Linq;
using Tools;
using UnityEngine;

namespace THE_DEAD
{
  public static class DeadRoom
  {
    private static GameObject Base;
    private static NPCRoomHandler Room;
    private static DialogueSO Dialogue;
    private static FreeFoolEncounterSO Free;
    private static SpeakerBundle bundle;
    private static SpeakerData speaker;

    private static string Name => "Didion";

    private static string Files => "Didion_CH";

    private static Character chara => _00_TheDead.Chara;

    private static int Zone => 0;

    private static bool Left => true;

    private static bool Center => false;

    public static Color32 Color => new Color32((byte) 50, (byte) 56, (byte) 161, byte.MaxValue);

    private static string roomName => DeadRoom.Name + "Room";

    private static string convoName => DeadRoom.Name + "Convo";

    private static string encounterName => DeadRoom.Name + "Encounter";

    private static Sprite Talk => DeadRoom.chara.frontSprite;

    private static Sprite Portal => DeadRoom.chara.overworldSprite;

    private static string Audio => DeadRoom.chara.dialogueSound;

    private static int ID => (int) DeadRoom.chara.entityID;

    public static void Setup()
    {
      BrutalAPI.BrutalAPI.AddSignType((SignType) DeadRoom.ID, DeadRoom.Portal);
      DeadRoom.Base = Backrooms.Assets.LoadAsset<GameObject>("Assets/Rooms/" + DeadRoom.Name + "Room.prefab");
      DeadRoom.Room = DeadRoom.Base.AddComponent<NPCRoomHandler>();
      DeadRoom.Room._npcSelectable = (BaseRoomItem) DeadRoom.Room.transform.GetChild(0).gameObject.AddComponent<BasicRoomItem>();
      DeadRoom.Room._npcSelectable._renderers = new SpriteRenderer[1]
      {
        DeadRoom.Room._npcSelectable.transform.GetChild(0).GetComponent<SpriteRenderer>()
      };
      DeadRoom.Room._npcSelectable._renderers[0].material = Backrooms.Mat;
      DialogueSO instance1 = ScriptableObject.CreateInstance<DialogueSO>();
      instance1.name = DeadRoom.convoName;
      instance1.dialog = Backrooms.Yarn;
      instance1.startNode = "Salt." + DeadRoom.Name + ".TryHire";
      DeadRoom.Dialogue = instance1;
      FreeFoolEncounterSO instance2 = ScriptableObject.CreateInstance<FreeFoolEncounterSO>();
      instance2.name = DeadRoom.encounterName;
      instance2._dialogue = DeadRoom.convoName;
      instance2.encounterRoom = DeadRoom.roomName;
      instance2._freeFool = DeadRoom.Files;
      instance2.signType = (SignType) DeadRoom.ID;
      instance2.npcEntityIDs = new EntityIDs[1]
      {
        (EntityIDs) DeadRoom.ID
      };
      DeadRoom.Free = instance2;
      DeadRoom.bundle = new SpeakerBundle()
      {
        dialogueSound = DeadRoom.Audio,
        portrait = DeadRoom.Talk,
        bundleTextColor = (UnityEngine.Color) DeadRoom.Color
      };
      SpeakerData instance3 = ScriptableObject.CreateInstance<SpeakerData>();
      instance3.speakerName = DeadRoom.Name + PathUtils.speakerDataSuffix;
      instance3.name = DeadRoom.Name + PathUtils.speakerDataSuffix;
      instance3._defaultBundle = DeadRoom.bundle;
      instance3.portraitLooksLeft = DeadRoom.Left;
      instance3.portraitLooksCenter = DeadRoom.Center;
      DeadRoom.speaker = instance3;
    }

    public static void Add()
    {
      if (!LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains<string>(PathUtils.encounterRoomsResPath + DeadRoom.roomName))
        LoadedAssetsHandler.LoadedRoomPrefabs.Add(PathUtils.encounterRoomsResPath + DeadRoom.roomName, (BaseRoomHandler) DeadRoom.Room);
      else
        LoadedAssetsHandler.LoadedRoomPrefabs[PathUtils.encounterRoomsResPath + DeadRoom.roomName] = (BaseRoomHandler) DeadRoom.Room;
      if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(DeadRoom.convoName))
        LoadedAssetsHandler.LoadedDialogues.Add(DeadRoom.convoName, DeadRoom.Dialogue);
      else
        LoadedAssetsHandler.LoadedDialogues[DeadRoom.convoName] = DeadRoom.Dialogue;
      if (!LoadedAssetsHandler.LoadedFreeFoolEncounters.Keys.Contains<string>(DeadRoom.encounterName))
        LoadedAssetsHandler.LoadedFreeFoolEncounters.Add(DeadRoom.encounterName, DeadRoom.Free);
      else
        LoadedAssetsHandler.LoadedFreeFoolEncounters[DeadRoom.encounterName] = DeadRoom.Free;
      Backrooms.AddPool(DeadRoom.encounterName, DeadRoom.Zone);
      if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains<string>(DeadRoom.speaker.speakerName))
        LoadedAssetsHandler.LoadedSpeakers.Add(DeadRoom.speaker.speakerName, DeadRoom.speaker);
      else
        LoadedAssetsHandler.LoadedSpeakers[DeadRoom.speaker.speakerName] = DeadRoom.speaker;
    }
  }
}
