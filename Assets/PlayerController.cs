using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public CharacterController controller; // Assign the Character Controller component here
    public float speed = 12f;
    public float gravity = -9.81f;

    private Vector3 velocity;

    void Update()
    {
        // Get keyboard input
        float x = Input.GetAxis("Horizontal"); // A/D keys
        float z = Input.GetAxis("Vertical");   // W/S keys

        // Create a direction vector based on the player's local orientation
        Vector3 move = transform.right * x + transform.forward * z;

        // Move the player
        controller.Move(move * speed * Time.deltaTime);

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}