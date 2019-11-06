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

        public float sqrHeatPropagationCutoffDist;
        public double heatPropagationWeight;

        public void Execute(ref Temperature temperature, ref Translation translation)
        {
            for (int i = 0; i < compareTranslations.Length; i++)
            {
                double sqrDis = math.pow(compareTranslations[i].Value.x - translation.Value.x, 2) +
                                math.pow(compareTranslations[i].Value.z - translation.Value.z, 2);

                if (sqrDis > 0 && sqrDis <= sqrHeatPropagationCutoffDist)
                {
                    temperature.temperature += (heatPropagationWeight * temperatures[i].temperature) / sqrDis;
                }
            }
        }
    }

    protected override JobHandle OnUpdate(JobHandle inputDependencies)
    {
        var job = new HeatJob()
        {
            temperatures = heatGroup.ToComponentDataArray<Temperature>(Allocator.TempJob),
            compareTranslations = heatGroup.ToComponentDataArray<Translation>(Allocator.TempJob),
            sqrHeatPropagationCutoffDist = 100,
            heatPropagationWeight = 0.01
        };

        return job.Schedule(heatGroup, inputDependencies);
    }

    private static bool CheckCollision(float3 posA, float3 posB, float radiusSqr)
    {
        float3 delta = posA - posB;
        float distanceSquare = delta.x * delta.x + delta.z * delta.z;

        return distanceSquare <= radiusSqr;
    }
}