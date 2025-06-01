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
        
        public void Execute(IEntity source, IEntity target, int stacks)
        {
            data.SetInitData(stacks);
            OnExecute(source, target);   
        }
        
        public void Tick(IEntity entity)
        {
            if (data.GetNextTickReady() == false || GetIsExpired()) 
                return;
            
            OnTick(entity);
            data.SetNextTickTime(Time.time + data.tickRate);
        }
        
        public void Remove(IEntity entity)
        {
            OnRemove(entity);
        }
        
        public bool GetIsExpired()
        {
            float expirationTime = data.CreationTime + Duration;

            return Time.time > expirationTime;
        }
        
        protected virtual void OnExecute(IEntity source, IEntity target) { } 
        protected virtual void OnTick(IEntity entity) { }
        protected virtual void OnRemove(IEntity entity) { }
    }
}