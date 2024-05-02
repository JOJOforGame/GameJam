using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffect : MonoBehaviour
{
    public PlayerMovement Player;
    public GameObject Shadow;
    public GameObject Dust;
    public IndicatorManager IndicatorManager;
    public InvManager InvManager;

    GameObject lastInteractiveObj;

    // Update is called once per frame
    void Update()
    {
        // Shadow effect.
        if (Player.isGrounded())
        {
            Shadow.SetActive(true);
        }
        else
        {
            Shadow.SetActive(false);
        }

        // Dust effect.
        if (Player.isRunning())
        {
            Dust.SetActive(true);
        }
        else
        {
            Dust.SetActive(false);
        }

        if (Player.ShouldFlip()) {
            Dust.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            Dust.GetComponent<SpriteRenderer>().flipX = false;
        }

        // Indicator effect.
        if (lastInteractiveObj != null)
        {
            IndicatorManager.ShowIndicator(lastInteractiveObj.name);
        }
        else
        {
            IndicatorManager.HideIndicator();
        }

        // Interact with object.
        if (Input.GetKeyDown(KeyCode.E) && lastInteractiveObj != null)
        {
            if (lastInteractiveObj.CompareTag("Item"))
            {
                bool res = InvManager.AddItem(lastInteractiveObj.GetComponent<InteractiveObj>().item);
                if (res)
                {
                    Destroy(lastInteractiveObj);
                }
            } else if (lastInteractiveObj.CompareTag("MountPoint"))
            {
                MountPoint mp = lastInteractiveObj.GetComponent<MountPoint>();
                if (mp.targetObj.activeSelf) {
                    mp.UnMountItem();
                } else {
                    mp.MountItem();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        InteractiveObj interactiveObj = collision.GetComponent<InteractiveObj>();
        if (interactiveObj != null)
        {
            lastInteractiveObj = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        InteractiveObj interactiveObj = collision.GetComponent<InteractiveObj>();
        if (interactiveObj != null)
        {
            if (collision.gameObject == lastInteractiveObj)
            {
                lastInteractiveObj = null;
            }
        }
    }
}
