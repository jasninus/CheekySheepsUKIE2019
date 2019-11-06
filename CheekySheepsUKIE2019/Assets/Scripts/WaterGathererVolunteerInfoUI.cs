using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGathererVolunteerInfoUI : VolunteerInfoUI
{
    public override void Activate(VolunteerType toDisplay)
    {
        base.Activate(toDisplay);
        Debug.Log("Derived info UI");
    }
}