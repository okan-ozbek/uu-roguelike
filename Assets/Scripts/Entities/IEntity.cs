using Entities.Handlers;
using Enums;
using Stats;

namespace Entities
{
    public interface IEntity
    {
        public EntityData Data { get; }
        
        public StatusEffectHandler StatusEffectHandler { get; }
        public ColorHandler ColorHandler { get; }
        public StatHandler StatHandler { get; }
    }
}