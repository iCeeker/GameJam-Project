using System;
using UnityEngine;

/// <summary>
/// Base for a third person character controller
/// </summary>
public class ThirdPersonController : MonoBehaviour
{
    // how fast the character can turn
    public float RotationSpeed;

    // Damping for locomotion animator parameter
    public float LocomotionParameterDamping = 0.1f;

    private Transform _cameraTransform;

    // Animator playing animations
    private Animator _animator;

    // Hash speed parameter
    private int _speedParameterHash;

    // Hash speed parameter
    private int _isWalkingParameterHash;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _speedParameterHash = Animator.StringToHash("speed");
        _isWalkingParameterHash = Animator.StringToHash("isMoving");
        _cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Stores inputs
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        float magnitude = Mathf.Clamp01(direction.magnitude);

        direction = Quaternion.AngleAxis(_cameraTransform.rotation.eulerAngles.y, Vector3.up) * direction;

        // Should walk? (left or right shift held)
        bool shouldWalk = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        // Set speed to half of input when charakter should walk
        // otherwise use horizontal input
        float speed = shouldWalk ? magnitude * 0.333f : magnitude;

        // Set animator isWalking parameter depending on input
        _animator.SetBool(_isWalkingParameterHash, magnitude > 0);

        // Set animaotr speed parameter with damping (moves the character via root motion)
        _animator.SetFloat(_speedParameterHash, speed, LocomotionParameterDamping, Time.deltaTime);

        if (direction != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, RotationSpeed * Time.deltaTime);
        }
    }
}
