using System;
using Entities;
using Enums;
using Stats;
using Unity.VisualScripting;
using UnityEngine;

namespace Effects.Actives
{
    public class DecreaseHealthStatusEffect : StatusEffect
    {
        private StatModifier _modifier;
        
        protected override void OnExecute(Entity source, Entity target)
        {
            _modifier = new StatModifier(Value, CalculationType.Multiply, Guid.NewGuid());
            
            source.StatusEffectHandler.Apply(this);
            source.AddModifier(_modifier, StatType.Health);
        }
        
        protected override void OnRemove(Entity entity)
        {
            entity.RemoveModifier(_modifier, StatType.Health);
        }
    }
}