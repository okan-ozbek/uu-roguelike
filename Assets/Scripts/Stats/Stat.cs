using System;
using System.Collections.Generic;
using System.Linq;
using Enums;
using UnityEngine;

namespace Stats
{
    [Serializable]
    public class Stat
    {
        public event Action<Stat> OnValueChanged;
        
        [SerializeField] private float baseValue;
        [SerializeField] private float maxValue;

        private List<StatModifier> _modifiers = new();

        public float Value
        {
            get => baseValue;
            set
            {
                baseValue = Mathf.Clamp(value, 0, MaxValue);
                OnValueChanged?.Invoke(this);
            }
        }

        public float MaxValue
        {
            get
            {
                return _modifiers == null || _modifiers?.Count == 0 
                    ? maxValue 
                    : _modifiers!.Aggregate(maxValue, (current, mod) => mod.Calculate(current));
            }
        }
        
        public void AlterValue(float value, CalculationType calculationType)
        {
            switch (calculationType)
            {
                case CalculationType.Add:
                    Value += value;
                    break;
                case CalculationType.Subtract:
                    Value -= value;
                    break;
                case CalculationType.Multiply:
                    Value *= value;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(calculationType), calculationType, null);
            }
        }
        
        public void AddModifier(StatModifier modifier)
        {
            _modifiers ??= new List<StatModifier>();
            
            _modifiers.Add(modifier);
            Value = Value;
        }
        
        public void RemoveModifiersBySource(object source)
        {
            if (InvalidList()) return;
            
            List<StatModifier> modifiersToRemove = _modifiers.Where(mod => mod.Source == source).ToList();
            foreach (var modifier in modifiersToRemove)
            {
                RemoveModifier(modifier);
            }

            Value = Value;
        }
        
        private void RemoveModifier(StatModifier modifier)
        {
            _modifiers.Remove(modifier);
        }

        private bool InvalidList()
        {
            return _modifiers == null || _modifiers.Count == 0;
        }
    }
}