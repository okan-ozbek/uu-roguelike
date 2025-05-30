using System;
using Entities;

namespace  Effects
{
    [Serializable]
    public abstract class Effect
    {
        public float value;

        public void Execute(Entity source, Entity target)
        {
            OnExecute(source, target);
        }
        
        protected abstract void OnExecute(Entity source, Entity target);
    }
}

    