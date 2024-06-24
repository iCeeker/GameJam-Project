using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    public float groundCheckDistance = 0.1F;
    public float gravityMultiplier = 5;
    public float ForceStrength = 100;

    float _ySpeed;
    Vector3 _velocity;

    Animator animator;
    CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGrounded())
        {
            _ySpeed = 0;
        }
        else
        {
            _ySpeed += Physics.gravity.y * gravityMultiplier * Time.deltaTime;
        }
    }

    private void OnAnimatorMove()
    {
        animator.ApplyBuiltinRootMotion();

        _velocity = animator.deltaPosition;
        _velocity.y = _ySpeed;

        characterController.Move(_velocity);
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position + new Vector3(0, groundCheckDistance * 0.5F, 0), Vector3.down * groundCheckDistance, IsGrounded() ? Color.green : Color.red);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rigidbody = hit.collider.attachedRigidbody;

        if (rigidbody != null)
        {
            Vector3 direction = hit.gameObject.transform.position - transform.position;
            direction.y = 0;
            direction.Normalize();
            rigidbody.AddForceAtPosition(direction * ForceStrength * _velocity.magnitude, transform.position, ForceMode.Impulse);
        }
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position + new Vector3(0, groundCheckDistance * 0.5F, 0), Vector3.down, groundCheckDistance);
    }
}
