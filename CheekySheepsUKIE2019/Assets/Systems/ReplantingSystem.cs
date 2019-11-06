using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class ReplantingSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((Entity entity, ref Death death, ref Health health, ref Translation translation, ref Temperature temperature) =>
        {
            if (death.isDead)
            {
                ReplantInstance[] replantInstances = VolunteerData.replantInstances.ToArray();
                foreach (ReplantInstance replantInstance in replantInstances)
                {
                    if (math.distancesq(replantInstance.position, translation.Value) <= VolunteerData.MAX_SQR_REPLANT_DISTANCE && temperature.temperature < VolunteerData.MAX_TREE_TEMP_BEFORE_DAMAGE)
                    {
                        temperature.temperature = 0;
                        death.isDead = false;
                        health.health = 100;
                        replantInstance.volunteer.Energy -= VolunteerData.PLANTER_ENERGY_LOSS_ON_REPLANT;
                        VolunteerData.replantInstances.Remove(replantInstance);
                        break;
                    }
                }
            }
        });
    }
}