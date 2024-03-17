// Decompiled with JetBrains decompiler
// Type: THE_DEAD.ApplyAnestheticsRangePlusFourEffect
// Assembly: THE_DEAD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0E881B45-A9B1-4850-B191-1A0A2F2FE025
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\THE_DEAD.dll

using UnityEngine;

namespace THE_DEAD
{
  public class ApplyAnestheticsRangePlusFourEffect : EffectSO
  {
    [SerializeField]
    public bool _justOneTarget;
    [SerializeField]
    public bool _randomBetweenPrevious;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 0;
      if (entryVariable <= 0)
        return false;
      StatusEffectInfoSO effectInfo;
      stats.statusEffectDataBase.TryGetValue((StatusEffectType) 204308, out effectInfo);
      stats.statusEffectDataBase.TryGetValue(StatusEffectType.Scars, out StatusEffectInfoSO _);
      entryVariable = Random.Range(entryVariable, entryVariable + 5);
      for (int index1 = 0; index1 < targets.Length; ++index1)
      {
        if (targets[index1].HasUnit)
        {
          int amount = this._randomBetweenPrevious ? Random.Range(this.PreviousExitValue, entryVariable + 1) : entryVariable;
          Anesthetics_StatusEffect anestheticsStatusEffect = new Anesthetics_StatusEffect(amount);
          anestheticsStatusEffect.SetEffectInformation(effectInfo);
          IStatusEffector unit = targets[index1].Unit as IStatusEffector;
          bool flag = false;
          int index2 = 999;
          for (int index3 = 0; index3 < unit.StatusEffects.Count; ++index3)
          {
            if (unit.StatusEffects[index3].EffectType == anestheticsStatusEffect.EffectType)
            {
              index2 = index3;
              flag = true;
            }
          }
          if (flag)
          {
            unit.StatusEffects[index2].TryAddContent(amount);
            unit.StatusEffectValuesChanged(unit.StatusEffects[index2].EffectType, amount);
            CombatManager.Instance.AddUIAction((CombatAction) new PlayStatusEffectPopupUIAction(targets[index1].Unit.ID, targets[index1].Unit.IsUnitCharacter, amount, unit.StatusEffects[index2].EffectInfo, StatusFieldEffectPopUpType.Number));
            exitAmount += amount;
          }
          else if (targets[index1].Unit.ApplyStatusEffect((IStatusEffect) anestheticsStatusEffect, amount))
            ++exitAmount;
        }
      }
      return exitAmount > 0;
    }
  }
}
