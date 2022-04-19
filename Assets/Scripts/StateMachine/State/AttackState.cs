using UnityEngine;

public class AttackState : State
{
    [SerializeField] private float _delay;
    [SerializeField] private Enemy _enemy;

    private DefenderTakingDamage _defenderTakingDamage;

    private int _damage;
    private float _lastAttackTime;

    private void Start()
    {
        _damage = _enemy.Damage;
    }

    private void Update()
    {
        if (_defenderTakingDamage != null)
        {
            if (_lastAttackTime <= 0)
            {
                _defenderTakingDamage.ApplyDamage(_damage);
                _lastAttackTime = _delay;
            }

            _lastAttackTime -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out DefenderTakingDamage defender))
        {
            _defenderTakingDamage = defender;
        }
    }
}