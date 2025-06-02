using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Stats
{
    public class Stat
    {
        [SerializeField] private float _value;
        [SerializeField] private float _maxValue;
        
        public List<StatModifier> Modifiers { get; } = new();

        public float Value
        {
            get => Mathf.Clamp(_value, 0.0f, _maxValue);
            set => _value = Mathf.Clamp(value, 0.0f, _maxValue);
        }

        public float MaxValue => (Modifiers?.Count > 0) 
            ? Modifiers.Aggregate(_maxValue, (current, modifier) => modifier.Calculate(current)) 
            : _maxValue;

        public void Add(StatModifier modifier)
        {
            bool isCurrentValueEqualToMax = Value == MaxValue;
            
            Modifiers.Add(modifier);
            
            Value = (isCurrentValueEqualToMax) 
                ? MaxValue 
                : Value;
        }
        
        public void RemoveModifiersBySource(object source)
        {
            bool isCurrentValueEqualToMax = Value == MaxValue;
            
            Modifiers.RemoveAll(modifier => modifier.Source == source);
            
            Value = (isCurrentValueEqualToMax) 
                ? MaxValue 
                : Value;
        }
    }
}