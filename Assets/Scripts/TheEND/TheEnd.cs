using UnityEngine;

public class TheEnd : MonoBehaviour
{
    [SerializeField] private Loss _loss;
    [SerializeField] private GameObject _panel;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out EnemyStateMachine enemyStateMachine))
        {
            _loss.OpenPanel(_panel);
        }
    }
}