using UnityEngine;

public class PlayerController : MonoBehaviour {

    //public player speed
    public float speed;

    //private player rigidbody
    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
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
