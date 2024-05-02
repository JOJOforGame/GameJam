using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public Image img;
    public Color selected, notSelected;

    void Awake()
    {
        Deselect();
    }

    public void Select()
    {
        img.color = selected;
    }

    public void Deselect()
    {
        img.color = notSelected;
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        InventoryItem item = dropped.GetComponent<InventoryItem>();
        item.setParentAfterDrag(transform);
    }
}
