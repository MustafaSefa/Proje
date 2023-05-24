using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle_Controller : MonoBehaviour
{
    private Transform startPos;

    public float speed;

    public GameObject eagle;

    void Start()
    {
        startPos = GameObject.FindGameObjectWithTag("Start").GetComponent<Transform>();
    }

    
    void Update()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            startPos.position,
            speed * Time.deltaTime
        );
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Start"))
        {
            Destroy(eagle);
        }
    }
}
