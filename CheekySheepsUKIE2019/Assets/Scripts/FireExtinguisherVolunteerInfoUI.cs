using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireExtinguisherVolunteerInfoUI : VolunteerInfoUI
{
    [SerializeField] private Text waterText, extinguishingText;

    public override void Activate(VolunteerType toDisplay)
    {
        base.Activate(toDisplay);
        ((FireExtinguisherVolunteer)toDisplay).updateExtinguishingUI += UpdateExtinguishing;
        ((FireExtinguisherVolunteer)toDisplay).updateWaterUI += UpdateWaterUI;
    }

    public override void Deactivate()
    {
        ((FireExtinguisherVolunteer)currentToDisplay).updateExtinguishingUI -= UpdateExtinguishing;
        ((FireExtinguisherVolunteer)currentToDisplay).updateWaterUI -= UpdateWaterUI;
        base.Deactivate();
    }

    private void UpdateWaterUI(float value) => waterText.text = value.ToString();

    private void UpdateExtinguishing(bool value) => extinguishingText.text = value ? "Yes" : "No";
}