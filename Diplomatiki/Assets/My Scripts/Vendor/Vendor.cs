using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vendor : MonoBehaviour
{
    Currency script;
    InventoryChris invScript;

    public GameObject vendorUI;
    public int cost;

	// Use this for initialization
	void Start ()
    {
        vendorUI.SetActive(false);
        script = GameObject.FindWithTag("GameController").GetComponent<Currency>();
        invScript = GameObject.FindWithTag("GameController").GetComponent<InventoryChris>();
    }
	
    void OnTriggerEnter()
    {
        vendorUI.SetActive(true);
        Cursor.visible = true;
       // Cursor.lockState = CursorLockMode.None;
    }

    void OnTriggerExit()
    {
        vendorUI.SetActive(false);
        Cursor.visible = false;
       // Cursor.lockState = CursorLockMode.Locked;

    }
    public void BuyItem(GameObject objToCreate)
    {
        if(script.gold >= cost)
        {
            script.gold -= cost;
            GameObject i = Instantiate(objToCreate);
            i.transform.SetParent(invScript.invTab.transform);
        }
    }

    

}
