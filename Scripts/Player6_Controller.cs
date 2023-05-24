using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player6_Controller : MonoBehaviour
{
    public Rigidbody2D rb;
    public float Speed;
    private float moveX;
    public Animator animator;
    public Animator anim;
    private bool jump = true;
    public GameObject DialogText;
    public GameObject Panel;
    public Transform MagicPoint;
    public GameObject magicPrefab;
    bool isPaused = false;

    public void pauseGame()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
        }
        else
        {
            Time.timeScale = 0;
            isPaused = true;
        }
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            pauseGame();
        }
        if (Input.GetButtonDown("Fire1"))
        {
            animator.Play("Player1_Attack");
            Shoot();
            anim.Play("Player1_Magic");
        }
        moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(
            moveX * Speed,
            rb.velocity.y
        );

        PlayerDirection();

        if (moveX != 0)
        {
            animator.SetBool("isWalking", true);
        }
        else if (moveX == 0)
        {
            animator.SetBool("isWalking", false);
        }
        if (Input.GetKeyDown(KeyCode.Space) && jump)
        {
            float jumpVelocity = 4f;
            rb.velocity = Vector2.up * jumpVelocity;
            jump = false;

        }
        else if (rb.velocity.y == 0)
        {
            jump = true;
        }
    }
    private void PlayerDirection()
    {
        if (moveX >= 0 && Input.GetKey("d"))
        {
            transform.localScale = new Vector3(1f, 1f, -5f);
        }
        else if (moveX < 0 && Input.GetKey("a"))
        {
            transform.localScale = new Vector3(-1f, 1f, -5f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Character1"))
        {
            Panel.SetActive(true);
            DialogText.SetActive(true);
        }
    }
    void Hurtanim()
    {
        animator.SetBool("isHurt", true);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Character1"))
        {
            Panel.SetActive(true);
            DialogText.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Character1"))
        {
            Panel.SetActive(false);
            DialogText.SetActive(false);
        }
    }
    void Shoot()
    {
        Instantiate(magicPrefab, MagicPoint.position, MagicPoint.rotation);
    }
}
