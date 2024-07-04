using System.Collections.Generic;
using UnityEngine;

public class EvaluationTrigger : MonoBehaviour
{
    [SerializeField] AsssemblingStation[] assemblingStations;
    [SerializeField] ArenaIndex arenaIndex;

    public void ToggleEvaluation()
    {
        GameManager.Instance.AddPoints(assemblingStations, arenaIndex);   
    }
}
