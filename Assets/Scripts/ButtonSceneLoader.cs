using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonSceneLoader : MonoBehaviour
{
    public Button button;
    public string sceneName;

    private void Start()
    {    
      
        // ????????????
        button.onClick.AddListener(LoadScene);
    }

    // ?????????
    private void LoadScene()
    {
        // ????????????
        SceneManager.LoadScene(sceneName);
    }
}
