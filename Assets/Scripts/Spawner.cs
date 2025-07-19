using System.Collections;
using Points;
using StaticData;
using StaticData.SO;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _spawnDelay = 2.0f;
    [SerializeField] private SpawnPoint[] _spawnPoints;

    private StaticDataService _staticDataService;
    private Coroutine _spawnCoroutine;

    public void Initialize(StaticDataService staticDataService) => 
        _staticDataService = staticDataService;

    private void Start()
    {
        if (_spawnCoroutine != null)
        {
            StopCoroutine(_spawnCoroutine);
            _spawnCoroutine = null;
        }

        _spawnCoroutine = StartCoroutine(StartSpawn());
    }

    private IEnumerator StartSpawn()
    {
        WaitForSeconds wait = new WaitForSeconds(_spawnDelay);

        bool isEnabled = true;

        while (isEnabled)
        {
            CreateEnemy();

            yield return wait;
        }
    }

    private void CreateEnemy()
    {
        SpawnPoint spawnPoint = ChooseRandomSpawnPoint();
        EnemyStaticData enemyStaticData = _staticDataService.ForEnemy(spawnPoint.EnemyType);

        Vector3 normalizeSpawnPosition = NormalizeSpawnPosition(spawnPoint.transform.position, enemyStaticData.Prefab.transform.position);

        Enemy enemy = Instantiate(enemyStaticData.Prefab, normalizeSpawnPosition, Quaternion.identity);
        enemy.StartMoveCoroutine(spawnPoint.Target, enemyStaticData.MoveSpeed);
    }

    private Vector3 NormalizeSpawnPosition(Vector3 spawnPointPosition, Vector3 prefabPosition) => 
        new(spawnPointPosition.x, prefabPosition.y, spawnPointPosition.z);

    private SpawnPoint ChooseRandomSpawnPoint() => 
        _spawnPoints[Random.Range(0, _spawnPoints.Length)];
}
