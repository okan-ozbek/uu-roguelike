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

        private void Start()
        {
            _source = GetComponent<Entity>();
            
            // Create a copy of item data to avoid modifying the original asset
            // TODO refactor
            data = Instantiate(data);
            
            for (int i = 0; i < 9; i++)
            {
                data.IncreaseStackCount();
            }
            // TODO until here
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
            if (Random.Range(0.0f, 1.0f) < data.triggerChance)
            {
                return true;
            }
            
            return false;
        }
    }
}