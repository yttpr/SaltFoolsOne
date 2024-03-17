// Decompiled with JetBrains decompiler
// Type: THE_DEAD.ToastRoom
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using BrutalAPI;
using System.Linq;
using Tools;
using UnityEngine;

namespace THE_DEAD
{
    public static class ToastRoom
    {
        private static GameObject Base;
        private static NPCRoomHandler Room;
        private static DialogueSO Dialogue;
        private static FreeFoolEncounterSO Free;
        private static SpeakerBundle bundle;
        private static SpeakerData speaker;

        private static string Name => "Toast";

        private static string Files => "TOAST_CH";

        private static Character chara => _09_TheToasted.AAAAAAAAAA;

        private static int Zone => 0;

        private static bool Left => false;

        private static bool Center => true;

        public static Color32 Color => new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);

        private static string roomName => ToastRoom.Name + "Room";

        private static string convoName => ToastRoom.Name + "Convo";

        private static string encounterName => ToastRoom.Name + "Encounter";

        private static Sprite Talk => ToastRoom.chara.frontSprite;

        private static Sprite Portal => ToastRoom.chara.overworldSprite;

        private static string Audio => ToastRoom.chara.dialogueSound;

        private static int ID => (int)ToastRoom.chara.entityID;

        public static void Setup()
        {
            BrutalAPI.BrutalAPI.AddSignType((SignType)ToastRoom.ID, ToastRoom.Portal);
            ToastRoom.Base = Backrooms.Assets.LoadAsset<GameObject>("Assets/Rooms/" + ToastRoom.Name + "Room.prefab");
            ToastRoom.Room = ToastRoom.Base.AddComponent<NPCRoomHandler>();
            ToastRoom.Room._npcSelectable = (BaseRoomItem)ToastRoom.Room.transform.GetChild(0).gameObject.AddComponent<BasicRoomItem>();
            ToastRoom.Room._npcSelectable._renderers = new SpriteRenderer[1]
            {
        ToastRoom.Room._npcSelectable.transform.GetChild(0).GetComponent<SpriteRenderer>()
            };
            ToastRoom.Room._npcSelectable._renderers[0].material = Backrooms.Mat;
            DialogueSO instance1 = ScriptableObject.CreateInstance<DialogueSO>();
            instance1.name = ToastRoom.convoName;
            instance1.dialog = Backrooms.Yarn;
            instance1.startNode = "Salt." + ToastRoom.Name + ".TryHire";
            ToastRoom.Dialogue = instance1;
            FreeFoolEncounterSO instance2 = ScriptableObject.CreateInstance<FreeFoolEncounterSO>();
            instance2.name = ToastRoom.encounterName;
            instance2._dialogue = ToastRoom.convoName;
            instance2.encounterRoom = ToastRoom.roomName;
            instance2._freeFool = ToastRoom.Files;
            instance2.signType = (SignType)ToastRoom.ID;
            instance2.npcEntityIDs = new EntityIDs[1]
            {
        (EntityIDs) ToastRoom.ID
            };
            ToastRoom.Free = instance2;
            ToastRoom.bundle = new SpeakerBundle()
            {
                dialogueSound = ToastRoom.Audio,
                portrait = ToastRoom.Talk,
                bundleTextColor = (UnityEngine.Color)ToastRoom.Color
            };
            SpeakerData instance3 = ScriptableObject.CreateInstance<SpeakerData>();
            instance3.speakerName = ToastRoom.Name + PathUtils.speakerDataSuffix;
            instance3.name = ToastRoom.Name + PathUtils.speakerDataSuffix;
            instance3._defaultBundle = ToastRoom.bundle;
            instance3.portraitLooksLeft = ToastRoom.Left;
            instance3.portraitLooksCenter = ToastRoom.Center;
            ToastRoom.speaker = instance3;
        }

        public static void Add()
        {
            if (!LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains<string>(PathUtils.encounterRoomsResPath + ToastRoom.roomName))
                LoadedAssetsHandler.LoadedRoomPrefabs.Add(PathUtils.encounterRoomsResPath + ToastRoom.roomName, (BaseRoomHandler)ToastRoom.Room);
            else
                LoadedAssetsHandler.LoadedRoomPrefabs[PathUtils.encounterRoomsResPath + ToastRoom.roomName] = (BaseRoomHandler)ToastRoom.Room;
            if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(ToastRoom.convoName))
                LoadedAssetsHandler.LoadedDialogues.Add(ToastRoom.convoName, ToastRoom.Dialogue);
            else
                LoadedAssetsHandler.LoadedDialogues[ToastRoom.convoName] = ToastRoom.Dialogue;
            if (!LoadedAssetsHandler.LoadedFreeFoolEncounters.Keys.Contains<string>(ToastRoom.encounterName))
                LoadedAssetsHandler.LoadedFreeFoolEncounters.Add(ToastRoom.encounterName, ToastRoom.Free);
            else
                LoadedAssetsHandler.LoadedFreeFoolEncounters[ToastRoom.encounterName] = ToastRoom.Free;
            Backrooms.AddPool(ToastRoom.encounterName, ToastRoom.Zone);
            if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains<string>(ToastRoom.speaker.speakerName))
                LoadedAssetsHandler.LoadedSpeakers.Add(ToastRoom.speaker.speakerName, ToastRoom.speaker);
            else
                LoadedAssetsHandler.LoadedSpeakers[ToastRoom.speaker.speakerName] = ToastRoom.speaker;
        }
    }
}
