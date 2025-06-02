using Entities;
using Entities.Handlers;
using StatusEffects;
using UnityEngine;

namespace Items.Concretes
{
    [CreateAssetMenu(fileName = "NewPassiveItem", menuName = "Items/Passive Item")]
    public class PassiveItem : Item
    {
        [SerializeField] private StatusEffect statusEffect;
        
        public override void Visit(IVisitable visitable)
        {
            if (visitable is StatusEffectHandler handler)
            {
                handler.Accept(statusEffect);
            }
        }
    }
}