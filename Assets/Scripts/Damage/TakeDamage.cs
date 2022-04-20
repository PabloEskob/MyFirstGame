using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public abstract class TakeDamage : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private Color _damageReceivedColor = Color.red;

    private int _currentHealth;
    private SpriteRenderer _spriteRenderer;
    private Color _intialColor;

    private void Start()
    {
        _currentHealth = _character.MaxHealth;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _intialColor = _spriteRenderer.color;
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth = Mathf.Clamp(_currentHealth - damage, _character.MinHealth, _character.MaxHealth);

        StartCoroutine(ChangeColor(0.3f));

        if (_currentHealth == _character.MinHealth)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator ChangeColor(float duration)
    {
        var waitForSecond = new WaitForSeconds(duration);
        _spriteRenderer.color = _damageReceivedColor;
        yield return waitForSecond;

        _spriteRenderer.color = _intialColor;
    }
}