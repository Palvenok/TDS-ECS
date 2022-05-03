using Unity.Entities;
using UnityEngine;

[GenerateAuthoringComponent]
public struct PlayerInputData : IComponentData
{
	public KeyCode upKey;
	public KeyCode leftKey;
	public KeyCode downKey;
	public KeyCode rightKey;
}
