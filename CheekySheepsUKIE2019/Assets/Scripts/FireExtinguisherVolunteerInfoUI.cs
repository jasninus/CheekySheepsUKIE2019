using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireExtinguisherVolunteerInfoUI : VolunteerInfoUI
{
    [SerializeField] private Text waterText, extinguishingText, extinguishButtonText;

    private FireExtinguisherVolunteer currentFireVolunteer;

    public override void Activate(VolunteerType toDisplay)
    {
        base.Activate(toDisplay);
        currentFireVolunteer = ((FireExtinguisherVolunteer)toDisplay);
        currentFireVolunteer.updateExtinguishingUI += UpdateExtinguishing;
        currentFireVolunteer.updateWaterUI += UpdateWaterUI;
    }

    public override void Deactivate()
    {
        ((FireExtinguisherVolunteer)currentToDisplay).updateExtinguishingUI -= UpdateExtinguishing;
        ((FireExtinguisherVolunteer)currentToDisplay).updateWaterUI -= UpdateWaterUI;
        currentFireVolunteer = null;
        base.Deactivate();
    }

    private void UpdateWaterUI(float value)
    {
        waterText.text = value.ToString();

        // Check if button should be set to extinguishing turned off
        if (value < FireExtinguisherVolunteer.ExtinguishingWaterDrain)
        {
            extinguishButtonText.text = "Start extinguishing";
        }
    }

    private void UpdateExtinguishing(bool value) => extinguishingText.text = value ? "Yes" : "No";

    public void ToggleExtinguishing()
    {
        currentFireVolunteer.IsExtinguishing = !currentFireVolunteer.IsExtinguishing;
        extinguishButtonText.text = currentFireVolunteer.IsExtinguishing ? "Stop extinguishing" : "Start extinguishing";
    }
}