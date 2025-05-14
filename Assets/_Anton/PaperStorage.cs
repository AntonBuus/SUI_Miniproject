using System.Collections.Generic;
using UnityEngine;

public class PaperStorage : MonoBehaviour
{   
    // This script was never implemented in a scene but was an early work of a place
    // to store papers. It is not used in the final version of the project. 
    public List<GameObject> storedPapers = new List<GameObject>();

    //Checks for collisions and whether the object has the tag "Paper"
    // If so, it adds the paper to the list and destroys the original paper object
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Paper"))
        {
            GameObject paper = other.gameObject;
            storedPapers.Add(paper);
            Destroy(paper);
            Debug.Log("Paper stored: " + paper.name);
        }
    }
    // takes the first paper in the list and instantiates it at the storage position
    public void PrintSelectedPaper()
    {
        if (storedPapers.Count > 0)
        {
            GameObject paperToPrint = storedPapers[0]; // Get the first paper in the list
            storedPapers.RemoveAt(0); // Remove it from the list
            GameObject printedPaper = Instantiate(paperToPrint, transform.position, Quaternion.identity);
            printedPaper.name = paperToPrint.name + "_Printed";
            Debug.Log("Printed paper: " + printedPaper.name);
        }
        else
        {
            Debug.Log("No papers to print!");
        }
    }
}
