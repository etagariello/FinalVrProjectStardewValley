using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ivy; This script is added to the cow object to detect player proximity for an audio queue
public class CowMooProximity : MonoBehaviour
{
    // initialize the audiosource
    private AudioSource audioSource;

    void Start()
    {
        // Get audio component from cow (moo sound)
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        // Checks if the colliding object is the Player object
        if (other.CompareTag("Player"))
        {
            // Play moo audio every time the player re-enters the sphere
            audioSource.Play();
        }
    }
}
