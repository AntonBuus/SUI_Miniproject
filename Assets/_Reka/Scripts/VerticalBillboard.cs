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

    void Update()
    {
        if (target == null) return;

        // Only rotate around the Y-axis (vertical) for readability
        Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, target.position.z);
        transform.LookAt(targetPosition);
    }
}
