using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SowSoil : MonoBehaviour
{
    public GameObject soil;

    void Start()
    {
        // Set the soil object inactive when the script starts
        soil.SetActive(false);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with an object having the specified tag
        if (collision.gameObject.CompareTag("Dirt"))
        {
            // Show the the sowed soil
            soil.SetActive(true);
        }
    }
}
