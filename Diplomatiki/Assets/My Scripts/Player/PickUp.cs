using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour

{
    public bool money;
    public int moneyAmount;
   Currency _currency;

    public bool item;
    public bool _itemMG = false;
    [SerializeField]
    private AudioClip _AudioPickup;

    InventoryChris invScript;
    public GameObject itemIcon;
    bool pickedUp = false;
    bool hasGold = false;

    WeaponSwitcsing _wswitch;
    // Use this for initialization
    void Start ()
    {
       // // Connect pickup script with Currency
       //GameObject moneyScriptGO = GameObject.FindWithTag("GoldCoins");
        _currency = GameObject.FindWithTag("GameController").GetComponent<Currency>();
        
        invScript = GameObject.FindWithTag("GameController").GetComponent<InventoryChris>();

        // I connect this script with the WeaponSwitching script
        GameObject wSwitchGO = GameObject.FindWithTag("WeaponSW");
        _wswitch = wSwitchGO.GetComponent<WeaponSwitcsing>();
    }
	
    void OnTriggerStay(Collider Player)
    {
        
        if (Player.tag == "Player")
        {
            if (money && Input.GetKeyDown(KeyCode.E) && !pickedUp)
            {
                hasGold = true;
                pickedUp = true;
                AudioSource.PlayClipAtPoint(_AudioPickup, transform.position, 1f);
                
                _currency.gold += moneyAmount;

                ////Text curText = _currency.GetComponent<Text>();
                //_currency.GetComponent<Text>().text = "Money: " + _currency.gold.ToString(); 
                GameObject i = Instantiate(itemIcon);
                i.transform.SetParent(invScript.invTab.transform);
                Destroy(gameObject);

                // StartCoroutine("PlayPickUp");
            }
            else if (item && Input.GetKeyDown(KeyCode.E) && !pickedUp)
            {
                AudioSource.PlayClipAtPoint(_AudioPickup, transform.position, 1f);
                GameObject i = Instantiate(itemIcon);
                i.transform.SetParent(invScript.invTab.transform);
                Destroy(gameObject);

                // pick up object or add it to your inventory
                // StartCoroutine("PlayPickUp");
            }
            else if (_itemMG== true && Input.GetKeyDown(KeyCode.E) && !pickedUp)
            {
                // Connect this script with WeaponHodler script to enable MG
                _wswitch.WeaponSwitchingEnabled = true;
                AudioSource.PlayClipAtPoint(_AudioPickup, transform.position, 1f);
                GameObject i = Instantiate(itemIcon);
                i.transform.SetParent(invScript.invTab.transform);
                Destroy(gameObject);

                // pick up object or add it to your inventory
                // StartCoroutine("PlayPickUp");
            }

        }
    }
        
    //IEnumerator PlayPickUp()
    //{
    //    yield return new WaitForSeconds(1);
    //    if (money)
    //    {
    //        moneyScript.gold += moneyAmount;
    //        Destroy(gameObject);
    //    }
    //    else if (item)
    //    {
    //        // pick up object or add it to your inventory

    //    }

    //}
  
    
}
