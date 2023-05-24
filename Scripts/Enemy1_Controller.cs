using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1_Controller : MonoBehaviour
{
    public int health = 100;
    public Animator animation;
    private Transform player;
    public bool enemy1 = false;
    public float speed;
    public GameObject enemy;
    public Rigidbody2D rb3;
    public GameObject magicPrefab;
    public int enemyDeath = 0;
    public GameObject EnemySpawner;

    void Start()
    {
        EnemySpawner = GameObject.FindGameObjectWithTag("enemySpawner");
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Die()
    {
        animation.SetBool("Enemy1_Walk", false);
        speed = 0;
        enemy1 = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            speed = 0;
            animation.SetBool("Enemy1_Walk", false);
            animation.SetBool("Enemy1_Idle", true);
            animation.SetBool("Enemy1_Attack", true);
        }
        if (collision.gameObject.CompareTag("magic"))
        {
            health -= 35;
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
        if (enemy1 == false)
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
        animation.SetBool("Enemy1_Attack", false);
        animation.SetBool("Enemy1_Idle", false);
        animation.SetBool("Enemy1_Walk", true);
        speed = 1;
    }
}
