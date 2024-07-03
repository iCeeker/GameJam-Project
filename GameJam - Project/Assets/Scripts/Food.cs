using UnityEngine;

public class Food : MonoBehaviour
{
    public FoodTypes FoodType;
    public FoodTiers FoodTier;

    [SerializeField] GameObject npcPrefab;
    [SerializeField] float timeUntilExpiration = 10;

    float expirationTime = float.MaxValue;
    NPCStateManager npcStateManager;
    void Start()
    {
        npcStateManager = GetComponent<NPCStateManager>();
        expirationTime = Time.time + timeUntilExpiration;
    }

    void Update()
    {
        if (expirationTime <= Time.time && npcStateManager == null)
        {
            Instantiate(npcPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}



public enum FoodTypes
{
    bread,
    salad,
    cheese,
    beef
}

public enum FoodTiers
{
    raw,
    processed
}
