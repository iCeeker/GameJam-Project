using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance { get; private set; }

    [SerializeField] GameObject[] possibleFoodPrefabs;
    [SerializeField] GameObject[] Player1Tubes;
    [SerializeField] GameObject[] Player2Tubes;
    [SerializeField] int objectCap = 15;
    [SerializeField] int npcCap = 5;
    [SerializeField] float initialCooldownMin = 2;
    [SerializeField] float initialCooldownMax = 5;
    [SerializeField] BoxCollider player1Zone;
    [SerializeField] BoxCollider player2Zone;

    float nextSpawnTime = float.MaxValue;
    string grabbableTag = "Grabable";

    public SpawnManager()
    {
        Instance = this;
    }

    void Start()
    {
        nextSpawnTime = Time.time + Random.Range(initialCooldownMin, initialCooldownMax);
    }

    void Update()
    {
        if (nextSpawnTime <= Time.time)
        {
            if (CheckGrabbableCap(player1Zone))
            {
                Spawn(Player1Tubes);
            }
            if (CheckGrabbableCap(player2Zone))
            {
                Spawn(Player2Tubes);
            }
            nextSpawnTime = Time.time + Random.Range(initialCooldownMin, initialCooldownMax);
        }
    }

    void Spawn(GameObject[] possibleTubes)
    {
        int randomFoodIndex = Random.Range(0, possibleFoodPrefabs.Length);
        int randomTubeIndex = Random.Range(0, possibleTubes.Length);
        FoodSpawner tube = possibleTubes[randomTubeIndex].GetComponent<FoodSpawner>();
        if (tube != null)
        {
            tube.Create(possibleFoodPrefabs[randomFoodIndex], possibleTubes[randomTubeIndex].transform);
        }
    }

    bool CheckGrabbableCap(BoxCollider zone)
    {
        GameObject[] foundObjects = GameObject.FindGameObjectsWithTag(grabbableTag);
        foundObjects = foundObjects.Where(a => zone.bounds.Contains(a.transform.position)).ToArray();
        return foundObjects.Length <= objectCap;
    }

    public bool CheckNPCCap(GameObject sender)
    {
        BoxCollider zone = new BoxCollider();
        if(player1Zone.bounds.Contains(sender.transform.position))
        {
            zone = player1Zone;
        }
        if (player2Zone.bounds.Contains(sender.transform.position))
        {
            zone = player2Zone;
        }
        if (zone == null)
        {
            return false;
        }
        GameObject[] foundObjects = GameObject.FindGameObjectsWithTag(grabbableTag);
        foundObjects = foundObjects.Where(a => zone.bounds.Contains(a.transform.position) && a.GetComponent<NPCStateManager>() != null).ToArray();
        return foundObjects.Length <= npcCap;
    }
}
