using System.Collections.Generic;
using UnityEngine;

namespace MagiciansBrawl.MBInventory
{
    public class InventoryFactory : MonoBehaviour
    {
        [Header("Inventory Settings")]
        [SerializeField]
        // All Editor Item Metas
        private List<ItemMeta> itemMetas = new List<ItemMeta>();

        // Start
        private void Start()
        {
            // Register Item Metas
            foreach (ItemMeta itemMeta in itemMetas)
            {
                if (!ItemMeta.Register(itemMeta))
                {
                    Debug.LogError("Could not register " + itemMeta.Id);
                }
            }
        }
    }
}
