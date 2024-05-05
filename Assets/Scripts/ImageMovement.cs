using UnityEngine;
using UnityEngine.UI;

public class ImageMovement : MonoBehaviour
{
    // ????
    public float fallSpeed = 1f;

    // ??????
    public float windFactor = 0.05f;

    // ????
    private Vector3 startPosition;

    // RectTransform ??
    private RectTransform rectTransform;

    void Start()
    {
        // ?? RectTransform ??
        rectTransform = GetComponent<RectTransform>();

        // ??????
        startPosition = rectTransform.anchoredPosition;
    }

    void Update()
    {
        // ???????
        rectTransform.anchoredPosition += Vector2.down * fallSpeed * Time.deltaTime;

        // ???????????
        float windOffset = Mathf.Sin(Time.time) * windFactor;
        rectTransform.anchoredPosition = new Vector2(startPosition.x + windOffset, rectTransform.anchoredPosition.y);
    }
}
