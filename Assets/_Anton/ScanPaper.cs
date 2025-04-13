using UnityEngine;
using TMPro;

public class ScanPaper : MonoBehaviour
{
    bool isScanned = false;
    bool readyToScan = true;
    public GameObject scanEffectPrefab;
    public GameObject pendingToBeSaved;
    public GameObject confirmScanMenu;
    public TMP_Text statusText;
    

    private void OnTriggerEnter(Collider other) 
    {
        if (readyToScan && other.CompareTag("Paper"))
        {
            readyToScan = false;
            GameObject scanEffect = Instantiate(scanEffectPrefab, transform.position, Quaternion.identity);
            Destroy(scanEffect, 2f); // Destroy the effect after 2 seconds
            Debug.Log("Paper scanned!");
            pendingToBeSaved = other.gameObject;
            confirmScanMenu.SetActive(true);
        }
        Debug.Log("Hallo");
    }
    
    public void CopyPaper()
    {
        if (pendingToBeSaved != null)
        {
            // Logic to save the scanned paper
            Debug.Log("Paper saved!");
            GameObject copiedPaper = Instantiate(pendingToBeSaved, pendingToBeSaved.transform.position, pendingToBeSaved.transform.rotation);
            copiedPaper.name = pendingToBeSaved.name + "_Copy";
            copiedPaper.transform.SetParent(null); // Unparent the copied paper
            Renderer copiedRenderer = copiedPaper.GetComponent<Renderer>();
            if (copiedRenderer != null)
            {
                Material copiedMaterial = copiedRenderer.material;
                Debug.Log("Copied paper material: " + copiedMaterial.name);
            }
            copiedRenderer.material.color = Color.cyan; // Change color to light blue for the copied paper
            pendingToBeSaved = null;
        }
        else
        {
            Debug.Log("No paper to save!");

        }
        confirmScanMenu.SetActive(false);
    }
    
}
