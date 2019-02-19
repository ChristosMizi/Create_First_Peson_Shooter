using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookX : MonoBehaviour
{
    [SerializeField]
    private float _sensitivity = 5f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float _mouseX = Input.GetAxis("Mouse X");

        // My variable Rotation holds my current local Euler angles
        Vector3 newRotation = transform.localEulerAngles;

        // I modify the Y
        newRotation.y += _mouseX * _sensitivity;

        // I set it assignet to the new rotation values
        // my cuurennt Location is transform.localEulerAnles
        transform.localEulerAngles = newRotation;

        // take this variable and add it to the y axis

        //transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y 
           // + _mouseX, transform.localEulerAngles.z);
    }
}
