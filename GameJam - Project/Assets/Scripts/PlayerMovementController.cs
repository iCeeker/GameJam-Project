using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] float RotationSpeed;
    [SerializeField] float Speed;
    [SerializeField] Animator animator;
    [SerializeField] AudioClip stepsound;
    [SerializeField] ParticleSystem stepParticle;
    [SerializeField] string horizontalAxis;
    [SerializeField] string verticalAxis;

    SoundManager soundManager;

    private void Start()
    {
        soundManager = GameObject.Find("AudioManger 1").GetComponent<SoundManager>();
    }

    void Update()
    {
        float verticalInput = Input.GetAxis(verticalAxis);
        float horizontalInput = Input.GetAxis(horizontalAxis);

        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);

        if (horizontalInput + verticalInput != 0)
        {
            animator.SetBool("isRunning", true);
            //soundManager.PlaySound(stepsound);
            if (!stepParticle.isPlaying)
            {
                stepParticle.Play();
            }
        }
        else
        {
            animator.SetBool("isRunning", false);
            stepParticle.Stop();
        }

        if (direction != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = rotation;
            transform.Translate(direction * Speed * Time.deltaTime, Space.World);
        }
    }
}
