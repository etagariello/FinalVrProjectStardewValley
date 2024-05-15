using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class PlantingScript : MonoBehaviour
{
    // target tag
    public string targetTag;
    // plant gameobject
    public GameObject plant;
    // ghost plant gameobject
    public GameObject ghostPlant;
    // plant position    
    private Transform plantPosition;
    // ghost plant position
    private Transform ghostPlantPosition;
    // plant rigidbodie    
    private Rigidbody plantRigidbody;
    // plant grabbable script    
    private OVRGrabbable plantGrabbable;
    
    private void Start() { 
        // plant positions        
        plantPosition = plant.transform;
        // ghost plant positions        
        ghostPlantPosition = ghostPlant.transform;
        // plant rigidbodies        
        plantRigidbody = plant.GetComponent<Rigidbody>();
        // plant grabbable scripts        
        plantGrabbable = plant.GetComponent<OVRGrabbable>(); 
        }
    
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided with " + collision.gameObject.name);
        // Check if the collision is with the correct tagged object: Carrot, Tomato, or Turnip assigned/dragged in inspector
        if (collision.gameObject.CompareTag(targetTag))
        {
            Debug.Log("Correct object tagged as: " + targetTag);
            ghostPlant.SetActive(false);

            // destroy the rigidbody so it no longer can move
            Destroy(plantRigidbody);

            // destroy the grabbable script so that it can no longer be grabbed once placed
            Destroy(plantGrabbable);

            // moves the plant that collided to the location of the ghost plant
            plantPosition.position = ghostPlantPosition.position;
        }
        else {
        Debug.Log("Incorrect object tagged as: " + collision.gameObject.tag);
        }
    }
}
