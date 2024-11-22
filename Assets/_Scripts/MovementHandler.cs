using Unity.VisualScripting;
using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    // Movement variables
    private int moveSpeed;

    // Components
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    // Input
    private Vector2 moveInput;

    void Start()
    {
        // Get components
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        moveSpeed = StatsHandler.Instance.speed;

        rb.freezeRotation = true;
    }

    void Update()
    {
        // Get movement input
        moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

        // Handle animations
        if (animator != null)
        {
            animator.SetFloat("xVelocity", moveInput.x);
            animator.SetFloat("yVelocity", moveInput.y);
            animator.SetFloat("Speed", moveInput.sqrMagnitude);
        }
    }

    void FixedUpdate()
    {
        // Apply movement
        rb.linearVelocity = moveInput * moveSpeed;

        // Flips the sprite for moving left and right 
        if(moveInput.x < 0 && transform.rotation == Quaternion.Euler(0,0,0))
            spriteRenderer.flipX = true;
        else
            spriteRenderer.flipX = false;

        // Optional: Rotate character to face movement direction
        if (moveInput != Vector2.zero)
        {
            float angle = Mathf.Atan2(moveInput.y, moveInput.x) * Mathf.Rad2Deg;
            //transform.rotation = Quaternion.Euler(0, 0, angle - 90); // Adjust the rotation as needed
        }
    }
}
