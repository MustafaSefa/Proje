using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : MonoBehaviour
{
    public Animator animator2;
    public GameObject DialogText;
    public GameObject Panel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Panel.SetActive(true);
            DialogText.SetActive(true);
            animator2.SetBool("isCommunication", true);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Panel.SetActive(true);
            DialogText.SetActive(true);
            animator2.SetBool("isCommunication", true);
        }   
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Panel.SetActive(false);
            DialogText.SetActive(false);
            animator2.SetBool("isCommunication", false);
        }
    }
}
