using Unity.Entities;
using Unity.Mathematics;

[GenerateAuthoringComponent]
public struct PlayerMovementData : IComponentData
{
	public float3 position;
	public float3 direction;
	public float3 velocity;
	public float speed;
}
