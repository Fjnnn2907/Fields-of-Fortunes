using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class text : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public string[] dialogue;
    private int index = 0;
    public float dialogueSpeed;
    public GameObject Panel1;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {       
            Panel1.SetActive(true);
            NextText();
    }

    public void NextText()
    {
        if (index < dialogue.Length - 1)
        {
            dialogueText.text = "";
            StartCoroutine(Text());
        }
    }
    IEnumerator Text()
    {
        foreach (char character in dialogue[index].ToCharArray())
        {
            dialogueText.text += character;
            yield return new WaitForSeconds(dialogueSpeed);
        }
        index++;
    }
}