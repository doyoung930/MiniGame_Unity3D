using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float controlSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        float xThrwow = Input.GetAxis("Horizontal");
        float yThrwow = Input.GetAxis("Vertical");

        float xOffset = xThrwow * Time.deltaTime * controlSpeed;
        float newXPos = transform.localPosition.x + xOffset;

        float yOffset = yThrwow * Time.deltaTime * controlSpeed;
        float newYPos = transform.localPosition.y + yOffset;

        transform.localPosition = new Vector3(newXPos, newYPos, transform.localPosition.z);
    }
}
