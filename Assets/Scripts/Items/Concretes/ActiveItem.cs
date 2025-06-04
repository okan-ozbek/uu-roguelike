using System.Collections.Generic;
using Entities;
using Entities.Handlers;
using StatusEffects;
using UnityEngine;

namespace Items.Concretes
{
    [CreateAssetMenu(fileName = "NewActiveItem", menuName = "Items/Active Item")]
    public class ActiveItem : Item, IStatusEffectVisitor, IEffectVisitor
    {
        [SerializeField] private List<Effect> effects;
        [SerializeField] private List<StatusEffect> statusEffects;

        public void Visit(IStatusEffectVisitable visitable)
        {
            if (visitable is not StatusEffectHandler handler) return;

            foreach (StatusEffect statusEffect in statusEffects)
            {
                handler.Accept(statusEffect);
            }
        }
        
        public void Visit(IEffectVisitable visitable)
        {
            if (visitable is not EffectHandler handler) return;

            foreach (Effect effect in effects)
            {
                handler.Accept(effect);
            }
        }
    }
}