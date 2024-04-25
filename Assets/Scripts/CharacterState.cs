using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterState : MonoBehaviour
{
    public UnityEvent ResetDialog;
    private bool playerInRange;

    void Start()
    {
        playerInRange = false;
    }

    public bool isPlayerInRange()
    {
        return playerInRange;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player in range");
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player out of range");
            playerInRange = false;
            ResetDialog.Invoke();
        }
    }
}
