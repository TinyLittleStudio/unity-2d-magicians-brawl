using System.Collections.Generic;
using UnityEngine;
using MagiciansBrawl.MBUtils;

namespace MagiciansBrawl.MBProjectile
{
    [RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
    public abstract class Projectile : MonoBehaviour
    {
        // List of Collidable Objects (Tags)
        private static readonly List<string> COLLIDE = new List<string>() {

            Settings.Tags.OBSTACLE,

            Settings.Tags.ENEMY,
        };

        // Projectiel Unique Key
        [Header("Projectile Settings")]
        [SerializeField]
        private string key;

        // Velocity
        [SerializeField]
        private float velocity = 1.0f;

        // LifeTime
        [SerializeField]
        private float time = 30.0f;

        // Rigidbody2D
        private Rigidbody2D rigidbody2d;

        // CircleCollider2D
        private CircleCollider2D circleCollider2d;

        // Awake
        private void Awake()
        {
            // Get the Rigidbody2D
            this.rigidbody2d = GetComponent<Rigidbody2D>();
            rigidbody2d.gravityScale = 0.0f;

            // Get the CircleCollider2D
            this.circleCollider2d = GetComponent<CircleCollider2D>();
            circleCollider2d.isTrigger = true;
        }

        // Update
        private void Update()
        {
            time -= Time.deltaTime;

            if (time <= 0)
            {
                Destroy(gameObject);
            }
            OnUpdate();
        }

        // On Trigger Enter 2D
        private void OnTriggerEnter2D(Collider2D collider2d)
        {
            // Call Only Valid Collisions
            string tag = collider2d.gameObject.tag;

            if (Projectile.COLLIDE.Contains(tag))
            {
                OnCollision(collider2d);
            }
        }

        // Abstract Update Method
        public abstract void OnUpdate();

        // Abstract Collide Method
        public abstract void OnCollision(Collider2D collider2d);

        // Sets Velocity of Projectile
        public void Towards(Vector2 direction)
        {
            rigidbody2d.AddForce(direction * velocity);
        }

        // Returns the Key
        public string Key
        {
            get
            {
                return key;
            }
        }
    }
}