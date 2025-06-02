using Entities;
using Entities.Handlers;
using UnityEngine;

namespace StatusEffects.Concretes
{
    [CreateAssetMenu(fileName = "NewPoisonStatusEffect", menuName = "StatusEffects/Poison Status Effect")]
    public class PoisonStatusEffect : StatusEffect
    {
        protected override void OnTick(StatusEffectHandler handler)
        {
            handler.Entity.Stats.health.Value -= Value;
            
            Debug.Log($"Entity poisoned! Health reduced by {Value}. Current health: {handler.Entity.Stats.health.Value}/{handler.Entity.Stats.health.MaxValue}");
        }
    }
}