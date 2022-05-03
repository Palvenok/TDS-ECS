using Unity.Entities;

[UpdateInGroup(typeof(LateSimulationSystemGroup))]
public partial class GameUiSystem : SystemBase
{
    private PlayerFireUiData _gameUiData;

    protected override void OnStartRunning()
    {
        var textContainer = GetSingletonEntity<PlayerFireUiData>();
        _gameUiData = EntityManager.GetComponentData<PlayerFireUiData>(textContainer);
    }

    protected override void OnUpdate()
    {
        Entities.ForEach((in PlayerFireData playerFireData) =>
        {
            _gameUiData.ammoCountText.text = $"Ammo: {playerFireData.currentAmmoCount}";
        }).WithoutBurst().Run();
    }
}
