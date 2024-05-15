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
    public GameObject Plants;
    private GameObject GhostPlants;
    
    // plant game objects
    private GameObject ThePlant;

    // ghost plant game objects
    private GameObject TheGhostPlant;
    
    // plant positions
    private Transform ThePlantPosition;
    
    // ghost plant positions
    private Transform TheGhostPlantPosition;

    // plant rigidbodies
    private Rigidbody ThePlantRigidbody;

    // plant grabbable scripts
    private OVRGrabbable ThePlantGrabbable;

    private void Start()
    {
        
        // assign values

        GhostPlants = gameObject;

        // plant game objects
        ThePlant = Plants.transform.GetChild(0).gameObject;

        // ghost plant game objects
        TheGhostPlant = GhostPlants.transform.GetChild(0).gameObject;

        // plant positions
        ThePlantPosition = ThePlant.transform;

        // ghost plant positions
        TheGhostPlantPosition = TheGhostPlant.transform;

        // plant rigidbodies
        ThePlantRigidbody = ThePlant.GetComponent<Rigidbody>();

        // plant grabbable scripts
        ThePlantGrabbable = ThePlant.GetComponent<OVRGrabbable>();
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject[] plants = {ThePlant};
        GameObject[] PlantGhosts = {TheGhostPlant};
        Transform[] PlantPositions = {ThePlantPosition};
        Transform[] GhostPlantPositions = {TheGhostPlantPosition};
        OVRGrabbable[] PlantGrabbables = {ThePlantGrabbable};
        Rigidbody[] PlantRigidbodies = {ThePlantRigidbody};

        if (collision.gameObject == plants[0]) {

            PlantPlacement(plants[0], PlantGhosts[0], PlantPositions[0], GhostPlantPositions[0], PlantGrabbables[0], PlantRigidbodies[0]);
        }
    }
    

    // this method is to move the plant where the ghost one was when called, and destroy what causes the plant to be moveable
    void PlantPlacement(GameObject Plants, GameObject GhostPlants, Transform PlantPosition, Transform GhostPlantPosition, OVRGrabbable PlantGrabbable, Rigidbody PlantRigidbody)
    {
        // deactivates ghost rock so that rock is visible
        GhostPlants.SetActive(false);

        // destroy the rigidbody so it no longer can move
        Destroy(PlantRigidbody);

        // destroy the grabbable script so that it can no longer be grabbed once placed
        Destroy(PlantGrabbable);

        // moves the rock that collided to the location of the ghost rock
        PlantPosition.position = GhostPlantPosition.position;
    }
}
