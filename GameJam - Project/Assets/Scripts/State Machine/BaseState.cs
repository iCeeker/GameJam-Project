using UnityEngine;

public abstract class BaseState
{
    public abstract void EnterState(StateManager player);

    public abstract void UpdateState(StateManager player);

    public abstract void OnCollisionEnter(StateManager player);
}
