using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Hands.Samples.Gestures.DebugTools;

public class DetectCurlAndSelect : MonoBehaviour
{
    public XRFingerShapeDebugBar _thumb_FSB;
    public XRFingerShapeDebugBar _index_FSB;
    public XRFingerShapeDebugBar _middle_FSB;
    public XRFingerShapeDebugBar _ring_FSB;
    public XRFingerShapeDebugBar _pinky_FSB;

    public InputActionProperty _deselectItem;
    public GameObject figdetCube;
    public GameObject figdetShell;
    public float _shellMultiplier = 0.5f;
    public GameObject _placeholderObject;
    public Collider _triggerCollider;
    
    
    [Header("Multipliers")]
    [Range(0.1f, 0.6f)] public float _scaleMultiplier = 0.3f;
    [Range(0f, 360f)] public float _rotationMultiplier;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FidgetCube"))
        {
            Debug.Log("potential object here");
            // Perform actions when the hand enters the trigger area
            figdetCube = other.gameObject;
            figdetShell = figdetCube.gameObject.transform.GetChild(0).gameObject;
            _triggerCollider.enabled = false;
            PlayFromAudiomanager();
            
        }
        // Debug.Log("something here");
    }
    void Update()
    {
        if(_deselectItem.action.WasPressedThisFrame() && figdetCube != _placeholderObject)
        {
            figdetCube = _placeholderObject;
            figdetShell = figdetCube.gameObject.transform.GetChild(0).gameObject;
            _triggerCollider.enabled = true;
            
            Debug.Log("deselecting object: ");
        }
        if (figdetCube != _placeholderObject)
        {
            ScaleObject();
            ScaleShell();
        }
        
    }
    private void ScaleShell()
    {
        float posVal = _ring_FSB.valueBar.localScale.x;
        float invertedPosValue = 1 - posVal;
        float constrainedScale = invertedPosValue * _shellMultiplier;
        // float clampedScale = Mathf.Clamp(constrainedScale, 0.1f, 0.2f);
        figdetShell.transform.localScale = new Vector3(1f + constrainedScale, 1f + constrainedScale, 1f + constrainedScale);
    }
    void ScaleObject()
    {
        float invertedIndexValue = 1 - _index_FSB.valueBar.localScale.x;
        figdetCube.transform.localScale = new Vector3(invertedIndexValue*_scaleMultiplier, 
        invertedIndexValue*_scaleMultiplier, invertedIndexValue*_scaleMultiplier);

        // figdetCube.transform.localScale = new Vector3(_index_FSB.valueBar.localScale.x*_scaleMultiplier, _index_FSB.valueBar.localScale.x*_scaleMultiplier, _index_FSB.valueBar.localScale.x*_scaleMultiplier);
        
        // figdetCube.transform.rotation = new Quaternion(0f, _thumb_FSB.valueBar.localScale.x*_rotationMultiplier, 0f, _thumb_FSB.valueBar.localScale.x*_rotationMultiplier);
        figdetCube.transform.rotation = Quaternion.Euler(0f, _thumb_FSB.valueBar.localScale.x 
        * _rotationMultiplier, 0f);
    }
    
    //setup for using audio manager if available
    public UnityEngine.Events.UnityEvent onInvoke;
    private void PlayFromAudiomanager()
    {
        if (onInvoke != null)
        {
            onInvoke.Invoke();
        }
    }
}
