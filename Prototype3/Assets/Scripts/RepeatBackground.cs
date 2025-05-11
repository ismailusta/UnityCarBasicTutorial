using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos; // Initial position of the background
    private float repeatWidth; // Width of the background
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position; // Store the initial position of the background
        repeatWidth = GetComponent<Renderer>().bounds.size.x / 2; // Get the width of the background
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos; // Reset the position of the background to its initial position
        }
    }
}
