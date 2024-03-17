using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace THE_DEAD
{
    class ExampleOfHowToAddCustomIntents
    {
        void ExampleOfHowToAddIntent()
        {
            new CustomIntentInfo("ExampleIntent", (IntentType)836931, ResourceLoader.LoadSprite("pretend i have a sprite for this", 32), IntentType.Status_Ruptured);
            //that's it.
            //make sure the first intent number, after the name, is custom enough that no other modder will use it, but also try to make it consistent if you want to reuse it among mods.
            //for the sprite, make sure the PPU is 32. this is a must or you may or may not get jumpscared by massive intent icon.
            //for the second intent, this is where the sound gets pulled from. i dont know if the sounds ever get used for intents but set it anyway. you can use any existing base game intent.
            //you do not need to call CustomIntentInfo.Add or anything nor do you need to call CustomIntentIconSystem.Setup it's all done automatically.
        }
        void ExampleOfHowToUseIntent()
        {
            CustomIntentIconSystem.GetIntent("ExampleIntent");
            //that's it. just plug this into your effect. or alternatively you can use the number you set it for if you copy and paste it but this is easier to remember i think.
            //if you're doing it this way, make sure to add the intent before you start using it in abilities. that is all.
            //btw this section replaces the "IntentType.Damage_1_2" or whatever you would normally do for intents.
        }
    }
    public static class CustomIntentIconSystem
    {
        public static Dictionary<string, IntentInfo> Intents = new Dictionary<string, IntentInfo>();
        public static void TryAddIntent(string name, IntentInfo intent)
        {
            if (Intents.Keys.Contains(name)) return;
            else Intents.Add(name, intent);
        }
        public static IntentType GetIntent(string name)
        {
            if (Intents.TryGetValue(name, out IntentInfo intentInfo))
            {
                return intentInfo.Type;
            }
            Debug.LogError("IntentType for: " + name + " does not exist. Did you not add it in the correct order?");
            return IntentType.Misc_Hidden;
        }
        public static void HookInIntent(IntentHandlerSO self, IntentInfo info)
        {
            if (info is CustomIntentInfo custom)
                if (self._intentDB.Keys.Contains(custom.GetSoundFrom))
                    info._sound = self._intentDB[custom.GetSoundFrom]._sound;
                else Debug.LogError("IntentInfo: " + custom.Name + " cannot pull sound from: " + custom.GetSoundFrom.ToString() + " because it does not exist.");
            if (!self._intentDB.TryGetValue(info.Type, out IntentInfo other))
                self._intentDB.Add(info.Type, info);
            else Debug.LogWarning("Intent for IntentType: " + info.Type.ToString() + " already exists!?");
        }
        public static void AddIntentsGeneral(Action<IntentHandlerSO> orig, IntentHandlerSO self)
        {
            orig(self);
            foreach (IntentInfo info in Intents.Values) HookInIntent(self, info);
        }
        static bool AlreadySet = false;
        public static void Setup()
        {
            if (AlreadySet) return;
            AlreadySet = true;
            IDetour idetour = new Hook(typeof(IntentHandlerSO).GetMethod(nameof(IntentHandlerSO.Initialize), ~BindingFlags.Default), typeof(CustomIntentIconSystem).GetMethod(nameof(AddIntentsGeneral), ~BindingFlags.Default));
        }
    }
    public class CustomIntentInfo : IntentInfo
    {
        public string Name;
        public CustomIntentInfo(string name, IntentType type, Sprite sprite, IntentType SoundSouce)
        {
            this.Name = name;
            this._type = type;
            this._sprite = sprite;
            this._color = Color.white;
            this.GetSoundFrom = SoundSouce;
            SetupInternal();
        }
        public CustomIntentInfo(string name, IntentType type, Sprite sprite, IntentType SoundSouce, Color color)
        {
            this.Name = name;
            this._type = type;
            this._sprite = sprite;
            this._color = color;
            this.GetSoundFrom = SoundSouce;
            SetupInternal();
        }

        public void SetupInternal()
        {
            CustomIntentIconSystem.Setup();
            CustomIntentIconSystem.TryAddIntent(Name, this);
        }

        public IntentType GetSoundFrom;

        public override Sprite GetSprite(bool selector)
        {
            return _sprite;
        }

        public override Color GetColor(bool selector)
        {
            return _color;
        }
    }
}
