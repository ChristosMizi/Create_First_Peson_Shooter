using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowBT : MonoBehaviour {

    public float _speed;
   // public float _stoppingDistance;

    private Transform target;
    Animator anim;

    // Use this for initialization
    void Start () {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        //float step = _speed * Time.deltaTime;
        //if (Vector2.Distance(transform.position,target.position) > 2)
        //{
        //    transform.position = Vector2.MoveTowards(transform.position, target.position, step);
        //}
        anim.SetBool("isIdle", true);


        if (Vector3.Distance(target.position, this.transform.position) >1)
        {
            Vector3 direction = target.position - this.transform.position;
            direction.y = 0;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                 Quaternion.LookRotation(direction), 0.1f);

            if (direction.magnitude < 5)
            {
                this.transform.Translate(0, 0, 0.05f);
                anim.SetBool("isIdle", false);
                anim.SetBool("Run", true);
            }

        }
    }
}
