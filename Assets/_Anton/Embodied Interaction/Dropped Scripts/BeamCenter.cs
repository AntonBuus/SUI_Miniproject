using UnityEngine;

public class BeamCenter : MonoBehaviour
{
    
    DetectCurl _DC_ring;

    [Header("Multipliers")]
    [Range(0.1f, 0.5f)] public float _scaleMultiplier;
    void Start()
    {
        // _DC_ring = GetComponent<DetectCurl>();
        _DC_ring = GameObject.Find("FidgetCube").GetComponent<DetectCurl>();
    }

    void Update()
    {
        float posVal = _DC_ring._ring_FSB.valueBar.localScale.x;
        float invertedPosValue = 1 - posVal;
        float constrainedScale = invertedPosValue * _scaleMultiplier;
        // float clampedScale = Mathf.Clamp(constrainedScale, 0.1f, 0.2f);
        this.transform.localScale = new Vector3(1f + constrainedScale, 1f + constrainedScale, 1f + constrainedScale);

    }
}
