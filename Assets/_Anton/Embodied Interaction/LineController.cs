using UnityEngine;

public class LineController : MonoBehaviour
{
    // Made this script initally because i wanted a line to follow the finger tip,
    // thoug it did not lead to a satifying interaction
    LineRenderer _LR;

    [SerializeField] Transform _fingerTip;
    [SerializeField] Transform _lineTarget;

    void Start()
    {
        _LR = GetComponent<LineRenderer>();
        _LR.startWidth = 0.001f;
        _fingerTip = this.transform;
    }
    void Update()
    {
        _LR.SetPosition(0, _fingerTip.position);
        _LR.SetPosition(1, _lineTarget.position);
    }
}
