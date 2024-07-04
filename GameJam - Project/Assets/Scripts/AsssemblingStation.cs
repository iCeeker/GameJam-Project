using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AsssemblingStation : Station
{
    public GameObject[] TestIndicators;

    List<FoodTypes> currentPlatter { get; set; }

    void Start()
    {
        currentPlatter = new List<FoodTypes>();
    }

    public int ClearAndGetPoints()
    {
        int score = currentPlatter.Count;
        currentPlatter.Clear();
        foreach (GameObject indicator in TestIndicators)
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
                    TestIndicators[1].SetActive(true);
                    break;
                case FoodTypes.beef:
                    TestIndicators[2].SetActive(true);
                    break;
                case FoodTypes.bread:
                    TestIndicators[0].SetActive(true);
                    break;
                case FoodTypes.cheese:
                    TestIndicators[3].SetActive(true);
                    break;
            }
        }
    }
}
