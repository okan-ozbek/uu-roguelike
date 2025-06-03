using UnityEngine;

namespace Items
{
    public class Pickup : MonoBehaviour
    {
        [SerializeField] private Item item;
    
        public void OnTriggerStay2D(Collider2D other)
        {
            switch (item)
            {
                case IActiveVisitor activeItem:
                    other.GetComponent<IActiveVisitable>()?.Accept(activeItem);
                    break;
                case IPassiveVisitor passiveItem:
                    other.GetComponent<IPassiveVisitable>()?.Accept(passiveItem);
                    break;
            }
            
            Destroy(gameObject);  
        }
    }
}