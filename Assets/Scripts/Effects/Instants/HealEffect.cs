using Entities;
using Enums;

namespace Effects.Instants
{
    public class HealEffect : Effect
    {
        protected override void OnExecute(IEntity source, IEntity target)
        {
            target.StatHandler.AlterStat(value, CalculationType.Add, StatType.Health);
        }
    }
}