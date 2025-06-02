using Entities;
using Entities.Handlers;
using Sirenix.OdinInspector;
using UnityEngine;

namespace StatusEffects
{
    public abstract class StatusEffect : ScriptableObject, IVisitor
    {
        [SerializeField, Required] private float value;
        [SerializeField, Required] private float duration;
        [SerializeField, Required] private float ticks;
        private float _createdAt;
        private float _nextTickTime;
        
        protected float Value => value;
        protected float Duration => duration;
        protected float Ticks => ticks;
        
        public void Visit(IVisitable visitable)
        {
            if (visitable is StatusEffectHandler handler)
            {
                handler.AddStatusEffect(this);
                
                Apply(handler);
                
                _nextTickTime = Time.time;
                _createdAt = Time.time;
            }
        }

        protected virtual void OnApply(StatusEffectHandler handler) { }
        protected virtual void OnRemove(StatusEffectHandler handler) { }
        protected virtual void OnTick(StatusEffectHandler handler) { }
        
        private void SetNextTickTime() => _nextTickTime = Time.time + (duration / ticks);
        
        public bool IsExpired() => Time.time > (_createdAt + duration);
        public void Apply(StatusEffectHandler handler) => OnApply(handler);
        public void Remove(StatusEffectHandler handler) => OnRemove(handler);

        public void Tick(StatusEffectHandler handler)
        {
            if (_nextTickTime > Time.time) return;

            OnTick(handler);
            SetNextTickTime();
        }
    }
}