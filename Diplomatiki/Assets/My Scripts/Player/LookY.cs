using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookY : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float _mouseY = Input.GetAxis("Mouse Y");
        // take this museY value and assign to the newRotation 
        Vector2 newRotation = transform.localEulerAngles;
        newRotation.x -= _mouseY;
        transform.localEulerAngles = newRotation;

    }
}
