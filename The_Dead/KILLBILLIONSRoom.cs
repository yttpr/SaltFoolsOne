// Decompiled with JetBrains decompiler
// Type: THE_DEAD.KILLBILLIONSRoom
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using BrutalAPI;
using System.Linq;
using Tools;
using UnityEngine;

namespace THE_DEAD
{
  public static class KILLBILLIONSRoom
  {
    private static GameObject Base;
    private static NPCRoomHandler Room;
    private static DialogueSO Dialogue;
    private static FreeFoolEncounterSO Free;
    private static SpeakerBundle bundle;
    private static SpeakerData speaker;

    private static string Name => "Infanticide";

    private static string Files => "Violence_CH";

    private static Character chara => _14_Infanticide.Chara;

    private static int Zone => 1;

    private static bool Left => false;

    private static bool Center => false;

    public static Color32 Color => new Color32(byte.MaxValue, (byte) 197, (byte) 229, byte.MaxValue);

    private static string roomName => KILLBILLIONSRoom.Name + "Room";

    private static string convoName => KILLBILLIONSRoom.Name + "Convo";

    private static string encounterName => KILLBILLIONSRoom.Name + "Encounter";

    private static Sprite Talk => KILLBILLIONSRoom.chara.frontSprite;

    private static Sprite Portal => KILLBILLIONSRoom.chara.overworldSprite;

    private static string Audio => KILLBILLIONSRoom.chara.dialogueSound;

    private static int ID => (int) KILLBILLIONSRoom.chara.entityID;

    public static void Setup()
    {
      BrutalAPI.BrutalAPI.AddSignType((SignType) KILLBILLIONSRoom.ID, KILLBILLIONSRoom.Portal);
      KILLBILLIONSRoom.Base = Backrooms.Assets.LoadAsset<GameObject>("Assets/Rooms/" + KILLBILLIONSRoom.Name + "Room.prefab");
      KILLBILLIONSRoom.Room = KILLBILLIONSRoom.Base.AddComponent<NPCRoomHandler>();
      KILLBILLIONSRoom.Room._npcSelectable = (BaseRoomItem) KILLBILLIONSRoom.Room.transform.GetChild(0).gameObject.AddComponent<BasicRoomItem>();
      KILLBILLIONSRoom.Room._npcSelectable._renderers = new SpriteRenderer[1]
      {
        KILLBILLIONSRoom.Room._npcSelectable.transform.GetChild(0).GetComponent<SpriteRenderer>()
      };
      KILLBILLIONSRoom.Room._npcSelectable._renderers[0].material = Backrooms.Mat;
      DialogueSO instance1 = ScriptableObject.CreateInstance<DialogueSO>();
      instance1.name = KILLBILLIONSRoom.convoName;
      instance1.dialog = Backrooms.Yarn;
      instance1.startNode = "Salt." + KILLBILLIONSRoom.Name + ".TryHire";
      KILLBILLIONSRoom.Dialogue = instance1;
      FreeFoolEncounterSO instance2 = ScriptableObject.CreateInstance<FreeFoolEncounterSO>();
      instance2.name = KILLBILLIONSRoom.encounterName;
      instance2._dialogue = KILLBILLIONSRoom.convoName;
      instance2.encounterRoom = KILLBILLIONSRoom.roomName;
      instance2._freeFool = KILLBILLIONSRoom.Files;
      instance2.signType = (SignType) KILLBILLIONSRoom.ID;
      instance2.npcEntityIDs = new EntityIDs[1]
      {
        (EntityIDs) KILLBILLIONSRoom.ID
      };
      KILLBILLIONSRoom.Free = instance2;
      KILLBILLIONSRoom.bundle = new SpeakerBundle()
      {
        dialogueSound = KILLBILLIONSRoom.Audio,
        portrait = KILLBILLIONSRoom.Talk,
        bundleTextColor = (UnityEngine.Color) KILLBILLIONSRoom.Color
      };
      SpeakerData instance3 = ScriptableObject.CreateInstance<SpeakerData>();
      instance3.speakerName = KILLBILLIONSRoom.Name + PathUtils.speakerDataSuffix;
      instance3.name = KILLBILLIONSRoom.Name + PathUtils.speakerDataSuffix;
      instance3._defaultBundle = KILLBILLIONSRoom.bundle;
      instance3.portraitLooksLeft = KILLBILLIONSRoom.Left;
      instance3.portraitLooksCenter = KILLBILLIONSRoom.Center;
      KILLBILLIONSRoom.speaker = instance3;
    }

    public static void Add()
    {
      if (!LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains<string>(PathUtils.encounterRoomsResPath + KILLBILLIONSRoom.roomName))
        LoadedAssetsHandler.LoadedRoomPrefabs.Add(PathUtils.encounterRoomsResPath + KILLBILLIONSRoom.roomName, (BaseRoomHandler) KILLBILLIONSRoom.Room);
      else
        LoadedAssetsHandler.LoadedRoomPrefabs[PathUtils.encounterRoomsResPath + KILLBILLIONSRoom.roomName] = (BaseRoomHandler) KILLBILLIONSRoom.Room;
      if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(KILLBILLIONSRoom.convoName))
        LoadedAssetsHandler.LoadedDialogues.Add(KILLBILLIONSRoom.convoName, KILLBILLIONSRoom.Dialogue);
      else
        LoadedAssetsHandler.LoadedDialogues[KILLBILLIONSRoom.convoName] = KILLBILLIONSRoom.Dialogue;
      if (!LoadedAssetsHandler.LoadedFreeFoolEncounters.Keys.Contains<string>(KILLBILLIONSRoom.encounterName))
        LoadedAssetsHandler.LoadedFreeFoolEncounters.Add(KILLBILLIONSRoom.encounterName, KILLBILLIONSRoom.Free);
      else
        LoadedAssetsHandler.LoadedFreeFoolEncounters[KILLBILLIONSRoom.encounterName] = KILLBILLIONSRoom.Free;
      Backrooms.AddPool(KILLBILLIONSRoom.encounterName, KILLBILLIONSRoom.Zone);
      if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains<string>(KILLBILLIONSRoom.speaker.speakerName))
        LoadedAssetsHandler.LoadedSpeakers.Add(KILLBILLIONSRoom.speaker.speakerName, KILLBILLIONSRoom.speaker);
      else
        LoadedAssetsHandler.LoadedSpeakers[KILLBILLIONSRoom.speaker.speakerName] = KILLBILLIONSRoom.speaker;
    }
  }
}
