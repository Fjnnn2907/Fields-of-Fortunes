using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class talk : MonoBehaviour
{
    public GameObject Panel1;
    public TextMeshProUGUI Text1;
    public string[] dialogue;
    public string[] specialDialogueLines;
    private bool isSpecialDialogue = false;
    private int index;

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
                StartCoroutine(Typing2());
                isSpecialDialogue = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && playerIsClose )
        {
            if (Panel1.activeInHierarchy)
            {
                zeroText();
            }
            else
            {

                Panel1.SetActive(true);
                StartCoroutine(Typing());
                isSpecialDialogue = false;
            }
        }

        if (Text1.text == (isSpecialDialogue ? specialDialogueLines[index] : dialogue[index])) //điều khiện đúng(Sai) ? toàn bộ đúng : toàn bộ sai
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (isSpecialDialogue)
                {
                    NextLine2();
                }
                else
                {
                    NextLine();
                }
            }
        }
    }

    public void zeroText()
    {
        Text1.text = "";
        index = 0;
        Panel1.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {
            Text1.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    IEnumerator Typing2()
    {
        foreach (char letter in specialDialogueLines[index].ToCharArray())
        {
            Text1.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {
        if (index < dialogue.Length - 1)
        {
            index++;
            Text1.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
        }
    }

    public void NextLine2()
    {
        if (index < specialDialogueLines.Length - 1)
        {
            index++;
            Text1.text = "";
            StartCoroutine(Typing2());
        }
        else
        {
            zeroText();
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
