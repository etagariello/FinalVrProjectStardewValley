using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

// Ivy; This script handles planting crops in their specific planting spots similar to rock stacking with snap positioning.
// You can only plant carrots, tomatoes, and turnips in their specified rows. (example plant on the right side of all rows) 
public class PlantingScript : MonoBehaviour
{
    // Target tag
    public string targetTag;
    // Plant gameobject
    public GameObject plant;
    // Ghost plant gameobject
    public GameObject ghostPlant;

    // Plant position    
    private Transform plantPosition;
    // Ghost plant position
    private Transform ghostPlantPosition;
    // Plant rigidbody  
    private Rigidbody plantRigidbody;
    // Plant grabbable script    
    private OVRGrabbable plantGrabbable;
    

    private void Start() { 
        // Plant positions        
        plantPosition = plant.transform;
        // Ghost plant positions        
        ghostPlantPosition = ghostPlant.transform;
        // Plant rigidbodies        
        plantRigidbody = plant.GetComponent<Rigidbody>();
        // Plant grabbable script        
        plantGrabbable = plant.GetComponent<OVRGrabbable>();
        }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided with " + collision.gameObject.name);
        // Check if the collision is with the correct tagged object: Carrot, Tomato, or Turnip assigned/dragged in inspector
        if (collision.gameObject.tag == targetTag)
        {
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
