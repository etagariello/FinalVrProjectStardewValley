using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Ivy; This script handles the teleportations of player to scenes by name
public class DoorScript : MonoBehaviour
{
    // Name of the scene to load (set this in the Inspector)
    public string sceneName;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collision is with the object this script is attached to and player
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player collided");
            // Load the scene by name
            SceneManager.LoadScene(sceneName);
        }
    }
}
