using UnityEngine;
using UnityEngine.UI; // <-- Make sure this is added!

public class PlayerController : MonoBehaviour {

    // Movement Variables
    public float speed;
    public float jumpForce = 8f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    
    // --- NEW UI AND SCORE VARIABLES ---
    public Text countText;
    public Text winText;
    private int count;

    // Private variables
    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // --- NEW ---
        // Initialize the score and UI when the game starts
        count = 0;
        SetCountText();
        winText.text = "";
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }
    
    // --- NEW HELPER FUNCTIONS ---

    // This public function can be called from other scripts (like our collectible)
    public void IncrementScore()
    {

            count = count + 1;
            SetCountText();   

    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12) 
        {
            winText.text = "You Win!";
        }
    }
}