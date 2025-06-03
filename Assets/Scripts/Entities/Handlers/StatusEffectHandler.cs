using System.Collections.Generic;
using System.Linq;
using StatusEffects;
using UnityEngine;

namespace Entities.Handlers
{
    public class StatusEffectHandler : MonoBehaviour, IActiveVisitable
    {
        public Entity Entity { get; private set; }
        
        private readonly List<StatusEffect> _statusEffects = new();
        
        private void Awake()
        {
            Entity = GetComponent<Entity>();
        }
        
        private void Update()
        {
            UpdateStatusEffects();
            RemoveStatusEffects();
        }
        
        public void Accept(IActiveVisitor visitor)
        {
            visitor.Visit(this);
        }
        
        public void AddStatusEffect(StatusEffect statusEffect)
        {
            _statusEffects.Add(statusEffect);
        }
        
        private void UpdateStatusEffects()
        {
            foreach (var statusEffect in _statusEffects)
            {
                statusEffect.Tick(this);
            }
        }

        private void RemoveStatusEffects()
        {
            foreach (var statusEffect in _statusEffects.Where(statusEffect => statusEffect.IsExpired()).ToList())
            {
                statusEffect.Remove(this);
            }
        
            _statusEffects.RemoveAll(statusEffect => statusEffect.IsExpired());
        }
    }
}