using System;
using System.Collections;
using Unity.Entities;
using UnityEngine;
using Cysharp.Threading.Tasks;

[AlwaysSynchronizeSystem]
public partial class PlayerFireSystem : SystemBase
{
    private int maxAmmoCount;
    private int currentAmmoCount;
    private bool isDelaed;
    private bool isReload;

    protected override void OnStartRunning()
    {
        Entities.ForEach((in PlayerFireData fireData) => 
        {
            maxAmmoCount = fireData.maxAmmoCount;
            currentAmmoCount = fireData.maxAmmoCount;
        }).WithoutBurst().Run();
    }

    protected override void OnUpdate()
    {
        Entities.ForEach((ref PlayerFireData fireData) => 
        {
            if (isReload) return;

            if (fireData.isFire && fireData.currentAmmoCount > 0 && !isDelaed)
            {
                isDelaed = true;
                Shoot(fireData.fireDelayMilliseconds);
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

    private async void Shoot(float delay)
    {
        currentAmmoCount--;
        await UniTask.Delay(TimeSpan.FromMilliseconds(delay));
        isDelaed = false;
    }

    private async void Reload(float delay)
    {
        await UniTask.Delay(TimeSpan.FromMilliseconds(delay));
        currentAmmoCount = maxAmmoCount;
        isReload = false;
    }
}
