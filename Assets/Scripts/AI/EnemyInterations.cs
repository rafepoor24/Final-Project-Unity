using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyInterations : MonoBehaviour
{
    private MeshRenderer _meshRendere;
    private Color _origiColor;
    public  float _FlashTime=0.15f;
    public float enemyHealt = 100;
    [SerializeField] private GameObject explosionPacticle;


    void Start()
    {
        _meshRendere = GetComponent<MeshRenderer>();
        _origiColor = _meshRendere.material.color;
    }


    public void TakeDamage(float amount)
    {
        enemyHealt -= amount;
        FlashStart();

        if (enemyHealt<=0f)
        {
            Die();
            
        }

    }


    void Die()
    {
        Instantiate(explosionPacticle, transform.position, transform.rotation);
        Destroy(transform.parent.gameObject);
    }


    void FlashStart()
    {
        _meshRendere.material.color=Color.red;
        Invoke("FlashStop", _FlashTime);
    }

    void FlashStop()
    {
        _meshRendere.material.color = _origiColor;
    }
    // [SerializeField] private GameObject ammoBox;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(50);

            //GameManager.Instance.LostHealtEnemy(25);
           // Instantiate(ammoBox, transform.position, transform.rotation);
        }
    }
}
