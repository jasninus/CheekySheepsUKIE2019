using System;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine.Jobs;

public class HeatSystem : JobComponentSystem
{
    private EntityQuery heatGroup;

    protected override void OnCreate()
    {
        heatGroup = GetEntityQuery(typeof(Temperature), typeof(Translation));
    }

    [BurstCompile]
    private struct HeatJob : IJobForEach<Temperature, Translation>
    {
        [NativeDisableParallelForRestriction] [DeallocateOnJobCompletion] public NativeArray<Temperature> temperatures;
        [DeallocateOnJobCompletion] [ReadOnly] public NativeArray<Translation> compareTranslations;

        [DeallocateOnJobCompletion] [ReadOnly] public NativeArray<float3> activeFireExtinguisherPositions;

        public float sqrHeatPropagationCutoffDist, maxHeat;
        public double heatPropagationWeight, extinguishingWeight, sqrFireExtinguishingCutoffRadius;

        public void Execute(ref Temperature temperature, ref Translation translation)
        {
            bool beingExtinguished = false;
            for (int i = 0; i < activeFireExtinguisherPositions.Length; i++)
            {
                double sqrDis = math.pow(activeFireExtinguisherPositions[i].x - translation.Value.x, 2) +
                                math.pow(activeFireExtinguisherPositions[i].z - translation.Value.z, 2);

                //math.distancesq(activeFireExtinguisherPositions[i], translation.Value);

                //math.distancesq(
                //    new float2(activeFireExtinguisherPositions[i].x, activeFireExtinguisherPositions[i].z),
                //    new float2(translation.Value.x, translation.Value.z));

                if (sqrDis < sqrFireExtinguishingCutoffRadius)
                {
                    beingExtinguished = true;
                    temperature.temperature = math.max(temperature.temperature - extinguishingWeight / sqrDis, 0);
                }
            }

            if (beingExtinguished)
            {
                return;
            }

            for (int i = 0; i < compareTranslations.Length; i++)
            {
                double sqrDis = math.pow(compareTranslations[i].Value.x - translation.Value.x, 2) +
                                math.pow(compareTranslations[i].Value.z - translation.Value.z, 2);

                if (sqrDis > 0 && sqrDis <= sqrHeatPropagationCutoffDist)
                {
                    temperature.temperature = math.min(temperature.temperature + (heatPropagationWeight * temperatures[i].temperature) / sqrDis, maxHeat);
                }
            }
        }
    }

    protected override JobHandle OnUpdate(JobHandle inputDependencies)
    {
        float3[] extPos = VolunteerData.GetActiveFireExtinguisherVolunteers();
        NativeArray<float3> extinguisherPosition = new NativeArray<float3>(extPos, Allocator.Persistent);

        var job = new HeatJob()
        {
            temperatures = heatGroup.ToComponentDataArray<Temperature>(Allocator.TempJob),
            compareTranslations = heatGroup.ToComponentDataArray<Translation>(Allocator.TempJob),
            activeFireExtinguisherPositions = extinguisherPosition,
            maxHeat = 100,
            sqrFireExtinguishingCutoffRadius = 25,
            extinguishingWeight = 0.1,
            sqrHeatPropagationCutoffDist = 100,
            heatPropagationWeight = 0.01
        };

        return job.Schedule(heatGroup, inputDependencies);
    }
}