using Entities.Handlers;
using Stats.Enums;
using UnityEngine;

namespace StatusEffects.Concretes
{
    [CreateAssetMenu(fileName = "NewDamageOverTimeStatusEffect", menuName = "StatusEffects/Damage Over Time Status Effect")]
    public class DamageOverTimeStatusEffect : StatusEffect
    {
        protected override void OnTick(StatusEffectHandler handler)
        {
            handler.Entity.Data.health.Value -= Value;
            
            Debug.Log($"DOT applied! Health reduced by {Value}. Current health: {handler.Entity.Data.health.Value}/{handler.Entity.Data.health.MaxValue}");
        }
    }
}