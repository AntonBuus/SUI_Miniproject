using UnityEngine;

public class PositionAbove : MonoBehaviour
{
    public GameObject anchorPoint;

    [Range(0.1f, 0.6f)]
    public float heightOffset = 0.3f;

    public float _maxHeight = 0.2f;
    public float _minHeight = 0.05f;
    DetectCurl _DC;

    void Start()
    {
        _DC = GetComponent<DetectCurl>();
    }
    void Update()
    {
        float posVal = _DC._middle_FSB.valueBar.localScale.x;
        float invertedPosValue = 1 - posVal;
        float constrainedHeight = invertedPosValue*_maxHeight;
        float constrainedValue = Mathf.Clamp(constrainedHeight, _minHeight, _maxHeight);
        this.transform.position = new Vector3(anchorPoint.transform.position.x, anchorPoint.transform.position.y + constrainedValue, anchorPoint.transform.position.z);

        // this.transform.position = new Vector3(anchorPoint.transform.position.x, anchorPoint.transform.position.y + heightOffset, anchorPoint.transform.position.z);
    }
}
