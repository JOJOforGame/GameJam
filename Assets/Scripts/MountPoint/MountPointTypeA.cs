using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("InteractiveObj/MPAScript")]
public class MountPointTypeA : InteractiveObj
{
    public Item requiredItem;
    public GameObject targetObj;
    public override void Interact()
    {
        Debug.Log("Interacting with MountPointTypeA");
        if (InvManager.instance.GetSelectedItem() == requiredItem)
        {
            InvManager.instance.RemoveSelectedItem();
            targetObj.SetActive(true);
            this.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("No required item is selected");
        }
    }
}
