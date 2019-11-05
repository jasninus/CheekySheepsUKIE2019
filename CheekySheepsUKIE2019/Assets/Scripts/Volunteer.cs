using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Volunteer : MonoBehaviour
{
    private VolunteerType type;

    private VolunteerInfoUIActivater infoUIActivater;

    private VolunteerRole role = VolunteerRole.WaterGatherer;

    private bool isSelected;

    private void Awake()
    {
        infoUIActivater = GameObject.FindWithTag("VolunteerInfoUIManager").GetComponent<VolunteerInfoUIActivater>();
        UpgradeTo(VolunteerRole.FireExtinguisher); // TODO remove, for testing purposes only
    }

    private GraphicRaycaster m_Raycaster;
    private PointerEventData m_PointerEventData;
    private EventSystem m_EventSystem;

    private void Start()
    {
        //Fetch the Raycaster from the GameObject (the Canvas)
        m_Raycaster = GameObject.FindWithTag("MainCanvas").GetComponent<GraphicRaycaster>();
        //Fetch the Event System from the Scene
        m_EventSystem = GetComponent<EventSystem>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (ThisClickedOnOrUIClickedOn())
            {
                isSelected = true;
                OpenInfoPanel();
            }
            else if (isSelected && !UIClickedOn())
            {
                isSelected = false;
                CloseInfoPanel();
            }
        }
    }

    private bool ThisClickedOnOrUIClickedOn()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out var hit);

        return hit.transform == transform;
    }

    private bool UIClickedOn()
    {
        m_PointerEventData = new PointerEventData(m_EventSystem) { position = Input.mousePosition };
        List<RaycastResult> results = new List<RaycastResult>();
        m_Raycaster.Raycast(m_PointerEventData, results);
        return results.Count > 0;
    }

    public void OpenInfoPanel()
    {
        infoUIActivater.ActivateInfo(role, type);
        type.UpdateAllUI();
    }

    public void CloseInfoPanel()
    {
        infoUIActivater.DeactivateInfo(role);
    }

    //private void OnMouseDown()
    //{
    //    OpenInfoPanel();
    //}

    public void UpgradeTo(VolunteerRole newRole)
    {
        role = newRole;
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
    WaterGatherer,
    FireExtinguisher,
    Planter,
    AnimalSaver
}