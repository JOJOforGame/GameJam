using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFinalConvaersation : MonoBehaviour
{
    public Canvas dialogueCanvas; 
    public ConversationManger dialogueManager; // ??????
    public Conversation conversation;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // ??????????
        {
            dialogueCanvas.gameObject.SetActive(true);
            dialogueManager.StartConversation(conversation);
            Destroy(gameObject); // ???????????????
        }
    }

}
