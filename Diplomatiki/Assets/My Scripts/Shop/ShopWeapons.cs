using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopWeapons : MonoBehaviour {

	//check for a colliision
    // check if the player
    //check for E key
    //Chck if player has coin
        //Remove coin from player
        //update the inventory display
        //play win sound
    //debug no coin Get out of here


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Player player = other.GetComponent<Player>();
                if (player != null)
                {
                    if (player.hascoin == true)
                    {
                        player.hascoin = false;
                        UIManager uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
                        if (uiManager != null)
                        {
                            uiManager.RemoveCoin();
                        }
                        AudioSource audio = GetComponent<AudioSource>();
                        audio.Play();
                        player.EnableMG();
                        player.DisablePistol();
                        
                    }
                    else
                    {
                        Debug.Log("Get out of Here");

                    }
                    
                }
                
            }
        }
    }


}
