using UnityEngine;

public class GrabbedState : NPCBaseState
{
    public override void EnterState(NPCStateManager npc)
    {
        npc.agent.isStopped = true;
    }

    public override void OnTriggerEnter(NPCStateManager npc, Collider other)
    {
    }

    public override void OnTriggerExit(NPCStateManager npc, Collider other)
    {
    }

    public override void UpdateState(NPCStateManager npc)
    {
        if(!npc.grabbable.grabbed)
        {
            npc.SwitchState(npc.runningAwayState);
            npc.SetRageTime();
        }
    }
}
