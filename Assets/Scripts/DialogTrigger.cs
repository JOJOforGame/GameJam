using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    private bool playerInRange;
    public Dialog Dialog;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player in range");
            playerInRange = true;
            Dialog.DialogIndicator.SetActive(!Dialog.InDialog());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player out of range");
            playerInRange = false;
            Dialog.DialogIndicator.SetActive(false);
            Dialog.EndDialog();
        }
    }

    private void Update()
    {
        if (playerInRange = true && Input.GetKeyDown(KeyCode.E))
        {
            Dialog.StartDialog();
        }
    }
}
