using System.Collections;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _duration;
    [SerializeField] private LayerMask _objectSelectLayerMask;
    [SerializeField] private float _distanceRaycast;

    private void Start()
    {
        StartCoroutine(Fire(_duration));
    }

    private IEnumerator Fire(float duration)
    {
        var waitForSecond = new WaitForSeconds(duration);

        while (true)
        {
            RaycastHit2D hit2D =
                Physics2D.Raycast(_shootPoint.position, _shootPoint.right, _distanceRaycast, _objectSelectLayerMask);
            if (hit2D)
            {
                Instantiate(_bullet, _shootPoint.position, Quaternion.identity);
            }

            yield return waitForSecond;
        }
    }
}