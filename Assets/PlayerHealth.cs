using UnityEngine;
// You MUST add this line to use the SceneManager
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    // This function is called when the CharacterController hits a collider
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Check if the object we hit has the "Asteroid" tag
        if (hit.gameObject.CompareTag("Asteroid"))
        {
            RestartLevel();
        }
    }

    void RestartLevel()
    {
        // Get the index of the currently active scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        
        // Reload the current scene
        SceneManager.LoadScene(currentSceneIndex);
    }
}