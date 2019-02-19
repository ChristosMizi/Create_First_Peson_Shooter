using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour {

    public Transform target;
    Vector3 screenPos;
    public ParticleSystem particles;


    public void Update()
    {

        screenPos = Camera.main.WorldToScreenPoint(target.position);
    }
    // for every contact/colliosion a particle will be spawned
    void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.tag =="Zombie")
        {

            GameObject particle = Instantiate(particles.gameObject, screenPos, Quaternion.identity) as GameObject;
            Destroy(particle, 4);
        }
    }
	
}
