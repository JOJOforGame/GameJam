using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountPointTypeA : MonoBehaviour
{
    public Item requiredItem;
    public GameObject targetObj;
    public GameObject mountPoint;
    public void MountItem()
    {
        if (InvManager.instance.GetSelectedItem() == requiredItem)
        {
            InvManager.instance.RemoveSelectedItem();
            targetObj.SetActive(true);
            mountPoint.SetActive(false);
        }
        else
        {
            Debug.Log("No required item is selected");
        }
    }

    public void UnMountItem()
    {
        Debug.Log("UnMountTriggered");
    }
}
