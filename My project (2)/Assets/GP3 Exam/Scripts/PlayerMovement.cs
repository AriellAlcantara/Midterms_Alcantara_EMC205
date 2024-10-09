using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;  // More descriptive variable name

    public GameManagement gameManager;  // Clearer reference to the GameManagement script

    void Update()
    {
        HandleMovement();
    }

    // Handles player movement based on input
    private void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical) * movementSpeed * Time.deltaTime;
        transform.Translate(movement);
    }

    // Handles collisions with collectable objects
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collectable"))
        {
            CollectOrb(collision);
        }
    }

    // Updates score and deactivates collected orb
    private void CollectOrb(Collision collectable)
    {
        gameManager.scoreBoard.IncreaseScore();
        collectable.gameObject.SetActive(false);
    }
}
