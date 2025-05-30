using System;
using Entities;
using Enums;
using Items;
using UnityEngine;

namespace Effects
{
    [Serializable]
    public abstract class StatusEffect
    {
        [SerializeField] protected StatusEffectData data;

        protected int Stacks { get; private set; } = 1;
        
        private float _creationTime;
        private float _nextTickTime;

        public bool IsExpired => SetIsExpired();
        private bool NextTickReady => SetNextTickReady();

        protected virtual float Value => data.baseValue;
        protected virtual float Duration => data.duration;
        
        public void Execute(Entity source, Entity target, ItemData item)
        {
            SetInternalVariables(item);
            OnExecute(source, target);   
        }
        
        public void Tick(Entity entity)
        {
            if (NextTickReady == false || IsExpired) 
                return;
            
            OnTick(entity);
            _nextTickTime = Time.time + data.tickRate;
        }
        
        public void Remove(Entity entity)
        {
            OnRemove(entity);
        }
        
        protected virtual void OnExecute(Entity source, Entity target) { } 
        protected virtual void OnTick(Entity entity) { }
        protected virtual void OnRemove(Entity entity) { }

        private void SetInternalVariables(ItemData item)
        {
            Stacks = item.Stacks;
            _creationTime = Time.time;
            _nextTickTime = Time.time;
        }

        public bool SetIsExpired()
        {
            float expirationTime = _creationTime + Duration;

            return Time.time > expirationTime;
        }

        public bool SetNextTickReady()
        {
            return Time.time > _nextTickTime;
        }
    }
}