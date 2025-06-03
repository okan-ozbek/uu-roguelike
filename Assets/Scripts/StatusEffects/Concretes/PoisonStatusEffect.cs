using Entities.Handlers;
using Stats.Enums;
using UnityEngine;

namespace StatusEffects.Concretes
{
    [CreateAssetMenu(fileName = "NewPoisonStatusEffect", menuName = "StatusEffects/Poison Status Effect")]
    public class PoisonStatusEffect : StatusEffect
    {
        protected override void OnTick(StatusEffectHandler handler)
        {
            handler.Entity.Data.health.Value -= Value;
            
            Debug.Log($"Entity poisoned! Health reduced by {Value}. Current health: {handler.Entity.Data.health.Value}/{handler.Entity.Data.health.MaxValue}");
        }
    }
}