using Unity.Entities;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public Camera cam;
	public GameObject playerPrefab;

	private Entity _entityPrefab;
	private Vector3 _mousePosition;
	private EntityManager _manager;

	public Vector3 MousePosition => _mousePosition;


    private void Awake()
	{
		_manager = World.DefaultGameObjectInjectionWorld.EntityManager;
		var epd = GetComponent<EntityData>();
		_entityPrefab = epd.PlayerPrefab;
		SpawnPlayer();
	}

    private void Update()
    {
		_mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
	}

    private void SpawnPlayer()
    {
		var player = _manager.Instantiate(_entityPrefab);
    }
}

