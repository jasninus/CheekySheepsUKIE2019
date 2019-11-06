using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterGathererVolunteerInfoUI : VolunteerInfoUI
{
    [SerializeField] private Text waterText;

    private WaterGathererVolunteer currentWaterGathererVolunteer;

    public override void Activate(VolunteerType toDisplay)
    {
        base.Activate(toDisplay);
        currentWaterGathererVolunteer = ((WaterGathererVolunteer)toDisplay);
        currentWaterGathererVolunteer.updateWaterUI += UpdateWaterUI;
    }

    private void UpdateWaterUI(float value) => waterText.text = value.ToString();

    public override void Deactivate()
    {
        currentWaterGathererVolunteer.updateWaterUI -= UpdateWaterUI;
        currentWaterGathererVolunteer = null;
        base.Deactivate();
    }
}