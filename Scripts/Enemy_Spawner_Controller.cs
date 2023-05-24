using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner_Controller : MonoBehaviour
{
    public GameObject enemyPrefab;

    public Transform[] spawnPoint;

    public float interval;

    public float time;

    void Start()
    {
        
        InvokeRepeating("Spawn", 0.5f, interval);
    }
    
    void FixedUpdate()
    {
        time += Time.deltaTime;
        if (time >= 24)
        {
            CancelInvoke();
        }
    }
    
    private void Spawn()
    {
        int randPos = Random.Range(0, spawnPoint.Length);
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint[randPos].position, Quaternion.identity);
    }
}
