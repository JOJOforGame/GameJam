using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationTrigger : MonoBehaviour
{
    public ConversationManger dialogueManager;
    public Conversation conversation;

    public AudioSource backgroundMusic;

    void Start()
    {
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
