using System;
using Entities;

namespace  Effects
{
    [Serializable]
    public abstract class Effect
    {
        public float value;

        public void Execute(IEntity source, IEntity target)
        {
            OnExecute(source, target);
        }
        
        protected abstract void OnExecute(IEntity source, IEntity target);
    }
}

    