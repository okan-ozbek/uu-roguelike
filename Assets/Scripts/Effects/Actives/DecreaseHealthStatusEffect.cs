using Entities;
using Enums;
using Stats;
using UnityEngine;

namespace Effects.Actives
{
    [CreateAssetMenu(fileName = "Decrease Health Status Effect", menuName = "Scriptable Objects/Status Effects/Decrease Health Status Effect", order = 1)]
    public class DecreaseHealthStatusEffect : StatusEffect
    {
        private StatModifier _modifier;
        
        protected override void OnExecute(Entity source, Entity target)
        {
            bool result = source.StatusEffectHandler.Apply(this);
            
            if (result)
            {
                _modifier = new StatModifier(Value, CalculationType.Multiply, 1);
                source.AddModifier(_modifier, StatType.Health);    
            }
            
        }
        
        protected override void OnRemove(Entity entity)
        {
            entity.RemoveModifier(_modifier, StatType.Health);
        }
    }
}