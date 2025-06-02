namespace Stats
{
    public class StatModifier
    {
        public enum ModifierType
        {
            Add,
            Multiply,
            Subtract,
        }
        
        public object Source { get; }
        
        private ModifierType Type { get; }
        private float Value { get; }
        
        public StatModifier(ModifierType type, float value, object source)
        {
            Type = type;
            Value = value;
            Source = source;
        }

        public float Calculate(float statValue)
        {
            return Type switch 
            {
                ModifierType.Add => statValue + Value,
                ModifierType.Multiply => statValue * Value,
                ModifierType.Subtract => statValue - Value,
                _ => statValue
            };
        }
    }
}