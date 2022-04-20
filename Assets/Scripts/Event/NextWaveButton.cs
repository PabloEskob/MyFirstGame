using UnityEngine;

public class NextWaveButton : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private UnityEngine.UI.Button _button;

    private void OnEnable()
    {
        _spawner.AllEnemySpawned += OnAllEnemySpawned;
        _button.onClick.AddListener(OnNextButtonClick);
    }

    private void OnDisable()
    {
        _spawner.AllEnemySpawned -= OnAllEnemySpawned;
        _button.onClick.RemoveListener(OnNextButtonClick);
    }

    public void OnAllEnemySpawned()
    {
        _button.gameObject.SetActive(true);
    }

    public void OnNextButtonClick()
    {
        _spawner.NextWave();
        _button.gameObject.SetActive(false);
    }
}