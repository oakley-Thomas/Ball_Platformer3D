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
    Vector3 spawnPoint;
    bool isOnGround;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        spawnPoint = rb.position;
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

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Respawn"))
        {
            StartCoroutine(Respawn());
        }
    }

    void OnCollisionStay(Collision collision)
    {
        isOnGround = true;
    }

    void OnCollisionExit(Collision collision)
    {
        isOnGround = false;
    }

    void Roll()
    {
        Vector3 direction = new Vector3(verticalInput * forwardSpeed, 0, horizontalInput * rightSpeed * -1);
        rb.AddTorque(direction, ForceMode.Acceleration);
    }

    void Jump()
    {
        if (isOnGround)
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    IEnumerator Respawn()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.isKinematic = true;
        rb.position = spawnPoint;
        yield return new WaitForSeconds(0.1f);
        rb.isKinematic = false;
    }
}
