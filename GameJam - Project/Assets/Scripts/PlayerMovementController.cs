using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] float RotationSpeed;
    [SerializeField] float Speed;


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
