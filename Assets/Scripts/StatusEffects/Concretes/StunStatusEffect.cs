using Entities.Handlers;
using Stats;
using Stats.Enums;
using UnityEngine;

namespace StatusEffects.Concretes
{    
    [CreateAssetMenu(fileName = "NewStunStatusEffect", menuName = "StatusEffects/Stun Status Effect")]
    public class StunStatusEffect : StatusEffect
    {
        private StatModifier _modifier;
        
        protected override void OnApply(StatusEffectHandler handler)
        {
            _modifier = new StatModifier(CalculationType.Multiply, 0.0f, this);
            handler.Entity.Data.movementSpeed.Add(_modifier);
            
            Debug.Log($"Stun effect applied. Movement speed reduced to {handler.Entity.Data.movementSpeed.Value}.");
        }
        
        protected override void OnRemove(StatusEffectHandler handler)
        {
            handler.Entity.Data.movementSpeed.RemoveModifiersBySource(this);
            
            Debug.Log($"Stun effect removed. Movement speed restored to {handler.Entity.Data.movementSpeed.Value}.");
        }
    }
}