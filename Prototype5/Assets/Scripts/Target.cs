using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * Random.Range(12, 16), ForceMode.Impulse);
        Vector3 randomTorque = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10));
        rb.AddTorque(randomTorque, ForceMode.Impulse);
        transform.position = new Vector3(Random.Range(-4, 4), -6);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
