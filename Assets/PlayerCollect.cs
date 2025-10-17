using UnityEngine;
using UnityEngine.UI; // Required for UI elements

public class PlayerCollect : MonoBehaviour
{
    private int score = 0;
    public Text scoreText; // Drag your UI Text object here in the Inspector

    public Text winText;

    void Start()
    {
        winText.text = "";
    }

    // This function is called when the player enters a trigger collider
    void OnTriggerEnter(Collider other)
    {
        // Check if the object we entered has the "Star" tag
        if (other.gameObject.CompareTag("Star"))
        {
            // Destroy the star object
            Destroy(other.gameObject);
            
            // Increase the score
            score++;

            // Update the UI Text
            scoreText.text = "Stars: " + score;
            
            if (score >= 50)
            {
                winText.text = "You Win!!";
            }
        }
    }
}