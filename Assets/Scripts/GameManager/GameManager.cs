using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField]private TextMeshProUGUI ammoText;
    [SerializeField]private TextMeshProUGUI healthText;
    public static GameManager Instance { get; private set; }

    public int gunAmmo = 10;
    private int health = 100;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        ammoText.text=gunAmmo.ToString();
        healthText.text=health.ToString();
    }
}


