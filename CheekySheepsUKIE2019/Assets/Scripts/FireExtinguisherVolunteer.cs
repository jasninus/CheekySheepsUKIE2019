using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguisherVolunteer : VolunteerType
{
    public static float ExtinguishingWaterDrain;
    [SerializeField] private float extinguishingWaterDrain, maxWater;
    private float currentWater;

    public Action<bool> updateExtinguishingUI;
    public Action<float> updateWaterUI;

    private void Awake()
    {
        ExtinguishingWaterDrain = extinguishingWaterDrain;
        CurrentWater = maxWater; // TODO remove, only for testing
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

    private float CurrentWater
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
}