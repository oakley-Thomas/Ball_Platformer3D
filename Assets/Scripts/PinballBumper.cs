using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinballBumper : MonoBehaviour
{
    [SerializeField] KeyCode activateKey;
    [SerializeField] int power;

    Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(activateKey))
        {
            Activate();
        }
    }


    void Activate()
    {
        rb.AddTorque(Vector3.up * power, ForceMode.Acceleration);
    }
}
