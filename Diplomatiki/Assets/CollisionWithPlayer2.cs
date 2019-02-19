using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionWithPlayer2 : MonoBehaviour
{
    public bool zombieIsThere;
    float timer;
    int timeBetweenAttack;
    Animator anim;
    public GameObject bloodyScreen;
    AudioSource attackSound;

    private PlayerHealth playerHealthscriptvar;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        timeBetweenAttack = 1;

        // with the 3 lines below we have a connection between the two scripts this and PlayerHealth
        GameObject PlayerHealthObject = GameObject.FindWithTag("Player");

        if (PlayerHealthObject != null)
        {
            playerHealthscriptvar = PlayerHealthObject.GetComponent<PlayerHealth>();
        }
        AudioSource[] audios = GetComponents<AudioSource>();
        attackSound = audios[0];
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;

        if (zombieIsThere && timer >= timeBetweenAttack)
        {
            Attack();
        }



    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            zombieIsThere = true;
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            zombieIsThere = false;


            anim.SetBool("isAttacking", false);
            bloodyScreen.gameObject.SetActive(false);
        }
    }

    void Attack()
    {
        timer = 0f;
        // GetComponent<Animator>().Play("attack");
        //anim.SetBool("isWalking", false);
        anim.SetBool("isAttacking", true);
        bloodyScreen.gameObject.SetActive(true);
        StartCoroutine(waitTwoSeconds());
        int deductedhealth = playerHealthscriptvar.health -= 5;
        Text healthComingFromScript = playerHealthscriptvar.healthText;

        string stringHealth = (deductedhealth).ToString();
        healthComingFromScript.text = "" + stringHealth;
        attackSound.Play();
    }
    IEnumerator waitTwoSeconds()
    {

        yield return new WaitForSeconds(3f);
        yield return new WaitForSeconds(3f);
        bloodyScreen.gameObject.SetActive(false);
    }
}
