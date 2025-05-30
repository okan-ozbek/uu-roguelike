using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    public class ItemInventory : MonoBehaviour
    {
        private List<ItemData> _items = new();
        
        public IReadOnlyList<ItemData> Items => _items.AsReadOnly();
        
        public void AddItem(ItemData item)
        {
            if (Has(item))
            {
                // Find item and increase its stack count
                int index = _items.IndexOf(item);
                if (index >= 0)
                {
                    _items[index].IncreaseStackCount();
                    return;
                }
            }
            
            _items.Add(item);
        }
        
        public void RemoveItem(ItemData item)
        {
            if (Has(item) == false)
            {
                return;
            }
            
            _items.Remove(item);
        }
        
        public bool Has(ItemData item)
        {
            return _items.Contains(item) && _items.Count > 0 && _items != null;
        }
    }
}