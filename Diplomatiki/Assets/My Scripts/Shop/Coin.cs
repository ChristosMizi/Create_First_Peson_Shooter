using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin: MonoBehaviour

{
    [SerializeField]
    private AudioClip _coinPickup;


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player") // if player collided with us
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Player player = other.GetComponent<Player>();
                if (player != null)

                {
                    player.hascoin = true;
                    AudioSource.PlayClipAtPoint(_coinPickup, transform.position, 1f);

                    UIManager uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();

                    if (uIManager != null)
                    {
                        uIManager.CollectedCoin();
                    }
                    Destroy(this.gameObject);
                }
            }
        }
    }
    //check for collision (on Trigger)
    // check if Player
    // within the check of the player , check for E key press
    // give player the coin
    // play coin sound!
    // destroy the coin



}
