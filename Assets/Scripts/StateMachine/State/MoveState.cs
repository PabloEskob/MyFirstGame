using UnityEngine;

public class MoveState : State
{
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);
    }
}