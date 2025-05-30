using Entities;
using Enums;
using UnityEngine;

namespace Effects.Actives
{
    public class RegenerationStatusEffect : StatusEffect
    {
        protected override float Value => SetValue();
        protected override float Duration => SetDuration();

        protected override void OnExecute(Entity source, Entity target)
        {
            source.StatusEffectHandler.Apply(this);
        }

        protected override void OnTick(Entity entity)
        {
            entity.AlterStat(Value, CalculationType.Add, StatType.Health);
        }

        private float SetValue()
        {
            if (Stacks == 1)
            {
                return data.baseValue;
            }
            
            return data.baseValue * Mathf.Pow(1 + data.stackMultiplier, Stacks - 1);
        }

        private float SetDuration()
        {
            return data.duration + Mathf.Pow(1 + data.stackMultiplier, Stacks - 1);
        }
    }
}