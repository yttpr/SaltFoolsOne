using System;

namespace THE_DEAD
{
    public class ImpatienceCondition : EffectorConditionSO
    {
        public ImpatienceCondition()
        {
        }

        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            IUnit unit = null;
            bool flag;
            bool flag1;
            DamageDealtValueChangeException damageDealtValueChangeException = args as DamageDealtValueChangeException;
            if (damageDealtValueChangeException == null)
            {
                flag1 = false;
            }
            else
            {
                unit = effector as IUnit;
                flag1 = unit != null;
            }
            if (!flag1)
            {
                flag = true;
            }
            else
            {
                damageDealtValueChangeException.AddModifier(new AdditionNotNegativeValueModifier(true, unit.GetStoredValue((UnitStoredValueNames)69696969)));
                flag = false;
            }
            return flag;
        }
    }
}