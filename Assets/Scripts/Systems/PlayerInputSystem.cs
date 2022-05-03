using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

[AlwaysSynchronizeSystem]
public partial class PlayerInputSystem : SystemBase
{
	private Camera _camera;

	protected override void OnStartRunning()
	{
		_camera = Camera.main;
	}
	protected override void OnUpdate()
    {
		float3 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);

		Entities.ForEach((ref PlayerMovementData moveData,
						  ref PlayerFireData fireData,
						  ref PlayerInputData inputData) =>
		{
			inputData.mouseWorldPosition = mousePosition;

			moveData.direction = float3.zero;

			moveData.direction.y += Input.GetKey(inputData.upKey) ? 1 : 0;
			moveData.direction.y -= Input.GetKey(inputData.downKey) ? 1 : 0;

			moveData.direction.x += Input.GetKey(inputData.rightKey) ? 1 : 0;
			moveData.direction.x -= Input.GetKey(inputData.leftKey) ? 1 : 0;

			fireData.isFire = Input.GetKey(inputData.fireKey) ? true : false;
			fireData.isReload = Input.GetKey(inputData.reloadKey) ? true : false;

		}).Run();
	}
}
