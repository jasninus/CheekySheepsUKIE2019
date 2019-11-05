using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolunteerInfoUIActivater : MonoBehaviour
{
    [SerializeField] private VolunteerInfoUI fireExtinguisherUI, waterGathererUI, planterUI, animalSaverUI;

    private void Awake()
    {
        fireExtinguisherUI.Activate(null);
    }

    public void ActivateInfo(VolunteerRole role, VolunteerType toDisplay)
    {
        switch (role)
        {
            case VolunteerRole.AnimalSaver:
                animalSaverUI.Activate(toDisplay);
                break;

            case VolunteerRole.FireExtinguisher:
                fireExtinguisherUI.Activate(toDisplay);
                break;

            case VolunteerRole.Planter:
                planterUI.Activate(toDisplay);
                break;

            case VolunteerRole.WaterGatherer:
                waterGathererUI.Activate(toDisplay);
                break;
        }
    }

    public void DeactivateInfo(VolunteerRole role)
    {
        switch (role)
        {
            case VolunteerRole.AnimalSaver:
                animalSaverUI.Deactivate();
                break;

            case VolunteerRole.FireExtinguisher:
                fireExtinguisherUI.Deactivate();
                break;

            case VolunteerRole.Planter:
                planterUI.Deactivate();
                break;

            case VolunteerRole.WaterGatherer:
                waterGathererUI.Deactivate();
                break;
        }
    }
}