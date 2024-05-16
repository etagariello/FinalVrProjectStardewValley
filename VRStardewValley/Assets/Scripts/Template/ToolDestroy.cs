using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ivy; This script is attached to the pickaxe, axe, and scythe tools
// Only the tools with the correct tag can destroy the type of objects assigned to them
public class ToolDestroy : MonoBehaviour
{
    // Tag of the object to destroy when hit by this tool
    public string targetTag;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided with " + collision.gameObject.name);
        // Check if the collision is with the correct tagged object: Tree, Rock, or Grass assigned/dragged in inspector
        if (collision.gameObject.tag == targetTag)
        {
            // Destroy the target object (Tree, Rock, or Grass)
            Destroy(collision.gameObject);
        }
    }
}
