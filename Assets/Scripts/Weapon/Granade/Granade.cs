using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private float delay = 3;
    [SerializeField] private float radius = 5;
    [SerializeField] private float explosionForce = 70;

    [Header("Componets")]
    [SerializeField] private GameObject explosionPacticle;


    private float countDown;
    private bool IsExploted;

    void Start()
    {
        countDown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countDown -= Time.deltaTime;

        if (countDown<=0 && IsExploted==false)
        {
            Exploded();
            IsExploted = true;  
        }
    }

    void Exploded()
    {
        Instantiate(explosionPacticle,transform.position,transform.rotation);
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (var rangeObjects in colliders)
        {
            Rigidbody rb= rangeObjects.GetComponent<Rigidbody>();   
            if(rb != null)
            {
                rb.AddExplosionForce(explosionForce * 10, transform.position, radius);
            }
        }
        Destroy(gameObject);    
    }
}
