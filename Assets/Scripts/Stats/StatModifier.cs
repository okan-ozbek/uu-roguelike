using Entities;
using Stats.Enums;

namespace Stats
{
    public class StatModifier
    {
        public object Source { get; }
        
        private CalculationType CalculationType { get; }
        private float Value { get; }
        
        public StatModifier(CalculationType calculationType, float value, object source)
        {
            CalculationType = calculationType;
            Value = value;
            Source = source;
        }

        public float Calculate(float statValue)
        {
            return CalculationType switch 
            {
                CalculationType.Add => statValue + Value,
                CalculationType.Multiply => statValue * Value,
                CalculationType.Subtract => statValue - Value,
                _ => statValue
            };
        }
    }
}