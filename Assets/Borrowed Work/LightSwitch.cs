using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LightSwitch : MonoBehaviour
{
    public GameObject _targetLight; // Reference to the GameObject you want to toggle

    public void LightToggle()
    {
        if (_targetLight != null)
        {
            _targetLight.SetActive(!_targetLight.activeSelf);
        }    
    }
}

