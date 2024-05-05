using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("InteractiveObj/MPCScript")]
public class MountPointTypeC : InteractiveObj
{
    public Item requiredItem;
    public GameObject targetObj;

    public override void Interact()
    {
        Debug.Log("Interacting with MountPointTypeC");
        if (targetObj.activeSelf)
        {
            UnMountItem();
        }
        else
        {
            MountItem();
        }
    }

    private void MountItem()
    {
        if (InvManager.instance.GetSelectedItem() == requiredItem)
        {
            InvManager.instance.RemoveSelectedItem();
            targetObj.SetActive(true);
        }
        else
        {
            Debug.Log("No required item is selected");
        }
    }

    private void UnMountItem()
    {
        targetObj.SetActive(false);
        InvManager.instance.AddItem(requiredItem);
    }
}
