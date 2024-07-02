using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject[] possibleFoodPrefabs;
    public float InitialCooldown = 5;

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
            nextSpawnTime = Time.time + InitialCooldown;
            int randomIndex = Random.Range(0, possibleFoodPrefabs.Length);
            Instantiate(possibleFoodPrefabs[randomIndex], spawnPoint.transform.position, possibleFoodPrefabs[randomIndex].transform.rotation);
        }
    }

    public void Activate()
    {
        isActive = true;
        nextSpawnTime = Time.time + InitialCooldown;
    }

    public void DeActivate()
    {
        isActive = false;
    }
}
