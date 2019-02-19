using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest1 : MonoBehaviour {

    [Range(0.0f, 1.0f)]
    public float factor;

    Quaternion closedAngle;
    Quaternion openedAngle;

    public bool closing;
    public bool opening;

    public float speed = 0.5f;

    int newAngle = 127;

    // Use this for initialization
    void Start()
    {
        openedAngle = transform.rotation;
        closedAngle = Quaternion.Euler(transform.eulerAngles + Vector3.right * newAngle);
    }

    // Update is called once per frame
    void Update()
    {

        if (closing)
        {
            factor += speed * Time.deltaTime;

            if (factor > 1.0f)
            {
                factor = 1.0f;
            }
        }
        if (opening)
        {
            factor -= speed * Time.deltaTime;

            if (factor < 0.0f)
            {
                factor = 0.0f;
            }
        }

        transform.rotation = Quaternion.Lerp(openedAngle, closedAngle, factor);
    }

    //You probably want to call this somewhere
   public void Close()
    {
        closing = true;
        opening = false;
    }

    public void Open()
    {
        opening = true;
        closing = false;
    }
}
