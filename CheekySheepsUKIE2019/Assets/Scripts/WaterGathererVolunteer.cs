using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGathererVolunteer : VolunteerType
{
    [SerializeField] private float waterGatheringSpeed, waterGivingSpeed, maxWater, riverRadius, waterGatheringDistanceTolerance, waterSupplyingDistanceTolerance;
    private float currentWater;

    private Transform riverTransformCenter, currentFireExtinguisherTarget;

    private FireExtinguisherVolunteer currentExtinguisherVolunteer;

    private Vector3 riverTargetPosition;

    private bool movingToRiver, movingToFireExtinguishers;

    private VolunteerMovement movement;

    public Action<float> updateWaterUI;

    private float CurrentWater
    {
        get => currentWater;
        set
        {
            currentWater = value;
            updateWaterUI?.Invoke(currentWater);
        }
    }

    private void Awake()
    {
        riverTransformCenter = GameObject.FindWithTag("RiverTransformCenter").transform;
        movement = GetComponent<VolunteerMovement>();
    }

    private void LateUpdate()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (movement.moving)
            {
                RaycastHit hit = RayCast();

                if (IsTargetingRiver(hit))
                {
                    riverTargetPosition = Vector3.MoveTowards(riverTransformCenter.position, transform.position, riverRadius);
                    movement.MoveToTarget(riverTargetPosition);
                    movingToRiver = true;
                    movingToFireExtinguishers = false;
                }
                else if (IsTargetingFireExtinguisherVolunteer(hit))
                {
                    currentFireExtinguisherTarget = hit.transform;
                    currentExtinguisherVolunteer = hit.transform.GetComponent<FireExtinguisherVolunteer>();
                    movement.MoveToTarget(currentFireExtinguisherTarget);
                    movingToFireExtinguishers = true;
                    movingToRiver = false;
                }
                else
                {
                    movingToRiver = false;
                    movingToFireExtinguishers = false;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (movingToRiver && Vector2.SqrMagnitude(new Vector2(riverTargetPosition.x - transform.position.x, riverTargetPosition.z - transform.position.z)) < waterGatheringDistanceTolerance)
        {
            Debug.Log("Incrementing water");
            CurrentWater = Mathf.Min(currentWater + waterGatheringSpeed, maxWater);
        }
        else if (movingToFireExtinguishers && Vector2.SqrMagnitude(new Vector2(currentFireExtinguisherTarget.position.x - transform.position.x, currentFireExtinguisherTarget.position.z - transform.position.z)) < waterGatheringDistanceTolerance)
        {
            TryGiveWaterToFireExtinguisher(CurrentWater >= waterGivingSpeed ? waterGivingSpeed : CurrentWater);
        }
    }

    private void TryGiveWaterToFireExtinguisher(float amount)
    {
        if (currentExtinguisherVolunteer.maxWater > currentExtinguisherVolunteer.CurrentWater + amount)
        {
            currentExtinguisherVolunteer.CurrentWater += amount;
            CurrentWater -= amount;
        }
        else
        {
            float toGive = currentExtinguisherVolunteer.maxWater - currentExtinguisherVolunteer.CurrentWater;
            currentExtinguisherVolunteer.CurrentWater += toGive;
            CurrentWater -= toGive;
        }
    }

    private RaycastHit RayCast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out var hit);
        return hit;
    }

    private bool IsTargetingRiver(RaycastHit hit)
    {
        return hit.transform.gameObject.layer == LayerMask.NameToLayer("River");
    }

    private bool IsTargetingFireExtinguisherVolunteer(RaycastHit hit)
    {
        FireExtinguisherVolunteer volunteer = hit.transform.GetComponent<FireExtinguisherVolunteer>();
        return volunteer != null && volunteer.enabled;
    }
}