using System;
using UnityEngine;

namespace THE_DEAD
{
    public class ResetMaxHealthEffect : EffectSO
    {
        [SerializeField]
        public bool _ignoreIfContains;

        [SerializeField]
        public UnitStoredValueNames _valueName = (UnitStoredValueNames)45544;

        public ResetMaxHealthEffect()
        {
        }

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            IUnit unit = null;
            bool flag;
            bool flag1;
            exitAmount = 0;
            if ((!this._ignoreIfContains ? false : caster.ContainsStoredValue(this._valueName)))
            {
                flag = false;
            }
            else
            {
                entryVariable = caster.MaximumHealth;
                caster.SetStoredValue(this._valueName, entryVariable);
                CharacterCombat characterCombat = caster as CharacterCombat;
                if (characterCombat != null)
                {
                    characterCombat.Character.GetMaxHealth(characterCombat.Rank);
                    if (caster.MaximumHealth != characterCombat.Character.GetMaxHealth(characterCombat.Rank))
                    {
                        caster.MaximizeHealth(characterCombat.Character.GetMaxHealth(characterCombat.Rank));
                    }
                }
                if (caster == null)
                {
                    flag1 = false;
                }
                else
                {
                    unit = caster;
                    flag1 = true;
                }
                if (flag1)
                {
                    int maximumHealth = unit.MaximumHealth;
                    CharacterCombat characterCombat1 = unit as CharacterCombat;
                    if (characterCombat1 != null)
                    {
                        characterCombat1.Character.GetMaxHealth(characterCombat1.Rank);
                    }
                }
                flag = true;
            }
            return flag;
        }
    }
}