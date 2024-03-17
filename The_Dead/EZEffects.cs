using System;
using UnityEngine;

namespace THE_DEAD
{
    // Token: 0x0200007C RID: 124
    public static class EZEffects
    {
        // Token: 0x06000200 RID: 512 RVA: 0x00017E1C File Offset: 0x0001601C
        public static PreviousEffectCondition DidThat<T>(bool success, int prev = 1) where T : PreviousEffectCondition
        {
            PreviousEffectCondition previousEffectCondition = ScriptableObject.CreateInstance<T>();
            previousEffectCondition.wasSuccessful = success;
            previousEffectCondition.previousAmount = prev;
            return previousEffectCondition;
        }

        // Token: 0x06000201 RID: 513 RVA: 0x00017E48 File Offset: 0x00016048
        public static AnimationVisualsEffect GetVisuals<T>(string visuals, bool isChara, BaseCombatTargettingSO targets) where T : AnimationVisualsEffect
        {
            AnimationVisualsEffect animationVisualsEffect = ScriptableObject.CreateInstance<T>();
            if (isChara)
            {
                animationVisualsEffect._visuals = LoadedAssetsHandler.GetCharacterAbility(visuals).visuals;
            }
            else
            {
                animationVisualsEffect._visuals = LoadedAssetsHandler.GetEnemyAbility(visuals).visuals;
            }
            animationVisualsEffect._animationTarget = targets;
            return animationVisualsEffect;
        }

        // Token: 0x06000202 RID: 514 RVA: 0x00017E98 File Offset: 0x00016098
        public static Targetting_ByUnit_Side TargetSide<T>(bool allies, bool allSlots, bool ignoreCast = false) where T : Targetting_ByUnit_Side
        {
            Targetting_ByUnit_Side targetting_ByUnit_Side = ScriptableObject.CreateInstance<T>();
            targetting_ByUnit_Side.ignoreCastSlot = ignoreCast;
            targetting_ByUnit_Side.getAllies = allies;
            targetting_ByUnit_Side.getAllUnitSlots = allSlots;
            return targetting_ByUnit_Side;
        }

        // Token: 0x06000203 RID: 515 RVA: 0x00017ECC File Offset: 0x000160CC
        public static SwapToOneSideEffect GoSide<T>(bool right) where T : SwapToOneSideEffect
        {
            SwapToOneSideEffect swapToOneSideEffect = ScriptableObject.CreateInstance<T>();
            swapToOneSideEffect._swapRight = right;
            return swapToOneSideEffect;
        }
    }
}
