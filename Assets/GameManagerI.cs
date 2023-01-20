using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerI : MonoBehaviour 
{
    private bool isPaused;
    public static GameManagerI Instance {get; private set; }
    private void Awake ()
  {
    if (Instance != null && Instance != this)
    {
        Destroy(this);
    }
    else 
    {
        Instance = this;
    }
  }  
    private void Update() 
     {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            UpdateGameState();
            
        }
    }
    private void UpdateGameState()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;

        }

    }

}