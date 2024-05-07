using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvManager : MonoBehaviour
{
    public static InvManager instance;
    public InventorySlot[] slots;
    public GameObject itemPrefab;

    int selectedSlot = -1;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (Input.inputString != null)
        {
            bool res = int.TryParse(Input.inputString, out int number);
            if (res && number > 0 && number < 10)
            {
                trySelectSlot(number - 1);
            }
        }
    }

    void trySelectSlot(int slot)
    {
        if (selectedSlot != -1)
        {
            slots[selectedSlot].Deselect();
        }
        if (selectedSlot == slot)
        {
            selectedSlot = -1;
            return;
        }
        selectedSlot = slot;
        slots[selectedSlot].Select();
    }

    public bool AddItem(Item item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            InventorySlot slot = slots[i];
            InventoryItem slotItem = slot.GetComponentInChildren<InventoryItem>();
            if (slotItem == null)
            {
                SpawnInvItem(item, slot);
                return true;
            }
        }
        return false;
    }

    void SpawnInvItem(Item item, InventorySlot slot)
    {
        GameObject itemObj = Instantiate(itemPrefab, slot.transform);
        InventoryItem invItem = itemObj.GetComponent<InventoryItem>();
        invItem.InitItem(item);
    }

    public Item GetSelectedItem()
    {
        if (selectedSlot != -1)
        {
            InventoryItem item = slots[selectedSlot].GetComponentInChildren<InventoryItem>();
            if (item != null)
            {
                return item.item;
            }
            return null;
        }
        return null;
    }

    public void RemoveSelectedItem()
    {
        if (selectedSlot != -1)
        {
            InventoryItem item = slots[selectedSlot].GetComponentInChildren<InventoryItem>();
            if (item != null)
            {
                Destroy(item.gameObject);
            }
        }
    }

    public int GetItemIndex(Item item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            InventoryItem slotItem = slots[i].GetComponentInChildren<InventoryItem>();
            if (slotItem != null && slotItem.item.Equals(item))
            {
                return i;
            }
        }
        return -1;
    }

    public void RemoveItemByIndex(int index)
    {
        if (index != -1)
        {
            Destroy(slots[index].GetComponentInChildren<InventoryItem>().gameObject);
        }
    }

    public bool TryRemoveItems(Item[] items)
    {
        int[] idxs = new int[items.Length];
        for (int i = 0; i < items.Length; i++)
        {
            idxs[i] = GetItemIndex(items[i]);
            if (idxs[i] == -1)
            {
                return false;
            }
        }
        foreach (int idx in idxs)
        {
            Destroy(slots[idx].GetComponentInChildren<InventoryItem>().gameObject);
        }
        return true;
    }
}