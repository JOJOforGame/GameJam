using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControl : MonoBehaviour
{
    public GameObject inGame;
    public GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        inGame.SetActive(true);
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
