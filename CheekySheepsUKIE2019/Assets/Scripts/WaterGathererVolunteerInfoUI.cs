using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterGathererVolunteerInfoUI : VolunteerInfoUI
{
    [SerializeField] private Text waterText;

    public override void Activate(VolunteerType toDisplay)
    {
        base.Activate(toDisplay);
        ((WaterGathererVolunteer)toDisplay).updateWaterUI += UpdateWaterUI;
    }

    private void UpdateWaterUI(float value) => waterText.text = value.ToString();
}