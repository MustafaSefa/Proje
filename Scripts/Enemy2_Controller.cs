using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2_Controller : MonoBehaviour
{
    public  int health = 100;
    public Animator animation;
    private Transform player;
    public bool enemy2 = false;
    public float speed;
    public GameObject enemy;
    public Rigidbody2D rb3;
    public GameObject magicPrefab;
    public int enemyDeath = 0;
    public GameObject EnemySpawner;
    
    void Die()
    {
        speed = 0;
        enemy2 = true;
    }
    void Start()
    {
        EnemySpawner = GameObject.FindGameObjectWithTag("enemySpawner");
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            speed = 0;
            animation.SetBool("Enemy2_Walk", false);
            animation.SetBool("Enemy2_Attack", true);
        }
        else if (collision.gameObject.CompareTag("magic"))
        {
            health -= 30;
            if(health <= 0)
            {
                Die();
                Destroy(GameObject.FindWithTag("enemy"));
            }
            Destroy(GameObject.FindWithTag("magic"));
        }
    }


    void Update()
    {
        if (enemy2 == false)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                player.position,
                speed * Time.deltaTime
            );
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        animation.SetBool("Enemy2_Attack", false);
        animation.SetBool("Enemy2_Walk", true);
        speed = 1;
    }
}
