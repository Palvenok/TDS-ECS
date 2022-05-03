using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

[GenerateAuthoringComponent]
public struct PlayerInputData : IComponentData
{
	public KeyCode upKey;
	public KeyCode leftKey;
	public KeyCode downKey;
	public KeyCode rightKey;
	[Space]
	public KeyCode fireKey;
	public KeyCode reloadKey;
	[Space]
	public float3 mouseWorldPosition;
}
