using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2_Controller2 : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public float speed = 2 ;
    public Transform Player2_Point;
    
    void Start()
    {
        Player2_Point = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Update()
    {
        anim.Play("Playe2_Idle");
    }
}
