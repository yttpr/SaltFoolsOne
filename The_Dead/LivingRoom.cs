// Decompiled with JetBrains decompiler
// Type: THE_DEAD.LivingRoom
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using BrutalAPI;
using System.Linq;
using Tools;
using UnityEngine;

namespace THE_DEAD
{
  public static class LivingRoom
  {
    private static GameObject Base;
    private static NPCRoomHandler Room;
    private static DialogueSO Dialogue;
    private static FreeFoolEncounterSO Free;
    private static SpeakerBundle bundle;
    private static SpeakerData speaker;

    private static string Name => "Rose";

    private static string Files => "Rose_CH";

    private static Character chara => _07_TheLiving.Chara;

    private static int Zone => 1;

    private static bool Left => true;

    private static bool Center => false;

    public static Color32 Color => new Color32((byte) 194, (byte) 33, (byte) 33, byte.MaxValue);

    private static string roomName => LivingRoom.Name + "Room";

    private static string convoName => LivingRoom.Name + "Convo";

    private static string encounterName => LivingRoom.Name + "Encounter";

    private static Sprite Talk => LivingRoom.chara.frontSprite;

    private static Sprite Portal => LivingRoom.chara.overworldSprite;

    private static string Audio => LivingRoom.chara.dialogueSound;

    private static int ID => (int) LivingRoom.chara.entityID;

    public static void Setup()
    {
      BrutalAPI.BrutalAPI.AddSignType((SignType) LivingRoom.ID, LivingRoom.Portal);
      LivingRoom.Base = Backrooms.Assets.LoadAsset<GameObject>("Assets/Rooms/" + LivingRoom.Name + "Room.prefab");
      LivingRoom.Room = LivingRoom.Base.AddComponent<NPCRoomHandler>();
      LivingRoom.Room._npcSelectable = (BaseRoomItem) LivingRoom.Room.transform.GetChild(0).gameObject.AddComponent<BasicRoomItem>();
      LivingRoom.Room._npcSelectable._renderers = new SpriteRenderer[1]
      {
        LivingRoom.Room._npcSelectable.transform.GetChild(0).GetComponent<SpriteRenderer>()
      };
      LivingRoom.Room._npcSelectable._renderers[0].material = Backrooms.Mat;
      DialogueSO instance1 = ScriptableObject.CreateInstance<DialogueSO>();
      instance1.name = LivingRoom.convoName;
      instance1.dialog = Backrooms.Yarn;
      instance1.startNode = "Salt." + LivingRoom.Name + ".TryHire";
      LivingRoom.Dialogue = instance1;
      FreeFoolEncounterSO instance2 = ScriptableObject.CreateInstance<FreeFoolEncounterSO>();
      instance2.name = LivingRoom.encounterName;
      instance2._dialogue = LivingRoom.convoName;
      instance2.encounterRoom = LivingRoom.roomName;
      instance2._freeFool = LivingRoom.Files;
      instance2.signType = (SignType) LivingRoom.ID;
      instance2.npcEntityIDs = new EntityIDs[1]
      {
        (EntityIDs) LivingRoom.ID
      };
      LivingRoom.Free = instance2;
      LivingRoom.bundle = new SpeakerBundle()
      {
        dialogueSound = LivingRoom.Audio,
        portrait = LivingRoom.Talk,
        bundleTextColor = (UnityEngine.Color) LivingRoom.Color
      };
      SpeakerData instance3 = ScriptableObject.CreateInstance<SpeakerData>();
      instance3.speakerName = LivingRoom.Name + PathUtils.speakerDataSuffix;
      instance3.name = LivingRoom.Name + PathUtils.speakerDataSuffix;
      instance3._defaultBundle = LivingRoom.bundle;
      instance3.portraitLooksLeft = LivingRoom.Left;
      instance3.portraitLooksCenter = LivingRoom.Center;
      LivingRoom.speaker = instance3;
    }

    public static void Add()
    {
      if (!LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains<string>(PathUtils.encounterRoomsResPath + LivingRoom.roomName))
        LoadedAssetsHandler.LoadedRoomPrefabs.Add(PathUtils.encounterRoomsResPath + LivingRoom.roomName, (BaseRoomHandler) LivingRoom.Room);
      else
        LoadedAssetsHandler.LoadedRoomPrefabs[PathUtils.encounterRoomsResPath + LivingRoom.roomName] = (BaseRoomHandler) LivingRoom.Room;
      if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(LivingRoom.convoName))
        LoadedAssetsHandler.LoadedDialogues.Add(LivingRoom.convoName, LivingRoom.Dialogue);
      else
        LoadedAssetsHandler.LoadedDialogues[LivingRoom.convoName] = LivingRoom.Dialogue;
      if (!LoadedAssetsHandler.LoadedFreeFoolEncounters.Keys.Contains<string>(LivingRoom.encounterName))
        LoadedAssetsHandler.LoadedFreeFoolEncounters.Add(LivingRoom.encounterName, LivingRoom.Free);
      else
        LoadedAssetsHandler.LoadedFreeFoolEncounters[LivingRoom.encounterName] = LivingRoom.Free;
      Backrooms.AddPool(LivingRoom.encounterName, LivingRoom.Zone);
      if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains<string>(LivingRoom.speaker.speakerName))
        LoadedAssetsHandler.LoadedSpeakers.Add(LivingRoom.speaker.speakerName, LivingRoom.speaker);
      else
        LoadedAssetsHandler.LoadedSpeakers[LivingRoom.speaker.speakerName] = LivingRoom.speaker;
    }
  }
}
