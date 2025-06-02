using UnityEngine;
using Utils.Input;

namespace Items
{
    public class Pickup : MonoBehaviour
    {
        [SerializeField] private Item item;
    
        public void OnTriggerStay2D(Collider2D other)
        {
            if (GameInput.Instance.HasPressedInteract)
            {
                other.GetComponent<IVisitable>()?.Accept(item);
                Destroy(gameObject);    
            }
        }
    }
}