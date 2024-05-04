using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountPointTypeB : MonoBehaviour
{
    public Item requiredItem;
    public GameObject targetObj;
    public GameObject mountPoint;
    public void MountItem()
    {
        Debug.Log("MountTriggered");
    }

    public void UnMountItem()
    {
        if (InvManager.instance.GetSelectedItem() == requiredItem)
        {
            InvManager.instance.RemoveSelectedItem();
            targetObj.SetActive(false);
            mountPoint.SetActive(false);
        }
        else
        {
            Debug.Log("No required item is selected");
        }
    }
}
