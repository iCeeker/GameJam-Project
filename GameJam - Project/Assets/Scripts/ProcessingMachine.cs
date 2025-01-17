using UnityEngine;

public class ProcessingMachine : Station
{
    [SerializeField] FoodTypes desiredFoodType;
    [SerializeField] GameObject processedFoodPrefab;
    [SerializeField] float processingTime = 3;
    [SerializeField] ParticleSystem particles;

    bool isWorking;
    float finishedTime = float.MaxValue;

    void Update()
    {
        if (finishedTime <= Time.time)
        {
            isWorking = false;
            particles.Stop();
            Create(processedFoodPrefab, transform);
            finishedTime = float.MaxValue;
        }
    }

    public override void Interact(GameObject objectForInteraction)
    {
        Food food = objectForInteraction.GetComponent<Food>();
        if (isWorking || food == null || food.FoodType != desiredFoodType || food.FoodTier != FoodTiers.raw)
        {
            Grabbable grabbable = objectForInteraction.GetComponent<Grabbable>();
            Eject(grabbable);
        }
        else
        {
            Destroy(objectForInteraction);
            finishedTime = Time.time + processingTime;
            particles.Play();            
            isWorking = true;
        }
    }
}
