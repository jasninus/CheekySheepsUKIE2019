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
        currentPlanterVolunteer = (PlanterVolunteer)toDisplay;
        currentPlanterVolunteer.updateReplantingUI += UpdateReplantingUI;
        currentPlanterVolunteer.updateSeedUI += UpdateSeedUI;
        Debug.Log("Derived info UI");
    }

    private void UpdateSeedUI(uint value)
    {
        seedText.text = value.ToString();
    }

    private void UpdateReplantingUI(bool value)
    {
        replantingText.text = value ? "Yes" : "No";
        replantingButtonText.text = value ? "Stop replanting" : "Start replanting";
    }

    public override void Deactivate()
    {
        currentPlanterVolunteer.updateReplantingUI -= UpdateReplantingUI;
        currentPlanterVolunteer.updateSeedUI -= UpdateSeedUI;
        currentPlanterVolunteer = null;
        base.Deactivate();
    }

    public void ToggleReplanting()
    {
        currentPlanterVolunteer.IsReplanting = !currentPlanterVolunteer.IsReplanting;
    }
}