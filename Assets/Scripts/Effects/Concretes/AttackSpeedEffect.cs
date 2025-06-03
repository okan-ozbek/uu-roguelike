using Entities.Handlers;
using UnityEngine;

namespace Effects.Concretes
{
    [CreateAssetMenu(fileName = "NewAttackSpeedEffect", menuName = "Effects/Attack Speed Effect")]
    public class AttackSpeedEffect : Effect
    {
        protected override void OnApply(EffectHandler handler)
        {
            handler.Entity.Data.attackSpeed.Add(Modifier);
            
            Debug.Log($"Health effect applied. Health increased to {handler.Entity.Data.health.Value}.");
        }
    }
}