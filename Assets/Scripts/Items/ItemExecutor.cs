using System.Linq;
using Entities;
using UnityEngine;
using Utils.Input;

namespace Items
{
    [RequireComponent(typeof(Entity))]
    public class ItemExecutor : MonoBehaviour
    {
        [SerializeField] private Entity target;
        [SerializeField] private ItemData data;

        private Entity _source;

        private void Awake()
        {
            data = Instantiate(data);
            
            _source = GetComponent<Entity>();
        }
        
        private void Update()
        {
            if (GameInputManager.Instance.HasPressedInteract)
            {
                foreach (var effect in data.Effects.Where(effect => Procced()))
                {              
                    effect.Execute(_source, target);
                }

                foreach (var statusEffect in data.StatusEffects.Where(statusEffect => Procced()))
                {
                    statusEffect.Execute(_source, target, data.Stacks);
                }
            }
        }

        private bool Procced()
        {
            return Random.Range(0.0f, 1.0f) < data.triggerChance;
        }
    }
}