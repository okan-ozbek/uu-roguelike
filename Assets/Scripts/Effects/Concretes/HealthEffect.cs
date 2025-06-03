using Entities.Handlers;
using UnityEngine;

namespace Effects.Concretes
{
    [CreateAssetMenu(fileName = "NewHealthEffect", menuName = "Effects/Health Effect")]
    public class HealthEffect : Effect
    {
        protected override void OnApply(EffectHandler handler)
        {
            handler.Entity.Data.health.Add(Modifier);
            
            Debug.Log($"Health effect applied. Health increased to {handler.Entity.Data.health.Value}.");
        }
    }
}