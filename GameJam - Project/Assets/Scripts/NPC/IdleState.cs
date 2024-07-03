using UnityEngine;

public class IdleState : NPCBaseState
{
    public override void EnterState(NPCStateManager npc)
    {
    }

    public override void UpdateState(NPCStateManager npc)
    {
    }

    public override void OnTriggerEnter(NPCStateManager npc, Collider other)
    {
        if(other.CompareTag(npc.playerTag))
        {
            npc.SwitchState(npc.runningAwayState);
        }
    }

    public override void OnTriggerExit(NPCStateManager npc, Collider other)
    {
    }
}
