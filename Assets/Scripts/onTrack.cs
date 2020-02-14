using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onTrack : DefaultTrackableEventHandler
{
    
    protected override void OnTrackingFound(){
        base.OnTrackingFound ();
        moveShip.imgFound = true;
    }

    protected override void OnTrackingLost(){
        base.OnTrackingLost ();
        moveShip.imgFound = false;
    }
}
