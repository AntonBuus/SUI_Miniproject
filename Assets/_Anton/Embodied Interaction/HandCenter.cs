using JetBrains.Annotations;
using UnityEngine;

public class HandCenter : MonoBehaviour
{
    // Was used to debug what degrees was optimal to use from the hancenter
    public GameObject _handCenter;

    void Update()
    {
        Vector3 _handCenterRotation = _handCenter.transform.rotation.normalized.eulerAngles;

           
        float clamped_handCenterRotationX = Mathf.Clamp(_handCenterRotation.x, -50f, 50f);
        float clamped_handCenterRotationZ = Mathf.Clamp(_handCenterRotation.z, -50f, 50f);


        Debug.Log("Clamped _handCenterRotation X: " + clamped_handCenterRotationX + ", Clamped _handCenterRotation Z: " + clamped_handCenterRotationZ);
    }

}
