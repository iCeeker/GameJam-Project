using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{
    public KeyCode InteractionKey = KeyCode.LeftShift;
    public float CarryHeight = 5;
    public float ThrowingPower = 5;

    GameObject currentTarget;
    GameObject grabbedObject;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(InteractionKey))
        {
            if (grabbedObject == null)
            {
                if (currentTarget != null)
                {
                    grabbedObject = currentTarget;
                    grabbedObject.transform.SetParent(transform, false);
                    grabbedObject.transform.localPosition = new Vector3(0, CarryHeight, 0);
                    grabbedObject.transform.rotation = transform.rotation;
                    grabbedObject.GetComponent<Rigidbody>().useGravity = false;
                }
            }
            else
            {
                grabbedObject.transform.parent = null;
                Rigidbody grabbedObjectRB = grabbedObject.GetComponent<Rigidbody>();
                grabbedObjectRB.AddRelativeForce(Vector3.forward * ThrowingPower, ForceMode.Impulse);
                grabbedObjectRB.useGravity = true;
                grabbedObject = null;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Grabable"))
        {
            currentTarget = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == currentTarget)
        {
            currentTarget = null;
        }
    }
}
