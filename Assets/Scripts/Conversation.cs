using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conversation : MonoBehaviour
{
    public string targetTag = "fishman"; // 目标对象的标签

    // 对话相关的内容和逻辑
    public void StartConversation()
    {
        Debug.Log("Sprites are talking to each other!");
        // 在这里添加你的对话逻辑
    }

    // 当有其他 Collider2D 进入触发器时调用
    void OnTriggerEnter2D(Collider2D other)
    {
        // 检查进入触发器的对象的标签是否为目标标签
        if (other.CompareTag(targetTag))
        {
            // 触发对话
            StartConversation();
        }
    }
}
