using System;
using Entities;
using Enums;
using Items;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Effects
{
    [CreateAssetMenu(fileName = "StatusEffect", menuName = "Scriptable Objects/StatusEffect", order = 1)]
    public abstract class StatusEffect : SerializedScriptableObject
    {
        [SerializeField] protected StatusEffectData data;
        
        public bool IsExpired => data.GetIsExpired();
        
        protected virtual float Value => data.baseValue;
        protected virtual float Duration => data.duration;
        
        public void Execute(Entity source, Entity target, int stacks)
        {
            data.SetInitData(stacks);
            OnExecute(source, target);   
        }
        
        public void Tick(Entity entity)
        {
            if (data.GetNextTickReady() == false || data.GetIsExpired()) 
                return;
            
            OnTick(entity);
            data.SetNextTickTime(Time.time + data.tickRate);
        }
        
        public void Remove(Entity entity)
        {
            OnRemove(entity);
        }
        
        protected virtual void OnExecute(Entity source, Entity target) { } 
        protected virtual void OnTick(Entity entity) { }
        protected virtual void OnRemove(Entity entity) { }
    }
}