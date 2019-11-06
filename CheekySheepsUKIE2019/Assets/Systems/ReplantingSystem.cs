using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class ReplantingSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((Entity entity, ref Death death, ref Health health, ref Translation translation) =>
        {
            if (death.isDead)
            {
                ReplantInstance[] replantInstances = VolunteerData.replantInstances.ToArray();
                foreach (ReplantInstance replantInstance in replantInstances)
                {
                    if (math.distancesq(replantInstance.position, translation.Value) <= VolunteerData.MAX_SQR_REPLANT_DISTANCE)
                    {
                        death.isDead = false;
                        health.health = 100;
                        replantInstance.volunteer.SeedsLeft--;
                        VolunteerData.replantInstances.Remove(replantInstance);
                        break;
                    }
                }
            }
        });
    }
}