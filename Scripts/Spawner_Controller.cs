using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Controller : MonoBehaviour
{
    public GameObject Player2_Prefab;

    public Transform[] spawnPoint;

    void Start()
    {
        if(Player2_Controller.Task == 6)
        {
            spawn();
        }
        
    }
    private void spawn()
    {
        int randPos = Random.Range(0, spawnPoint.Length);
        GameObject newPlayer2 = Instantiate(Player2_Prefab, spawnPoint[randPos].position, Quaternion.identity);
    }

}
