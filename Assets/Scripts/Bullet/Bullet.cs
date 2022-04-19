using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out EnemyTakingDamage enemy))
        {
            Destroy(gameObject);
            enemy.ApplyDamage(_damage);
        }
    }
}