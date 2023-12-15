using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

   void FixedUpdate()
    {   
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical);

        if (direction.magnitude >= 0.1f)
        {
            animator.SetBool("Walk", true);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetBool("Walk", false);
                animator.SetBool("Run", true);
            }
            else
            {
                animator.SetBool("Run", false);
                animator.SetBool("Walk", true);
            }
        }
        else
        {
            animator.SetBool("Walk", false);
            animator.SetBool("Run", false);
        }
    }
}

