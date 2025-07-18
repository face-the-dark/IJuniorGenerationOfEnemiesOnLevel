using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1.0f;

    private Coroutine _moveCoroutine;

    public void StartCoroutineMove(Vector3 direction)
    {
        if (_moveCoroutine != null)
        {
            StopCoroutine(_moveCoroutine);
            _moveCoroutine = null;
        }

        _moveCoroutine = StartCoroutine(StartMove(direction));
    }

    private IEnumerator StartMove(Vector3 direction)
    {
        bool isEnabled = true;

        while (isEnabled)
        {
            transform.Translate(direction * (_moveSpeed * Time.deltaTime), Space.World);
            
            yield return null;
        }
    }
}
