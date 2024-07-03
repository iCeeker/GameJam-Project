using UnityEngine;

public abstract class NPCBaseState
{
    public abstract void EnterState(NPCStateManager npc);

    public abstract void UpdateState(NPCStateManager npc);

    public abstract void OnTriggerEnter(NPCStateManager npc, Collider other);

    public abstract void OnTriggerExit(NPCStateManager npc, Collider other);
}
