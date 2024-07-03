using UnityEngine;

public class Food : MonoBehaviour
{
    public FoodTypes FoodType;
    public FoodTiers FoodTier;
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
