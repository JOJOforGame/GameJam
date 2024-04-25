using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShadow : MonoBehaviour
{
    public PlayerMovement Player;
    public GameObject Shadow;
    public GameObject Dust;

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
            Debug.Log("Flip");
            Dust.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            Debug.Log("Not Flip");
            Dust.GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
