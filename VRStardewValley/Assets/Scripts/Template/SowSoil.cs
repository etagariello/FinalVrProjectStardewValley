using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ivy; This script handles the hoe colliding with the soil to plow it
public class SowSoil : MonoBehaviour
{
    // Set the objects for soil in inspector
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
