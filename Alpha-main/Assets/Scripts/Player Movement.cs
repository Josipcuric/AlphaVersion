using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody; // Reference to the player's Rigidbody component
    private bool canJump = true; // Boolean variable to track jump ability
    public float jumpForce = 10f; // Force applied for jumping
    public float movementSpeed = 5f; // Speed at which the player moves
    public Transform respawnPoint; // Respawn point for the player

    void Start()
    {
        // Get the Rigidbody component of the player
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Check for player position constraints
        if (transform.position.y < 0f) // If player falls below the ground
        {
            // Reset the player's position to the respawn point
            transform.position = respawnPoint.position;
        }

        // Player movement based on arrow keys (left/right/up/down)
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * movementSpeed * Time.deltaTime;
        transform.Translate(movement);

        // Check if the player can jump and the jump key (e.g., Space) is pressed
        if (canJump && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void Jump()
    {
        // Apply an upward force for jumping
        playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        // Disable jumping and start coroutine to reset jump ability after delay
        canJump = false;
        StartCoroutine(ResetJump());
    }

    System.Collections.IEnumerator ResetJump()
    {
        // Wait for 1 second before allowing another jump
        yield return new WaitForSeconds(1f);

        // Enable jumping again
        canJump = true;
    }
}
