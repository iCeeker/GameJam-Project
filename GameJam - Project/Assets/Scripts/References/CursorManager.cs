using UnityEngine;

public class CursorManager : MonoBehaviour
{
    private void OnApplicationFocus(bool focus)
    {
        Cursor.lockState = focus ? CursorLockMode.Locked : CursorLockMode.None;
    }
}
