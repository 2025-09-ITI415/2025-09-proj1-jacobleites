using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("Shooting")]
    public GameObject bulletPrefab; // The bullet object to be fired
    public Transform firePoint;     // The point from where the bullet is fired
    public float bulletForce = 20f; // The force applied to the bullet

    void Update()
    {
        // Check if the "Fire1" button (Left Mouse Button or Ctrl) is pressed
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // 1. Create a new bullet instance at the firePoint's position and rotation
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // 2. Get the Rigidbody component from the instantiated bullet
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        // 3. Apply a force to the bullet in the direction the firePoint is facing
        rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
    }
}
