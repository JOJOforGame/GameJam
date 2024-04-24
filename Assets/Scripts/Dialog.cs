using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    public GameObject DialogBubble;
    public GameObject DialogIndicator;
    public TMP_Text DialogText;
    public float TypeSpeed = 0.5f;

    [TextAreaAttribute(1, 3)]
    public List<string> sentences;

    private int s_index;
    private bool inDialog;
    private Coroutine typingRoutine;

    private void Awake()
    {
        DialogBubble.SetActive(false);
        DialogIndicator.SetActive(false);
    }

    public void StartDialog()
    {
        if (inDialog)
        {
            return;
        }

        inDialog = true;
        DialogBubble.SetActive(true);
        DialogIndicator.SetActive(false);
        DialogText.text = string.Empty;
        s_index = -1;
    }

    public void EndDialog()
    {
        inDialog = false;
        DialogBubble.SetActive(false);
        if (typingRoutine != null)
        {
            StopCoroutine(typingRoutine);
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        DialogText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            DialogText.text += letter;
            yield return new WaitForSeconds(TypeSpeed);
        }
    }

    private void Update()
    {
        if (inDialog && Input.GetKeyDown(KeyCode.E))
        {
            s_index += 1;
            if (s_index < sentences.Count)
            {
                if (typingRoutine != null)
                {
                    StopCoroutine(typingRoutine);
                }
                typingRoutine = StartCoroutine(TypeSentence(sentences[s_index]));
            }
            else
            {
                EndDialog();
                DialogIndicator.SetActive(true);
            }
        }
    }

    public bool InDialog()
    {
        return inDialog;
    }
}
