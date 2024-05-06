using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/NPC")]
public class NPC : ObjBase
{
    void OnEnable()
    {
        this.description = "对话";
    }
}