using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] float valueX = 0;
    [SerializeField] float valueY = 1;
    [SerializeField] float valueZ = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(valueX, valueY, valueZ);
    }
}
