using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//* This is attached to the deposit box at the port, and when you give it fish, it will
// return the fish to its original location and increase the counter of the fish collected. *//
public class DepositFishBehavior : FishingCastBehavior
{
    public TextMeshProUGUI FishCountText;
    private int FishCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        //if the object that collided has the tag Fish
        if (other.CompareTag("Fish"))
        {
            //reset the fish animation back to normal
            FishAnim.Play("Idle");

            //reset the bools by calling the method from the parent class
            ResetBools();
        }
    }

    new private void Update()
    {
        // change the fish count text to the new amount every frame
        FishCountText.text = "Amount of Fish: " + FishCount;
    }
}
