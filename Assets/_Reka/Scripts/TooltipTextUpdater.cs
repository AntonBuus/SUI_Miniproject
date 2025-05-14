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

    // I made it so we can define what text should be shown: manual, tag, or name.
    public enum TooltipMode { ManualText, UseTag, UseName }
    public TooltipMode tooltipMode = TooltipMode.ManualText;

    // This is used to set the tooltip text based on the selected mode
    private void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;

        if (canvas == null)
            canvas = GetComponentInChildren<Canvas>();

        UpdateTooltipText(); // Set initial text
        SetVisible(false);   // Start hidden
    }

    // Turns the tooltip on/off visually
    public void SetVisible(bool isVisible)
    {
        if (gameObject != null)
            gameObject.SetActive(isVisible);
    }

    // Updates the text based on selected mode
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


    public void Refresh()
    {
        UpdateTooltipText();
    }
}
