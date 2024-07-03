using System.Linq;
using UnityEngine;

public class StealingState : NPCBaseState
{
    GameObject target;

    public override void EnterState(NPCStateManager npc)
    {
    }

    public override void UpdateState(NPCStateManager npc)
    {
        GameObject[] allGrabables = GameObject.FindGameObjectsWithTag(npc.grabbableTag);

        GameObject[] possibleTargets = allGrabables.Where(a => a.GetComponent<Food>()?.FoodTier == FoodTiers.processed).ToArray();
        if (possibleTargets.Length > 0)
        {
            target = GetNearestTarget(possibleTargets, npc.transform.position);
        }
        else
        {
            possibleTargets = allGrabables.Where(a => a.GetComponent<Food>()?.FoodTier == FoodTiers.raw && a.GetComponent<NPCStateManager>() == null).ToArray();
            if (possibleTargets.Length > 0)
            {
                target = GetNearestTarget(possibleTargets, npc.transform.position);
            }
            else
            {
                npc.agent.isStopped = true;
            }
        }

        if (target != null)
        {
            npc.agent.isStopped = false;
            npc.agent.SetDestination(target.transform.position);

            Grabbable grabbable = target.GetComponent<Grabbable>();
            if (grabbable != null && Vector3.Distance(target.transform.position, npc.transform.position) <= npc.grabDistance)
            {
                grabbable.Grab(npc.transform, new Vector3(0, npc.carryHeight, 0));
                npc.grabbedObject = grabbable;
                npc.SwitchState(npc.idleState);
            }
        }
    }

    public override void OnTriggerEnter(NPCStateManager npc, Collider other)
    {
    }

    public override void OnTriggerExit(NPCStateManager npc, Collider other)
    {
    }

    GameObject GetNearestTarget(GameObject[] possibleTargets, Vector3 position)
    {
        return possibleTargets.OrderBy(a => Vector3.Distance(a.transform.position, position)).First();
    }
}
