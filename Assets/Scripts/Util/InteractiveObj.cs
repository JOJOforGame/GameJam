using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObj : MonoBehaviour
{
    public ObjBase objBase;
    public GameObject outline;

    void Start()
    {
        Debug.Log("Start IO: " + objBase);
        if (objBase != null && objBase.sp != null)
        {
            Debug.Log("Render sp: " + objBase.id);
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

    public virtual void OnPlayerExit()
    {
        Debug.Log("Player exit");
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
            OnPlayerExit();
        }
    }
}
