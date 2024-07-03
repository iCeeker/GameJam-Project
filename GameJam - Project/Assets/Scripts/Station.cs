using UnityEngine;

public abstract class Station : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;

    public void Create(GameObject grabbablePrefab, Transform parent)
    {
        GameObject grabbableInstance = Instantiate(grabbablePrefab, spawnPoint.position, grabbablePrefab.transform.rotation);
        grabbableInstance.transform.SetParent(parent, true);
        Grabbable grabbable = grabbableInstance.GetComponent<Grabbable>();
        if (grabbable != null)
        {
            grabbable.Place(spawnPoint.transform);
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
            grabbable.Place(spawnPoint.transform);
        }
    }

    public abstract void Interact(GameObject objectForInteraction);
}
