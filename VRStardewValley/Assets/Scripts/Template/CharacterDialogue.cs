using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ivy; This script is attatched to each NPC, thier dialogue is then attached in the inspector
public class CharacterDialogue : MonoBehaviour
{
    // Get the dialogue component that will be activated
    public GameObject dialogueActivate;

    void Start()
    {
        // Deactivate the object initially
        dialogueActivate.SetActive(false);
    }

    // Sphere radius in front of NPC
    void OnTriggerEnter(Collider other)
    {
        // Check if the entering collider is "Player"
        if (other.CompareTag("Player"))
        {
            // Activate the object
            dialogueActivate.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Check if the exiting collider is "Player"
        if (other.CompareTag("Player"))
        {
            // Deactivate the object again
            dialogueActivate.SetActive(false);
        }
    }
}
