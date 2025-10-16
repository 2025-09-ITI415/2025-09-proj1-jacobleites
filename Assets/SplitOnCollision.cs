using UnityEngine;

public class SplitOnCollision : MonoBehaviour
{
    [Header("Shrink Settings")]
    [Tooltip("The tag of the object that causes this to shrink (e.g., a projectile).")]
    public string triggerTag = "Projectile";
    [Tooltip("How small the cube becomes (e.g., 0.5 is half size).")]
    public float sizeMultiplier = 0.5f;
    [Tooltip("The material the cube changes to after shrinking.")]
    public Material collectibleMaterial;

    // A private variable to track the cube's state
    private bool isCollectible = false;

    // STAGE 1: Shrink when hit by a projectile
    private void OnCollisionEnter(Collision collision)
    {
        // Check if this cube hasn't been shrunk yet AND if it was hit by a projectile
        if (!isCollectible && collision.gameObject.CompareTag(triggerTag))
        {
            // 1. Shrink the cube
            transform.localScale *= sizeMultiplier;

            // 2. Change its material
            if (collectibleMaterial != null)
            {
                GetComponent<Renderer>().material = collectibleMaterial;
            }

            // 3. Turn its collider into a trigger so the player can collect it
            GetComponent<Collider>().isTrigger = true;
            
            // 4. Update its state so this can't happen again
            isCollectible = true;
        }
    }

    // STAGE 2: Get collected when touched by the player
    private void OnTriggerEnter(Collider other)
    {
        // Check if this cube is in its collectible state AND if it was touched by the Player
        if (isCollectible && other.CompareTag("Projectile"))
        {
            // Find the PlayerController and tell it to add a point
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.IncrementScore();
            }

            // Destroy this cube
            Destroy(gameObject);
        }
    }
}