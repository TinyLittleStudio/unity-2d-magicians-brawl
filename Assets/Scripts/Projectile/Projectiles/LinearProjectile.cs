using UnityEngine;

namespace MagiciansBrawl.MBProjectile
{
    public class LinearProjectile : Projectile
    {
        [Header("Linear Projectile Settings")]
        // Explosion Effect On Collide
        public GameObject explosion;


        // Update
        public override void OnUpdate()
        {

        }

        // Collision
        public override void OnCollision(Collider2D collider2d)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);

            // Destroy On Collision
            Destroy(gameObject);
        }
    }
}
