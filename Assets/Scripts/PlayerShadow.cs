using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShadow : MonoBehaviour
{
    public PlayerMovement Player;
    public GameObject Shadow;

    // Update is called once per frame
    void Update()
    {
        if (Player.isGrounded())
        {
            Shadow.SetActive(true);
        }
        else
        {
            Shadow.SetActive(false);
        }
    }
}
