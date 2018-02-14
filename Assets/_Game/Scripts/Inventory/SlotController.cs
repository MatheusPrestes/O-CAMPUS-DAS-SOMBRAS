using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotController : MonoBehaviour {

    public SlotInventory slot1;
    public SlotInventory slot2;
    public SlotInventory slot3;
    public SlotInventory slot4;
    public SlotInventory slot5;
    public SlotInventory slot6;
    public SlotInventory slot7;
    public SlotInventory slot8;
    public SlotInventory slot9;

    public InventoryController inventory;


    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addSlot()
    {
        inventory.addSlotToInventory(slot1);
        inventory.addSlotToInventory(slot2);
        inventory.addSlotToInventory(slot3);
        inventory.addSlotToInventory(slot4);
        inventory.addSlotToInventory(slot5);
        inventory.addSlotToInventory(slot6);
        inventory.addSlotToInventory(slot7);
        inventory.addSlotToInventory(slot8);
        inventory.addSlotToInventory(slot9);
    }    
}
