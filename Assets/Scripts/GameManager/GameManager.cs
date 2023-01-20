using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    //[SerializeField]private TextMeshProUGUI ammoText;
    [SerializeField]private TextMeshProUGUI healthText;
    [SerializeField]private TextMeshProUGUI WaveText;
    public static GameManager Instance { get; private set; }

    //public int gunAmmo = 10;
    private int health = 100;
    private int healthEnemy = 100;
    private int wave = 0;
    

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        //ammoText.text=gunAmmo.ToString();
        healthText.text=health.ToString();
        WaveText.text=wave.ToString();
    }

    public void LostHealt(int valueToLost)
    {
        health -= valueToLost;
        RestarLevel();

    }
    public void RestarLevel()
    {
        if(health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void nextWave(int _wave)
    {
        wave +=_wave;
       

    }

    public void LostHealtEnemy(int valueToLostEnemy)
    {
        healthEnemy -= valueToLostEnemy;

        if (healthEnemy<=0)
        {
            Destroy(FindObjectOfType<EnemyInterations>().transform.parent.gameObject);
        }

    }

}


