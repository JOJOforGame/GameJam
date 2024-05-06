using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : ScriptableObject
{
    public string questID;
    public bool completed;

    public virtual void resetQuest()
    {
        completed = false;
    }

    public virtual void tryCompleteQuest()
    {
        Debug.Log("Quest completed!");
    }
}
