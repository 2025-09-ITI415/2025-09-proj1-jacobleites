    using UnityEngine;

public class BigAsteroidSeperate : MonoBehaviour
{


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
 
    }
    // Upon click, turn big asteroid into two
    private void OnCollisionEnter(Collision collision){

        if (collision.gameObject.CompareTag("Player"))
        {
            // Store original properties
            Vector3 originalPosition = transform.position;
            Vector3 originalScale = transform.localScale;

            // Create new game object
            GameObject newBlock = Instantiate(gameObject, originalPosition, transform.rotation = Quaternion.identity);

            // Halve scale of asteroid on the x-axis
            // Split x-axis in half
            Vector3 splitScale = new Vector3(originalScale.x / 2f, originalScale.y / 2f, originalScale.z / 2f);

            // Turn the normal scale into 'splitScale'
            transform.localScale = splitScale;
            newBlock.transform.localScale = splitScale;

            float offset = (originalScale.x / 4f) + 5;
            transform.position -= transform.right * offset;
            newBlock.transform.position += transform.right * offset;


            Destroy(newBlock.GetComponent<BigAsteroidSeperate>()); // Destroy script on the clone
            Destroy(this); // Destroy script on the original
            }
        }
    // Update is called once per frame
    void Update()
    {
        
    }
}
