using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowMooProximity : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        // Get audio component (moo sound)
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        // Checks if the colliding object is the Player object
        if (other.CompareTag("Player"))
        {
            // Play moo audio every time re-enter the sphere
            audioSource.Play();
        }
    }
}
