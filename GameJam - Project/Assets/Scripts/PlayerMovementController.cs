using System;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public float RotationSpeed;
    public float Speed;

    void Start()
    {

    }

    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);


        if (direction != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = rotation;
            transform.Translate(direction * Speed * Time.deltaTime, Space.World);
        }
    }
}
