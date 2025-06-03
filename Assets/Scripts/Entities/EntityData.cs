using Stats;
using Stats.Enums;
using UnityEngine;

namespace Entities
{
    [CreateAssetMenu(fileName = "NewEntityData", menuName = "Datas/Entity Data")]
    public class EntityData : ScriptableObject
    {
        [SerializeReference] public Stat health;
        [SerializeReference] public Stat movementSpeed;
        [SerializeReference] public Stat attackSpeed;
        
        public Stat GetStat(StatType type)
        {
            return type switch
            {
                StatType.Health => health,
                StatType.MovementSpeed => movementSpeed,
                StatType.AttackSpeed => attackSpeed,
                _ => throw new System.ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}