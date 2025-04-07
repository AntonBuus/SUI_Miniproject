using System;
using UnityEngine;
using UnityEngine.XR.Hands.Samples.Gestures.DebugTools;

public class DetectCurlAndSelect : MonoBehaviour
{
    public XRFingerShapeDebugBar _thumb_FSB;
    public XRFingerShapeDebugBar _index_FSB;
    public XRFingerShapeDebugBar _middle_FSB;
    public XRFingerShapeDebugBar _ring_FSB;
    public XRFingerShapeDebugBar _pinky_FSB;

    public GameObject figdetCube;

    [Header("Multipliers")]
    [Range(0.1f, 0.6f)] public float _scaleMultiplier = 0.3f;
    [Range(0f, 360f)] public float _rotationMultiplier;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FidgetCube"))
        {
            Debug.Log("Hand detected!");
            // Perform actions when the hand enters the trigger area
        }
    }
    void Update()
    {
        float invertedIndexValue = 1 - _index_FSB.valueBar.localScale.x;
        figdetCube.transform.localScale = new Vector3(invertedIndexValue*_scaleMultiplier, invertedIndexValue*_scaleMultiplier, invertedIndexValue*_scaleMultiplier);

        // figdetCube.transform.localScale = new Vector3(_index_FSB.valueBar.localScale.x*_scaleMultiplier, _index_FSB.valueBar.localScale.x*_scaleMultiplier, _index_FSB.valueBar.localScale.x*_scaleMultiplier);
        
        // figdetCube.transform.rotation = new Quaternion(0f, _thumb_FSB.valueBar.localScale.x*_rotationMultiplier, 0f, _thumb_FSB.valueBar.localScale.x*_rotationMultiplier);
        figdetCube.transform.rotation = Quaternion.Euler(0f, _thumb_FSB.valueBar.localScale.x * _rotationMultiplier, 0f);
    }
}
