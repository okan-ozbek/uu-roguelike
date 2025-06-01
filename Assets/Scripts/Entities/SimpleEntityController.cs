using Entities.Handlers;
using Enums;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace Entities
{
    public class SimpleEntityController : MonoBehaviour, IEntity
    {
        // TODO remove this field when the UI is implemented
        [SerializeField] private TMP_Text healthText;
        
        [SerializeField, Required] 
        private EntityData data;

        public StatusEffectHandler StatusEffectHandler { get; private set; }
        public ColorHandler ColorHandler { get; private set; }
        public StatHandler StatHandler { get; private set; }

        public EntityData Data => data;

        private void Awake()
        {
            data = Instantiate(data);

            StatusEffectHandler = GetComponent<StatusEffectHandler>() ?? gameObject.AddComponent<StatusEffectHandler>();
            ColorHandler = GetComponent<ColorHandler>() ?? gameObject.AddComponent<ColorHandler>();
            StatHandler = GetComponent<StatHandler>() ?? gameObject.AddComponent<StatHandler>();
        }

        private void Update()
        {
            healthText.text = $"Health: {data.Stats[StatType.Health].Value}";
            
            if (data.Stats[StatType.Health].Value <= 0)
            {
                // TODO remove this line when the UI is implemented
                // Handle entity death logic here, e.g., destroy the entity or trigger a death animation
                Destroy(gameObject);
            }
        }
    }
}