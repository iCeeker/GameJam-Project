using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessingMachine : MonoBehaviour
{
    public FoodTypes DesiredFoodType;
    public GameObject SpawningPoint;
    public GameObject ProcessedFoodPrefab;
    public float bounceBackStrength;
    public float processingTime;

    bool isWorking;
    float finishedTime = float.MaxValue;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (finishedTime <= Time.time)
        {
            isWorking = false;
            Instantiate(ProcessedFoodPrefab, SpawningPoint.transform.position, ProcessedFoodPrefab.transform.rotation);
            //finishedTime = float.MaxValue;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Food food = collision.gameObject.GetComponent<Food>();
        if (isWorking || food == null || food.FoodType != DesiredFoodType /*|| food.FoodTier != FoodTiers.raw*/)
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * bounceBackStrength, ForceMode.Impulse);
        }
        else
        {
            Destroy(collision.gameObject);
            finishedTime = Time.time + processingTime;
            isWorking = true;
        }
    }
}
