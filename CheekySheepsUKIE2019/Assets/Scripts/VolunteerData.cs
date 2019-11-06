using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public static class VolunteerData
{
    private static List<FireExtinguisherVolunteer> fireExtinguisherVolunteers = new List<FireExtinguisherVolunteer>();

    public static float3[] GetActiveFireExtinguisherVolunteers()
    {
        return fireExtinguisherVolunteers.Where(v => v.IsExtinguishing).Select(v => (float3)v.transform.position).ToArray();
    }
}