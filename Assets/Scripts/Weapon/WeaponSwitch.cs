using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    [SerializeField] private GameObject[] weapons;
    [SerializeField] private int selectedWeapon = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int previosWeapon = selectedWeapon;
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (selectedWeapon >= weapons.Length - 1)
            {
                selectedWeapon = 0;
            }
            else
            {
                selectedWeapon++;
            }

        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (selectedWeapon <= 0)
            {
                selectedWeapon = weapons.Length - 1;
            }
            else
            {
                selectedWeapon--;
            }

        }
        if (previosWeapon != selectedWeapon)
        {
            SelectedWeapon();
        }
        void SelectedWeapon()
        {
            int i = 0;
            foreach (Transform weapon in transform)
            {
                if (weapon.gameObject.layer==LayerMask.NameToLayer("Weapon"))
                {
                    if (i == selectedWeapon)
                    { 
                       weapon.gameObject.SetActive(true);
                    }
                    else
                    {
                        weapon.gameObject.SetActive(false);
                    }
                    i++;
                }
            }
        }
    }
}
