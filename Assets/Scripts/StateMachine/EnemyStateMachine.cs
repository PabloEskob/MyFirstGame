using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private State _firstState;

    private State _curentState;

    private void Start()
    {
        Reset();
    }

    private void Update()
    {
        if (_curentState == null)
        {
            return;
        }

        var nextState = _curentState.GetNextState();

        if (nextState != null)
        {
            Transit(nextState);
        }
    }

    private void Reset()
    {
        _curentState = _firstState;

        if (_curentState != null)
        {
            _curentState.Enter();
        }
    }

    private void Transit(State nextState)
    {
        if (_curentState != null)
        {
            _curentState.Exit();
        }

        _curentState = nextState;

        if (_curentState != null)
        {
            _curentState.Enter();
        }
    }
}