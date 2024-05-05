using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObj : MonoBehaviour
{
    public ObjBase objBase;
    public GameObject outline;

    void Start()
    {
        if (objBase != null && objBase.sp != null)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = objBase.sp;
        }
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
