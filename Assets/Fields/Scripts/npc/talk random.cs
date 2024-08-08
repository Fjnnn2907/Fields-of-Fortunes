using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;

public class random : MonoBehaviour
{
    private int index;
    public string[] dialogues;
    public TextMeshProUGUI dialogueText;
    public GameObject Panel1;
    public float wordSpeed;
    public bool playerIsClose;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            if (Panel1.activeInHierarchy)
            {
                zeroText();
            }
            else
            {
                Panel1.SetActive(true);
                StartCoroutine(Speak());
            }
        }
    }

    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        Panel1.SetActive(false);
    }

    IEnumerator Speak()
    {
        // Chọn một câu thoại ngẫu nhiên từ mảng
        int randomIndex = UnityEngine.Random.Range(0, dialogues.Length);
        string dialogue = dialogues[randomIndex];

        // Hiển thị câu thoại từng từ một
        dialogueText.text = "";
        index = 0;
        while (index < dialogue.Length)
        {
            dialogueText.text += dialogue[index];
            index++;
            yield return new WaitForSeconds(wordSpeed);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
        }
    }
}