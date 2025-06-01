using Entities.Handlers;
using Enums;
using Sirenix.OdinInspector;
using Stateforge;
using Stats;
using UnityEngine;

namespace Entities
{
    public abstract class AdvancedEntityController : Controller, IEntity
    {
        [SerializeField, Required] 
        private EntityData data;

        public StatusEffectHandler StatusEffectHandler { get; private set; }
        public ColorHandler ColorHandler { get; private set; }
        public StatHandler StatHandler { get; private set; }
        
        public Rigidbody2D Rigidbody { get; private set; }
        public EntityData Data => data;

        private void Awake()
        {
            data = Instantiate(data);
            
            StatusEffectHandler = GetComponent<StatusEffectHandler>() ?? gameObject.AddComponent<StatusEffectHandler>();
            ColorHandler = GetComponent<ColorHandler>() ?? gameObject.AddComponent<ColorHandler>();
            StatHandler = GetComponent<StatHandler>() ?? gameObject.AddComponent<StatHandler>();
            
            InitializeRigidbody();
            
            OnAwake();
        }

        private void Update()
        {
            OnUpdate();
        }
        
        protected abstract void OnAwake();
        protected abstract void OnUpdate();
        
        private void InitializeRigidbody()
        {
            Rigidbody = GetComponent<Rigidbody2D>() ?? gameObject.AddComponent<Rigidbody2D>();
            
            Rigidbody.gravityScale = 0f;
            Rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
            Rigidbody.interpolation = RigidbodyInterpolation2D.Interpolate;
            Rigidbody.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        }

        private void OnDrawGizmos()
        {
#if UNITY_EDITOR
            if (Application.isPlaying)
            {
                // Get all the active states as a tree
                UnityEditor.Handles.Label(transform.position,
                    "Active: " + stateMachine.GetTree(stateMachine.currentState));
            }
#endif
        }
    }
}