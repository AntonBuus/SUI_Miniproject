using System.Collections.Generic;
using UnityEngine;

public class PaperStorage : MonoBehaviour
{
    public List<GameObject> storedPapers = new List<GameObject>();

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
