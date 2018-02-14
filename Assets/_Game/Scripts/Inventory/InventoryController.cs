using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour {

    private SlotInventory slotController;

    public List<SlotInventory> inventoryItems;
    public InventoryController currentSlot;
    public SlotController controller;
    private ItemBase currentItem;    

    void Start()
    {
        controller.addSlot();
    }


    public void addSlotToInventory(SlotInventory slot)
    {
        inventoryItems.Add(slot);               
    }

    public SlotInventory getSlotList(int pos)  // retorna SLot da posição desejada
    {
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (pos == i)
            {
                return inventoryItems[pos];
            }
        }
        return null;
    }

    public bool slotFull(SlotInventory slot, int pos)
    {
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (pos==i && slot.getSlotFull())
            {
                return true;
            }
        }       
        return false;
    }

    public void addItemSlot(ItemBase item, SlotInventory slot)  // adiciona item no slot
    {        
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if(slot.getSlotFull()==false)
            {               
                slot.setItemSlot(item);
                slot.setSlotFull(true);
                slot.setNameItem(item.getNome());
            }
            
        }        
    }

    public void removeItemSlot(int index, bool remv)
    {
        if (remv == true)
        {
            ItemBase itemNovo = null;
            for (int i = 0; i < inventoryItems.Count; i++)
            {
                inventoryItems[index].setItemSlot(itemNovo);
                slotController = inventoryItems[index];
                slotController.setSlotFull(false);
                slotController.setNameItem(null);
            }
        }
    }

    public SlotInventory selectSlot()  // seleciona slot vazio
    {
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (inventoryItems[i].getSlotFull() == false)
            {
                return inventoryItems[i];
            }
        }
        return null;
    }

    public ItemBase selectItemSlot(int pos)
    {
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if(i==pos)
            {
                currentItem = inventoryItems[i].getItemSlot();
                return currentItem;
            }
        }
        return null;
    }

    public int invetoryCapacity()
    {
        return inventoryItems.Count;
    }
	
}
