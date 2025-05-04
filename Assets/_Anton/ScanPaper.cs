using UnityEngine;
using TMPro;

public class ScanPaper : MonoBehaviour
{
    
    bool readyToScan = true;
    public GameObject scanEffectPrefab;
    public GameObject pendingToBeSaved;
    public GameObject confirmScanMenu;
    public TMP_Text statusText;
    public float _copyPositionOffset = 0.2f; // Offset for the copied paper position
    private Vector3 paperPosition; // Store the position of the scanned paper
    

    private void OnTriggerEnter(Collider other) 
    {
        if (readyToScan && other.CompareTag("Paper"))
        {
            readyToScan = false;
            GameObject scanEffect = Instantiate(scanEffectPrefab, transform.position, Quaternion.identity);
            Destroy(scanEffect, 2f); // Destroy the effect after 2 seconds
            Debug.Log("Paper scanned!");
            pendingToBeSaved = other.gameObject;
            paperPosition = new Vector3(other.transform.position.x, other.transform.position.y + _copyPositionOffset, other.transform.position.z);
            confirmScanMenu.SetActive(true);
            // confirmScanMenu.SetActive(true);
        }
        Debug.Log("Hallo");
    }
    
    public void CopyPaper()
    {
        if (pendingToBeSaved != null)
        {
            // Logic to save the scanned paper
            Debug.Log("Paper saved!");

            GameObject copiedPaper = Instantiate(pendingToBeSaved, paperPosition, pendingToBeSaved.transform.rotation);
            copiedPaper.name = pendingToBeSaved.name + "_Copy";
            copiedPaper.transform.SetParent(null); // Unparent the copied paper
            
            //change the color of the copied paper to light blue
            Renderer copiedRenderer = copiedPaper.GetComponent<Renderer>();
            if (copiedRenderer != null)
            {
                Material copiedMaterial = copiedRenderer.material;
                Debug.Log("Copied paper material: " + copiedMaterial.name);
            }
            copiedRenderer.material.color = Color.cyan; // Change color to light blue for the copied paper
            
            //make the copied paper kinematic
            Rigidbody copiedRigidbody = copiedPaper.GetComponent<Rigidbody>();
            if (copiedRigidbody != null)
            {
                copiedRigidbody.isKinematic = true; // Make the copied paper kinematic
            }
            
            pendingToBeSaved = null;
            confirmScanMenu.SetActive(false);
            ReadyScan();
        }
        else
        {
            Debug.Log("No paper to save!");

        }
        
    }
    public void ReadyScan()
    {
        readyToScan = true;

        Debug.Log("Ready to scan again!");
        if (pendingToBeSaved != null)
        {
            Destroy(pendingToBeSaved);
            pendingToBeSaved = null;
        }
    }
    
}
