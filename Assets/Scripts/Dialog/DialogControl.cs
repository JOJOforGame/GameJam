using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogControl : MonoBehaviour
{
    public GameObject DialogBubble;
    public GameObject DialogIndicator;
    public TMP_Text DialogText;
    public float TypeSpeed = 0.5f;
    [TextAreaAttribute(1, 3)]
    public List<string> sentences;

    private int s_index;
    private Coroutine typingRoutine;

    public void resetDialog()
    {
        DialogBubble.SetActive(false);
        DialogIndicator.SetActive(true);
        s_index = -1;
        stopTyping();
    }

    private void Start()
    {
        resetDialog();
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

    public void TryShowDialog()
    {
        s_index += 1;
        if (this.inDialog())
        {
            stopTyping();
            Debug.Log("Type sentence: " + sentences[s_index]);
            typingRoutine = StartCoroutine(TypeSentence(sentences[s_index]));
        } else {
            resetDialog();
            QuestManager.instance.TryGoToNextScene();
        }

        DialogIndicator.SetActive(!this.inDialog());
        DialogBubble.SetActive(this.inDialog());
    }

    private void stopTyping()
    {
        if (typingRoutine != null)
        {
            StopCoroutine(typingRoutine);
        }
    }

    public bool inDialog()
    {
        return s_index >= 0 && s_index < sentences.Count;
    }
}
