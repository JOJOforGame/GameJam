using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("InteractiveObj/ItemScript")]
public class ItemScript : InteractiveObj
{
    public override void Interact()
    {
        bool res = InvManager.instance.AddItem(this.objBase as Item);
        if (res)
        {
            Destroy(this.gameObject);
        }
    }
}