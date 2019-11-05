using Unity.Entities;
using Unity.Transforms;

[UpdateInGroup(typeof(InitializationSystemGroup))]
public class RemoveDeadSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((Entity entity, ref Health health, ref Translation pos) =>
        {
            if (health.Value <= 0)
            {
               if (EntityManager.HasComponent(entity, typeof(UnitSpawner)))
                {
                    PostUpdateCommands.DestroyEntity(entity);
                    //BulletImpactPool.PlayBulletImpact(pos.Value);
                }
            }
        });
    }
}