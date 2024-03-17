// Decompiled with JetBrains decompiler
// Type: THE_DEAD.CopyAndSpawnCustomCharacterPerLevelPlusOneEffect
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using Tools;
using UnityEngine;

namespace THE_DEAD
{
  public class CopyAndSpawnCustomCharacterPerLevelPlusOneEffect : EffectSO
  {
    [Header("Rank Data")]
    [CharacterRef]
    [SerializeField]
    public string _characterCopy = "Venus_CH";
    [SerializeField]
    public int _rank = 0;
    [SerializeField]
    public NameAdditionLocID _nameAddition;
    [SerializeField]
    public bool _permanentSpawn = true;
    [SerializeField]
    public bool _usePreviousAsHealth;
    [SerializeField]
    public WearableStaticModifierSetterSO[] _extraModifiers;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 0;
      CharacterSO charcater = LoadedAssetsHandler.GetCharcater("Venus_CH");
      if ((Object) charcater == (Object) null || ((object) charcater).Equals((object) null))
        return false;
      int currentHealth = this._usePreviousAsHealth ? Mathf.Max(1, this.PreviousExitValue) : charcater.GetMaxHealth(this._rank);
      WearableStaticModifiers modifiers = new WearableStaticModifiers();
      this._extraModifiers = new WearableStaticModifierSetterSO[0];
      foreach (WearableStaticModifierSetterSO extraModifier in this._extraModifiers)
        extraModifier.OnAttachedToCharacter(modifiers, charcater, this._rank);
      string nameAdditionData = LocUtils.LocDB.GetNameAdditionData(this._nameAddition);
      for (int index = 0; index < entryVariable; ++index)
      {
        int firstAbility;
        int secondAbility;
        charcater.GenerateAbilities(out firstAbility, out secondAbility);
        CombatManager.Instance.AddSubAction((CombatAction) new SpawnCharacterAction(charcater, -1, false, nameAdditionData, this._permanentSpawn, this._rank, firstAbility, secondAbility, currentHealth, modifiers));
        if (Random.Range(0, 100) < 0 && this._rank > 0)
          --this._rank;
      }
      exitAmount = entryVariable;
      return true;
    }
  }
}
