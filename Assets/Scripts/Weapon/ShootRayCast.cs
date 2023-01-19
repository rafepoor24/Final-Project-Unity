using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class ShootRayCast : MonoBehaviour
{
    public float damage = 100f;
    public float range = 150f;
    public Camera fpsCamera;
    public ParticleSystem muzzle;
    public GameObject impactEffect;
    public GameObject impactEffectSteel;
    public int maxAmmo=10;
    public float reloadTime=1f;
    public Animator anim;
    [SerializeField] private TextMeshProUGUI ammoText;
    [SerializeField] private float shootForce = 1500f;
    [SerializeField] private float shootRate = 0.8f;
    private float shootRateTime = 0.5f;
    public int currentAmmo;
    private bool isRealoding=false;

    public static ShootRayCast shootRayInstance { get; private set; }
    private void Awake()
    {
        shootRayInstance = this;
    }



    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = maxAmmo;
        
    }

    // Update is called once per frame
    void Update()
    {
        ammoText.text = currentAmmo.ToString();

        if (isRealoding)
        {
            return;
        }
        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Time.time > shootRateTime && currentAmmo > 0)
            {
                currentAmmo--;
              //  GameManager.Instance.gunAmmo--;
                Shoot();
                shootRateTime = Time.time + shootRate;
            }
               
        }
    }

    IEnumerator Reload()
    {
        isRealoding = true;
        Debug.Log("Reloading");
        anim.SetBool("IsReloading",true);
        yield return new WaitForSeconds(reloadTime);
        anim.SetBool("IsReloading", false);


        currentAmmo = maxAmmo;
        isRealoding = false;
    }

    void Shoot()
    {

        
        muzzle.Play();


        RaycastHit hit;
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            //Debug.Log(hit.transform.name);
            EnemyInterations _enemy= hit.transform.GetComponent<EnemyInterations>();
            if (_enemy !=null)
            {
                _enemy.TakeDamage(damage);
            }
            if (hit.transform.name=="Enemy")
            {
                GameObject impactGO = Instantiate(impactEffectSteel, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 2f);
            }
            else
            {
                GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 2f);
            }
           
        }
        
    }
}
