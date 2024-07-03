using UnityEngine;

public class FoodSpawner : Station
{
    [SerializeField] GameObject[] possibleFoodPrefabs;
    [SerializeField] float initialCooldown = 5;

    float nextSpawnTime = float.MaxValue;
    bool isActive;

    void Start()
    {
        Activate();
    }

    void Update()
    {
        if (nextSpawnTime <= Time.time && isActive)
        {
            nextSpawnTime = Time.time + initialCooldown;
            int randomIndex = Random.Range(0, possibleFoodPrefabs.Length);
            Create(possibleFoodPrefabs[randomIndex]);
        }
    }

    public void Activate()
    {
        isActive = true;
        nextSpawnTime = Time.time + initialCooldown;
    }

    public void DeActivate()
    {
        isActive = false;
    }

    public override void Interact(GameObject objectForInteraction)
    {
    }
}
