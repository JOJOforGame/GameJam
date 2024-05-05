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

    GameObject lastInteractGO;

    // Update is called once per frame
    void Update()
    {
        InteractiveObj iobj = lastInteractGO != null ? lastInteractGO.GetComponent<InteractiveObj>() : null;

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

        // Interact with object.
        if (Input.GetKeyDown(KeyCode.E) && iobj != null)
        {
            iobj.Interact();
        }

        // Indicator effect.
        if (iobj != null && ShouldShowIndicatorForNPC(iobj))
        {
            if (iobj.objBase != null &&
                !string.IsNullOrEmpty(iobj.objBase.description)
            )
            {
                IndicatorManager.ShowIndicator(iobj.objBase.description);
            }
            else
            {
                IndicatorManager.ShowIndicator(lastInteractGO.name);
            }
        }
        else
        {
            IndicatorManager.HideIndicator();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        InteractiveObj interactiveObj = collision.GetComponent<InteractiveObj>();
        if (interactiveObj != null)
        {
            lastInteractGO = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        InteractiveObj interactiveObj = collision.GetComponent<InteractiveObj>();
        if (interactiveObj != null)
        {
            if (collision.gameObject == lastInteractGO)
            {
                lastInteractGO = null;
            }
        }
    }

    private bool ShouldShowIndicatorForNPC(InteractiveObj obj)
    {
        NPCScript npc = obj as NPCScript;
        return npc != null && !npc.inDialog();
    }
}
