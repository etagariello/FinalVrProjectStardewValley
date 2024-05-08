using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FishingCastBehavior : OVRGrabber
{
    private bool FishBiteBool = false; 
    private bool FishingBool = false;
    private int FishCount = 0;
    public TextMeshProUGUI FishBiteExclamation;
    public TextMeshProUGUI FishCountText;
    public Animator FishAnim;
    public GameObject Player;

    // Update is called once per frame
    new void Update()
    {
        if (FishingBool == false)
        {
            if (m_grabbedObj != null && OVRInput.Get(OVRInput.RawButton.A) == true)
            {
                FishingBool = true;

                //disable the movement scripts attached to the player, so that they can't teleport or walk away
                StopMovement();

                //cause fish to bite
                FishBite();
            }
        }

        //changes the ui to the amount of fish caught
        FishCountText.text = "Fish: " + FishCount;
        
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

            //then if they press A again
            if (OVRInput.Get(OVRInput.RawButton.A) == true)
            {
                //begin the fish catching animation
                FishAnim.SetTrigger("Play");

                //increase the fish count by 1
                FishCount++;

                //give the player back their movement
                StartMovement();

                //remove the exclamation mark
                FishBiteExclamation.enabled = false;

                FishBiteBool = true;
            }
        }
    }
}
