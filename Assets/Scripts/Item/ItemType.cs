using System.Collections.Generic;

namespace MagiciansBrawl.MBInventory
{
    public class ItemType
    {
        // Equipable
        public static readonly ItemType EQUIPABLE = new ItemType("EQUIPABLE", 1);

        // Consumable
        public static readonly ItemType CONSUMABLE = new ItemType("CONSUMABLE", 16);

        // Values
        public static IEnumerable<ItemType> Values
        {
            get
            {
                yield return EQUIPABLE;

                yield return CONSUMABLE;
            }
        }

        // Name
        private readonly string name;

        // Max Stack Size
        private readonly int maxStackSize;

        // Constructor
        ItemType(string name, int maxStackSize)
        {
            this.name = name;
            this.maxStackSize = maxStackSize;
        }

        // Returns the Name
        public string Name
        {
            get
            {
                return name;
            }
        }

        // Returns the Max Stack Size
        public int MaxStackSize
        {
            get
            {
                return maxStackSize;
            }
        }

        // To String
        public override string ToString()
        {
            return name;
        }
    }
}