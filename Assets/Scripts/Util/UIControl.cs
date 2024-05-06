using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControl : MonoBehaviour
{
    public GameObject InGameUI;
    public GameObject PauseMenu;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        InGameUI.SetActive(true);
        PauseMenu.SetActive(false);
    }

    public void onInGameMenuClicked()
    {
        Debug.Log("InGameMenuClicked");
        Time.timeScale = 0;
        InGameUI.SetActive(false);
        PauseMenu.SetActive(true);
    }

    public void onPauseMenuResumeClicked()
    {
        Debug.Log("PauseMenuResumeClicked");
        Time.timeScale = 1;
        InGameUI.SetActive(true);
        PauseMenu.SetActive(false);
    }
}
