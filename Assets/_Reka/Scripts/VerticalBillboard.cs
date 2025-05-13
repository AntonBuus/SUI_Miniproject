using UnityEngine;

public class VerticalBillboard : MonoBehaviour
{
    public Transform target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(target == null)
        target = Camera.main.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
    }
}
