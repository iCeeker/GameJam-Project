using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] float RotationSpeed;
    [SerializeField] float Speed;
    [SerializeField] Animator animator;
    [SerializeField] AudioClip stepsound;
    [SerializeField] GameObject stepPartikle;

    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);

        if (horizontalInput + verticalInput != 0)
        {
            animator.SetBool("isRunning", true);
            SoundManager soundManager = GameObject.Find("AudioManger 1").GetComponent<SoundManager>();
            soundManager.PlaySound(stepsound);
            stepPartikle.SetActive(true);
        }
        else
        {
            animator.SetBool("isRunning", false);
            stepPartikle.SetActive(false);
        }

        if (direction != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = rotation;
            transform.Translate(direction * Speed * Time.deltaTime, Space.World);
        }
    }
}
