using UnityEngine;

public abstract class Character : ScriptableObject
{
    [SerializeField] protected int _maxHealth;

    private int _minHealth = 0;

    public int MaxHealth => _maxHealth;
    public int MinHealth => _minHealth;
}