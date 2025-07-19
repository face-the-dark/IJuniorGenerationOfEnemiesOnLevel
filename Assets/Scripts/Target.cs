using StaticData;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private Transform[] _wayPoints;

    private StaticDataService _staticDataService;

    private float _moveSpeed;

    private int _currentWayPointIndex = 0;

    public void Initialize(StaticDataService staticDataService) => 
        _staticDataService = staticDataService;

    private void Start() => 
        _moveSpeed = _staticDataService.ForTarget().MoveSpeed;

    private void Update()
    {
        Vector3 wayPointPosition = _wayPoints[_currentWayPointIndex].position;
        
        if (IsPositionsEquals(wayPointPosition)) 
            _currentWayPointIndex = (_currentWayPointIndex + 1) % _wayPoints.Length;

        transform.position = Vector3.MoveTowards(transform.position,
            NormalizeTargetPosition(wayPointPosition),
            _moveSpeed * Time.deltaTime);
    }

    private bool IsPositionsEquals(Vector3 wayPointPosition)
    {
        return Mathf.Approximately(transform.position.x, wayPointPosition.x) 
               && Mathf.Approximately(transform.position.z, wayPointPosition.z);
    }

    private Vector3 NormalizeTargetPosition(Vector3 targetPosition) =>
        new(targetPosition.x, transform.position.y, targetPosition.z);
}