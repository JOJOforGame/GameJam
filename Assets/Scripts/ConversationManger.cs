using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConversationManger : MonoBehaviour
{
    public TMP_Text characterNameText; // 显示角色名字的文本框
    public TMP_Text dialogueText; // 显示对话的文本框
    public Image leftCharacterImage; // 显示左侧角色头像的图片框
    public Image rightCharacterImage; // 显示右侧角色头像的图片框
    public Button nextButton; // 下一个按钮
    public Canvas dialogueCanvas; // 对话框的 Canvas
    public Canvas bagCanvas;
    public bool isConversationActive = false; // 对话是否正在进行中的标志

    private Queue<string> sentences = new Queue<string>();// 对话内容队列

    private string currentCharacterName; // 当前对话角色名字

    public event Action ConversationEnded;

    private void Awake()
    {
        nextButton.onClick.AddListener(DisplayNextSentence);
    }

    public void StartConversation(Conversation conversation)
    {
        if (isConversationActive)
        {
            return; // 如果对话已经在进行中，则不执行新的对话
        }

        if (sentences == null)
        {
            sentences = new Queue<string>();
        }
        sentences.Clear();

        foreach (string sentence in conversation.xieYanSentences)
        {
            sentences.Enqueue(sentence);
        }

        // 添加右侧角色的对话内容和头像
        foreach (string sentence in conversation.xieMingSentences)
        {
            sentences.Enqueue(sentence);
        }

        isConversationActive = true;


        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndConversation();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;

        if (!string.IsNullOrEmpty(currentCharacterName))
        {
            characterNameText.text = currentCharacterName;
        }

        if (leftCharacterImage.gameObject.activeSelf)
        {
            rightCharacterImage.gameObject.SetActive(true);
            leftCharacterImage.gameObject.SetActive(false);
        }
        else if (rightCharacterImage.gameObject.activeSelf)
        {
            leftCharacterImage.gameObject.SetActive(true);
            rightCharacterImage.gameObject.SetActive(false);
        }
    }

    void EndConversation()
    {
        isConversationActive = false; 
        dialogueCanvas.gameObject.SetActive(false);
        bagCanvas.gameObject.SetActive(true);
        ConversationEnded?.Invoke();
    }

}

[System.Serializable]
public class Conversation
{
    public string xieYanName = "谢言";
    public string[] xieYanSentences = {
        "纸鸢纸鸢，挂树上了！",
        "姐姐会飞檐走壁，一定可以帮我拿到纸鸢的~"
    };

    public string xieMingName = "谢明";
    public string[] xieMingSentences = {
        "言言别担心，阿姊来！",
        "言言以后一定会和大树一样高高的~"
    };
    
    public Sprite xieYanSprite;
    public Sprite xieMingSprite;
}

public class ConversationA
{
    public string xieYanName = "神树";
    public string xieMingName = "谢明";
    public string[] shenshuSentences = {
    "遠方之客，來者何事？",
    "吾何故以珍贵之叶与汝？且人生天地间，各有天命。宇宙循环，自然法则。若救尔妹，必有其相应之代价。人欲求幸福，往往视物表象，而忽视其中深意。尔是否愿为一时之喜而付不可逆之代价？",
    "尔之决心可嘉，然天地秩序不可轻逆。取此神叶，亦当受其带来之一切。"
};

    public string[] xieMingSentences = {
    "神明之树，闻尔叶可救我妹之危，敢求一片以救我妹矣。",
    "然则，妹为我生之至爱，愿以一切代之！"
};
    

    public Sprite shenshuSprite;
    public Sprite xieMingSprite;
}
