using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalConversation : MonoBehaviour
{
   
    public Canvas bagCanvas;
    public AudioSource backgroundMusic;

    void Start()
    {
        bagCanvas.gameObject.SetActive(false);
        backgroundMusic.Play();
        
    }
}
