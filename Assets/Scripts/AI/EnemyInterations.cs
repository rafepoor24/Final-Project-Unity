using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class EnemyInterations : MonoBehaviour
{
    public GameObject ammoBox;
    public GameObject healthBox;
    private MeshRenderer _meshRendere;
    private Color _origiColor;
    public  float _FlashTime=0.15f;
    public int enemyHealt = 100;
    public int currentHealth;
    [SerializeField] private GameObject explosionPacticle;
    public HealthBarEnemy _healthBarEnemy;
    private int randomPowerUp;


    void Start()
    {
        randomPowerUp = Random.Range(1, 10);
        _meshRendere = GetComponent<MeshRenderer>();
        _origiColor = _meshRendere.material.color;
        currentHealth=enemyHealt;
        _healthBarEnemy.SetMaxHealth(enemyHealt);
    }


    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        _healthBarEnemy.SetHealth(currentHealth);
        FlashStart();

        if (currentHealth<=0f)
        {
            Die();
            if (randomPowerUp == 2)
            {
                Instantiate(ammoBox, transform.position, transform.rotation);
            }
            if (randomPowerUp==3)
            {
                Instantiate(healthBox, transform.position, transform.rotation);
            }
            
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
