using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/NPCState")]
public class NPCState : ScriptableObject
{
    public Quest[] requiredQuests;

    public NPCState nextState;

    [TextArea]
    public List<string> sentences;

    public NPCState tryNextState()
    {
        if (checkQuest())
        {
            if (nextState != null)
            {
                return nextState;
            }
        }
        return this;
    }

    private bool checkQuest()
    {
        foreach(Quest q in requiredQuests)
        {
            if (!q.completed)
            {
                return false;
            }
        }
        return true;
    }
}
