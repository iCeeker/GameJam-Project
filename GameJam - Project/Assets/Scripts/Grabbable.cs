using UnityEngine;

public class Grabbable : MonoBehaviour
{
    [SerializeField] float bouncingStrength;

    [HideInInspector] public bool grabbed;

    Rigidbody rb;
    float initialHeight;
    Transform grabber;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (grabbed)
        {
            transform.localPosition = new Vector3(0, initialHeight, 0);
            transform.rotation = grabber.rotation;
        }
    }

    public void Grab(Transform parent, Vector3 position)
    {
        //transform.parent = parent;
        transform.SetParent(parent, true);
        transform.localPosition = position;
        transform.rotation = transform.rotation;
        if (rb != null)
        {
            rb.useGravity = false;
        }
        grabbed = true;
        initialHeight = transform.localPosition.y;
        grabber = parent;
    }

    public void Bounce(Vector3 direction)
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
        transform.SetParent(null, true);
        //transform.parent = null;
        rb.AddRelativeForce(direction * bouncingStrength, ForceMode.Impulse);
        rb.useGravity = true;
        grabbed = false;
    }

    public void Place(Transform targetArea)
    {
        transform.localPosition = targetArea.localPosition;
        transform.rotation = targetArea.rotation;
        transform.SetParent(null, true);
        grabbed = false;
        //transform.parent = null;
    }
}
