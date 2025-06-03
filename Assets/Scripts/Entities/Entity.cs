using Entities.Handlers;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace Entities
{
    [RequireComponent(typeof(StatusEffectHandler))]
    [RequireComponent(typeof(EffectHandler))]
    public class Entity : MonoBehaviour
    {
        [SerializeField, Required] private EntityData data;

        public EntityData Data { get; private set; }

        protected virtual void Awake()
        {
            Data = Instantiate(data);
        }
        
        #region TODO: Remove this shit
        private string HealthText => $"{Data.health.Value}/{Data.health.MaxValue}";
        private string MovementSpeedText => $"{Data.movementSpeed.Value}/{Data.movementSpeed.MaxValue}";
        public TMP_Text healthTextComponent;
        public TMP_Text movementSpeedTextComponent;
        
        private void FixedUpdate()
        {
            healthTextComponent.text = HealthText;
            movementSpeedTextComponent.text = MovementSpeedText;
        }
        #endregion
    }
}