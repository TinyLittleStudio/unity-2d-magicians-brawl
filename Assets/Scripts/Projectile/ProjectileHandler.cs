using System.Collections.Generic;
using UnityEngine;

namespace MagiciansBrawl.MBProjectile
{
    public class ProjectileHandler : MonoBehaviour
    {
        // Projectile Handler Instance
        private static ProjectileHandler instance;

        // All Available Projectiles
        [SerializeField]
        private List<Projectile> projectiles = new List<Projectile>();

        // Constructor
        private ProjectileHandler()
        {

        }

        // Awake
        private void Awake()
        {
            if (ProjectileHandler.instance == null)
            {
                ProjectileHandler.instance = this;
            }
            else
            {
                Destroy(this);
            }

            // Check for Double Entries
            List<Projectile> projectiles = new List<Projectile>();

            foreach (Projectile projectile in this.projectiles)
            {
                bool exists = false;

                foreach (Projectile temp in projectiles)
                {
                    string key = temp.Key;

                    if (projectile.Key.Equals(key))
                    {
                        Debug.LogError(key + " Is Registered Twice");
                        exists = true;
                    }
                }

                if (!exists)
                {
                    projectiles.Add(projectile);
                }
            }

            // Set Filtered Projectile List
            this.projectiles = projectiles;
        }

        // Get Projectile by Key
        public static Projectile GetProjectile(string key)
        {
            if (ProjectileHandler.instance == null)
            {
                return null;
            }

            if (key == null || key.Length == 0)
            {
                return null;
            }

            foreach (Projectile projectile in ProjectileHandler.instance.projectiles)
            {
                if (projectile.Key.Equals(key))
                {
                    return projectile;
                }
            }
            return null;
        }

        // Get All Projectiels
        public static List<Projectile> GetProjectiles()
        {
            if (ProjectileHandler.instance == null)
            {
                return null;
            }
            return ProjectileHandler.instance.projectiles;
        }
    }
}