using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Script : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private float _spawnDelay = 2.0f;
    [SerializeField] private Transform[] _spawnpoints;

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
        Spawn();
        
        yield return new WaitForSeconds(_spawnDelay);
    }

    private void Spawn()
    {
        Enemy enemy = Instantiate(_prefab, ChooseRandomSpawnPosition(), Quaternion.identity);
        enemy.StartCoroutineMove(ChooseEnemyMoveDirection());
    }

    private Vector3 ChooseRandomSpawnPosition()
    {
        return _spawnpoints[Random.Range(0, _spawnpoints.Length)].position;
    }

    private Vector3 ChooseEnemyMoveDirection()
    {
        return _vectorUtils.GetRandomVector3();
    }
}
