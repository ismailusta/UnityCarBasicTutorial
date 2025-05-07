using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private float speed = 20f; // Speed of the player movement
    private float rotationSpeed = 45f; // Speed of the player rotation
    private float horizontalInput; // Input value for horizontal movement
    private float verticalInput; // Input value for vertical movement
    private Transform transformPlayer; // Reference to the Transform component

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transformPlayer = gameObject.transform; // Get the Transform component of the GameObject
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal"); // Get horizontal input (A/D or Left/Right arrow keys)
        verticalInput = Input.GetAxis("Vertical"); // Get vertical input (W/S or Up/Down arrow keys)
        transformPlayer.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime); // Move the player forward at a constant speed
        transformPlayer.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);// Rotate the player based on horizontal input
    }
}
