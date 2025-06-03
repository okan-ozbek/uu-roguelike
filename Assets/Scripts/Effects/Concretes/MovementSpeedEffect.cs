using Entities.Handlers;
using UnityEngine;

namespace Effects.Concretes
{
    [CreateAssetMenu(fileName = "NewMovementSpeedEffect", menuName = "Effects/Movement Speed Effect")]
    public class MovementSpeedEffect : Effect
    {
        protected override void OnApply(EffectHandler handler)
        {
            handler.Entity.Data.movementSpeed.Add(Modifier);
            
            Debug.Log($"Health effect applied. Movement speed increased to {handler.Entity.Data.health.Value}.");
        }
    }
}