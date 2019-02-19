using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTriggered : MonoBehaviour {

    public GameObject PickUpUI;
    private int collision = 0;
    public AudioClip sound;
    private AudioSource audio;
    private bool alreadyPlayed = false;

    // Use this for initialization
    void Start()
    {
        audio = GetComponent<AudioSource>();
        PickUpUI.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && PickUpUI.activeSelf == false && collision == 0 && alreadyPlayed == false)
        {
            PickUpUI.SetActive(true);
            audio.PlayOneShot(sound, 5);
            alreadyPlayed = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            PickUpUI.SetActive(false);
        collision = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("T") && collision == 1)
        {
            PickUpUI.SetActive(true);
            if (Input.GetButtonDown("T"))
            {
                audio.PlayOneShot(sound, 5);
            }

        }
        if (Input.GetButtonUp("T") && collision == 1)
        {
            PickUpUI.SetActive(false);
        }


    }
}
