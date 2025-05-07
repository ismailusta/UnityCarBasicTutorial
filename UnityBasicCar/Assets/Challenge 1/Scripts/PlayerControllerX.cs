using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    private float speed = 20f;
    private float rotationSpeed = 45f;
    private float verticalInput;
    private float horizontalInput;
    private float JumpInput;
    private float JumpForce = 10f;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        JumpInput = Input.GetAxis("Jump");
        if (JumpInput == 1)
        {
            rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);

        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);

    }
}
