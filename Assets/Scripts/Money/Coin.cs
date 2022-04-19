using UnityEngine;

[RequireComponent(typeof(Transform))]
public class Coin : MonoBehaviour
{
    [SerializeField] private int _pointOfDeath;
    [SerializeField] private float _speed;

    private Transform _coin;
    private bool _activeSelf = true;

    public bool ActiveSelf => _activeSelf;

    private void Start()
    {
        _coin = GetComponent<Transform>();
    }

    private void Update()
    {
        _coin.Translate(Vector3.down * _speed * Time.deltaTime);

        if (_coin.transform.position.y < _pointOfDeath)
        {
            Die();
        }
    }

    private void OnMouseDown()
    {
        GlobalEvent.SendCoin();
        Die();
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }

    public void SetActive(bool choice)
    {
        gameObject.SetActive(choice);
        _activeSelf = false;
    }
}