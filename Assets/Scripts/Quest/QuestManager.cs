using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;
    public Quest[] quests;

    void Awake()
    {
        instance = this;
        foreach (Quest quest in quests)
        {
            quest.completed = false;
        }
    }
}