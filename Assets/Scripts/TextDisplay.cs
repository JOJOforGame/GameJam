using UnityEngine;
using TMPro;

public class TextDisplay : MonoBehaviour
{
    public TMP_Text textComponent;
    public float displaySpeedInFrames = 5f; // ??????????????

    private string[] lines; // ????????
    private int currentIndex = 0; // ????????
    private float timer = 0f; // ???

    void Start()
    {
        // ??????????????
        lines = textComponent.text.Split('\n');
        // ? TextMeshPro ????????????????
        textComponent.text = "";
    }

    void Update()
    {
        // ?????????
        if (currentIndex < lines.Length)
        {
            // ?????
            timer += Time.deltaTime * displaySpeedInFrames;
            // ???????????????
            if (timer >= 1f)
            {
                // ???????????????? 0
                textComponent.text += lines[currentIndex] + "\n";
                currentIndex++;
                timer = 0f;
            }
        }
    }
}