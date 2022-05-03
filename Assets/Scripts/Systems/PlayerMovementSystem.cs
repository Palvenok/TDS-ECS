﻿using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Transforms;
using UnityEngine;

[AlwaysSynchronizeSystem]
public partial class PlayerMovementSystem : SystemBase
{

    protected override void OnUpdate()
	{
		float deltaTime = Time.DeltaTime;

		Entities.ForEach((ref Translation transt,
						  ref Rotation rot, 
						  ref PhysicsVelocity vel, 
						  in PlayerMovementData data,
						  in PlayerInputData inputData) =>
		{
			var velocity = vel.Linear;

			float2 pos = new float2 { x = transt.Value.x, y = transt.Value.y };

			float angle = math.atan2(inputData.mouseWorldPosition.x - pos.x,
									 inputData.mouseWorldPosition.y - pos.y);// * Mathf.Rad2Deg;

			float3 angle3 = new float3 { x = 0, y = 0, z = angle};

			velocity = data.direction * data.speed;

			vel.Linear = math.lerp(vel.Linear, velocity, deltaTime * 5);
			rot.Value = quaternion.RotateZ(-angle);
		}).Run();
	}
}