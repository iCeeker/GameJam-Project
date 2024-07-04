using System.Collections.Generic;
using UnityEngine;

public class EvaluationTrigger : MonoBehaviour
{
    [SerializeField] AsssemblingStation[] assemblingStations;
    [SerializeField] ArenaIndex arenaIndex;
    [SerializeField] AudioClip dingsound;

    public void ToggleEvaluation()
    {
        SoundManager soundManager = GameObject.Find("AudioManger 1").GetComponent<SoundManager>();
        soundManager.PlaySound(dingsound);
        GameManager.Instance.AddPoints(assemblingStations, arenaIndex);   
    }
}
