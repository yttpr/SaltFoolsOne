// Decompiled with JetBrains decompiler
// Type: THE_DEAD.MultiplyPercentDamageItem
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using BrutalAPI;
using UnityEngine;

namespace THE_DEAD
{
  public class MultiplyPercentDamageItem : Item
  {
    public Effect[] effects = new Effect[0];
    public bool immediate = false;
    public bool useDealt = true;
    [SerializeField]
    [Min(1f)]
    public int _percentageToModify = 50;

    public override BaseWearableSO Wearable()
    {
      PercentageDamageModifierSetterWearable instance = ScriptableObject.CreateInstance<PercentageDamageModifierSetterWearable>();
      instance.BaseWearable((Item) this);
      instance._percentageToModify = this._percentageToModify;
      instance._useDealt = this.useDealt;
      return (BaseWearableSO) instance;
    }
  }
}
