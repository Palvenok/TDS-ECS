using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

[UpdateInGroup(typeof(LateSimulationSystemGroup))]
public partial class CrossHairSystem : SystemBase
{
    private CrossHairData _crossHair;
    protected override void OnStartRunning()
    {
        var crossHairContainer = GetSingletonEntity<CrossHairData>();
        _crossHair = EntityManager.GetComponentData<CrossHairData>(crossHairContainer);

        Cursor.visible = false;
    }

    protected override void OnUpdate()
    {
        Entities.ForEach((
            in PlayerInputData inputData) => 
        {
            var position = inputData.mouseWorldPosition;
            position.z = -9f;
            _crossHair.crossHire.transform.position = position;
        }).WithoutBurst().Run();
    }
}
