using Entities;
using Enums;

namespace Effects.Instants
{
    public class DamageEffect : Effect
    {
        protected override void OnExecute(Entity source, Entity target)
        {
            target.AlterStat(value, CalculationType.Subtract, StatType.Health);
        }
    }
}