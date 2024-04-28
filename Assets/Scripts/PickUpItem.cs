using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite itemSprite; // 道具的图片
    public int slotIndex; // 添加到道具栏的槽位索引
    public InventoryManager inventoryManager; // 道具栏管理器
    private Color originalColor; // 原始颜色

    private bool canPickup; // 是否可以拾取物品

    void Start()
    {
        originalColor = spriteRenderer.color; // 保存原始颜色
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canPickup = true;
            spriteRenderer.color = Color.black;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canPickup = false;
            spriteRenderer.color = originalColor;
        }
    }

    void Update()
    {
        if (canPickup && Input.GetKeyDown(KeyCode.E))
        {
            inventoryManager.AddItem(itemSprite, slotIndex); // 按下 E 键时，将道具添加到道具栏
            Destroy(gameObject); // 销毁道具
        }
    }
}
