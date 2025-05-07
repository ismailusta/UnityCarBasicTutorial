using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform player; // Reference to the player's transform
    private Vector3 offset; // Offset distance between the camera and the player

    void Start()
    {
        offset = transform.position - player.position;
    }
    // Update is called once per frame
    void LateUpdate()
    {// Check if the player transform is assigned
        if (player != null)
        {
            transform.position = player.position + offset; // Update the camera position based on the player's position and the offset
        }
    }
}
