using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player_Controller : MonoBehaviour
{
    public TextMeshProUGUI TaskText;
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
    public int task = 0;
    public GameObject TaskPanel;
    public GameObject Rain;
    bool isPaused = false;

    void Start()
    {
        task = Player2_Controller.Task;
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
    void Update()
    {
        /*currentHealth = 100;
        currentHealth = maxHealth;
        healthBar.slider.value = 100;*/
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            //healthBar.slider.value = 100;
            pauseGame();
        }
        if(Dialog.task == true)
        {
            TaskPanel.SetActive(true);
        }
        switch (task)
        {
            case 1:
                TaskText.text = "1/6";
                break;
            case 2:
                TaskText.text = "2/6";
                break;
            case 3:
                TaskText.text = "3/6";
                break;
            case 4:
                TaskText.text = "4/6";
                break;
            case 5:
                TaskText.text = "5/6";
                break;
            case 6:
                TaskText.text = "6/6";
                break;
            default:
                TaskText.text = "0/6";
                break;
        }
        if(task == 1)
        {
            Invoke("rain", 1);
        }
        else if(task == 4)
        {
            CancelInvoke("rain");
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

        if(moveX != 0)
        {
            animator.SetBool("isWalking", true);
        }
        else if(moveX == 0)
        {
            animator.SetBool("isWalking", false);
        }
        if (Input.GetKeyDown(KeyCode.Space) && jump)
        {
            float jumpVelocity = 4f;
            rb.velocity = Vector2.up * jumpVelocity;
            jump = false;
            
        }
        else if(rb.velocity.y == 0)
        {
            jump = true;
        }
    }
    private void PlayerDirection()
    {
        if(moveX >= 0 && Input.GetKey("d"))
        {
            transform.localScale = new Vector3(1f, 1f, -5f);
        }
        else if(moveX < 0 && Input.GetKey("a"))
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
        if(collision.gameObject.CompareTag("Character1"))
        {
            Panel.SetActive(true);
            DialogText.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Character1"))
        {
            Panel.SetActive(false);
            DialogText.SetActive(false);
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
    void rain()
    {
        Rain.SetActive(true);
    }
}
