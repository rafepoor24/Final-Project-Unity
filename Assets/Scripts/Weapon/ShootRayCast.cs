using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootRayCast : MonoBehaviour
{
    public float damage = 100f;
    public float range = 150f;
    public Camera fpsCamera;
    public ParticleSystem muzzle;
    public GameObject impactEffect;
    [SerializeField] private float shootForce = 1500f;
    [SerializeField] private float shootRate = 0.8f;
    private float shootRateTime = 0.5f;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Time.time > shootRateTime && GameManager.Instance.gunAmmo > 0)
            {
                GameManager.Instance.gunAmmo--;
                Shoot();
                shootRateTime = Time.time + shootRate;
            }
               
        }
    }

    void Shoot()
    {

        
        muzzle.Play();


        RaycastHit hit;
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            EnemyInterations _enemy= hit.transform.GetComponent<EnemyInterations>();
            if (_enemy !=null)
            {
                _enemy.TakeDamage(damage);
            }
            if (!(hit.transform.name=="Enemy"))
            {
                GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 2f);
            }
           
        }
        
    }
}
