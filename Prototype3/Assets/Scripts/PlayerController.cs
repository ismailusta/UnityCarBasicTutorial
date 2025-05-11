using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float jumpForce = 10f; // Force applied when the player jumps
    public float gravityModifier;
    public bool isGrounded; // Check if the player is on the ground
    public bool isGameOver; // Check if the game is over
    private Animator playerAnim; // Reference to the Animator component
    private Rigidbody rb; // Reference to the Rigidbody component
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        isGrounded = false; // Set isGrounded to true at the start
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false; // Set isGrounded to false after jumping
        playerAnim.SetTrigger("Jump_trig");
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            isGameOver = true;
            Debug.Log("Game Over");
            // Add game over logic here (e.g., stop the game, show a game over screen)
        }
    }
}
