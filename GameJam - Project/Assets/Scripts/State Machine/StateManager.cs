using UnityEngine;

public class StateManager : MonoBehaviour
{
    public BaseState currentState = null;
    public ExampleState exampleState = new ExampleState();

    void Start()
    {
        SwitchState(exampleState);
    }

    void Update()
    {       
        currentState.UpdateState(this);
    }

    public void SwitchState(BaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollisionEnter(this);
    }
}
