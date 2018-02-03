using UnityEngine;

namespace MagiciansBrawl.MBInventory
{
    public class InventoryHandler : MonoBehaviour
    {
        // Inventory Handler Instance
        private static InventoryHandler instance;

        // Inventory
        private Inventory inventory;

        // Awake
        private void Awake()
        {
            if (InventoryHandler.instance == null)
            {
                InventoryHandler.instance = this;
            }
            else
            {
                Destroy(this);
            }
            this.inventory = new Inventory();
        }

        // Get Inventory
        public static Inventory GetInventory()
        {
            if (InventoryHandler.instance)
            {
                return null;
            }
            return InventoryHandler.instance.inventory;
        }
    }
}
