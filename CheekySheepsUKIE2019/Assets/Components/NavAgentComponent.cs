using Unity.Entities;
using Unity.Mathematics;


public enum NavAgentStatus
{
    Idle = 1,
    Moving = 1,
}


public struct UnitNavAgent : IComponentData
{
    public float3 finalDestination;
    public NavAgentStatus agentStatus;
}
