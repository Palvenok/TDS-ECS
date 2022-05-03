using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

[AlwaysSynchronizeSystem]
public partial class PlayerInputSystem : SystemBase
{

    protected override void OnUpdate()
    {
		Entities.ForEach((ref PlayerMovementData moveData, in PlayerInputData inputData) =>
		{
			moveData.direction = float3.zero;

			moveData.direction.y += Input.GetKey(inputData.upKey) ? 1 : 0;
			moveData.direction.y -= Input.GetKey(inputData.downKey) ? 1 : 0;

			moveData.direction.x += Input.GetKey(inputData.rightKey) ? 1 : 0;
			moveData.direction.x -= Input.GetKey(inputData.leftKey) ? 1 : 0;
		}).Run();
	}
}
