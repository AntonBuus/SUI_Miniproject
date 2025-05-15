using UnityEngine;

public class TransformThis : MonoBehaviour
{
    
    public Transform target;

    public float amplifier =5.0f;

    void Update()
    {
        // transform.rotation = target.rotation;
        transform.rotation = Quaternion.Euler(target.position.x*amplifier, target.position.y*amplifier, target.position.z*amplifier);
        transform.localScale = new Vector3(target.rotation.z, target.rotation.z, target.rotation.z);
    }
}