using System.Collections.Generic;
using Enums;
using Sirenix.OdinInspector;
using Stats;
using UnityEngine;

namespace Entities
{
    [CreateAssetMenu(fileName = "Entity data", menuName = "Scriptable Objects/EntityData", order = 1)]
    public class EntityData : SerializedScriptableObject
    {
        [SerializeField]
        public Dictionary<StatType, Stat> Stats = new();
    }
}