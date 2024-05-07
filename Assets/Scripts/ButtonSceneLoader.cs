using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonSceneLoader : MonoBehaviour
{
    public Button button;

    private void Start()
    {    
      
        // ????????????
        button.onClick.AddListener(LoadScene);
    }

    // ?????????
    private void LoadScene()
    {
        // ????????????
        SceneManager.LoadScene("LastScene");
    }
}
