using Entities;
using Enums;
using UnityEngine;

namespace Effects.Actives
{
    [CreateAssetMenu(fileName = "Regeneration Status Effect", menuName = "Scriptable Objects/Status Effects/Regeneration Status Effect", order = 1)]
    public class RegenerationStatusEffect : StatusEffect
    {
        protected override float Value => SetValue();
        protected override float Duration => SetDuration();

        protected override void OnExecute(IEntity source, IEntity target)
        {
            source.StatusEffectHandler.Apply(this);
        }

        protected override void OnTick(IEntity entity)
        {
            entity.StatHandler.AlterStat(Value, CalculationType.Add, StatType.Health);
        }

        private float SetValue()
        {
            if (data.Stacks == 1)
            {
                return data.baseValue;
            }
            
            return data.baseValue * Mathf.Pow(1 + data.stackMultiplier, data.Stacks - 1);
        }

        private float SetDuration()
        {
            return data.duration + Mathf.Pow(1 + data.stackMultiplier, data.Stacks - 1);
        }
    }
}