using Unity.Entities;
using UnityEngine;

[AlwaysSynchronizeSystem]
public partial class EntitySpawnSystem : SystemBase
{
    private Entity _playerPrefab;

    protected override void OnStartRunning()
    {
        var entityPrefabData = GetSingleton<EntityData>();
        _playerPrefab = entityPrefabData.PlayerPrefab;

        SpawnPlayer();
    }

    protected override void OnUpdate()
    {

    }

    private void SpawnPlayer()
    {
        var player = EntityManager.Instantiate(_playerPrefab);
    }
}
