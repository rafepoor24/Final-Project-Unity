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
    public static GameManager Instance { get; private set; }

    //public int gunAmmo = 10;
    public int health = 100;
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
    
}


