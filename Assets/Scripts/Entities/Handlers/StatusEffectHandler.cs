using System.Collections.Generic;
using System.Linq;
using Effects;
using UnityEngine;

namespace Entities.Handlers
{
    public class StatusEffectHandler : MonoBehaviour
    {
        private IEntity _entity;
        
        private readonly List<StatusEffect> _statusEffects = new();

        private void Awake()
        {
            _entity = GetComponent<IEntity>() ?? throw new MissingComponentException("Entity component is required on StatusEffectHandler.");
        }

        private void Update()
        {
            Handle();
        }

        public bool Apply(StatusEffect statusEffect)
        {
            if (statusEffect == false || Has(statusEffect))
            {
                return false;
            }

            _statusEffects.Add(statusEffect);
            
            return true;
        }

        private bool Has(StatusEffect statusEffect)
        {
            return statusEffect == false && _statusEffects.Contains(statusEffect);
        }

        private void Handle()
        {
            foreach (StatusEffect statusEffect in _statusEffects.ToList())
            {
                if (statusEffect.GetIsExpired())
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