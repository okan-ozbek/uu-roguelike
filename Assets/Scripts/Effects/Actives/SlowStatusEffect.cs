using Entities;
using Enums;
using Stats;

namespace Effects.Actives
{
    public class SlowStatusEffect : StatusEffect
    {
        private StatModifier _modifier;
        
        protected override void OnExecute(IEntity source, IEntity target)
        {
            bool result = source.StatusEffectHandler.Apply(this);
            
            if (result)
            {
                _modifier = new StatModifier(Value, CalculationType.Multiply, 2);
                source.StatHandler.AddModifier(_modifier, StatType.Health);    
            }
        }
        
        protected override void OnRemove(IEntity entity)
        {
            entity.StatHandler.RemoveModifier(_modifier, StatType.Health);
        }
    }
}