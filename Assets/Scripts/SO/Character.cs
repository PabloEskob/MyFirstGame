using UnityEngine;

public abstract class Character : ScriptableObject
{
    [SerializeField] protected GameObject _prefab;
    [SerializeField] protected int _maxHealth;

    private int _minHealth = 0;
    
    public int MaxHealth => _maxHealth;
    public GameObject Prefab => _prefab;
    public int MinHealth => _minHealth;
}