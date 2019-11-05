using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguisherVolunteer : VolunteerType
{
    [SerializeField] private float extinguishingWaterDrain, maxWater;
    private float currentWater;

    public bool IsExtinguishing { get; private set; }

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