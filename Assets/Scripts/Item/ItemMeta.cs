using System;
using System.Collections.Generic;
using UnityEngine;

namespace MagiciansBrawl.MBInventory
{
    [Serializable]
    public class ItemMeta : IEquatable<ItemMeta>
    {
        // All Available Item Metas
        private static List<ItemMeta> itemMetas = new List<ItemMeta>();

        private static int baseId = 0;

        // Id
        private int id;

        // Name and Description
        [SerializeField]
        private string name, description;

        // Sprite
        [SerializeField]
        private Sprite sprite;

        // Item Type
        [SerializeField]
        private ItemType itemType;

        // Constructor
        public ItemMeta(int id, string name, string description, string effect, Sprite sprite, ItemType itemType)
        {
            this.id = baseId++;

            // Check for Id
            if (ItemMeta.GetItemMeta(id) != null)
            {
                throw new ArgumentException(id + " ItemMeta already exists");
            }
            this.name = name;
            this.description = description;

            this.sprite = sprite;

            this.itemType = itemType;
        }

        // Returns the id
        public int Id
        {
            get
            {
                return id;
            }
        }

        // Get Name
        public string GetName()
        {
            return name;
        }

        // Get Description
        public string GetDescription()
        {
            return description;
        }

        // Get Sprite
        public Sprite GetSprite()
        {
            return sprite;
        }

        // Get Item Type
        public ItemType GetItemType()
        {
            return itemType;
        }

        // Register Item Meta
        public static bool Register(ItemMeta itemMeta)
        {
            if (itemMeta == null)
            {
                return false;
            }
            int id = itemMeta.id;

            if (GetItemMeta(id) == null)
            {
                itemMetas.Add(itemMeta);
                return true;
            }
            return false;
        }

        // Unregister Item Meta
        public static bool Unregister(ItemMeta itemMeta)
        {
            if (itemMeta == null)
            {
                return false;
            }

            if (itemMetas.Contains(itemMeta))
            {
                return itemMetas.Remove(itemMeta);
            }
            int id = itemMeta.id;

            if (GetItemMeta(id) != null)
            {
                return itemMetas.Remove(itemMeta);
            }
            return false;
        }

        // Get Item Meta by Id
        public static ItemMeta GetItemMeta(int id)
        {
            foreach (ItemMeta itemMeta in ItemMeta.itemMetas)
            {
                if (itemMeta.id == id)
                {
                    return itemMeta;
                }
            }
            return null;
        }

        // Get Item Metas as List
        public static List<ItemMeta> GetItemMetas()
        {
            return ItemMeta.itemMetas;
        }

        // Equals
        public bool Equals(ItemMeta itemMeta)
        {
            return itemMeta != null && itemMeta.Id.Equals(id);
        }
    }
}