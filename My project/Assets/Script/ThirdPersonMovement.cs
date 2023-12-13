using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class ThirdPersonMovement : MonoBehaviour
{
    public Transform cam;

    public float speed = 6f;
    public float turnSmoothTime = 0.1f;

    private Rigidbody rb;
    private float turnSmoothVelocity;

    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Prevent rigidbody from rotating due to physics.
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {   
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical);

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            // rb.MovePosition(rb.position + moveDir.normalized * speed * Time.fixedDeltaTime);
            rb.velocity = moveDir.normalized * speed;

            animator.SetBool("Walk", true);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = 6f;
                animator.SetBool("Walk", false);
                animator.SetBool("Run", true);
            }
            else
            {
                animator.SetBool("Run", false);
                animator.SetBool("Walk", true);
                speed = 3f;
            }
        }
        else
        {
            animator.SetBool("Walk", false);
            animator.SetBool("Run", false);
        }
    }
}

