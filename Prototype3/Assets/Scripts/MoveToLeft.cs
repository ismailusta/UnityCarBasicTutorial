using UnityEngine;

public class MoveToLeft : MonoBehaviour
{
    private float speed = 30f;
    private float leftBound = -15f; // Left boundary for the object
    private PlayerController playerControllerScript; // Reference to the PlayerController script
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.isGameOver == false)
        {
            Move();
        }
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject); // Destroy the object if it goes beyond the left boundary
        }
    }
    void Move()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
