using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TriggerFinalConversation : MonoBehaviour
{
    public Canvas dialogueCanvas; // 对话框 Canvas
    public ConversationManger dialogueManager; // 对话管理器
    public Conversation conversation; // 对话
    public Button button1; // 第一个按钮
    public ParticleSystem particleEffect; // 粒子效果
    public GameObject player; // Player 对象

    private bool playerIsHidden = false; // 记录 player 是否已隐藏
    private SpriteRenderer playerRenderer; // Player 对象的 SpriteRenderer 组件
    private Color playerColor; // Player 对象的颜色

    private void Start()
    {
        // 获取 Player 对象的 SpriteRenderer 组件
        playerRenderer = player.GetComponent<SpriteRenderer>();
        // 获取 Player 对象的初始颜色
        playerColor = playerRenderer.color;
        particleEffect.Stop();
        dialogueManager.ConversationEnded += OnConversationEnded;
        button1.onClick.AddListener(OnButton1Click);
        button1.gameObject.SetActive(false);
    }

    private void OnConversationEnded()
    {
        // 在按钮点击后播放粒子效果并逐渐隐藏 player
        StartCoroutine(FadeOutPlayer());

        // 显示第一个按钮
        button1.gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // 如果碰撞体是 "Player" 标签的对象
        {
            dialogueCanvas.gameObject.SetActive(true); // 激活对话框 Canvas
            dialogueManager.StartConversation(conversation); // 开始对话
            //Destroy(gameObject); // 销毁触发器对象自身，触发器只用一次
        }
    }

    IEnumerator StartConversationAndCheckScene()
    {
        dialogueCanvas.gameObject.SetActive(true); // 激活对话框 Canvas
        dialogueManager.StartConversation(conversation); // 开始对话

        // 等待对话结束
        while (dialogueManager.isConversationActive)
        {
            yield return null;
        }

        // 显示第一个按钮
        button1.gameObject.SetActive(true);

        // 在按钮点击后播放粒子效果并逐渐隐藏 player
        StartCoroutine(FadeOutPlayer());
    }

    // 第一个按钮的点击事件处理程序
    public void OnButton1Click()
    {
         
            particleEffect.Play(); // 播放粒子效果
            // 启动协程逐渐隐藏 player
            StartCoroutine(FadeOutPlayer());
            button1 .gameObject.SetActive(false);
        
    }

    IEnumerator FadeOutPlayer()
    {
        float fadeDuration = 1f; // 渐变持续时间
        float elapsedTime = 0f; // 已经过的时间

        while (elapsedTime < fadeDuration)
        {
            // 计算当前透明度
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            // 设置新的颜色，保持原始颜色的 RGB 部分不变，仅修改透明度
            playerRenderer.color = new Color(playerColor.r, playerColor.g, playerColor.b, alpha);

            elapsedTime += Time.deltaTime; // 增加已过时间
            yield return null; // 等待一帧
        }

        // 最终将透明度设为 0（确保没有误差）
        playerRenderer.color = new Color(playerColor.r, playerColor.g, playerColor.b, 0f);
        playerIsHidden = true; // 记录 player 已隐藏
    }
}
