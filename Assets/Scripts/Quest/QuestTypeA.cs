using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Quest/QuestTypeA")]
public class QuestTypeA : Quest
{
    public Item[] requiredItems;

    public override void tryCompleteQuest()
    {
        int[] slotIdxs = new int[requiredItems.Length];
        for (int i = 0; i < requiredItems.Length; i++)
        {
            Item item = requiredItems[i];
            int slotIdx = InvManager.instance.GetItemIndex(item);
            if (slotIdx == -1)
            {
                Debug.Log("Can't complete quest");
                return;
            }
            slotIdxs[i] = slotIdx;
        }
        foreach(int i in slotIdxs)
        {
            InvManager.instance.RemoveItemByIndex(i);
        }
        Debug.Log("Quest complete");
        completed = true;
    }
}
