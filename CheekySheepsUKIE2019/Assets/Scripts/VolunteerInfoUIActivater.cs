using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolunteerInfoUIActivater : MonoBehaviour
{
    [SerializeField] private GameObject waterGathererUI, planterUI, animalSaverUI;

    [SerializeField] private FireExtinguisherVolunteerInfoUI fireExtinguisherUI;

    private void Awake()
    {
    }

    private void ActivateInfo(VolunteerRole role, Volunteer toDisplay)
    {
        //switch (role)
        //{
        //    case VolunteerRole.AnimalSaver:
        //        animalSaverUI.
        //}
    }
}