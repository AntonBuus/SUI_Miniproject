using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class PositionAboveAndSelect : MonoBehaviour
{
    public GameObject anchorPoint;
    [Header("Height")]
    // [Range(0.1f, 0.6f)]
    public float heightOffset = 0.15f;

    public float _maxHeight = 0.3f;
    public float _minHeight = 0.05f;
    DetectCurlAndSelect _DC;

    [Header("Position")]
    public GameObject _handCenter;
    public float _positionMultiplierX = 0.009f;
    public float _positionMultiplierZ = 0.0025f;
    public float _maxRotationX = 80f;
    public float _maxRotationZ = 80f;
    // HandCenter _HC;
    void Start()
    {
        _DC = GetComponent<DetectCurlAndSelect>();
        // _HC = GetComponent<HandCenter>();
    }
    void Update()
    {
        // ControlHeight();
        // ControlPosition();
        ControlBoth();
    }
    private void ControlBoth()
    {
        //Height calculation
        float posVal = _DC._middle_FSB.valueBar.localScale.x;
        float invertedPosValue = 1 - posVal;
        float constrainedHeight = invertedPosValue*_maxHeight; 
        float constrainedValue = Mathf.Clamp(constrainedHeight, _minHeight, _maxHeight);

        //Position calculation
        Vector3 _handCenterRotation = _handCenter.transform.rotation.normalized.eulerAngles;

        float clamped_handCenterRotationX = Mathf.Clamp(_handCenterRotation.x, -_maxRotationX, _maxRotationX);
        float clamped_handCenterRotationZ = Mathf.Clamp(_handCenterRotation.z, -_maxRotationX, _maxRotationZ);

        if (clamped_handCenterRotationX == _maxRotationX || clamped_handCenterRotationX == -_maxRotationX)
        {
            clamped_handCenterRotationX = 0f;
        }
        if (clamped_handCenterRotationZ == _maxRotationZ || clamped_handCenterRotationZ == -_maxRotationZ)
        {
            clamped_handCenterRotationZ = 0f;
        }

        // Combine height and position calculations on the same frame       
        _DC.figdetCube.transform.position = new Vector3(
        anchorPoint.transform.position.x - _positionMultiplierZ*clamped_handCenterRotationZ, //positionX
        anchorPoint.transform.position.y + constrainedValue, //heightOffset
        anchorPoint.transform.position.z + _positionMultiplierX*clamped_handCenterRotationX); //positionZ


    }
    private void ControlHeight()
    {
        float posVal = _DC._middle_FSB.valueBar.localScale.x;
        float invertedPosValue = 1 - posVal;
        float constrainedHeight = invertedPosValue*_maxHeight;
        float constrainedValue = Mathf.Clamp(constrainedHeight, _minHeight, _maxHeight);
        this.transform.position = new Vector3(anchorPoint.transform.position.x, anchorPoint.transform.position.y + constrainedValue, anchorPoint.transform.position.z);


        // this.transform.position = new Vector3(anchorPoint.transform.position.x, anchorPoint.transform.position.y + heightOffset, anchorPoint.transform.position.z);
    }

    private void ControlPosition()
    {
        Vector3 _handCenterRotation = _handCenter.transform.rotation.normalized.eulerAngles;

        float clamped_handCenterRotationX = Mathf.Clamp(_handCenterRotation.x, -50f, 50f);
        float clamped_handCenterRotationZ = Mathf.Clamp(_handCenterRotation.z, -50f, 50f);

        // Debug.Log("Clamped _handCenterRotation X: " + clamped_handCenterRotationX + ", Clamped _handCenterRotation Z: " + clamped_handCenterRotationZ);
        this.transform.position = new Vector3(
        anchorPoint.transform.position.x + _positionMultiplierX*clamped_handCenterRotationX, 
        anchorPoint.transform.position.y, //heightOffset
        anchorPoint.transform.position.z + _positionMultiplierZ*clamped_handCenterRotationZ);
    }
}
