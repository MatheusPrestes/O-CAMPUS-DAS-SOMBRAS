using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotInventory : MonoBehaviour {

    public InventoryController inventory;

    public ItemBase currentItem = null;    
    public Text nameItem;  
    public bool slotFull = false;
    public int index;   

    public static SlotInventory instance;
    
    // Use this for initialization
	void Start () {
        instance = this;   
	}   

    public Text getNameItem()
    {
        return nameItem;
    }

    public void setNameItem(string nomeNovo)
    {
        nameItem.text = nomeNovo;
    }
    
    public ItemBase getItemSlot()
    {
        return currentItem;
    }

    public void setItemSlot(ItemBase itemNovo)
    {
        currentItem = itemNovo;
    }

    public int getIndex()
    {
        return index;
    }

    public void setIndex(int indexNovo)
    {
        index = indexNovo;
    }

    public bool getSlotFull()
    {
        return slotFull;
    } 
    
    public void setSlotFull(bool full)
    {
        slotFull = full;
    }

       

    


}
