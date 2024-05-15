using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDialogue : MonoBehaviour
{
    public GameObject dialogueActivate; // Object to activate

    void Start()
    {
        // Deactivate the object initially
        dialogueActivate.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the entering collider is tagged as "Player"
        if (other.CompareTag("Player"))
        {
            // Activate the object
            dialogueActivate.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Check if the exiting collider is tagged as "Player"
        if (other.CompareTag("Player"))
        {
            // Deactivate the object
            dialogueActivate.SetActive(false);
        }
    }
}
