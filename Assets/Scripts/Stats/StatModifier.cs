using Enums;

namespace Stats
{
    public class StatModifier
    {
        private readonly float _value;
        private readonly CalculationType _calculationType;
        
        public object Source { get; }

        public float Calculate(float value)
        {
            return _calculationType switch
            {
                CalculationType.Add => value + _value,
                CalculationType.Subtract => value - _value,
                CalculationType.Multiply => value * _value,
                _ => value
            };
        }
        
        public StatModifier(float value, CalculationType calculationType, object source = null)
        {
            _value = value;
            _calculationType = calculationType;
            Source = source;
        }
    }
}