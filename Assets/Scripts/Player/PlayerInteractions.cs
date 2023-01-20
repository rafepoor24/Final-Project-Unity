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
            ShootRayCast.shootRayInstance.currentAmmo += other.gameObject.GetComponent<AmmoBox>().ammo;   
            Destroy(other.gameObject);
            
        }
        if (other.gameObject.CompareTag("DeathFloor"))
        {

            GameManager.Instance.LostHealt(50);
            gameObject.transform.position = startPointTransform.position;

        }

        if (other.gameObject.CompareTag("HealthBox"))
        {
            GameManager.Instance.health +=other.gameObject.GetComponent<HealthBox>().health;
            Destroy(other.gameObject);


        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
           
            GameManager.Instance.LostHealt(5);
        }
    }
}
