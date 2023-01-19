using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float shootForce=1500f;
    [SerializeField] private float shootRate=0.5f;
private float shootRateTime = 0.5f;





    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Time.time > shootRateTime /*&& GameManager.Instance.gunAmmo > 0*/)
            {
              // GameManager.Instance.gunAmmo--;

                ShootBullet();

                shootRateTime = Time.time + shootRate;



            }
        }

    }

    void ShootBullet()
    {
        GameObject newBullet;

        newBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
        newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shootForce);
        newBullet.transform.parent = spawnPoint.transform;
        Destroy(newBullet, 5f);

    }

}
