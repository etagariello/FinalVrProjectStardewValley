using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this is a small script that simply tracks if the fish gets grabbed, and when it does, reset the rod animation
public class FishGrabbedBehavior : FishingCastBehavior
{
    new private void Update()
    {
        if (m_grabbedObj != null)
        {
            RodAnim.Play("Idle");
        }
    }
}
