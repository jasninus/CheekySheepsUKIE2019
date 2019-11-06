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

    public static readonly float MAX_SQR_REPLANT_DISTANCE = 20;

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