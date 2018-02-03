using UnityEngine;

namespace MagiciansBrawl.MBUtils
{
    public class Lifetime : MonoBehaviour
    {
        [Header("Lifetime Settings")]
        // Lifetime
        public float time;

        // Awake
        private void Awake()
        {
            // Particle System Lifetime
            ParticleSystem particleSystem = GetComponent<ParticleSystem>();

            if (particleSystem != null)
            {
                time = particleSystem.main.duration + particleSystem.main.startLifetime.constant;
            }
        }

        // Update
        private void Update()
        {
            // Check For Time
            time -= Time.deltaTime;

            if (time <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}