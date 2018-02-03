using UnityEngine;
using MagiciansBrawl.MBUtils;
using System;

namespace MagiciansBrawl.MBInventory
{
    [RequireComponent(typeof(SpriteRenderer), typeof(CircleCollider2D))]
    public abstract class BaseItem : MonoBehaviour, IEquatable<BaseItem>
    {
        // Item Meta Id
        [SerializeField]
        private int id;

        // Item Meta
        private ItemMeta itemMeta;

        // Awake
        private void Awake()
        {
            // Set Sprite
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = itemMeta.GetSprite();
            }
        }

        // On Trigger Enter 2D
        public void OnTriggerEnter2D(Collider2D collision)
        {
            // Player Pick Up
            if (collision.tag.Equals(Settings.Tags.PLAYER))
            {
                OnPickUp();

                // Destroy Item
                Destroy(gameObject);
            }
        }

        // Get Item Meta
        public ItemMeta GetItemMeta()
        {
            return itemMeta ?? (itemMeta = ItemMeta.GetItemMeta(id));
        }

        // Abstract OnPickUp Method
        public abstract void OnPickUp();

        // Equals
        public bool Equals(BaseItem baseItem)
        {
            return baseItem != null && baseItem.itemMeta.Id.Equals(itemMeta.Id);
        }
    }
}