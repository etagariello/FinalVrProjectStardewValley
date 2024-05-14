using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolDestroy : MonoBehaviour
{
    public string targetTag; // Tag of the object to destroy when hit by this tool

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with an object having the specified tag
        if (collision.gameObject.CompareTag(targetTag))
        {
            // Destroy the target object
            Destroy(collision.gameObject);
        }
    }
}
