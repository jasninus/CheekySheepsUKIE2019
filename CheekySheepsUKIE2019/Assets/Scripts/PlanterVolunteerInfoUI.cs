using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanterVolunteerInfoUI : VolunteerInfoUI
{
    [SerializeField] private Text seedText, replantingText, replantingButtonText;

    private PlanterVolunteer currentPlanterVolunteer;

    public override void Activate(VolunteerType toDisplay)
    {
        base.Activate(toDisplay);
        //currentPlanterVolunteer =
        Debug.Log("Derived info UI");
    }

    private void UpdateSeedUI(uint value)
    {
        seedText.text = value.ToString();
    }

    private void UpdateReplantingButtonUI(bool value)
    {
        replantingText.text = value ? "Yes" : "No";
        replantingButtonText.text = value ? "Stop replanting" : "Start replanting";
    }
}