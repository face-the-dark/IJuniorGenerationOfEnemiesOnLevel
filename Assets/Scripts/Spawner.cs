using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Script : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private float _spawnDelay = 2.0f;
    [SerializeField] private Transform[] _spawnPoints;

    private VectorUtils _vectorUtils;
    private Coroutine _spawnCoroutine;

    private void Awake()
    {
        _vectorUtils = new VectorUtils();
    }

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
            Spawn();

            yield return wait;
        }
    }

    private void Spawn()
    {
        Enemy enemy = Instantiate(_prefab, ChooseRandomSpawnPosition(), Quaternion.identity);
        enemy.StartCoroutineMove(ChooseEnemyMoveDirection());
    }

    private Vector3 ChooseRandomSpawnPosition()
    {
        Vector3 spawnPointPosition = _spawnPoints[Random.Range(0, _spawnPoints.Length)].position;
        float prefabPositionY = _prefab.transform.position.y;

        Vector3 spawnPosition = new Vector3(spawnPointPosition.x, prefabPositionY, spawnPointPosition.z);

        return spawnPosition;
    }

    private Vector3 ChooseEnemyMoveDirection()
    {
        return _vectorUtils.GetRandomVector3();
    }
}
