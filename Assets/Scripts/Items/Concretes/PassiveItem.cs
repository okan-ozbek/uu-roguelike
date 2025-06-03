using System.Collections.Generic;
using Effects;
using Entities.Handlers;
using UnityEngine;

namespace Items.Concretes
{
    [CreateAssetMenu(fileName = "NewPassiveItem", menuName = "Items/Passive Item")]
    public class PassiveItem : Item, IPassiveVisitor
    {
        [SerializeField] private List<Effect> effects;
        
        public void Visit(IPassiveVisitable visitable)
        {
            if (visitable is EffectHandler handler)
            {
                foreach (var effect in effects)
                {
                    handler.Accept(effect);
                }
            }
        }
    }
}