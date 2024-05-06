using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretControl : MonoBehaviour
{
    public Quest[] secretQuests;

    void Update()
    {
        this.gameObject.SetActive(checkQuestComplete());
    }

    private bool checkQuestComplete()
    {
        foreach (Quest q in secretQuests)
        {
            if (!q.completed)
            {
                return false;
            }
        }
        return true;
    }
}