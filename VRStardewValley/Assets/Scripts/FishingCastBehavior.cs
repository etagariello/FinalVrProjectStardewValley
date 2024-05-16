using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// This script allows the player to fish.
public class FishingCastBehavior : MonoBehaviour
{
    private bool FishBiteBool = false; 
    private bool FishingBool = false;
    public TextMeshProUGUI FishBiteExclamation;
    public TextMeshProUGUI ArrowText;
    public Animator RodAnim;
    public Animator FishAnim;
    public GameObject Fish;

    

    void Update()
    {
        if (RodAnim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            ResetBools();
        }
        Fishing();
    }
    private void Fishing()
    {
        // if they aren't already fishing
        if (FishingBool == false)
        {
            // and if they are grabbing the rod and press the A button
            if (OVRInput.Get(OVRInput.RawButton.A) == true)
            {
                // say that they are fishing now
                FishingBool = true;

                //start casting animation
                RodAnim.Play("Cast");
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Water")
        {
            FishBite();
        }
    }

    private void FishBite()
    {
        if (FishBiteBool == false)
        {
            //make a ui exclamation mark pop up
            FishBiteExclamation.enabled = true;

            //then if they press A again and the cast animation is being played
            if (OVRInput.Get(OVRInput.RawButton.A) == true) //&& 
            {
                Fish.SetActive(true);

                //begin the fish catching and reel in animations
                RodAnim.Play("ReelIn");
                FishAnim.Play("FishCaught");

                //remove the exclamation mark
                FishBiteExclamation.enabled = false;

                FishBiteBool = true;
            }
        }
    }
    private void ResetBools()
    {
        FishingBool = false;
        FishBiteBool = false;
    }
}
