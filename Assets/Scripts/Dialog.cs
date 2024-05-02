using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    public GameObject Character;
    public GameObject DialogBubble;
    public GameObject DialogIndicator;
    public TMP_Text DialogText;
    public float TypeSpeed = 0.5f;
    [TextAreaAttribute(1, 3)]
    public List<string> sentences;

    private int s_index;
    private Coroutine typingRoutine;

    private void resetDialog()
    {
        DialogBubble.SetActive(false);
        DialogIndicator.SetActive(Character.GetComponent<CharacterState>().isPlayerInRange());
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

    public void onPlayerExit()
    {
        resetDialog();
    }

    private void Update()
    {
        CharacterState characterState = Character.GetComponent<CharacterState>();
        if (characterState.isPlayerInRange() && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Start dialog");
            s_index += 1;
            Debug.Log("s_index: " + s_index);
            if (this.inDialog())
            {
                stopTyping();
                Debug.Log("Type sentence: " + sentences[s_index]);
                typingRoutine = StartCoroutine(TypeSentence(sentences[s_index]));
            } else {
                resetDialog();
            }
        }

        bool shouldShowDialogIndicator =
            characterState.isPlayerInRange() &&
            !this.inDialog();
        bool shouldShowDialogBubble =
            characterState.isPlayerInRange() &&
            this.inDialog();
        DialogIndicator.SetActive(shouldShowDialogIndicator);
        DialogBubble.SetActive(shouldShowDialogBubble);
    }

    private void stopTyping()
    {
        if (typingRoutine != null)
        {
            StopCoroutine(typingRoutine);
        }
    }

    private bool inDialog()
    {
        return s_index >= 0 && s_index < sentences.Count;
    }
}
