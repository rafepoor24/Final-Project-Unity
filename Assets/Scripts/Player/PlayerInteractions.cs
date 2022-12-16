using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    [SerializeField]private Transform startPointTransform;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GunAmmo"))
        {
            GameManager.Instance.gunAmmo += other.gameObject.GetComponent<AmmoBox>().ammo;   
            Destroy(other.gameObject);
            
        }
        if (other.gameObject.CompareTag("DeathFloor"))
        {

            GameManager.Instance.LostHealt(50);
            gameObject.transform.position = startPointTransform.position;

        }
    }
}
