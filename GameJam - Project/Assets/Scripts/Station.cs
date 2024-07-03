using UnityEngine;

public abstract class Station : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;

    public void Create(GameObject grabbablePrefab)
    {
        GameObject grabbableInstance = Instantiate(grabbablePrefab, spawnPoint.position, grabbablePrefab.transform.rotation);
        Grabbable grabbable = grabbableInstance.GetComponent<Grabbable>();
        if (grabbable != null)
        {
            grabbable.Bounce(spawnPoint.forward);
        }
        else
        {
            Destroy(grabbableInstance);
        }
    }

    public void Eject(Grabbable grabbable)
    {
        if (grabbable != null)
        {
            grabbable.Grab(transform, spawnPoint.localPosition);
            grabbable.Bounce(transform.forward);
        }
    }

    public abstract void Interact(GameObject objectForInteraction);
}
