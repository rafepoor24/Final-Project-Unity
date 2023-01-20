using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static WaveSpawner;

public class WaveSpawner : MonoBehaviour
{
    
    public enum SpawnState { SPAWNING, WAITING,COUNTING};

    [System.Serializable]
    public class Wave
    { 
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }
    public Wave[] waves;
    public int nextWave=0;
    public Transform[] spawnPoints;



    public float timeBetweenWaves= 5F;
    private float waveCountDown;
    private float searchCountDown =1f;

    private SpawnState state = SpawnState.COUNTING;

void Start()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.Log("No spawnPoints referenced");
        }
        waveCountDown =timeBetweenWaves;

    }

    void Update()
    {
        if (state ==SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                WaveCompleted();
            }
            else
            {
                return;
            }
        }

        if (waveCountDown <=0)
        {
            if (state!=SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountDown-=Time.deltaTime;
        }

        //GameManager.Instance.nextWave(nextWave);
    }

    void WaveCompleted()
    {
        Debug.Log("WaveCompleted");
        state = SpawnState.COUNTING;
        waveCountDown = timeBetweenWaves;
        if (nextWave +1 >waves.Length -1)
        {
            nextWave = 0;
            //here code for completed level and load the next level
            Debug.Log("ALL WAVES COMPLETED");
        }
        else
        {
            nextWave++;
        }
        
    }

    bool EnemyIsAlive()
    {
       
        searchCountDown -= Time.deltaTime;
        if (searchCountDown <= 0f)
        {
            searchCountDown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
       
        return true;    
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning Wave: " +_wave.name );

        state =SpawnState.SPAWNING;
        for (int i = 0; i <_wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }
        state=SpawnState.WAITING;
        yield break;
    }

    void SpawnEnemy (Transform _enemy)
    {
        Debug.Log("Spawning Enemy" + _enemy.name);
        
        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy, _sp.position, _sp.rotation);
    }

  
}
