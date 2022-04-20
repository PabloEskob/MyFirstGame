using UnityEngine;

[RequireComponent(typeof(Shoot))]
[RequireComponent(typeof(BoxCollider2D))]
public class Unit : MonoBehaviour
{
    private Shoot _shoot;
    private BoxCollider2D _boxCollider2D;

    private void Awake()
    {
        _shoot = GetComponent<Shoot>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    public void RegulateVisibility(bool result)
    {
        _shoot.enabled = result;
        _boxCollider2D.enabled = result;
    }
}