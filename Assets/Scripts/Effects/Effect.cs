using Entities.Handlers;
using Sirenix.OdinInspector;
using Stats;
using Stats.Enums;
using UnityEngine;

namespace Effects
{
    public abstract class Effect : ScriptableObject, IEffectVisitor
    {
        [SerializeField, Required] protected float value;
        [SerializeField, Required] protected CalculationType calculationType;

        protected StatModifier Modifier => new(calculationType, value, this);

        public void Visit(IEffectVisitable visitable)
        {
            if (visitable is EffectHandler handler)
            {
                Apply(handler);
            }
        }
        
        protected virtual void OnApply(EffectHandler handler) { }

        private void Apply(EffectHandler handler) => OnApply(handler);
    }
}