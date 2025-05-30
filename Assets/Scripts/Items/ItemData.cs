using System.Collections.Generic;
using Effects;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Item", order = 1)]
    public class ItemData : SerializedScriptableObject
    {
        public string label;
        public string description;
        public Sprite icon;
        
        [Range(0.0f, 1.0f), Tooltip("Chance of the item triggering its effects when used.")]
        public float triggerChance = 1.0f;
        
        [Tooltip("Effects that are applied when the item is used.")]
        public readonly List<Effect> Effects = new();
        public readonly List<StatusEffect> StatusEffects = new();
        
        [SerializeField] public int Stacks { get; private set; } = 1;
        
        public void IncreaseStackCount()
        {
            Stacks++;
        }
    }
}