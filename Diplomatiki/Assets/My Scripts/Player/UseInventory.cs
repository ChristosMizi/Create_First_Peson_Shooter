using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseInventory : MonoBehaviour {
    public bool stats;
    public bool item_Key;
    public bool item_Gold_Coins;
    public int hValue;
    GameObject inv;
    GameObject player;
    public bool item_MG;

    
    UIManager _uiManager;
    PlayerHealth playerHealthvar;
    private BoxWithGold bx;

    Animator anim;

    public int costMG = 40;
    Currency _currency;
    private PickUp _pickUP;

    WeaponSwitcsing _wswitch;
    // Use this for initialization
    void Start ()
    {

        inv = GameObject.FindWithTag("GameController");
        player = GameObject.FindWithTag("Player");
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        playerHealthvar = player.GetComponent<PlayerHealth>();

        // I connect this script with the script <BoxWithGold>
        GameObject  bxgold= GameObject.FindWithTag("chest");
        bx=  bxgold.GetComponent<BoxWithGold>();

        // I connect this script with the PickUp Script
        GameObject pickUpGO = GameObject.FindWithTag("ItemMG");
        _pickUP = pickUpGO.GetComponent<PickUp>();

        // I connect this script with the WeaponSwitching script
        GameObject wSwitchGO = GameObject.FindWithTag("WeaponSW");
        _wswitch = wSwitchGO.GetComponent<WeaponSwitcsing>();

        _currency = GameObject.FindWithTag("GameController").GetComponent<Currency>();

        ////I connect this script with the Currency
        //GameObject curGO = GameObject.FindWithTag("Currency");
        //_currency = curGO.GetComponent<Currency>();
    }

    public void UseItem()
    {

        if (stats)
        {
           int nHealth =  player.GetComponent<PlayerHealth>().health += 20;
            

            string stringHealth = (nHealth).ToString();
            Text initialHealthtxt = playerHealthvar.healthText;
            initialHealthtxt.text = "" + stringHealth;
            Destroy(gameObject);
        }
        if (item_Key)
        {

            bx.openBox = true;
            
            Destroy(gameObject);

        }
        if (item_Gold_Coins)
        {
            Destroy(gameObject);
            
            _pickUP._itemMG = true;

            

            if (_currency.gold >= costMG)
            {
                _currency.gold -= costMG;
                
            }
            

        }
        if (item_MG)
        {
            Destroy(gameObject);
            // Connect this script with WeaponHodler script to enable MG
            _wswitch.WeaponSwitchingEnabled = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
