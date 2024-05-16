using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ivy; This script starts a timer once the specified gameObject is hidden, attached to each plant.
// After the specified time, the plant will grow.
public class Timer : MonoBehaviour
{
    // Inspecter-assignable plant variables
    public GameObject ghostPlant;
    public GameObject plant;
    public GameObject grownPlant;

    // Create float varaibles for time-keeping
    public float growthTime = 10f;
    private float timer = 0;

    // Create a boolean for if the crop has been planted yet
    private bool isPlanted = false;

    // Update is called once per frame
    void Update()
    {
        // Check if the ghostPlant is active
        if (!ghostPlant.activeSelf && !isPlanted)
        {
            // Set isPlanted to true once the ghostPlant is inactive
            // This indicates that the plant has taken its place
            isPlanted = true;
        }

        if (isPlanted) {
            // If isPlanted, timer begins to increase every second
            timer += Time.deltaTime;

            if (timer >= growthTime)
            {
                // If timer gets to the set growthTime, display the grown plant
                grownPlant.SetActive(true);
                // Hide the initial plant
                plant.SetActive(false);
                // Reset timer
                timer = 0;
                // Reset isPlanted
                isPlanted = false;
            }
        }
    }
}