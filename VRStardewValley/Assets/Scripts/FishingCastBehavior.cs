using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// This script allows the player to fish.
public class FishingCastBehavior : OVRGrabber
{
    private bool FishBiteBool = false; 
    private bool FishingBool = false;
    public TextMeshProUGUI FishBiteExclamation;
    public Animator RodAnim;
    public Animator FishAnim;
    public GameObject Player;

    // Update is called once per frame
    new void Update()
    {
        // if they aren't already fishing
        if (FishingBool == false)
        {
            // and if they are grabbing the rod and press the A button
            if (m_grabbedObj != null && OVRInput.Get(OVRInput.RawButton.A) == true)
            {
                // say that they are fishing now
                FishingBool = true;

                //disable the movement scripts attached to the player, so that they can't teleport or walk away
                StopMovement();

                //start casting animation
                RodAnim.Play("Cast");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if the collided object is water
        if (other.CompareTag("Water"))
        {
            //allow them to catch fish
            FishBite();
        }
    }

    void StopMovement()
    {
        //disable all of the movement script components
        Player.GetComponent<CharacterCameraConstraint>().enabled = false;
        Player.GetComponent<SimpleCapsuleWithStickMovement>().enabled = false;
        Player.GetComponentInChildren<LocomotionController>().enabled = false;
        Player.GetComponentInChildren<LocomotionTeleport>().enabled = false;
        Player.GetComponentInChildren<TeleportInputHandler>().enabled = false;
    }

    void StartMovement()
    {
        //enable all of the movement script components
        Player.GetComponent<SimpleCapsuleWithStickMovement>().enabled = true;
        Player.GetComponentInChildren<LocomotionController>().enabled = true;
        Player.GetComponentInChildren<LocomotionTeleport>().enabled = true;
        Player.GetComponentInChildren<TeleportInputHandler>().enabled = true;
    }

    void FishBite()
    {
        while (FishBiteBool == false)
        {
            //make a ui exclamation mark pop up
            FishBiteExclamation.enabled = true;

            //then if they press A again and the cast animation is being played
            if (OVRInput.Get(OVRInput.RawButton.A) == true && RodAnim.GetCurrentAnimatorStateInfo(0).IsName("Cast"))
            {
                //begin the fish catching and reel in animations
                RodAnim.Play("ReelIn");
                FishAnim.Play("Caught");

                //give the player back their movement
                StartMovement();

                //remove the exclamation mark
                FishBiteExclamation.enabled = false;

                FishBiteBool = true;
            }
        }
    }

    protected void ResetBools()
    {
        FishBiteBool = false;
        FishingBool = false;
    }
}
