using UnityEngine;

namespace MagiciansBrawl.MBInventory
{
    public class Inventory
    {
        // Inventory Size
        public static readonly int SIZE = 10;

        // Inventory Contents
        private ItemStack[] itemStacks;

        // Constructor
        public Inventory()
        {
            // Create Inventory
            this.itemStacks = new ItemStack[Inventory.SIZE];

            for (int i = 0; i < itemStacks.Length; i++)
            {
                itemStacks[i] = new ItemStack();
            }
        }

        // Add Item
        public int Add(Item item)
        {
            return Add(item.GetItemMeta(), 1);
        }

        // Add Item
        public int Add(Item item, int amount)
        {
            return Add(item.GetItemMeta(), 1);
        }

        // Add Item by Meta
        public int Add(ItemMeta itemMeta)
        {
            return Add(itemMeta, 1);
        }

        // Add Item by Meta
        public int Add(ItemMeta itemMeta, int amount)
        {
            if (itemMeta == null || amount == 0)
            {
                return 0;
            }
            int maxStackSize = itemMeta.GetItemType().MaxStackSize;

            foreach (ItemStack itemStack in itemStacks)
            {
                if (itemStack.IsEmpty())
                {
                    continue;
                }

                if (!itemMeta.Equals(itemStack.GetItemMeta()))
                {
                    continue;
                }

                if (itemStack.GetAmount() == maxStackSize)
                {
                    continue;
                }

                if (itemStack.GetAmount() + amount <= maxStackSize)
                {
                    itemStack.SetAmount(itemStack.GetAmount() + amount);
                    amount = 0;
                    break;
                }
                else
                {
                    amount -= itemStack.GetAmount() + amount - maxStackSize;
                    itemStack.SetAmount(maxStackSize);
                }
            }

            if (amount > 0)
            {
                int firstEmpty = FindEmpty();

                if (firstEmpty != -1 && firstEmpty < itemStacks.Length)
                {
                    ItemStack itemStack = itemStacks[firstEmpty];

                    if (itemStack == null || !itemStack.IsEmpty())
                    {
                        return amount;
                    }

                    if (amount <= maxStackSize)
                    {
                        itemStack.SetItemStack(itemMeta, amount);
                        amount = 0;
                    }
                    else
                    {
                        amount -= maxStackSize;
                        itemStack.SetItemStack(itemMeta, maxStackSize);
                        Add(itemMeta, amount);
                    }
                }
            }
            return amount;
        }

        // Remove Item
        public int Remove(Item item)
        {
            return Remove(item.GetItemMeta(), 1);
        }

        // Remove Item
        public int Remove(Item item, int amount)
        {
            return Remove(item.GetItemMeta(), 1);
        }

        // Remove Item by Meta
        public int Remove(ItemMeta itemMeta)
        {
            return Remove(itemMeta, 1);
        }

        // Remove Item by Meta
        public int Remove(ItemMeta itemMeta, int amount)
        {
            if (itemMeta == null || amount == 0)
            {
                return 0;
            }
            int minStackSize = 0;

            foreach (ItemStack itemStack in itemStacks)
            {
                if (itemStack.IsEmpty())
                {
                    continue;
                }

                if (!itemMeta.Equals(itemStack.GetItemMeta()))
                {
                    continue;
                }

                if (itemStack.GetAmount() - amount > minStackSize)
                {
                    itemStack.SetAmount(itemStack.GetAmount() - amount);
                    amount = 0;
                    break;
                }
                else
                {
                    amount = Mathf.Abs(itemStack.GetAmount() - amount);
                    itemStack.Clear();
                }
            }
            return amount;
        }

        // Find Empty Slot
        public int FindEmpty()
        {
            for (int i = 0; i < itemStacks.Length; i++)
            {
                ItemStack itemStack = itemStacks[i];

                if (itemStack == null || !itemStack.IsEmpty())
                {
                    continue;
                }
                return i;
            }
            return -1;
        }
    }
}