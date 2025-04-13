using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class TooltipManager : MonoBehaviour
{
    public Camera mainCamera;
    public float maxDistance = 5f;
    [SerializeField]
    private List<TooltipTextUpdater> tooltips;

    void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;
    
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
            foreach (var tooltip in tooltips)
            {
                Debug.Log("Hit: " + hit.collider.name+ " == " + tooltip.targetObject.name); 
                if (hit.collider.gameObject == tooltip.targetObject)
                {
                    Debug.Log("tooltip: " + hit.collider.gameObject.name);
                    tooltip.gameObject.SetActive(true);
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
