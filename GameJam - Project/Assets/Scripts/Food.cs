using UnityEngine;

public class Food : MonoBehaviour
{
    public FoodTypes FoodType;
    public FoodTiers FoodTier;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
