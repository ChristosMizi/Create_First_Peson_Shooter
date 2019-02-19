using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    NavMeshAgent nav;
    public float enemyHealth = 100f;
    bool isDead;
    CapsuleCollider capsuleCollider;
    Animator anim;

    int pointValue = 10;
    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
       
        anim = GetComponent<Animator>();
        
        
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    public void DeductHealth(float deductHealth)
    {
        enemyHealth -= deductHealth;

        if(!isDead)
        {
            
            if (enemyHealth <= 0)

            {
                EnemyDead();
            }
        }

       


    }
    void EnemyDead()
    {
        // print damage
        isDead = true;
          nav.isStopped = true;
        //   turn the collider into a trigger so that shots can pass through it
         capsuleCollider.isTrigger = true;

        anim.SetTrigger("isDead");
        if (this.gameObject!= null)
        {
            Destroy(gameObject, 3f); // after 4 seconds
        }
        


       // Destroy(gameObject);
    }
}
