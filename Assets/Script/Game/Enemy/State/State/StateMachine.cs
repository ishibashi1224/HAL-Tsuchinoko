using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private State currentState;

    public StateMachine()
    {
        currentState = null;
    }

    public State CurrentState
    {
        get { return currentState; }
    }

    public void ChangeState(State state)
    {
        if (currentState != null)
        {
            currentState.Uninit();
        }
        currentState = state;
        currentState.Init();
    }

    public void Update()
    {
        if (currentState != null)
        {
            currentState.Update();
        }
    }
}