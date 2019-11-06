using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguisherVolunteer : VolunteerType
{
    public static float ExtinguishingWaterDrain;
    [SerializeField] private float extinguishingWaterDrain, extinguishingEnergyDrain;
    public float maxWater;
    private float currentWater;

    public Action<bool> updateExtinguishingUI;
    public Action<float> updateWaterUI;

    protected override void Awake()
    {
        base.Awake();
        ExtinguishingWaterDrain = extinguishingWaterDrain;
        CurrentWater = maxWater;
    }

    public bool IsExtinguishing
    {
        get => isExtinguishing;
        set
        {
            isExtinguishing = value && currentWater > extinguishingWaterDrain;
            updateExtinguishingUI?.Invoke(isExtinguishing);
        }
    }

    public float CurrentWater
    {
        get => currentWater;
        set
        {
            currentWater = value;
            updateWaterUI?.Invoke(currentWater);
        }
    }

    private bool isExtinguishing;

    private void FixedUpdate()
    {
        if (IsExtinguishing)
        {
            CurrentWater -= extinguishingWaterDrain;
            Energy -= extinguishingEnergyDrain;

            if (CurrentWater < extinguishingWaterDrain)
            {
                StopExtinguishing();
            }
        }
    }

    public void StartExtinguishing()
    {
        IsExtinguishing = true;
    }

    public void StopExtinguishing()
    {
        IsExtinguishing = false;
    }

    public override void UpdateAllUI()
    {
        base.UpdateAllUI();
        updateWaterUI?.Invoke(currentWater);
        updateExtinguishingUI?.Invoke(isExtinguishing);
    }

    public override void Disband()
    {
        base.Disband();
        VolunteerData.fireExtinguisherVolunteers.Remove(this);
    }
}