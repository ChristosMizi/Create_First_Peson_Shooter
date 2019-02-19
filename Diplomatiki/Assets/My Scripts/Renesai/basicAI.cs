using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

namespace UnityStandardAssets.Characters.ThirdPerson
{

    public class basicAI : MonoBehaviour
    {
        Transform player;

        //-----------------------------
        public NavMeshAgent agent;
        public ThirdPersonCharacter character;

        public enum State
        {
            PATROL,
            CHASE,

        }
        public State state;
        private bool alive;
        //Variables for Patrolling
        public GameObject[] waypoints;
        private int waypointInd = 0;
        public float patrolSpeed = 0.5f;

        //Variables for Chasing

        public float chaseSpeed = 1f;
        public GameObject target;
        // Use this for initialization
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;

            //----------------------------
            agent = GetComponent<NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();

            agent.updatePosition = true;
            agent.updateRotation = false;

            // set your initial state
            state = basicAI.State.PATROL;

            alive = true;

            //Start FSM

            StartCoroutine("FSM");
        }

        IEnumerator FSM()
        {
            while (alive)
            {

                switch (state)
                {
                    case State.PATROL:
                        Patrol();
                        break;
                    case State.CHASE:
                        Chase();
                        break;
                }
                yield return null;
            }
        }

        void Patrol()
        {
            agent.speed = patrolSpeed;
            if (Vector3.Distance(this.transform.position, waypoints[waypointInd].transform.position)>=2)
            {
                agent.SetDestination(waypoints[waypointInd].transform.position);
               // this.transform.Translate(0, 0, 0.05f);
                character.Move(agent.desiredVelocity, false, false);
            }
            else if (Vector3.Distance(this.transform.position, waypoints[waypointInd].transform.position)<=2)
            {
                waypointInd += 1;
                if (waypointInd > waypoints.Length)
                {
                    waypointInd = 0;
                }

            }
            else
            {

                this.transform.Translate(0,0,0);
            }
         

        }

        void Chase()
        {

        }

        void onTriggerEnter (Collider coll)
        {


        }


    }


}

