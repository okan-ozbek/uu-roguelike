using System.Collections.Generic;
using System.Linq;
using Effects;
using UnityEngine;

namespace Entities
{
    public class StatusEffectHandler : MonoBehaviour
    {
        private Entity _entity;
        
        private readonly List<StatusEffect> _statusEffects = new();

        private void Awake()
        {
            _entity = GetComponent<Entity>() ?? throw new MissingComponentException("Entity component is required on StatusEffectHandler.");
        }

        private void Update()
        {
            Handle();
        }

        public void Apply(StatusEffect statusEffect)
        {
            if (statusEffect == null || Has(statusEffect)) return;

            _statusEffects.Add(statusEffect);
        }

        public bool Has(StatusEffect statusEffect)
        {
            return statusEffect != null && _statusEffects.Contains(statusEffect);
        }

        private void Handle()
        {
            foreach (StatusEffect statusEffect in _statusEffects.ToList())
            {
                if (statusEffect.IsExpired)
                {
                    statusEffect.Remove(_entity);
                    _statusEffects.Remove(statusEffect);
                    continue;
                }
                
                statusEffect.Tick(_entity);
            }
        }
    }
}