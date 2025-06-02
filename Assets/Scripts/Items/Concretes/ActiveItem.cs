using System.Collections.Generic;
using Entities;
using Entities.Handlers;
using StatusEffects;
using UnityEngine;

namespace Items.Concretes
{
    [CreateAssetMenu(fileName = "NewActiveItem", menuName = "Items/Active Item")]
    public class ActiveItem : Item
    {
        [SerializeField] private List<StatusEffect> statusEffects;
        
        public override void Visit(IVisitable visitable)
        {
            if (visitable is StatusEffectHandler handler)
            {
                foreach (var statusEffect in statusEffects)
                {
                    handler.Accept(statusEffect);
                }
            }
        }
    }
}