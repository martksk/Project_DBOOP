using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovemenrt : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 90f;
    public Rigidbody rb;
    Vector3 movement;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("HorizontalZ");
        if (movement != Vector3.zero)
        {
            float targetRotation = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, targetRotation, 0), rotationSpeed * Time.deltaTime);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}

