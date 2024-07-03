using UnityEngine;

public class RunningAwayState : NPCBaseState
{
    public override void EnterState(NPCStateManager npc)
    {
    }

    public override void UpdateState(NPCStateManager npc)
    {
        Vector3 direction = (npc.transform.position - npc.player.position).normalized;

        npc.agent.isStopped = false;
        npc.agent.SetDestination(npc.transform.position + direction * npc.runAwayDistance);
    }

    public override void OnTriggerEnter(NPCStateManager npc, Collider other)
    {
    }

    public override void OnTriggerExit(NPCStateManager npc, Collider other)
    {
        if (other.CompareTag(npc.playerTag))
        {
            npc.SwitchState(npc.idleState);
            npc.agent.isStopped = true;
        }
    }
}
