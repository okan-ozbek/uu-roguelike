using UnityEngine;

namespace Entities.Handlers
{
    public class EffectHandler : MonoBehaviour, IPassiveVisitable
    {
        public Entity Entity { get; private set; }

        private void Awake()
        {
            Entity = GetComponent<Entity>();
        }
        
        public void Accept(IPassiveVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}