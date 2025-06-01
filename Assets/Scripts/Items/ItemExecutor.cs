using System.Linq;
using Entities;
using UnityEngine;
using Utils.Input;

namespace Items
{
    [RequireComponent(typeof(IEntity))]
    public class ItemExecutor : MonoBehaviour
    {
        private IEntity _target;
        
        [SerializeField] private ItemData data;

        private IEntity _source;

        private void Awake()
        {
            data = Instantiate(data);
            
            _source = GetComponent<IEntity>();
            _target ??= FindObjectsByType<SimpleEntityController>(FindObjectsSortMode.None).First();
        }
        
        private void Update()
        {
            if (GameInputManager.Instance.HasPressedInteract)
            {
                foreach (var effect in data.Effects.Where(effect => Procced()))
                {              
                    effect.Execute(_source, _target);
                }

                foreach (var statusEffect in data.StatusEffects.Where(statusEffect => Procced()))
                {
                    statusEffect.Execute(_source, _target, data.Stacks);
                }
            }
        }

        private bool Procced()
        {
            return Random.Range(0.0f, 1.0f) < data.triggerChance;
        }
    }
}