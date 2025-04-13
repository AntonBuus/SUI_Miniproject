using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class TooltipManager : MonoBehaviour
{
    public Camera mainCamera;
    public float maxDistance = 5f;
    private List<TooltipTextUpdater> tooltips;

    void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;

    tooltips = new List<TooltipTextUpdater>(FindObjectsByType<TooltipTextUpdater>(FindObjectsSortMode.None));

    }

    void Update()
    {
        Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
        RaycastHit hit;
        TooltipTextUpdater activeTooltip = null;

        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            Debug.Log("Hit: " + hit.collider.name);
            foreach (var tooltip in tooltips)
            {
                if (hit.collider.gameObject == tooltip.targetObject)
                {
                    activeTooltip = tooltip;
                    break;
                }
            }
        }

        // Update tooltip visibility
        foreach (var tooltip in tooltips)
        {
            tooltip.SetVisible(tooltip == activeTooltip);
        }
    }
}
