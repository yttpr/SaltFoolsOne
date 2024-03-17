// Decompiled with JetBrains decompiler
// Type: THE_DEAD.ParanoidRoom
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using BrutalAPI;
using System.Linq;
using Tools;
using UnityEngine;

namespace THE_DEAD
{
  public static class ParanoidRoom
  {
    private static GameObject Base;
    private static NPCRoomHandler Room;
    private static DialogueSO Dialogue;
    private static FreeFoolEncounterSO Free;
    private static SpeakerBundle bundle;
    private static SpeakerData speaker;

    private static string Name => "Pynchon";

    private static string Files => "Pynchon_CH";

    private static Character chara => _04_TheParanoid.Chara;

    private static int Zone => 2;

    private static bool Left => false;

    private static bool Center => true;

    public static Color32 Color => new Color32((byte) 194, (byte) 33, (byte) 33, byte.MaxValue);

    private static string roomName => ParanoidRoom.Name + "Room";

    private static string convoName => ParanoidRoom.Name + "Convo";

    private static string encounterName => ParanoidRoom.Name + "Encounter";

    private static Sprite Talk => ParanoidRoom.chara.frontSprite;

    private static Sprite Portal => ParanoidRoom.chara.unlockedSprite;

    private static string Audio => ParanoidRoom.chara.dialogueSound;

    private static int ID => (int) ParanoidRoom.chara.entityID;

    public static void Setup()
    {
      BrutalAPI.BrutalAPI.AddSignType((SignType) ParanoidRoom.ID, ParanoidRoom.Portal);
      ParanoidRoom.Base = Backrooms.Assets.LoadAsset<GameObject>("Assets/Rooms/" + ParanoidRoom.Name + "Room.prefab");
      ParanoidRoom.Room = ParanoidRoom.Base.AddComponent<NPCRoomHandler>();
      ParanoidRoom.Room._npcSelectable = (BaseRoomItem) ParanoidRoom.Room.transform.GetChild(0).gameObject.AddComponent<BasicRoomItem>();
      ParanoidRoom.Room._npcSelectable._renderers = new SpriteRenderer[1]
      {
        ParanoidRoom.Room._npcSelectable.transform.GetChild(0).GetComponent<SpriteRenderer>()
      };
      ParanoidRoom.Room._npcSelectable._renderers[0].material = Backrooms.Mat;
      DialogueSO instance1 = ScriptableObject.CreateInstance<DialogueSO>();
      instance1.name = ParanoidRoom.convoName;
      instance1.dialog = Backrooms.Yarn;
      instance1.startNode = "Salt." + ParanoidRoom.Name + ".TryHire";
      ParanoidRoom.Dialogue = instance1;
      FreeFoolEncounterSO instance2 = ScriptableObject.CreateInstance<FreeFoolEncounterSO>();
      instance2.name = ParanoidRoom.encounterName;
      instance2._dialogue = ParanoidRoom.convoName;
      instance2.encounterRoom = ParanoidRoom.roomName;
      instance2._freeFool = ParanoidRoom.Files;
      instance2.signType = (SignType) ParanoidRoom.ID;
      instance2.npcEntityIDs = new EntityIDs[1]
      {
        (EntityIDs) ParanoidRoom.ID
      };
      ParanoidRoom.Free = instance2;
      ParanoidRoom.bundle = new SpeakerBundle()
      {
        dialogueSound = ParanoidRoom.Audio,
        portrait = ParanoidRoom.Talk,
        bundleTextColor = (UnityEngine.Color) ParanoidRoom.Color
      };
      SpeakerData instance3 = ScriptableObject.CreateInstance<SpeakerData>();
      instance3.speakerName = ParanoidRoom.Name + PathUtils.speakerDataSuffix;
      instance3.name = ParanoidRoom.Name + PathUtils.speakerDataSuffix;
      instance3._defaultBundle = ParanoidRoom.bundle;
      instance3.portraitLooksLeft = ParanoidRoom.Left;
      instance3.portraitLooksCenter = ParanoidRoom.Center;
      ParanoidRoom.speaker = instance3;
    }

    public static void Add()
    {
      if (!LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains<string>(PathUtils.encounterRoomsResPath + ParanoidRoom.roomName))
        LoadedAssetsHandler.LoadedRoomPrefabs.Add(PathUtils.encounterRoomsResPath + ParanoidRoom.roomName, (BaseRoomHandler) ParanoidRoom.Room);
      else
        LoadedAssetsHandler.LoadedRoomPrefabs[PathUtils.encounterRoomsResPath + ParanoidRoom.roomName] = (BaseRoomHandler) ParanoidRoom.Room;
      if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(ParanoidRoom.convoName))
        LoadedAssetsHandler.LoadedDialogues.Add(ParanoidRoom.convoName, ParanoidRoom.Dialogue);
      else
        LoadedAssetsHandler.LoadedDialogues[ParanoidRoom.convoName] = ParanoidRoom.Dialogue;
      if (!LoadedAssetsHandler.LoadedFreeFoolEncounters.Keys.Contains<string>(ParanoidRoom.encounterName))
        LoadedAssetsHandler.LoadedFreeFoolEncounters.Add(ParanoidRoom.encounterName, ParanoidRoom.Free);
      else
        LoadedAssetsHandler.LoadedFreeFoolEncounters[ParanoidRoom.encounterName] = ParanoidRoom.Free;
      Backrooms.AddPool(ParanoidRoom.encounterName, ParanoidRoom.Zone);
      if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains<string>(ParanoidRoom.speaker.speakerName))
        LoadedAssetsHandler.LoadedSpeakers.Add(ParanoidRoom.speaker.speakerName, ParanoidRoom.speaker);
      else
        LoadedAssetsHandler.LoadedSpeakers[ParanoidRoom.speaker.speakerName] = ParanoidRoom.speaker;
    }
  }
}
