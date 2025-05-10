using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float speed = 10f;
    public float range;
    public GameObject pizzaPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(pizzaPrefab, transform.position, pizzaPrefab.transform.rotation);
        }
        if (transform.position.x < -range)
        {
            transform.position = new Vector3(-range, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > range)
        {
            transform.position = new Vector3(range, transform.position.y, transform.position.z);
        }
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
    }
}
