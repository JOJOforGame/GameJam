using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("InteractiveObj/MPDScript")]
public class MountPointTypeD : InteractiveObj
{
    public GameObject targetObj;
    public QuestTypeB quest;
    public int idx;

    void Start()
    {
        targetObj.SetActive(false);
    }

    public override void Interact()
    {
        Debug.Log("Interacting with MountPointTypeD");
        if (targetObj.activeSelf)
        {
            UnMountItem();
        }
        else
        {
            MountItem();
        }
    }

    private void MountItem()
    {
        Item item = InvManager.instance.GetSelectedItem();
        if (item != null)
        {
            targetObj.SetActive(true);
            targetObj.GetComponent<SpriteRenderer>().sprite = item.sp;
            this.quest.slotItems[idx] = item;
            InvManager.instance.RemoveSelectedItem();
        }
        else
        {
            Debug.Log("No item is selected");
        }
    }

    private void UnMountItem()
    {
        Item item = quest.slotItems[idx];
        bool res = InvManager.instance.AddItem(item);
        if (!res)
        {
            Debug.Log("Inventory is full");
            return;
        }
        quest.slotItems[idx] = null;
        targetObj.SetActive(false);
    }
}
