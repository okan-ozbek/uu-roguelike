using Entities;
using Entities.Handlers;
using Stats;
using UnityEngine;

namespace StatusEffects.Concretes
{    
    [CreateAssetMenu(fileName = "NewFreezeStatusEffect", menuName = "StatusEffects/Freeze Status Effect")]
    public class FreezeStatusEffect : StatusEffect
    {
        private StatModifier _movementSpeedModifier;
        
        protected override void OnApply(StatusEffectHandler handler)
        {
            _movementSpeedModifier = new StatModifier(StatModifier.ModifierType.Multiply, 0, this);
            handler.Entity.Stats.movementSpeed.Add(_movementSpeedModifier);
            Debug.Log($"Slow effect applied. Movement speed reduced to {handler.Entity.Stats.movementSpeed.Value}.");
        }
        
        protected override void OnRemove(StatusEffectHandler handler)
        {
            handler.Entity.Stats.movementSpeed.RemoveModifiersBySource(this);
            Debug.Log($"Slow effect removed. Movement speed restored to {handler.Entity.Stats.movementSpeed.Value}.");
        }
    }
}