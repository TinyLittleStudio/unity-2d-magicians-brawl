using UnityEngine;

namespace MagiciansBrawl.MBPlayer
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {
        // Bug: Camera and Player Movement Not Working Together

        // Smoothness Value for Camera Movement
        [Header("Camera Controller Settings")]
        public float smoothness = 0.2f;

        // Camera Offset Distance
        [Space(10)]
        public float distance = 3.5f;

        // Camera Offset to Target Player
        [Space(10)]
        public Vector3 offset = new Vector3(0, 0, 1);

        // Player Movement Velocity
        [Header("Player Controller Settings")]
        public float velocity = 10.0f;

        // Player Ridigbody2D
        private Rigidbody2D rigidbody2d;

        // Player Delta Movement
        private Vector2 movement;

        // Reference Camera Velocity
        private Vector3 reference;

        // Start
        private void Start()
        {
            // Get Rigidbody2D
            if (rigidbody2d == null)
            {
                this.rigidbody2d = GetComponent<Rigidbody2D>();
            }
        }

        // Update
        private void Update()
        {
            // Receive Input
            Vector2 input = new Vector2
            {
                x = Input.GetAxisRaw("Horizontal"),
                y = Input.GetAxisRaw("Vertical")
            };
            movement = input.normalized * velocity;
        }

        // FixedUpdate
        private void FixedUpdate()
        {
            // Move Player
            rigidbody2d.MovePosition(rigidbody2d.position + movement * Time.fixedDeltaTime);

            // Camera Update
            LateFixedUpdate();
        }

        // (Pseudo) Late Fixed Update
        private void LateFixedUpdate()
        {
            // Camera Movement and Smoothing
            Vector3 position = GetMousePosition() + offset;

            Vector3 target = transform.position + position * distance;

            target.z = offset.z;

            Vector3 camera = Vector3.SmoothDamp(Camera.main.transform.position, target, ref reference, smoothness);

            Camera.main.transform.position = camera;
        }

        // Get Mouse Position
        private Vector3 GetMousePosition()
        {
            Vector2 result = Camera.main.ScreenToViewportPoint(Input.mousePosition);

            result *= 2;
            result -= Vector2.one;

            float max = 0.9f;

            if (Mathf.Abs(result.x) > max || Mathf.Abs(result.y) > max)
            {
                result = result.normalized;
            }
            return result;
        }
    }
}