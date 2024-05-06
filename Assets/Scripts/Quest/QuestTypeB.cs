using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Quest/QuestTypeB")]
public class QuestTypeB : Quest
{
    public Item[] requiredItems;
    public Item[] slotItems;

    public override void resetQuest()
    {
        completed = false;
        for (int i = 0; i < slotItems.Length; i++)
        {
            slotItems[i] = null;
        }
    }

    public override void tryCompleteQuest()
    {
        Debug.Log("Trying to complete QuestTypeB");
        for (int i = 0; i < requiredItems.Length; i++)
        {
            if (slotItems[i] != requiredItems[i])
            {
                return;
            }
        }
        completed = true;
    }
}
