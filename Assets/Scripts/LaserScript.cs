using Unity.Mathematics;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public static LaserScript main;

    [SerializeField] private LineRenderer linePrefab;

    private LineRenderer line;

    private void Awake()
    {
        if ( main != null)
        {
            Destroy(gameObject);
            return;
        }

        main = this;
    }

    private void Start()
    {
        line = Instantiate(linePrefab, transform);
        HideLaser();
    }

    public void ShowLaser(float3 laserStartPosition, float3 laserEnndPosition)
    {
        line.SetPosition(0, laserStartPosition);
        line.SetPosition(1, laserEnndPosition);
        line.enabled = true;
    }

    public void HideLaser()
    {
        line.SetPosition(0, Vector3.zero);
        line.SetPosition(1, Vector3.zero);
        line.enabled = false;
    }
}
