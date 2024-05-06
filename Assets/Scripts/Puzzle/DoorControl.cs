using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    public GameObject door;

    void Update()
    {
        door.SetActive(QuestManager.instance.checkQuestCompletion());
    }
}