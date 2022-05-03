using Unity.Entities;

[GenerateAuthoringComponent]
public struct PlayerFireData : IComponentData
{
    public bool isFire;
    public bool isReload;
    public float fireDelayMilliseconds;
    public float reloadDelayMilliseconds;
    public int maxAmmoCount;
    public int currentAmmoCount;
}
