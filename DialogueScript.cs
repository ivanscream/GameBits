using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueScript : MonoBehaviour

    // should be attached to canvas, TMPRO also required to show text. Don't forget to add it to the script component!
{
    public TextMeshProUGUI textComponent;
    public string[] conversationLines;
    public float textSpeed; // the less the faster

    private int index;

    private void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == conversationLines[index])
            {
                NextLine();
            }


            else
            {
                StopAllCoroutines();
                textComponent.text = conversationLines[index];
            }
        }
    }

    void NextLine()
    {
        if (index < conversationLines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            SceneManager.LoadScene("GameplayStart");
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in conversationLines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }



}
