using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private GameObject enemyBullet;
    [SerializeField] private Transform spawnBullet;
    [SerializeField] private float speedBullet=100;
     private Transform playerPosition;



    void Start()
    {
        playerPosition = FindObjectOfType<PlayerMovement>().transform;
        Invoke("ShootPlayer", 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ShootPlayer()
    {
        Vector3 playerDirection= playerPosition.position-transform.position;
        GameObject newBullet;
        newBullet= Instantiate(enemyBullet,spawnBullet.position,spawnBullet.rotation);
        newBullet.GetComponent<Rigidbody>().AddForce(playerDirection*speedBullet, ForceMode.Force);
        Invoke("ShootPlayer", 3);
    }
}
