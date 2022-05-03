using Unity.Entities;
using Unity.Mathematics;

[GenerateAuthoringComponent]
public struct PlayerMovementData : IComponentData
{
	public float3 direction;
	public float speed;
}
