using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class WeaponSwicth : MonoBehaviour
{
   [SerializeField] private GameObject[] weapons;
   [SerializeField] private int selecweapon=0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int previusWeapon=selecweapon;
         
        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if(selecweapon >= weapons.Length - 1)
            {
                selecweapon = 0;
            }
            else
            {
                selecweapon++;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (selecweapon <=0 )
            {
                selecweapon = weapons.Length-1;
            }
            else
            {
                selecweapon--;
            }
        }
        if(previusWeapon != selecweapon)
        {
            SelectecWeapon();
        }
    }
    void SelectecWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (weapon.gameObject.layer == LayerMask.NameToLayer("Weapon"))
            {
                if (i==selecweapon)
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
