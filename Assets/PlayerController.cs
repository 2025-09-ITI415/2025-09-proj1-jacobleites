using UnityEngine;

public class PlayerController : MonoBehaviour {

    //public player speed
    public float speed;
    
    // --- NEW JUMP VARIABLES ---
    public float jumpForce = 8f;
    public Transform groundCheck; // A point at the player's feet
    public float groundDistance = 0.4f; // Radius of the ground check sphere
    public LayerMask groundMask; // A mask to determine what is ground

    //private player rigidbody
    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Use Update for input checks
    void Update()
    {
        // Ground Check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // Check for jump input
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Apply an immediate upward force
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        // Horizontal and Vertical variables for movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Vector3 to update movement (X & Z only)
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Multiply by 'speed'
        rb.AddForce(movement * speed);
    }
}