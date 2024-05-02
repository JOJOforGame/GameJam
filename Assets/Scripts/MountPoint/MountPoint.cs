using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountPoint : MonoBehaviour
{
    public Item requiredItem;
    public GameObject targetObj;
    public void MountItem()
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

    public void UnMountItem()
    {
        targetObj.SetActive(false);
        InvManager.instance.AddItem(requiredItem);
    }
}
