using UnityEngine;

public class EvaluationTrigger : MonoBehaviour
{
    [SerializeField] AsssemblingStation[] assemblingStations;

    public void ToggleEvaluation()
    {
        int summedUpScore = 0;
        foreach (AsssemblingStation station in assemblingStations)
        {
            summedUpScore = station.ClearAndGetPoints();
        }

        // TODO: Evaluate via GameManager
    }
}
