using Unity.Entities;
using UnityEngine;

[AlwaysSynchronizeSystem]
public partial class EntitySpawnSystem : SystemBase
{
    private Entity _playerPrefab;
    private EntityManager _manager;

    protected override void OnStartRunning()
    {
        _manager = World.DefaultGameObjectInjectionWorld.EntityManager;

        var entityPrefabData = GetSingleton<EntityData>();
        _playerPrefab = entityPrefabData.PlayerPrefab;


        SpawnPlayer();
    }

    protected override void OnUpdate()
    {

    }

    private void SpawnPlayer()
    {
        var player = _manager.Instantiate(_playerPrefab);
    }
}
