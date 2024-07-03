using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AsssemblingStation : Station
{
    [SerializeField] GameObject[] testIndicator;

    List<FoodTypes> currentPlatter { get; set; }

    void Start()
    {
        currentPlatter = new List<FoodTypes>();
    }

    public int ClearAndGetPoints()
    {
        int score = currentPlatter.Count;
        currentPlatter.Clear();
        foreach (GameObject indicator in testIndicator)
        {
            indicator.SetActive(false);
        }
        return score;
    }

    public override void Interact(GameObject objectForInteraction)
    {
        Food food = objectForInteraction.GetComponent<Food>();
        if (food == null || food.FoodTier != FoodTiers.processed || currentPlatter.Any(a => a == food.FoodType) || currentPlatter.Count == 4)
        {
            Grabbable grabbable = objectForInteraction.GetComponent<Grabbable>();
            Eject(grabbable);
        }
        else
        {
            currentPlatter.Add(food.FoodType);
            Destroy(objectForInteraction);

            // Only for Testing
            switch (food.FoodType)
            {
                case FoodTypes.salad:
                    testIndicator[1].SetActive(true);
                    break;
                case FoodTypes.beef:
                    testIndicator[2].SetActive(true);
                    break;
                case FoodTypes.bread:
                    testIndicator[0].SetActive(true);
                    break;
                case FoodTypes.cheese:
                    testIndicator[3].SetActive(true);
                    break;
            }
        }
    }
}
