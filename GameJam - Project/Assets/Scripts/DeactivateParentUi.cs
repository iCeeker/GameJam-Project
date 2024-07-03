using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateParentUi : MonoBehaviour
{
    void OnMouseUp()
    {
        this.transform.parent.gameObject.SetActive(false);
    }

}
