using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainTrust = 2000f;
    [SerializeField] float rotationThrust = 100f;
    [SerializeField] AudioClip mainEngine;

    [SerializeField] ParticleSystem mainEngineThrust;
    [SerializeField] ParticleSystem leftEngineThrust;
    [SerializeField] ParticleSystem rightEngineThrust;

    Rigidbody rb;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
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
            StartThrust();
            
        }
        else{
            StopThrusting();
        }
        
    }

    void ProcessRotation(){
        if(Input.GetKey(KeyCode.A))
        {
            StartRotatingRight();
        }
        else if(Input.GetKey(KeyCode.D))
        {
            StartRotatingLeft();
        }
        else{
            StopRotating();
            
        }
    }

    void ApplyRoation(float rotationThisFrame)
    {
        rb.freezeRotation = true; // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward* rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }
    void StartThrust(){
        rb.AddRelativeForce(Vector3.up * mainTrust * Time.deltaTime);
        if(!audioSource.isPlaying){
            audioSource.PlayOneShot(mainEngine);
        }
        if(!mainEngineThrust.isPlaying){
            
            mainEngineThrust.Play();
        }        
    }
    void StopThrusting()
    {
        if(!leftEngineThrust.isPlaying && !rightEngineThrust.isPlaying){
        audioSource.Stop();
        }
        mainEngineThrust.Stop();
    }
void StartRotatingLeft(){
    ApplyRoation(rotationThrust);
    if(!leftEngineThrust.isPlaying){
        leftEngineThrust.Play();
    }
    if (!audioSource.isPlaying) {
        audioSource.PlayOneShot(mainEngine);
    }
}

void StartRotatingRight(){
    ApplyRoation(-rotationThrust);
    if(!rightEngineThrust.isPlaying){
        rightEngineThrust.Play();
    }
    if (!audioSource.isPlaying) {
        audioSource.PlayOneShot(mainEngine);
    }
}
    void StopRotating(){
        
        leftEngineThrust.Stop();
            rightEngineThrust.Stop();
    }

}
