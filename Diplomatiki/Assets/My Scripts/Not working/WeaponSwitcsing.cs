using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcsing : MonoBehaviour {
    // Enabling or disabling the GO of the WeaponHolder
    public int _selectedWeapon = 0;

    public bool WeaponSwitchingEnabled = false;
	// Use this for initialization
	void Start ()
    {
       // SelectWeapon();
	}
	
	// Update is called once per frame
	void Update ()
    {
        int previousSelectedWeapon = _selectedWeapon;
	    if (Input.GetAxis("Mouse ScrollWheel")>0f && WeaponSwitchingEnabled == true)
        {
            if (_selectedWeapon>=transform.childCount-1)
            {
                _selectedWeapon = 0;
            }
            else
            _selectedWeapon++;
        }

        //opposite direction as well
        if (Input.GetAxis("Mouse ScrollWheel") < 0f && WeaponSwitchingEnabled == true)
        {
            if (_selectedWeapon <= 0)
            {
                _selectedWeapon = transform.childCount - 1;
            }
            else
                _selectedWeapon --;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && WeaponSwitchingEnabled == true)
        {

            _selectedWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount>=2 && WeaponSwitchingEnabled == true)
        {

            _selectedWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3 && WeaponSwitchingEnabled == true)
        {

            _selectedWeapon = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4 && WeaponSwitchingEnabled == true)
        {

            _selectedWeapon = 3;
        }



        if (previousSelectedWeapon != _selectedWeapon && WeaponSwitchingEnabled == true)
        {
            SelectWeapon();
        }
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach(Transform weapon in transform)
        {
            if (i == _selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
