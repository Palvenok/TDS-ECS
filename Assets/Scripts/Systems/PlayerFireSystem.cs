using System;
using UnityEngine;
using Unity.Entities;
using Cysharp.Threading.Tasks;
using Unity.Physics;
using Unity.Physics.Systems;
using Unity.Mathematics;

[AlwaysSynchronizeSystem]
public partial class PlayerFireSystem : SystemBase
{
    private int maxAmmoCount;
    private int currentAmmoCount;
    private bool isDelaed;
    private bool isReload;

    private BuildPhysicsWorld _buildPhysicsWorld;
    private CollisionWorld _collisionWorld;

    protected override void OnStartRunning()
    {
        _buildPhysicsWorld = World.GetOrCreateSystem<BuildPhysicsWorld>();

        Entities.ForEach((in PlayerFireData fireData) => 
        {
            maxAmmoCount = fireData.maxAmmoCount;
            currentAmmoCount = fireData.maxAmmoCount;
        }).WithoutBurst().Run();
    }

    protected override void OnUpdate()
    {
        Entities.ForEach((ref PlayerFireData fireData,
                          in PlayerMovementData playerMovementData) => 
        {
            if (isReload) return;

            if (fireData.isFire && fireData.currentAmmoCount > 0 && !isDelaed)
            {
                isDelaed = true;
                Shoot(fireData.fireDelayMilliseconds, 
                      playerMovementData,
                      10);
            }

            if (fireData.isReload)
            {
                isReload = true;
                fireData.currentAmmoCount = 0;
                Reload(fireData.reloadDelayMilliseconds);
            }

            fireData.currentAmmoCount = currentAmmoCount;
             
            
        }).WithoutBurst().Run();
    }

    private async void Shoot(float delay, PlayerMovementData data, float range = 5)
    {
        currentAmmoCount--;

        _collisionWorld = _buildPhysicsWorld.PhysicsWorld.CollisionWorld;

        var ray = new UnityEngine.Ray(data.position, data.direction);

        LaserScript.main.ShowLaser(ray.origin, ray.GetPoint(10));

        Debug.DrawRay(data.position, data.direction * range);

        await UniTask.Delay(TimeSpan.FromMilliseconds(delay));
        LaserScript.main.HideLaser();
        isDelaed = false;
    }

    private async void Reload(float delay)
    {
        await UniTask.Delay(TimeSpan.FromMilliseconds(delay));
        currentAmmoCount = maxAmmoCount;
        isReload = false;
    }

    private bool Raycast(float3 rayStart, float rayLenght, out Unity.Physics.RaycastHit raycastHit)
    {
        var raycastInput = new RaycastInput
        {

        };

        return _collisionWorld.CastRay(raycastInput, out raycastHit);
    }
}
