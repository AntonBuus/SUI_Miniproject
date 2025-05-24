using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Hands.Samples.Gestures.DebugTools;

public class DetectCurlAndSelect : MonoBehaviour
{
    //references the the finger float values
    public XRFingerShapeDebugBar _thumb_FSB;
    public XRFingerShapeDebugBar _index_FSB;
    public XRFingerShapeDebugBar _middle_FSB;
    public XRFingerShapeDebugBar _ring_FSB;
    public XRFingerShapeDebugBar _pinky_FSB;

    public InputActionProperty _deselectItem; // References the action of the left hand pinch
    public GameObject figdetCube; //the item that will be selected
    public GameObject figdetShell; //first childobject of the selected item
    public float _shellMultiplier = 0.5f;
    public GameObject _placeholderObject; //object assigned to the fidgetCube when nothing is selected
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
        // deselect a chosen object if the user pinches with their left hand
        if(_deselectItem.action.WasPressedThisFrame() && figdetCube != _placeholderObject)
        {
            figdetCube = _placeholderObject;
            figdetShell = figdetCube.gameObject.transform.GetChild(0).gameObject; // resets the shell to the placeholder object
            _triggerCollider.enabled = true;
            
            Debug.Log("deselecting object: ");
        }
        if (figdetCube != _placeholderObject) //scales if object is selected
        {
            ScaleObject();
            ScaleShell();
        }
        
    }
    private void ScaleShell()
    {
        float posVal = _ring_FSB.valueBar.localScale.x; //float value of the ring finger
        float invertedPosValue = 1 - posVal; //inverted value of the ring finger
        float constrainedScale = invertedPosValue * _shellMultiplier; // combining for ease of use
        // +1 one on each axis to prevent the shell from shirinking below the size of the cube
        figdetShell.transform.localScale = new Vector3(1f + constrainedScale, 1f + 
        constrainedScale, 1f + constrainedScale);
    }

    void ScaleObject() //both scales and rotates the target object
    {

        float invertedIndexValue = 1 - _index_FSB.valueBar.localScale.x; //inverted value of the index finger
        //Scales the target object based on finger curl and the scale multiplier which is set in the inspector
        figdetCube.transform.localScale = new Vector3(invertedIndexValue*_scaleMultiplier, 
        invertedIndexValue*_scaleMultiplier, invertedIndexValue*_scaleMultiplier); 
         
        figdetCube.transform.rotation = Quaternion.Euler(0f, _thumb_FSB.valueBar.localScale.x 
        * _rotationMultiplier, 0f); // uses a euler angle to rotate the object around the y axis
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
