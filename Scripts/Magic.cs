using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Magic : MonoBehaviour
{
    public Transform firePoint;
    public Rigidbody2D rb;
    public float speed = 20f;
    public Animator anim;

    [SerializeField]
    float timeDestroy = 3;

    //public static int damage = 40;

    public Transform enemy;

    public Transform enemy1;

    public Transform spawnPoint;

    //public static int Damage = 35;
    
    void Start()
    {
        firePoint = GameObject.FindGameObjectWithTag("point").GetComponent<Transform>();
    }

    void Update()
    {
        rb.velocity = transform.right * speed; 
        Destroy(gameObject, timeDestroy);
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            
        }
    }*/
}
