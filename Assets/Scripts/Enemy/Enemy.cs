using UnityEngine;

[CreateAssetMenu(fileName = "new Enemy", menuName = "Character/Create new Enemy")]
public class Enemy : Character
{
    [SerializeField] private int _damage;
    
    public int Damage => _damage;
}