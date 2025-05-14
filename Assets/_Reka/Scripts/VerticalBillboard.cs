using UnityEngine;

// This script creates a line between two points in 3D space using a LineRenderer component.

// Makes the tooltip face the camera vertically
public class VerticalBillboard : MonoBehaviour
{
    public Transform target;

    void Start()
    {
        if(target == null)
        target = Camera.main.gameObject.transform;
    }

    // Rotates the object each frame to face the camera (used for billboard effect)
    // This is done in the Update method to ensure it happens every frame
    // The LookAt method makes the object face the target (camera)
    void Update()
    {
        transform.LookAt(target);
    }
}
