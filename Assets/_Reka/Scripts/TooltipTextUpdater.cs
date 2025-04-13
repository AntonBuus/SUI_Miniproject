// using UnityEngine;
// using TMPro;

// public class TooltipTextUpdater : MonoBehaviour
// {
//     public Camera mainCamera;
//     public float maxDistance = 5f;
//     public TMP_Text textElement;

//     void Start()
//     {
//         if(mainCamera == null)
//         mainCamera = Camera.main;
//     }
//     void Update()
//     {
//         Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
//         RaycastHit hit;

//         if (Physics.Raycast(ray, out hit, maxDistance))
//         {
//             // Only show tooltip if this is the object being looked at
//             if (hit.collider.gameObject == gameObject)
//             {
//                 textElement.text = gameObject.name;  // or .tag if using tags
//             }
//             else
//             {
//                 textElement.text = "";  // Hide this tooltip
//             }
//         }
//         else
//         {
//             textElement.text = ""; // Nothing is being looked at
//         }
//     }
// }

using UnityEngine;
using TMPro;

public class TooltipTextUpdater : MonoBehaviour
{
    public Camera mainCamera;
    public float maxDistance = 5f;

    public Canvas canvas;
    public TMP_Text textElement;
    public GameObject targetObject;
    public string tooltipText = "Default Tooltip";

    public enum TooltipMode { ManualText, UseTag, UseName }
    public TooltipMode tooltipMode = TooltipMode.ManualText;

    private void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;

        if (canvas == null)
            canvas = GetComponentInChildren<Canvas>();

        UpdateTooltipText(); // Set initial text
        SetVisible(false);   // Start hidden
    }

    public void SetVisible(bool isVisible)
    {
        if (gameObject != null)
            gameObject.SetActive(isVisible);
    }

    private void UpdateTooltipText()
    {
        if (textElement == null || targetObject == null)
            return;

        switch (tooltipMode)
        {
            case TooltipMode.UseTag:
                textElement.text = targetObject.tag;
                break;
            case TooltipMode.UseName:
                textElement.text = targetObject.name;
                break;
            case TooltipMode.ManualText:
            default:
                textElement.text = tooltipText;
                break;
        }
    }

    // Optional: Call this again if you change tooltipMode at runtime
    public void Refresh()
    {
        UpdateTooltipText();
    }
}
