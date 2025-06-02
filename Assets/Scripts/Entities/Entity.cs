using Entities.Handlers;
using Sirenix.OdinInspector;
using Stats;
using UnityEngine;

namespace Entities
{
    [RequireComponent(typeof(StatusEffectHandler))]
    public class Entity : MonoBehaviour
    {
        [SerializeField, Required] private StatContainer stats;

        public StatContainer Stats { get; private set; }

        protected virtual void Awake()
        {
            Stats = Instantiate(stats);
            Debug.Log("Hello world");
            Debug.Log(Stats.movementSpeed.Value);
        }
    }
}