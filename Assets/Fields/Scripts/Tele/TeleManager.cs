using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleManager : MonoBehaviour
{
    public GameObject Panel;
    public bool isOpen = false;
    private bool isPlayerInTrigger = false;

    private void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            if (!isOpen)
            {
                Panel.SetActive(true);
                isOpen = true;
            }
            else
            {
                Panel.SetActive(false);
                isOpen = false;
            }
        }

        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    if (!isOpen)
        //    {
        //        Panel.SetActive(true);
        //        isOpen = true;
        //    }
        //    else
        //    {
        //        Panel.SetActive(false);
        //        isOpen = false;
        //    }
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isPlayerInTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isPlayerInTrigger = false;
            //Panel.SetActive(false);
            //isOpen = false;
        }
    }
}
