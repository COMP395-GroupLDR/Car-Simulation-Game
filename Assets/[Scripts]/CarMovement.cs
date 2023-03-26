using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float speed = 10.0f;
    public float turnSpeed = 100.0f;

    private float horizontalInput;
    private float verticalInput;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        // Move the car forward and backward
        Vector3 forward = -transform.forward * verticalInput * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forward);

        // Rotate the car left and right
        float turn = horizontalInput * turnSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0.0f, turn, 0.0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}
