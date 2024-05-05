using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Item")]
public class Item : ObjBase
{
    public Sprite icon;

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Item other = (Item) obj;
        return id == other.id;
    }

    // Override GetHashCode as well when Equals is overridden
    public override int GetHashCode()
    {
        return id.GetHashCode();
    }
}