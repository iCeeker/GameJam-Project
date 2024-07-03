using UnityEngine;
using System.Linq;

public class PlayerInteractionController : MonoBehaviour
{
    [SerializeField] KeyCode InteractionKey = KeyCode.LeftShift;
    [SerializeField] float carryHeight = 5;
    [SerializeField] float sphereCastRadius = 5;
    [SerializeField] float sphereCastYOffset = -1;
    [SerializeField] float sphereCastForwardOffset = 1;

    Grabbable grabbedObject;
    Vector3 sphereCastOrigin;

    string evaluationTriggerTag = "EvaluationTrigger";
    string grabbableTag = "Grabable";
    string receiverTag = "Receiver";

    void Start()
    {
        sphereCastOrigin = transform.position;
        sphereCastOrigin.y += sphereCastYOffset;
    }

    void Update()
    {
        if (Input.GetKeyDown(InteractionKey))
        {
            RaycastHit[] hits = Physics.SphereCastAll(sphereCastOrigin, sphereCastRadius, transform.forward, sphereCastForwardOffset);
            if (grabbedObject != null)
            {
                hits = hits.Where(a => a.collider.gameObject != grabbedObject.gameObject).ToArray();
            }

            if (hits.Length > 0)
            {
                Collider collider = hits.OrderBy(a => Vector3.Distance(transform.position, a.collider.transform.position)).First().collider;
                if (collider.CompareTag(evaluationTriggerTag))
                {
                    collider.GetComponent<EvaluationTrigger>().ToggleEvaluation();
                }
                else if (collider.CompareTag(grabbableTag))
                {
                    if (grabbedObject != null)
                    {
                        grabbedObject.Bounce(Vector3.forward);
                    }

                    grabbedObject = collider.GetComponent<Grabbable>();
                    grabbedObject.Grab(transform, new Vector3(0, carryHeight, 0));
                }
                else if (collider.CompareTag(receiverTag))
                {
                    if (grabbedObject != null)
                    {
                        collider.GetComponent<Station>().Interact(grabbedObject.gameObject);
                        grabbedObject = null;
                    }
                }
            }
            else if (grabbedObject != null)
            {
                grabbedObject.Bounce(Vector3.forward);
                grabbedObject = null;
            }
        }
    }

    private void OnDrawGizmos()
    {
        sphereCastOrigin = transform.position;
        sphereCastOrigin.y += sphereCastYOffset;
        Gizmos.DrawWireSphere(sphereCastOrigin + transform.forward * sphereCastForwardOffset, sphereCastRadius);
    }
}
