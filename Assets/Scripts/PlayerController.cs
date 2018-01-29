using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    // Bug: Camera and Player Movement Not Working Together

    // Smoothness Value for Camera Movement
    [Header("Camera Controller Settings")]
    public float smoothness = 10.0f;

    // Camera Offset to Target
    [Space(10)]
    public Vector3 offset = new Vector3(0, 0, 1);

    // Player Movement Velocity
    [Header("Player Controller Settings")]
    public float velocity = 10.0f;

    // Player Ridigbody2D
    private Rigidbody2D rigidbody2d;

    // Player Delta Movement
    private Vector2 movement;

    // Start
    void Start()
    {
        // Get Rigidbody2D
        if (rigidbody2d == null)
        {
            this.rigidbody2d = GetComponent<Rigidbody2D>();
        }
    }

    // Update
    void Update()
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
    void FixedUpdate()
    {
        // Move Player
        rigidbody2d.MovePosition(rigidbody2d.position + movement * Time.fixedDeltaTime);
    }

    // Late Update
    void LateUpdate()
    {
        // Camera Smoothing
        Vector3 destination = transform.position + offset;

        Vector3 position = Vector3.Lerp(Camera.main.transform.position, destination, smoothness);

        Camera.main.transform.position = position;
    }
}
