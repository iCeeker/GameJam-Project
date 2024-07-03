using UnityEngine;
using UnityEngine.AI;

public class NPCStateManager : MonoBehaviour
{
    public float runAwayDistance = 2;
    public float grabDistance = 1;
    public float carryHeight = 1.5F;
    [SerializeField] float timeUntilRage = 10;

    public NPCBaseState currentState = null;
    public IdleState idleState = new IdleState();
    public RunningAwayState runningAwayState = new RunningAwayState();
    public StealingState stealingState = new StealingState();
    public GrabbedState grabbedState = new GrabbedState();

    [HideInInspector] public string playerTag = "Player";
    [HideInInspector] public string grabbableTag = "Grabable";
    [HideInInspector] public Transform player;
    [HideInInspector] public NavMeshAgent agent;
    [HideInInspector] public Grabbable grabbable;
    [HideInInspector] public Grabbable grabbedObject;

    bool alreadyRaged;
    float rageDeadline = float.MaxValue;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        grabbable = GetComponent<Grabbable>();

        agent.isStopped = true;
        SwitchState(idleState);

        SetRageTime();
    }

    void Update()
    {
        if (rageDeadline <= Time.time && !alreadyRaged)
        {
            SwitchState(stealingState);
            alreadyRaged = true;
        }
        if (grabbable.grabbed)
        {
            SwitchState(grabbedState);
            if (grabbedObject != null)
            {
                grabbedObject.Bounce(transform.forward);
                grabbedObject = null;
            }
        }

        currentState.UpdateState(this);
    }

    public void SwitchState(NPCBaseState state)
    {
        if (currentState != state)
        {
            currentState = state;
            state.EnterState(this);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            player = other.gameObject.transform;
        }
        currentState.OnTriggerEnter(this, other);
    }

    private void OnTriggerExit(Collider other)
    {
        currentState.OnTriggerExit(this, other);
    }

    public void SetRageTime()
    {
        rageDeadline = Time.time + timeUntilRage;
        alreadyRaged = false;
    }
}
