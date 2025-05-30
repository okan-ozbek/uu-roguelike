using Entities;
using Enums;

namespace Effects.Instants
{
    public class HealEffect : Effect
    {
        protected override void OnExecute(Entity source, Entity target)
        {
            target.AlterStat(value, CalculationType.Add, StatType.Health);
        }
    }
}