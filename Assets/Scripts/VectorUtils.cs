using UnityEngine;

public class VectorUtils
{
    private Vector3[] _vectors =
    {
        Vector3.forward,
        Vector3.back,
        Vector3.left,
        Vector3.right,
    };

    public Vector3 GetRandomVector3()
    {
        return _vectors[Random.Range(0, _vectors.Length)];
    }
}