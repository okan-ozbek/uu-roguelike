using Entities;
using Enums;
using UnityEngine;

namespace Effects.Actives
{
    [CreateAssetMenu(fileName = "Poison Status Effect", menuName = "Scriptable Objects/Status Effects/Poison Status Effect", order = 1)]
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
            entity.SetColor(Color.green, 0.25f);
        }
        
        private float SetValue()
        {
            if (data.Stacks == 1)
            {
                return data.baseValue;
            }
            
            return data.baseValue * Mathf.Pow(1 + data.stackMultiplier, data.Stacks - 1);
        }
    }
}