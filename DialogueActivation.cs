using System;
using System.Collections;
using UnityEngine;

public class DialogueActivation : MonoBehaviour
{
    public Canvas dialogueSystem;

    void Start()
    {
        if(dialogueSystem != null)
            dialogueSystem.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Dialogue Activated. Searching for canvas.");

            ShowDialogue();
        }
    }

    void ShowDialogue()
    {
        Debug.Log("Dialogue Started.");
        dialogueSystem.gameObject.SetActive(true);
    }
}
