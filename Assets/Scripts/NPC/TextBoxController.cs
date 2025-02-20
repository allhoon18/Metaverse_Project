using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class TextBoxController : MonoBehaviour
{
    public string[] Dialogues;

    public TextMeshProUGUI textBox;

    int dialogueIndex = -1;

    public GameObject TextBoxSet;


    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && TextBoxSet.gameObject)
        {
            ShowNextDialogue();
        }
    }

    void ShowNextDialogue()
    {
        dialogueIndex++;

        if (dialogueIndex >= Dialogues.Length)
            dialogueIndex = 0;

        textBox.text = Dialogues[dialogueIndex];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TextBoxSet.gameObject.SetActive(true);

        if (dialogueIndex < 0)
            dialogueIndex = 0;

        textBox.text = Dialogues[dialogueIndex];
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        TextBoxSet.gameObject.SetActive(false);
    }

}
