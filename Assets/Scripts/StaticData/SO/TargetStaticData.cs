using UnityEngine;

namespace StaticData.SO
{
    [CreateAssetMenu(fileName = "Target", menuName = "Static Data/Target")]
    public class TargetStaticData : ScriptableObject
    {
        [Range(1f, 10f)]
        public float MoveSpeed = 1f;
    }
}