using UnityEngine;
using TMPro;

public class ScanPaper : MonoBehaviour
{
    // this script is placed on the gameobject called "Scanner"
    
    bool readyToScan = true;
    public GameObject scanEffectPrefab; //for now just a gameobject but could be more effective wiht a particle system
    public GameObject pendingToBeSaved; //where we store the paper that is scanned
    public GameObject confirmScanMenu; // a part of the hand menu which we enable once a paper is scanned
    public TMP_Text statusText;
    public float _copyPositionOffset = 0.1f; // How far above we want to place the copied paper from where it was scanned
    private Vector3 paperPosition; // Store the position of the scanned paper

    public Material _copiedMaterial;
    
    //will register collisions with object tagged "Paper" if the scanner is ready.
    // We spawn a scan effect and then destoy it, then save the paper and its position for use in the copyPaper method
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
            PlayFromAudiomanager(); //will play sound if available
        }
        Debug.Log("Hallo");
    }
    // This method is called with a button press in the confirmScanMenu that appears.
    // it will spawn a copy and modify it to make it look more "digital"
    public void CopyPaper()
    {
        if (pendingToBeSaved != null)
        {
            Debug.Log("Paper saved!");
            
            // Spawns the copied paper above the point where the original paper was scanned and tidys the hierarchy
            GameObject copiedPaper = Instantiate(pendingToBeSaved, paperPosition, pendingToBeSaved.transform.rotation);
            copiedPaper.name = pendingToBeSaved.name + "_Copy";
            copiedPaper.transform.SetParent(null); 
            
            //change the color of the copied paper to light blue
            Renderer copiedRenderer = copiedPaper.GetComponent<Renderer>();
            if (copiedRenderer != null)
            {
                Material copiedMaterial = copiedRenderer.material;
                Debug.Log("Copied paper material: " + copiedMaterial.name);
            }
            copiedRenderer.material = _copiedMaterial; // Change color to light blue for the copied paper
            
            //make the copied paper kinematic, we do this to distinguish it from what 
            //should feel like a real paper
            Rigidbody copiedRigidbody = copiedPaper.GetComponent<Rigidbody>();
            if (copiedRigidbody != null)
            {
                copiedRigidbody.isKinematic = true;
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
    // sets the scanner to be ready to scan again which is called when the CopyPaper() method is called
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

    //setup for using audio manager if available
    public UnityEngine.Events.UnityEvent onInvoke;
    private void PlayFromAudiomanager()
    {
        if (onInvoke != null)
        {
            onInvoke.Invoke();
        }
    }
    
}
