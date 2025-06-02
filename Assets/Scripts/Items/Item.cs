using UnityEngine;

namespace Items
{
    public abstract class Item : ScriptableObject, IVisitor
    {
        public abstract void Visit(IVisitable visitable);
    }
}