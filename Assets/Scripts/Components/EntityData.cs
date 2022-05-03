using Unity.Entities;
using UnityEngine;

[GenerateAuthoringComponent]
public struct EntityData : IComponentData
{
    public Entity PlayerPrefab;
}
