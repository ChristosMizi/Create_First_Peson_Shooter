using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorTriggerZoneScript : MonoBehaviour {
    public bool isDamaging;
    public int damage = 1;

    PlayerHealth ph;

	private void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player")
        {
            //col.SendMessage((isDamaging) ? "TakeDamage" : "HealDamage", Time.deltaTime * damage);
            DamageFromLava();
        }
    }

    void Start() {

        GameObject go = GameObject.FindWithTag("Player");
        ph = go.GetComponent<PlayerHealth>();
    }
    void DamageFromLava()
    {
        
        int deductedhealth  = ph.health - damage;
      
        Text healthComingFromScript = ph.healthText;

        string stringHealth = (deductedhealth).ToString();
        healthComingFromScript.text = "" + stringHealth;

        int slideDeductedHealth = ph.health -= damage;
        ph.healthbar.value = slideDeductedHealth;
    }
}
