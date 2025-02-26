using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float forwardSpeed;
    [SerializeField] float rightSpeed;
    [SerializeField] float jumpForce;

    float horizontalInput = 0;
    float verticalInput = 0;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    // FixedUpdate is called multiple times per frame
    void FixedUpdate()
    {
        Roll();
    }

    void Roll()
    {
        Vector3 direction = new Vector3(verticalInput * forwardSpeed, 0, horizontalInput * rightSpeed * -1);
        rb.AddTorque(direction, ForceMode.Acceleration);
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
