using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public static class VolunteerData
{
    public static List<FireExtinguisherVolunteer> fireExtinguisherVolunteers = new List<FireExtinguisherVolunteer>();
    public static List<ReplantInstance> replantInstances = new List<ReplantInstance>();

    public static readonly float MAX_SQR_REPLANT_DISTANCE = 20, MAX_TREE_TEMP_BEFORE_DAMAGE = 80f, PLANTER_ENERGY_LOSS_ON_REPLANT = 5F, ANIMAL_SAVER_ENERGY_LOSS_ON_SAVE = 5F;

    public static float3[] GetActiveFireExtinguisherVolunteers()
    {
        return fireExtinguisherVolunteers.Where(v => v.IsExtinguishing).Select(v => (float3)v.transform.position).ToArray();
    }
}

public struct ReplantInstance
{
    public PlanterVolunteer volunteer;
    public float3 position;
}