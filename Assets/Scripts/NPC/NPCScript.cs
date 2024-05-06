using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("InteractiveObj/NPCScript")]
public class NPCScript : InteractiveObj
{
    public NPCState State;

    public DialogControl DC;

    public GameObject optionalTarget;

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
        // Advance quest
        foreach (Quest q in this.State.requiredQuests)
        {
            q.tryCompleteQuest();
        }
        NPCState prevState = this.State;
        this.State = State.tryNextState();
        if (prevState != this.State)
        {
            DC.sentences = this.State.sentences;
            DC.resetDialog();
            if (optionalTarget != null)
            {
                optionalTarget.SetActive(true);
            }
        }
        DC.TryShowDialog();
    }

    public override void OnPlayerExit()
    {
        DC.resetDialog();
    }
}