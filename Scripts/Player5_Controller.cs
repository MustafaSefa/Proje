using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player5_Controller : MonoBehaviour
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
    public PolygonCollider2D PC;
    public int maxHealth = 100;
    public int currentHealth;
    public Health_Bar healthBar;
    public int damage = 20;
    public static bool key = false;
    bool isPaused = false;
    public GameObject gameOver;

    void Start()
    {
        print(key);
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
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
    public void Restart(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        Time.timeScale = 1;
    }
    public void Exit()
    {
        Time.timeScale = 1;
        Application.Quit();
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (currentHealth == 0)
        {
            pauseGame();
            gameOver.SetActive(true);
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
        if (collision.gameObject.CompareTag("enemy"))
        {
            InvokeRepeating("TakeDamage", 0.5f, 1.5f);
            InvokeRepeating("Hurtanim", 0.8f, 0.5f);
        }

        if (collision.gameObject.CompareTag("key"))
        {
            key = true;
            Destroy(GameObject.FindWithTag("key"));
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
        else if (collision.gameObject.CompareTag("enemy"))
        {
            CancelInvoke("TakeDamage");
            CancelInvoke("Hurtanim");
            animator.SetBool("isHurt", false);
        }
    }
    void Shoot()
    {
        Instantiate(magicPrefab, MagicPoint.position, MagicPoint.rotation);
    }

    void TakeDamage()
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
