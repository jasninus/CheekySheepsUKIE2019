using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguisherVolunteer : VolunteerType
{
    [SerializeField] private float extinguishingWaterDrain, maxWater;
    private float currentWater;

    public Action<bool> updateExtinguishingUI;
    public Action<float> updateWaterUI;

    public bool IsExtinguishing
    {
        get => isExtinguishing;
        private set
        {
            isExtinguishing = value;
            updateExtinguishingUI?.Invoke(isExtinguishing);
        }
    }

    private bool isExtinguishing;

    private void FixedUpdate()
    {
        if (IsExtinguishing)
        {
            currentWater -= extinguishingWaterDrain;

            if (currentWater < extinguishingWaterDrain)
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
}