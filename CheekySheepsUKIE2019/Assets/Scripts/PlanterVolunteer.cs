using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanterVolunteer : VolunteerType
{
    public Action<uint> updateSeedUI;
    public Action<bool> updateReplantingUI;

    private bool isReplanting;

    public uint seedsLeft;

    public uint SeedsLeft
    {
        get => seedsLeft;
        set
        {
            seedsLeft = value;
            if (seedsLeft == 0)
            {
                Disband();
            }

            updateSeedUI?.Invoke(seedsLeft);
        }
    }

    public bool IsReplanting
    {
        get => isReplanting;
        set
        {
            isReplanting = value;
            updateReplantingUI?.Invoke(isReplanting);
        }
    }

    private void Update()
    {
        Debug.Log("Hello");
    }

    private void Disband()
    {
        Debug.Log("Hey ho, we are disbanding yo");
    }
}