using UnityEngine;

namespace Items
{
    public class Pickup : MonoBehaviour
    {
        [SerializeField] private Item item;
    
        public void OnTriggerStay2D(Collider2D other)
        {
            if (item is IStatusEffectVisitor activeItem)
            {
                other.GetComponent<IStatusEffectVisitable>()?.Accept(activeItem);
            }

            if (item is IEffectVisitor passiveItem)
            {
                other.GetComponent<IEffectVisitable>()?.Accept(passiveItem);
            }

            Destroy(gameObject);  
        }
    }
}