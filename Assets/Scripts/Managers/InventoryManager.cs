using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class InventoryManager : MonoBehaviour
{
    [SerializeField] Slot[] inventorySlots;

    private static InventoryManager inventoryManager;
    public static InventoryManager Instance
    {
        get
        {
            return inventoryManager;
        }
    }

    private void Awake()
    {
        inventoryManager = this;
    }

    public bool CheckSlots()
    {
        foreach (Slot slot in inventorySlots)
        {
            if (slot.bookSection == Section.NONE)
            {
                return true;
            }
        }

        return false;
    }

    public Slot ReturnSlotAtIndex(int index)
    {
        return inventorySlots[index];
    }

    public void RemoveSlotAtIndex(int index)
    {
        inventorySlots[index].RemoveBookTaskWithReward();
    }

    public bool SetSlot(BookTask bookTask, Color color, Section section)
    {
        foreach (Slot slot in inventorySlots)
        {
            if (slot.isEmpty)
            {
                slot.SetBookTask(bookTask, color, section);
                return true;
            }
        }
        
        return false;
    }
}
