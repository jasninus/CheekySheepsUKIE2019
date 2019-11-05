using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volunteer : MonoBehaviour
{
    private VolunteerType type;

    public void OpenInfoPanel()
    {
        type.GetInfoUI().SetActive(true);
    }

    public void CloseInfoPanelCanvas()
    {
        type.GetInfoUI().SetActive(false);
    }

    public void UpgradeTo(VolunteerRole newRole)
    {
        switch (newRole)
        {
            case VolunteerRole.FireExtinguisher:
                type = GetComponent<FireExtinguisherVolunteer>();
                break;

            case VolunteerRole.AnimalSaver:
                type = GetComponent<AnimalSaverVolunteer>();
                break;

            case VolunteerRole.Planter:
                type = GetComponent<PlanterVolunteer>();
                break;
        }
    }
}

public enum VolunteerRole
{
    FireExtinguisher,
    Planter,
    AnimalSaver,
    WaterGatherer
}