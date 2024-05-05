using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("InteractiveObj/MPBScript")]
public class MountPointTypeB : InteractiveObj
{
    public Item requiredItem;
    public GameObject targetObj;

    public override void Interact()
    {
        Debug.Log("Interacting with MountPointTypeB");
        if (InvManager.instance.GetSelectedItem() == requiredItem)
        {
            InvManager.instance.RemoveSelectedItem();
            targetObj.SetActive(false);
            this.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("No required item is selected");
        }
    }
}
