using UnityEngine;

namespace StaticData.SO
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "Static Data/Enemy")]
    public class EnemyStaticData : ScriptableObject
    {
        public EnemyType EnemyType;
        
        [Range(1f, 10f)]
        public float MoveSpeed = 1f;
        
        public Enemy Prefab;
    }
}