using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObj : MonoBehaviour
{
    public Item item;
    public GameObject obj;
    public GameObject outline;

    void Start()
    {
        obj.GetComponent<SpriteRenderer>().sprite = item.sp;
        if (outline != null)
        {
            outline.SetActive(false);
        }
    }

    public void TestMethod()
    {
        Debug.Log("Test method called");
    }

    public virtual void Interact()
    {
        Debug.Log("Interacted with " + name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (outline != null)
            {
                outline.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (outline != null)
            {
                outline.SetActive(false);
            }
        }
    }
}
