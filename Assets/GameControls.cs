using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;  // Speed of movement
    public float jumpForce = 10f;  // Force applied when jumping
    public GameObject bulletPrefab;  // Bullet prefab
    public Transform bulletSpawn;  // The position from which bullets are fired
    public float bulletSpeed = 20f;  // Speed of the bullet

    private Rigidbody2D rb;  // Reference to the Rigidbody2D
    private bool isGrounded = false;  // Whether the player is on the ground
    private bool facingRight = true;  // Track the current facing direction

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Get the Rigidbody2D component attached to the player
    }

    void Update()
    {
        // Handle left/right movement
        float moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        // Flip the character sprite if moving in the opposite direction
        if (moveX > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveX < 0 && facingRight)
        {
            Flip();
        }

        // Handle jumping when grounded
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        // Fire bullets when the right control key is pressed
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            FireBullet();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;  // Toggle the facing direction
        Vector3 scale = transform.localScale;
        scale.x *= -1;  // Flip the X axis
        transform.localScale = scale;
    }

    void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.velocity = new Vector2((facingRight ? 1 : -1) * bulletSpeed, 0);
        Destroy(bullet, 2); // Destroy the bullet after 2 seconds to clean up
    }

    // Detect ground collisions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;  // The player is grounded
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;  // The player is no longer grounded
        }
    }
}
