using UnityEngine;

public class StateMachine //doesnt actually exist in our scene, doesnt need monobehaviour
{
    public State CurrentState {get; private set;}

    public void Initialize(State startingState)
    {
        CurrentState = startingState;
        CurrentState.Enter();
    }
}

