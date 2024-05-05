using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("InteractiveObj/NPCScript")]
public class NPCScript : InteractiveObj
{
    public NPCState State;

    public DialogControl DC;

    void Start()
    {
        Debug.Log(State.sentences);
        DC.sentences = this.State.sentences;
    }

    public bool inDialog()
    {
        return DC.inDialog();
    }

    public override void Interact()
    {
        Debug.Log("Interacting with NPC");
        NPCState prevState = this.State;
        this.State = State.tryNextState();
        if (prevState != this.State)
        {
            DC.sentences = this.State.sentences;
            DC.resetDialog();
        }
        DC.TryShowDialog();
    }

    public override void OnPlayerExit()
    {
        DC.resetDialog();
    }
}