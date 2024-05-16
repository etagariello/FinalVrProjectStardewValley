using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

// Ivy; This script handles planting crops in their specific planting spots similar to rock stacking with snap positioning, creating a timer once its planted,
// and grow the plant after some time. You can only plant carrots, tomatoes, and turnips in their specified rows. (example plant on the right side of all rows) 
public class PlantingScript : MonoBehaviour
{
    // Target tag
    public string targetTag;
    // Plant gameobject
    public GameObject plant;
    // Ghost plant gameobject
    public GameObject ghostPlant;
    // Gameobject representing the plant fully grown
    public GameObject grownPlant;

    // Plant position    
    private Transform plantPosition;
    // Ghost plant position
    private Transform ghostPlantPosition;
    // Plant rigidbody  
    private Rigidbody plantRigidbody;
    // Plant grabbable script    
    private OVRGrabbable plantGrabbable;
    // GrownPlant grabbable
    private OVRGrabbable grownPlantGrabbable;

    // isPlanted boolean
    private bool isPlanted;
    // A timer float
    private float timer;
    // A time to grow float, set at 10 seconds
    private float growthTime = 10f;
    
    
    private void Start() { 
        // Plant positions        
        plantPosition = plant.transform;
        // Ghost plant positions        
        ghostPlantPosition = ghostPlant.transform;
        // Plant rigidbodies        
        plantRigidbody = plant.GetComponent<Rigidbody>();
        // Plant grabbable script        
        plantGrabbable = plant.GetComponent<OVRGrabbable>();
        // Set isPlanted to false on start 
        isPlanted = false;
        // GrownPlant grabbable
        grownPlantGrabbable = grownPlant.GetComponent<OVRGrabbable>();
        }
    
    private void Update() {
        // Checks each frame if isPlanted is true
        if (isPlanted) {
            // If isPlanted, timer begins to increase every second
            timer += Time.deltaTime;
            Debug.Log("Timer: " + timer);
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

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided with " + collision.gameObject.name);
        // Check if the collision is with the correct tagged object: Carrot, Tomato, or Turnip assigned/dragged in inspector
        if (collision.gameObject.CompareTag(targetTag))
        {
            // Set isPlanted to true
            isPlanted = true;

            // Disable the ghostPlant
            ghostPlant.SetActive(false);

            // Destroy the rigidbody so it no longer can move
            Destroy(plantRigidbody);

            // Destroy the grabbable script so that it can no longer be grabbed once placed
            Destroy(plantGrabbable);

            // Moves the plant that collided to the location of the ghost plant
            plantPosition.position = ghostPlantPosition.position;
        }
    }
}
