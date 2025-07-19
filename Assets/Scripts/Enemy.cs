using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Coroutine _moveCoroutine;

    public void StartMoveCoroutine(Transform target, float moveSpeed)
    {
        if (_moveCoroutine != null)
        {
            StopCoroutine(_moveCoroutine);
            _moveCoroutine = null;
        }

        _moveCoroutine = StartCoroutine(StartMove(target, moveSpeed));
    }

    private IEnumerator StartMove(Transform target, float moveSpeed)
    {
        bool isEnabled = true;

        while (isEnabled)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

            yield return null;
        }
    }
}
