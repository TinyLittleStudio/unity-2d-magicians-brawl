namespace MagiciansBrawl.MBInventory
{
    public class ItemStack
    {
        // ItemMeta
        private ItemMeta itemMeta;

        // Amount
        private int amount;

        // Constructor
        public ItemStack()
        {

        }

        // Constructor
        public ItemStack(ItemMeta itemMeta) : this(itemMeta, 1)
        {

        }

        // Constructor
        public ItemStack(ItemMeta itemMeta, int amount)
        {
            SetItemStack(itemMeta, amount);
        }

        // Constructor
        public ItemStack(ItemStack itemStack)
        {
            SetItemStack(itemStack);
        }

        // Set Item Stack
        public void SetItemStack(ItemMeta itemMeta, int amount)
        {
            this.itemMeta = itemMeta;
            this.amount = amount;

            this.itemMeta = null;
        }

        // Set Item Stack
        public void SetItemStack(ItemMeta itemMeta)
        {
            SetItemStack(itemMeta, 1);
        }

        // Set Item Stack
        public void SetItemStack(ItemStack itemStack)
        {
            SetItemStack(itemStack.itemMeta, itemStack.amount);
        }

        // Set Amount
        public void SetAmount(int amount)
        {
            this.amount = IsEmpty() ? 0 : amount;
        }

        // Get Amount
        public int GetAmount()
        {
            return amount;
        }

        // Set ItemMeta by Id
        public void SetItem(int id)
        {
            this.itemMeta = ItemMeta.GetItemMeta(id);
        }

        // Set ItemMeta
        public void SetItem(ItemMeta itemMeta)
        {
            this.itemMeta = itemMeta;
        }

        // Get ItemMeta
        public ItemMeta GetItemMeta()
        {
            return itemMeta;
        }

        // Clear Item Stack
        public void Clear()
        {
            this.amount = 0;
            this.itemMeta = null;
        }

        // Is Empty
        public bool IsEmpty()
        {
            return itemMeta == null || amount == 0;
        }
    }
}
