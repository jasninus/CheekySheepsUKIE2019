using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volunteer : MonoBehaviour
{
    private VolunteerType type;

    private VolunteerInfoUIActivater infoUIActivater;

    private VolunteerRole role;

    private void Awake()
    {
        infoUIActivater = GameObject.FindWithTag("VolunteerInfoUIManager").GetComponent<VolunteerInfoUIActivater>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (IsClickedOn())
            {
                OpenInfoPanel();
            }
            else
            {
                CloseInfoPanel();
            }
        }
    }

    private bool IsClickedOn()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out var hit, LayerMask.NameToLayer("Volunteer"));
        return hit.transform == transform;
    }

    public void OpenInfoPanel()
    {
        infoUIActivater.ActivateInfo(role, type);
    }

    public void CloseInfoPanel()
    {
        infoUIActivater.DeactivateInfo(role);
    }

    private void OnMouseDown()
    {
        OpenInfoPanel();
    }

    public void UpgradeTo(VolunteerRole newRole)
    {
        Debug.Log($"Upgrading to: {newRole}");

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