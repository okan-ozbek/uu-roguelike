using System.Collections;
using Entities.Handlers;
using Enums;
using Sirenix.OdinInspector;
using Stats;
using TMPro;
using UnityEngine;
using Utils.Input;

namespace Entities
{
    public class Entity : MonoBehaviour
    {
        [SerializeField] 
        private TMP_Text healthText;
        
        [SerializeField, Required] 
        private EntityData data;

        public StatusEffectHandler StatusEffectHandler { get; private set; }
        public ColorHandler ColorHandler { get; private set; }

        private void Awake()
        {
            data = Instantiate(data);
            healthText.text = $"Health has not been assigned yet.";
            
            StatusEffectHandler = GetComponent<StatusEffectHandler>() ?? gameObject.AddComponent<StatusEffectHandler>();
            ColorHandler = GetComponent<ColorHandler>() ?? gameObject.AddComponent<ColorHandler>();
        }
        
        private void Update()
        {
            if (GameInputManager.Instance.HasPressedJump)
            {
                data.Stats[StatType.Health].Value -= 10.0f;
            }
        
            if (GameInputManager.Instance.HasReleasedAttack)
            {
                data.Stats[StatType.Health].Value = 100.0f;
            }
        
            healthText.text = $"Health: {Mathf.Round(data.Stats[StatType.Health].Value)}/{Mathf.Round(data.Stats[StatType.Health].MaxValue)}";
        }
        
        public void AlterStat(float value, CalculationType calculationType, StatType statType)
        {
            data.Stats[statType].AlterValue(value, calculationType);
        }
        
        public void AddModifier(StatModifier modifier, StatType statType)
        {
            data.Stats[statType].AddModifier(modifier);
        }

        public void RemoveModifier(StatModifier modifier, StatType statType)
        {
            data.Stats[statType].RemoveModifiersBySource(modifier.Source);
        }
    }
}