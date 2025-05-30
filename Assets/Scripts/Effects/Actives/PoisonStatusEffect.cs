using Entities;
using Enums;
using UnityEngine;

namespace Effects.Actives
{
    public class PoisonStatusEffect : StatusEffect
    {
        protected override float Value => SetValue();
        
        protected override void OnExecute(Entity source, Entity target)
        {
            target.StatusEffectHandler.Apply(this);
        }

        protected override void OnTick(Entity entity)
        {
            entity.AlterStat(Value, CalculationType.Subtract, StatType.Health);
        }
        
        private float SetValue()
        {
            if (Stacks == 1)
            {
                return data.baseValue;
            }
            
            return data.baseValue * Mathf.Pow(1 + data.stackMultiplier, Stacks - 1);
        }
    }
}