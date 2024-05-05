using UnityEngine;
using UnityEngine.UI;

public class ToggleImage : MonoBehaviour
{
    public GameObject canvas; // ???Canvas??

    public GameObject Image; // ?????????
    public Button button;

   
    void Start()
    {
        // ?????????Canvas
        Image.SetActive(false);
        button.onClick.AddListener(OnButtonClick);
    }

    public void OnButtonClick()
    {
      
        if(Image.activeSelf)
        {
            canvas.SetActive(false);
        }
        else
        {
            Image.SetActive(true);
        }


       
        
    }
}
