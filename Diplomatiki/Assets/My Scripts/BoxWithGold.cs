using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxWithGold : MonoBehaviour {

    Animator anim;
    public bool openBox; // to open the box while the scene is running

	// Use this for initialization
	void Start () {
        anim = GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (openBox)
        {
            OpenMysteryBox();
            CloseLid();

        }
	}

    void OpenMysteryBox()
    {
        OpenLid();
    }

    void OpenLid()
    {

        anim.SetBool("OpenLid", true);
    }

    void CloseLid()
    {
        anim.SetBool("CloseLid", true);
    }
}
