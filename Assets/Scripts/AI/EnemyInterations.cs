using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInterations : MonoBehaviour
{
    public int enemyHealt = 100;
    [SerializeField] private GameObject ammoBox;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {

            GameManager.Instance.LostHealtEnemy(25);
            Instantiate(ammoBox, transform.position, transform.rotation);
        }
    }
}
