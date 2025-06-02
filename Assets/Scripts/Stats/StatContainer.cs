using Sirenix.OdinInspector;
using UnityEngine;

namespace Stats
{
    [CreateAssetMenu(fileName = "NewStatContainer", menuName = "Stats/Stat Container")]
    public class StatContainer : ScriptableObject
    {
        [SerializeReference] public Stat health;
        [SerializeReference] public Stat movementSpeed;
    }
}