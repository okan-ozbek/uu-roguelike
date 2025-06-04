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

        [SerializeReference] public Dictionary<ItemType, Item> items;
    }
}