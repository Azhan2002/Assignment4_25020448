using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;  // Speed of movement
    public float jumpForce = 10f; // Force applied when jumping
    private Rigidbody2D rb;       // Reference to the Rigidbody2D
    private bool isGrounded = false; // Whether the player is on the ground

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
    }

    void Update()
    {
        // Handle left and right movement
        float moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        // Jump when space is pressed and the player is grounded
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    // Called when the player starts colliding with an object
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player has collided with an object tagged as "Ground"
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // The player is now grounded
        }
    }

    // Called when the player stops colliding with an object
    private void OnCollisionExit2D(Collision2D collision)
    {
        // Check if the player has stopped colliding with the "Ground"
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false; // The player is no longer grounded
        }
    }
}
