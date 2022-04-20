using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _pointOfDeath;
    [SerializeField] private float _speed;
    
    private bool _activeSelf = true;

    public bool ActiveSelf => _activeSelf;
    
    private void Update()
    {
        gameObject.transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (gameObject.transform.position.y < _pointOfDeath)
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