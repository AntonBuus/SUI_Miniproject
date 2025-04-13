using UnityEngine;
using SystemCollections.Generic;
using System.Collections;
using TMPro;

public class ScanPaper : MonoBehaviour
{
    bool isScanned = false;
    bool readyToScan = false;
    public GameObject scanEffectPrefab;
    public GameObject pendingToBeSaved;
    public GameObject confirmScanMenu;
    public TMPtext statusText = "Scan Paper";
    

    private void OnTriggerEnter(Collider other) 
    {
        if (readyToScan && other.CompareTag("PaperToScan"))
        {
            readyToScan = false;
            GameObject scanEffect = Instantiate(scanEffectPrefab, transform.position, Quaternion.identity);
            Destroy(scanEffect, 2f); // Destroy the effect after 2 seconds
            Debug.Log("Paper scanned!");
            pendingToBeSaved = other.GameObject;
            confirmScanMenu.SetActive(true);
        }
    }
    
    public void CopyPaper()
    {
        if (pendingToBeSaved != null)
        {
            // Logic to save the scanned paper
            Debug.Log("Paper saved!");
            Destroy(pendingToBeSaved);
            pendingToBeSaved = null;
        }
        else
        {
            Debug.Log("No paper to save!");

        }
        confirmScanMenu.SetActive(false);
    }
    
}
