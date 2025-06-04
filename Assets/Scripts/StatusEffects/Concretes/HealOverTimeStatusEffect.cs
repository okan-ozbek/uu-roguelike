using Entities.Handlers;
using Stats.Enums;
using UnityEngine;

namespace StatusEffects.Concretes
{
    [CreateAssetMenu(fileName = "NewHealOverTimeStatusEffect", menuName = "StatusEffects/Heal Over Time Status Effect")]
    public class HealOverTimeStatusEffect : StatusEffect
    {
        protected override void OnTick(StatusEffectHandler handler)
        {
            handler.Entity.Data.health.Value += Value;
            
            Debug.Log($"HOT applied! Health reduced by {Value}. Current health: {handler.Entity.Data.health.Value}/{handler.Entity.Data.health.MaxValue}");
        }
    }
}