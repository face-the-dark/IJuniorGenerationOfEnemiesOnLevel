using UnityEngine;

namespace Points
{
    public class SpawnPoint : Point
    {
        [SerializeField] private EnemyType _enemyType = EnemyType.Basic;
        [SerializeField] private Transform _target;

        public EnemyType EnemyType => _enemyType;
        public Transform Target => _target;
    }
}
