using UnityEngine;

namespace Points
{
    public class Point : MonoBehaviour
    {
        [SerializeField] private float _gizmosSphereRadius = 1.0f;
        [SerializeField] private Color _gizmosColor = Color.red;
    
        private void OnDrawGizmos()
        {
            Gizmos.color = _gizmosColor;
            Gizmos.DrawSphere(transform.position, _gizmosSphereRadius);
        }
    }
}