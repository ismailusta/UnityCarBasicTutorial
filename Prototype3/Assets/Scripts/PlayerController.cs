using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float jumpForce = 10f; // Force applied when the player jumps
    public float gravityModifier;
    public bool isGrounded; // Check if the player is on the ground
    public bool isGameOver; // Check if the game is over
    private Animator playerAnim; // Reference to the Animator component
    public ParticleSystem explosionParticle; // Reference to the explosion particle system
    public ParticleSystem dirtParticle; // Reference to the dirt particle system
    public AudioClip jumpSound; // Reference to the jump sound effect
    public AudioClip crashSound; // Reference to the crash sound effect
    private AudioSource playerAudio;
    private Camera mainCamera; // Reference to the main camera
    private Rigidbody rb; // Reference to the Rigidbody component
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        isGrounded = false; // Set isGrounded to true at the start
        isGameOver = false; // Set isGameOver to false at the start
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        mainCamera = Camera.main; // Get the main camera
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isGameOver)
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        playerAudio.PlayOneShot(jumpSound, 1.0f); // Play the jump sound effect
        isGrounded = false; // Set isGrounded to false after jumping
        playerAnim.SetTrigger("Jump_trig");
        dirtParticle.Stop(); // Stop the dirt particle system

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            isGameOver = true;
            Debug.Log("Game Over");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop(); // Stop the dirt particle system
            playerAudio.PlayOneShot(crashSound, 1.0f);
            mainCamera.GetComponent<AudioSource>().Stop(); // Stop the main camera's audio source
        }
    }
}
