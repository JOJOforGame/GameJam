using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationTrigger : MonoBehaviour
{
    public ConversationManger dialogueManager;
    public Conversation conversation;
    public Canvas bagCanvas;
    public Canvas dialogueCanvas; // ???? Canvas

    public AudioSource backgroundMusic;

    void Start()
    {
        bagCanvas.gameObject.SetActive(false);
        dialogueCanvas.gameObject.SetActive(true);
        backgroundMusic.Play();
        if (dialogueManager != null && conversation != null)
        {
            dialogueManager.StartConversation(conversation);
        }
        else
        {
            Debug.LogWarning("Dialogue Manager or Conversation is not assigned to DialogueTrigger.");
        }
    }
}
