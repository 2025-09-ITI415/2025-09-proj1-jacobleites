using UnityEngine;

public class SplitOnCollision : MonoBehaviour
{
    // You can set this tag in the Unity Inspector
    public string triggeringTag = "Projectile";

    [Header("Split Settings")]
    [Tooltip("The new size of each block (e.g., 0.5 is half size).")]
    public float sizeMultiplier = 0.5f;

    [Tooltip("The amount of empty space to create between the two new blocks.")]
    public float separation = 0.2f;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(triggeringTag))
        {
            SplitBlock();
        }
    }

private void SplitBlock()
{
    // Store the original's properties before any changes
    Vector3 originalPosition = transform.position;
    Vector3 originalScale = transform.localScale;

    // Create a perfect clone of this GameObject
    GameObject newBlock = Instantiate(gameObject, originalPosition, transform.rotation);
    
    // Calculate the new scale, keeping the original shape
    Vector3 newScale = originalScale * sizeMultiplier;

    // Apply the new, smaller scale to both blocks
    transform.localScale = newScale;
    newBlock.transform.localScale = newScale;

    // --- MODIFIED SECTION START ---

    // 1. Get the object's right direction
    Vector3 splitDirection = transform.right;

    // 2. Flatten the direction by removing any vertical (Y) movement
    splitDirection.y = 0;

    // 3. Normalize the vector to ensure consistent distance, regardless of original rotation
    splitDirection.Normalize();

    // 4. Calculate how far to move each block from the center
    float moveDistance = (newScale.x / 2f) + (separation / 2f);

    // 5. Apply the new positions using the flattened direction
    transform.position -= splitDirection * moveDistance;
    newBlock.transform.position += splitDirection * moveDistance;
    
    // --- MODIFIED SECTION END ---

    // Destroy the script component on both blocks to prevent them from splitting again
    Destroy(newBlock.GetComponent<SplitOnCollision>());
    Destroy(this);
}
}