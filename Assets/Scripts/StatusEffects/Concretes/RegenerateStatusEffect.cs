using Entities;
using Entities.Handlers;
using Stats.Enums;
using UnityEngine;

namespace StatusEffects.Concretes
{
    [CreateAssetMenu(fileName = "NewRegenerateStatusEffect", menuName = "StatusEffects/Regenerate Status Effect")]
    public class RegenerateStatusEffect : StatusEffect
    {
        protected override void OnTick(StatusEffectHandler handler)
        {
            handler.Entity.Data.health.Value += Value;
            
            Debug.Log($"Entity healed! Health increased by {Value}. Current health: {handler.Entity.Data.health.Value}/{handler.Entity.Data.health.MaxValue}");
        }
    }
}