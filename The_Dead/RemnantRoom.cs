// Decompiled with JetBrains decompiler
// Type: THE_DEAD.RemnantRoom
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using BrutalAPI;
using System.Linq;
using Tools;
using UnityEngine;

namespace THE_DEAD
{
  public static class RemnantRoom
  {
    private static GameObject Base;
    private static NPCRoomHandler Room;
    private static DialogueSO Dialogue;
    private static FreeFoolEncounterSO Free;
    private static SpeakerBundle bundle;
    private static SpeakerData speaker;

    private static string Name => "Faith";

    private static string Files => "Faith_CH";

    private static Character chara => _08_TheRemnant.Chara;

    private static int Zone => 2;

    private static bool Left => true;

    private static bool Center => false;

    public static Color32 Color => LostRoom.Color;

    private static string roomName => RemnantRoom.Name + "Room";

    private static string convoName => RemnantRoom.Name + "Convo";

    private static string encounterName => RemnantRoom.Name + "Encounter";

    private static Sprite Talk => RemnantRoom.chara.frontSprite;

    private static Sprite Portal => RemnantRoom.chara.overworldSprite;

    private static string Audio => RemnantRoom.chara.dialogueSound;

    private static int ID => (int) RemnantRoom.chara.entityID;

    public static void Setup()
    {
      BrutalAPI.BrutalAPI.AddSignType((SignType) RemnantRoom.ID, RemnantRoom.Portal);
      RemnantRoom.Base = Backrooms.Assets.LoadAsset<GameObject>("Assets/Rooms/" + RemnantRoom.Name + "Room.prefab");
      RemnantRoom.Room = RemnantRoom.Base.AddComponent<NPCRoomHandler>();
      RemnantRoom.Room._npcSelectable = (BaseRoomItem) RemnantRoom.Room.transform.GetChild(0).gameObject.AddComponent<BasicRoomItem>();
      RemnantRoom.Room._npcSelectable._renderers = new SpriteRenderer[1]
      {
        RemnantRoom.Room._npcSelectable.transform.GetChild(0).GetComponent<SpriteRenderer>()
      };
      RemnantRoom.Room._npcSelectable._renderers[0].material = Backrooms.Mat;
      DialogueSO instance1 = ScriptableObject.CreateInstance<DialogueSO>();
      instance1.name = RemnantRoom.convoName;
      instance1.dialog = Backrooms.Yarn;
      instance1.startNode = "Salt." + RemnantRoom.Name + ".TryHire";
      RemnantRoom.Dialogue = instance1;
      FreeFoolEncounterSO instance2 = ScriptableObject.CreateInstance<FreeFoolEncounterSO>();
      instance2.name = RemnantRoom.encounterName;
      instance2._dialogue = RemnantRoom.convoName;
      instance2.encounterRoom = RemnantRoom.roomName;
      instance2._freeFool = RemnantRoom.Files;
      instance2.signType = (SignType) RemnantRoom.ID;
      instance2.npcEntityIDs = new EntityIDs[1]
      {
        (EntityIDs) RemnantRoom.ID
      };
      RemnantRoom.Free = instance2;
      RemnantRoom.bundle = new SpeakerBundle()
      {
        dialogueSound = RemnantRoom.Audio,
        portrait = RemnantRoom.Talk,
        bundleTextColor = (UnityEngine.Color) RemnantRoom.Color
      };
      SpeakerData instance3 = ScriptableObject.CreateInstance<SpeakerData>();
      instance3.speakerName = RemnantRoom.Name + PathUtils.speakerDataSuffix;
      instance3.name = RemnantRoom.Name + PathUtils.speakerDataSuffix;
      instance3._defaultBundle = RemnantRoom.bundle;
      instance3.portraitLooksLeft = RemnantRoom.Left;
      instance3.portraitLooksCenter = RemnantRoom.Center;
      RemnantRoom.speaker = instance3;
    }

    public static void Add()
    {
      if (!LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains<string>(PathUtils.encounterRoomsResPath + RemnantRoom.roomName))
        LoadedAssetsHandler.LoadedRoomPrefabs.Add(PathUtils.encounterRoomsResPath + RemnantRoom.roomName, (BaseRoomHandler) RemnantRoom.Room);
      else
        LoadedAssetsHandler.LoadedRoomPrefabs[PathUtils.encounterRoomsResPath + RemnantRoom.roomName] = (BaseRoomHandler) RemnantRoom.Room;
      if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(RemnantRoom.convoName))
        LoadedAssetsHandler.LoadedDialogues.Add(RemnantRoom.convoName, RemnantRoom.Dialogue);
      else
        LoadedAssetsHandler.LoadedDialogues[RemnantRoom.convoName] = RemnantRoom.Dialogue;
      if (!LoadedAssetsHandler.LoadedFreeFoolEncounters.Keys.Contains<string>(RemnantRoom.encounterName))
        LoadedAssetsHandler.LoadedFreeFoolEncounters.Add(RemnantRoom.encounterName, RemnantRoom.Free);
      else
        LoadedAssetsHandler.LoadedFreeFoolEncounters[RemnantRoom.encounterName] = RemnantRoom.Free;
      Backrooms.AddPool(RemnantRoom.encounterName, RemnantRoom.Zone);
      if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains<string>(RemnantRoom.speaker.speakerName))
        LoadedAssetsHandler.LoadedSpeakers.Add(RemnantRoom.speaker.speakerName, RemnantRoom.speaker);
      else
        LoadedAssetsHandler.LoadedSpeakers[RemnantRoom.speaker.speakerName] = RemnantRoom.speaker;
    }
  }
}
