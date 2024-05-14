using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ivy; attached to fish
public class FeedTreat : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided?" + collision.gameObject.name);
        // Check if the colliding object is the cow
        if (collision.gameObject.CompareTag("Cow"))
        {
            // Make the treat disappear
            gameObject.SetActive(false);
        }
    }
}
