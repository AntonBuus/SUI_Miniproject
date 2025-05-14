using UnityEngine;

// The tooltip setup visually connects the object (e.g., a stove or book) to its floating tooltip panel
// The script is attached to the line object and updates its position based on the two points (pointA and pointB) it connects.
[ExecuteInEditMode]
public class TwoPointsLine : MonoBehaviour
{
    // The two points between which the line will be drawn
    // These can be set in the inspector or assigned dynamically
    public Transform pointA;
    public Transform pointB;

    // The LineRenderer component is used to draw the line between the two points
    private LineRenderer line;

    void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    void Update()
    {
        line.positionCount = 2;
        line.SetPosition(0, pointA.position);
        line.SetPosition(1, pointB.position);
    }
}
