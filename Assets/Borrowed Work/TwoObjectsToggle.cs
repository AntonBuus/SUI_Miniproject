using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TwoObjectsToggle : MonoBehaviour
{
    public GameObject _object1;
    public GameObject _object2; 

    public void ToggleTwoObjects()
    {
        if (_object1 != null && _object2 != null)
        {
            _object1.SetActive(!_object1.activeSelf);
            _object2.SetActive(!_object2.activeSelf);
        }   
    }
}

