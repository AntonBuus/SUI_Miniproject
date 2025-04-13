using UnityEngine;
using TMPro;

public class TooltipTextUpdater : MonoBehaviour
{
    public Camera mainCamera; // Usually your XR or main camera
    public float maxDistance = 5f;
    public TMP_Text textElement;

    void Start()
    {
        if(mainCamera == null)
        mainCamera = Camera.main;
    }
    void Update()
    {
        Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            // Option 1: Use the object's tag
            if (!string.IsNullOrEmpty(hit.collider.tag) && hit.collider.tag != "Untagged")
            {
                textElement.text = hit.collider.tag;
            }
            // Option 2: Use the object's name
            else
            {
                textElement.text = hit.collider.gameObject.name;
            }
        }
        else
        {
            textElement.text = ""; // Clear when not looking at anything
        }
    }
}
