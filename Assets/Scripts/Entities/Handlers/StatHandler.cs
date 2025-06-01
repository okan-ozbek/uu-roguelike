using Enums;
using Stats;
using UnityEngine;

namespace Entities.Handlers
{
    public interface IStatHandler
    {
        public void AlterStat(float value, CalculationType calculationType, StatType statType);
        public void AddModifier(StatModifier modifier, StatType statType);
        public void RemoveModifier(StatModifier modifier, StatType statType);
    }
    
    public class StatHandler : MonoBehaviour
    {
        private IEntity _entity;
        
        private void Awake()
        {
            _entity = GetComponent<IEntity>() ?? throw new MissingComponentException("Entity component is required on StatHandler.");
        }
        
        public void AlterStat(float value, CalculationType calculationType, StatType statType)
        {
            _entity.Data.Stats[statType].AlterValue(value, calculationType);
        }
        
        public void AddModifier(StatModifier modifier, StatType statType)
        {
            _entity.Data.Stats[statType].AddModifier(modifier);
        }

        public void RemoveModifier(StatModifier modifier, StatType statType)
        {
            _entity.Data.Stats[statType].RemoveModifiersBySource(modifier.Source);
        }
    }
}