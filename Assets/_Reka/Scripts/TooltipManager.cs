// using UnityEngine;
// using TMPro;
// using System.Collections.Generic;

// public class TooltipManager : MonoBehaviour
// {
//     public Camera mainCamera;
//     public float maxDistance = 5f;
//     [SerializeField]
//     private List<TooltipTextUpdater> tooltips;

//     void Start()
//     {
//         if (mainCamera == null)
//             mainCamera = Camera.main;
    
//     List<TooltipTextUpdater> tooltips_n = new List<TooltipTextUpdater>(FindObjectsByType<TooltipTextUpdater>(FindObjectsSortMode.None));
//     foreach (TooltipTextUpdater tooltipText in tooltips_n)
//         tooltips.Add(tooltipText);

//     }

//     void Update()
//     {
//         Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
//         RaycastHit hit;
//         TooltipTextUpdater activeTooltip = null;

//         if (Physics.Raycast(ray, out hit, maxDistance))
//         {

//             foreach (var tooltip in tooltips)
//             {
//                 Debug.Log("Hit: " + hit.collider.name+ " == " + tooltip.targetObject.name); 
//                 if (hit.collider.gameObject == tooltip.targetObject)
//                 {
//                     Debug.Log("tooltip: " + hit.collider.gameObject.name);
//                     tooltip.gameObject.SetActive(true);
//                     activeTooltip = tooltip;
//                     break;
//                 }
//             }
//         }

//         // Update tooltip visibility
//         foreach (var tooltip in tooltips)
//         {
//             tooltip.SetVisible(tooltip == activeTooltip);
//         }
//     }
// }

using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class TooltipManager : MonoBehaviour
{
    public Camera mainCamera;
    public float maxDistance = 5f;
    public float sphereRadius = 0.3f; // <- tweak this for looseness
    [SerializeField]
    private List<TooltipTextUpdater> tooltips = new();

    void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;

        // Make sure the list is cleared before filling (if using [SerializeField])
        List<TooltipTextUpdater> tooltips_n = new List<TooltipTextUpdater>(FindObjectsByType<TooltipTextUpdater>(FindObjectsSortMode.None));
        foreach (TooltipTextUpdater tooltipText in tooltips_n)
            tooltips.Add(tooltipText);
    }

    void Update()
    {
        Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
        RaycastHit hit;

        TooltipTextUpdater activeTooltip = null;

        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            // Do a sphere cast at the hit point to check for nearby objects
            Collider[] hits = Physics.OverlapSphere(hit.point, sphereRadius);
            Debug.Log(hits.Length + " hits found " + hits[0].name);
            foreach (var tooltip in tooltips)
            {
                foreach (var nearby in hits)
                {
                    if (nearby.gameObject == tooltip.targetObject)
                    {
                        Debug.Log("Tooltip activated for: " + tooltip.targetObject.name);
                        tooltip.gameObject.SetActive(true);
                        activeTooltip = tooltip;
                    }
                }
                if (activeTooltip != null) break;
            }
        }

        // Update tooltip visibility
        foreach (var tooltip in tooltips)
        {
            tooltip.SetVisible(tooltip == activeTooltip);
        }

        
    }

    void OnDrawGizmos()
{
    if (!Application.isPlaying || mainCamera == null) return;

    Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
    if (Physics.Raycast(ray, out RaycastHit hit, maxDistance))
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(hit.point, sphereRadius);
    }
}

}
