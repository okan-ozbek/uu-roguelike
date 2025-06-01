using Entities;
using Enums;

namespace Effects.Instants
{
    public class DamageEffect : Effect
    {
        protected override void OnExecute(IEntity source, IEntity target)
        {
            target.StatHandler.AlterStat(value, CalculationType.Subtract, StatType.Health);
        }
    }
}