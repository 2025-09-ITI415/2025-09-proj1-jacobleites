using UnityEngine;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered has the "Player" tag
        if (other.CompareTag("Projectile"))
        {
            // Find the PlayerController script on the player and call its public IncrementScore function
            other.GetComponent<PlayerController>().IncrementScore();
            // Now, destroy this collectible object
            Destroy(gameObject);
        }
    }
}