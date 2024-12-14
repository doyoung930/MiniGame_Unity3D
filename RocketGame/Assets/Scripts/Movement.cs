using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainTrust = 2000f;
    [SerializeField] float rotationThrust = 100f;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust(){
        if(Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * mainTrust * Time.deltaTime);
        }
        
    }
    void ProcessRotation(){
        if(Input.GetKey(KeyCode.A))
        {
            ApplyRoation(-rotationThrust);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            ApplyRoation(rotationThrust);
        }
    }

    void ApplyRoation(float rotationThisFrame)
    {
        transform.Rotate(Vector3.forward* rotationThisFrame * Time.deltaTime);
    }
}
