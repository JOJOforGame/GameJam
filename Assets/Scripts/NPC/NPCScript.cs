using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("InteractiveObj/NPCScript")]
public class NPCScript : InteractiveObj
{
    public Quest[] quests;

    public override void Interact()
    {
        Debug.Log("Interacting with TestObjA");
    }
}