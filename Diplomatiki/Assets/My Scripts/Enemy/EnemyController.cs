using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    //NavMeshAgent nav;
    Transform player;
    public float enemyHealth = 100f;
    
    [SerializeField]
    public float damagePlayer = 5;
    Animator anim;

    string state = "patrol";

    float health;
    GameManagement game;
    CapsuleCollider capsuleCollider;
    bool isDead = false;
    UIManager _uiManager;
    public float timeToAttack;
    public float attackTimer;

    // Use this for initialization
    void Awake()
    {
       // nav = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        game = FindObjectOfType<GameManagement>();
        health = 20 + (1.25F * game.round);
        capsuleCollider = GetComponent<CapsuleCollider>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

    }
   

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            if (Vector3.Distance(player.position, this.transform.position) < 10)
            {
                Vector3 direction = player.position - this.transform.position;
                direction.y = 0;
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                     Quaternion.LookRotation(direction), 0.1f);

                if (direction.magnitude > 5)
                {
                    this.transform.Translate(0, 0, 0.05f);
                    anim.SetBool("isIdle", false);
                    anim.SetBool("isWalking", true);
                }

            }
            float distance = Vector3.Distance(transform.position, player.position);
            if (distance < 3)
            {
                attackTimer += Time.deltaTime;


            }
            else if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime * 2;

            }
            else
                attackTimer = 0;
        }
        //nav.SetDestination(player.position);

    }

    bool Attack()
    {
        if(attackTimer > timeToAttack)
        {
            //sound
            attackTimer = 0;
            anim.SetBool("isAttacking", true);
            return true;
        }
        return false;
    }

    // Deduct Health
    public void DeductEnemyHealth(float deductHealth)
    {
        enemyHealth -= deductHealth;

        if (!isDead)
        {
            _uiManager.UpdateScore();
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
       // nav.isStopped = true;
        //   turn the collider into a trigger so that shots can pass through it
        capsuleCollider.isTrigger = true;

        anim.SetTrigger("isDead");
        if (this.gameObject != null)
        {
            Destroy(gameObject, 7f); // after 7 seconds
        }

    }

    // when the collsion of the two players happens
    //void OnCollisionStay(Collision collisionInfo)
    //{
    //    if (collisionInfo.gameObject.tag =="Player")
    //    {
    //        if(Attack())
    //            collisionInfo.collider.SendMessageUpwards("PlayerDamage",damage,SendMessageOptions)
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            anim.SetBool("isAttacking", true);
            PlayerHealthBar ph = other.GetComponent<PlayerHealthBar>();

            if (ph != null)
            {
                ph.TakeDamage(damagePlayer);
            }


        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            anim.SetBool("isIdle", true);
        }
    }
}
