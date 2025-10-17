using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public int health = 3;
    public GameObject starPrefab; // Drag your Star prefab here in the Inspector

    // This function is called when another collider hits this one
    void OnCollisionEnter(Collision collision)
    {
        // Check if the object that hit it was the bullet
        if (collision.gameObject.GetComponent<Bullet>() != null)
        {
            health--; // Reduce health
            if (health <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        // Create the star at the asteroid's current position
        Instantiate(starPrefab, transform.position, Quaternion.identity);
        
        // Destroy the asteroid
        Destroy(gameObject);
    }
}