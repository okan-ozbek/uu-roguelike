using System;
using Entities;
using Enums;
using Items;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Effects
{
    public abstract class StatusEffect : SerializedScriptableObject
    {
        [SerializeField] protected StatusEffectData data;
        
        protected virtual float Value => data.baseValue;
        protected virtual float Duration => data.duration;
        
        public void Execute(Entity source, Entity target, int stacks)
        {
            data.SetInitData(stacks);
            OnExecute(source, target);   
        }
        
        public void Tick(Entity entity)
        {
            if (data.GetNextTickReady() == false || GetIsExpired()) 
                return;
            
            OnTick(entity);
            data.SetNextTickTime(Time.time + data.tickRate);
        }
        
        public void Remove(Entity entity)
        {
            OnRemove(entity);
        }
        
        public bool GetIsExpired()
        {
            float expirationTime = data.CreationTime + Duration;

            return Time.time > expirationTime;
        }
        
        protected virtual void OnExecute(Entity source, Entity target) { } 
        protected virtual void OnTick(Entity entity) { }
        protected virtual void OnRemove(Entity entity) { }
    }
}