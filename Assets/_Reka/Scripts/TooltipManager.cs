using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class TooltipManager : MonoBehaviour
{
    public Camera mainCamera;
    public float maxDistance = 5f;
    public float sphereRadius = 0.3f; 

     // List of all tooltips in the scene
    [SerializeField]
    private List<TooltipTextUpdater> tooltips = new();

    void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;

        // Find all TooltipTextUpdater components in the scene and add them to the list
        List<TooltipTextUpdater> tooltips_n = new List<TooltipTextUpdater>(FindObjectsByType<TooltipTextUpdater>(FindObjectsSortMode.None));
        foreach (TooltipTextUpdater tooltipText in tooltips_n)
            tooltips.Add(tooltipText);
    }

    void Update()
    {
        // Check if the main camera is assigned
        Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
        RaycastHit hit;

        TooltipTextUpdater activeTooltip = null;

        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            // Do a sphere cast at the hit point to check for nearby objects.
            Collider[] hits = Physics.OverlapSphere(hit.point, sphereRadius);
            Debug.Log(hits.Length + " hits found " + hits[0].name);

            // Check if any of the nearby objects match the tooltip target active - hide the others.
            foreach (var tooltip in tooltips)
            {
                // Check if the tooltip's target object is within the sphere radius
                foreach (var nearby in hits)
                {
                    // Check if the nearby object is the same as the tooltip's target object
                    // If it is, activate the tooltip and set it as the active tooltip
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

    // Draw a gizmo to visualize the sphere radius in the editor.
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
