using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieWalk : MonoBehaviour {


    protected Animator myAnimation;

	// Use this for initialization
	void Start () {
        myAnimation = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        myAnimation.SetFloat("Speed", Input.GetAxis("Vertical"));
	}
}
