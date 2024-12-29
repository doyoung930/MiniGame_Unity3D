using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [Header("General setup settings")]
    [Tooltip("How fast ship moves up and down based upon player input")]
    [SerializeField] float controlSpeed = 20f;
    [SerializeField] float xRange = 10f;
    [SerializeField] float yRange = 6f;

     [Header("Laser gun array")]
    [SerializeField] GameObject[] lasers;

     [Header("Screen position based tuning")]
    [SerializeField] float positionPitchFactor = -3f;
    [SerializeField] float controlPitchFactor = -10f;
     [Header("Player input based tuning")]
    [SerializeField] float positionYawFactor = 3f;
    [SerializeField] float controlRollFactor = -20f;


    float xThrow, yThrow;


    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }

    void ProcessTranslation(){
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);


        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
    void ProcessRotation(){
        float pitchDueToPosition = transform.localPosition.y* positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;

        float pitch = pitchDueToPosition + pitchDueToControlThrow;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }


    void ProcessFiring()
    {
        if(Input.GetButton("Fire1"))
        {
            //Debug.Log("true");
            SetActiveLasers(true);
        }
        else{
            //Debug.Log("false");
            SetActiveLasers(false);
        }
    }

    void SetActiveLasers(bool isActive)
    {
        
        foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }

}

