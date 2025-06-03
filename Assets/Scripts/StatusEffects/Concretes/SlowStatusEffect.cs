using Entities;
using Entities.Handlers;
using Stats;
using Stats.Enums;
using UnityEngine;

namespace StatusEffects.Concretes
{    
    [CreateAssetMenu(fileName = "NewSlowStatusEffect", menuName = "StatusEffects/Slow Status Effect")]
    public class SlowStatusEffect : StatusEffect
    {
        private StatModifier _modifier;
        
        protected override void OnApply(StatusEffectHandler handler)
        {
            _modifier = new StatModifier(CalculationType.Multiply, Value, this);
            handler.Entity.Data.movementSpeed.Add(_modifier);
            
            Debug.Log($"Slow effect applied. Movement speed reduced to {handler.Entity.Data.movementSpeed.Value}.");
        }
        
        protected override void OnRemove(StatusEffectHandler handler)
        {
            handler.Entity.Data.movementSpeed.RemoveModifiersBySource(this);
            
            Debug.Log($"Slow effect removed. Movement speed restored to {handler.Entity.Data.movementSpeed.Value}.");
        }
    }
}