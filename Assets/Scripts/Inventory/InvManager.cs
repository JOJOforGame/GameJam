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
                selectSlot(number - 1);
            }
        }
    }

    void selectSlot(int slot)
    {
        if (selectedSlot != -1)
        {
            slots[selectedSlot].Deselect();
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
                Debug.Log(item.item.name);
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
}