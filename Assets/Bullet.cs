using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Start()
    {
        // Destroy the bullet after 3 seconds
        Destroy(gameObject, 3f);
    }

    // Destroy the bullet immediately if it hits something
    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}