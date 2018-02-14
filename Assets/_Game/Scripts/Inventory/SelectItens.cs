using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectItens : MonoBehaviour {


    //public Batalha battle;
    public AreaBattle battle;
    public BossArea battleBoss;
    private ItemBase itemSelect;
    private ItemBase itemNull;

    public UseItem usarItem;

    public InventoryController inventory;

    public Button bt_inventario;
    public Button slot1;
    public Button slot2;
    public Button slot3;
    public Button slot4;
    public Button slot5;
    public Button slot6;
    public Button slot7;
    public Button slot8;
    public Button slot9;
    private int opcao;    
    private bool teste = false;

    public AudioSource nullItem;  // informa ao jogador que não possui itens no espaço selecionado do inventario
    public AudioSource audioInventario;
    public AudioBattle audios;
    
    private AudioSource source;
    private AudioSource sourceAudio;

    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();
        sourceAudio = GetComponent<AudioSource>();        
    }
	
	// Update is called once per frame
	void Update () {

        if(GameController.getCurrentState() == GAME_STATE.IN_INVENTORY || GameController.getCurrentState() == GAME_STATE.IN_BATTLE || GameController.getCurrentState() == GAME_STATE.IN_BOSS)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (opcao == 1)
                {
                    if (itemSelect != null)
                    {
                        sourceAudio = null;
                        itemNull = itemSelect;
                        itemSelect = null;
                        if (itemNull.getCurrentState() == TYPE_ITEM.IN_POCAO)
                        {                                                      
                            inventory.removeItemSlot(opcao - 1, true);
                            if (GameController.getCurrentState() == GAME_STATE.IN_BATTLE)
                            {
                                Debug.Log("pocao");
                                sourceAudio = addAudioSource(audios.getAudioBattle(20));
                                sourceAudio.Play();
                                usarItem.usarItemMonster(itemNull);                                                                
                            }
                            else
                            {
                                Debug.Log("entrando aqui");
                                sourceAudio = addAudioSource(audios.getAudioBattle(20));
                                sourceAudio.Play();
                                usarItem.useItemBoss(itemNull);                               
                            }
                        }
                        else if ((GameController.getCurrentState() == GAME_STATE.IN_BATTLE || GameController.getCurrentState() == GAME_STATE.IN_BOSS) && itemNull.getCurrentState() == TYPE_ITEM.IN_MAGIC)
                        {                                                        
                            if (GameController.getCurrentState() == GAME_STATE.IN_BATTLE)
                            {
                                sourceAudio = addAudioSource(audios.getAudioBattle(21));
                                sourceAudio.Play();
                                usarItem.usarItemMonster(itemNull);                                
                            }
                            else
                            {
                                sourceAudio = addAudioSource(audios.getAudioBattle(21));
                                sourceAudio.Play();
                                usarItem.useItemBoss(itemNull);                                
                            }    
                            inventory.removeItemSlot(opcao - 1, true);                            
                        }
                        else if (GameController.getCurrentState() == GAME_STATE.IN_INVENTORY && itemNull.getCurrentState() == TYPE_ITEM.IN_MAGIC)
                        {
                            sourceAudio = addAudioSource(audios.getAudioBattle(19));
                            sourceAudio.Play();                            
                            return;
                        }
                        else
                            inventory.removeItemSlot(opcao - 1, false);                        
                    }
                    else
                        nullItem.Play();
                }
                if (opcao == 2)
                {
                    if (itemSelect != null)
                    {
                        itemNull = itemSelect;
                        itemSelect = null;
                        if (itemNull.getCurrentState() == TYPE_ITEM.IN_POCAO)
                        {
                            inventory.removeItemSlot(opcao - 1, true);
                            if (GameController.getCurrentState() == GAME_STATE.IN_BATTLE)
                            {
                                sourceAudio = addAudioSource(audios.getAudioBattle(20));
                                sourceAudio.Play();
                                usarItem.usarItemMonster(itemNull);
                            }
                            else
                            {
                                sourceAudio = addAudioSource(audios.getAudioBattle(20));
                                sourceAudio.Play();
                                usarItem.useItemBoss(itemNull);
                            }
                        }
                        else if ((GameController.getCurrentState() == GAME_STATE.IN_BATTLE || GameController.getCurrentState() == GAME_STATE.IN_BOSS) && itemNull.getCurrentState() == TYPE_ITEM.IN_MAGIC)
                        {
                            if (GameController.getCurrentState() == GAME_STATE.IN_BATTLE)
                            {
                                sourceAudio = addAudioSource(audios.getAudioBattle(21));
                                sourceAudio.Play();
                                usarItem.usarItemMonster(itemNull);
                            }
                            else
                            {
                                sourceAudio = addAudioSource(audios.getAudioBattle(21));
                                sourceAudio.Play();
                                usarItem.useItemBoss(itemNull);
                            }
                            inventory.removeItemSlot(opcao - 1, true);
                        }
                        else if (GameController.getCurrentState() == GAME_STATE.IN_INVENTORY && itemNull.getCurrentState() == TYPE_ITEM.IN_MAGIC)
                        {
                            sourceAudio = addAudioSource(audios.getAudioBattle(19));
                            sourceAudio.Play();
                            return;
                        }
                        else
                            inventory.removeItemSlot(opcao - 1, false);
                    }
                    else
                        nullItem.Play();
                }
                if (opcao == 3)
                {
                    if (itemSelect != null)
                    {
                        itemNull = itemSelect;
                        itemSelect = null;
                        if (itemNull.getCurrentState() == TYPE_ITEM.IN_POCAO)
                        {
                            inventory.removeItemSlot(opcao - 1, true);
                            if (GameController.getCurrentState() == GAME_STATE.IN_BATTLE)
                            {
                                sourceAudio = addAudioSource(audios.getAudioBattle(20));
                                sourceAudio.Play();
                                usarItem.usarItemMonster(itemNull);
                            }
                            else
                            {
                                sourceAudio = addAudioSource(audios.getAudioBattle(20));
                                sourceAudio.Play();
                                usarItem.useItemBoss(itemNull);
                            }
                        }
                        else if ((GameController.getCurrentState() == GAME_STATE.IN_BATTLE || GameController.getCurrentState() == GAME_STATE.IN_BOSS) && itemNull.getCurrentState() == TYPE_ITEM.IN_MAGIC)
                        {
                            if (GameController.getCurrentState() == GAME_STATE.IN_BATTLE)
                            {
                                sourceAudio = addAudioSource(audios.getAudioBattle(21));
                                sourceAudio.Play();
                                usarItem.usarItemMonster(itemNull);
                            }
                            else
                            {
                                sourceAudio = addAudioSource(audios.getAudioBattle(21));
                                sourceAudio.Play();
                                usarItem.useItemBoss(itemNull);
                            }
                            inventory.removeItemSlot(opcao - 1, true);
                        }
                        else if (GameController.getCurrentState() == GAME_STATE.IN_INVENTORY && itemNull.getCurrentState() == TYPE_ITEM.IN_MAGIC)
                        {
                            sourceAudio = addAudioSource(audios.getAudioBattle(19));
                            sourceAudio.Play();
                            return;
                        }
                        else
                            inventory.removeItemSlot(opcao - 1, false);
                    }
                    else
                        nullItem.Play();
                }
                if (opcao == 4)
                {
                    if (itemSelect != null)
                    {
                        itemNull = itemSelect;
                        itemSelect = null;
                        if (itemNull.getCurrentState() == TYPE_ITEM.IN_POCAO)
                        {
                            inventory.removeItemSlot(opcao - 1, true);
                            if (GameController.getCurrentState() == GAME_STATE.IN_BATTLE)
                            {
                                sourceAudio = addAudioSource(audios.getAudioBattle(20));
                                sourceAudio.Play();
                                usarItem.usarItemMonster(itemNull);
                            }
                            else
                            {
                                sourceAudio = addAudioSource(audios.getAudioBattle(20));
                                sourceAudio.Play();
                                usarItem.useItemBoss(itemNull);
                            }
                        }
                        else if ((GameController.getCurrentState() == GAME_STATE.IN_BATTLE || GameController.getCurrentState() == GAME_STATE.IN_BOSS) && itemNull.getCurrentState() == TYPE_ITEM.IN_MAGIC)
                        {
                            if (GameController.getCurrentState() == GAME_STATE.IN_BATTLE)
                            {
                                sourceAudio = addAudioSource(audios.getAudioBattle(21));
                                sourceAudio.Play();
                                usarItem.usarItemMonster(itemNull);
                            }
                            else
                            {
                                sourceAudio = addAudioSource(audios.getAudioBattle(21));
                                sourceAudio.Play();
                                usarItem.useItemBoss(itemNull);
                            }
                            inventory.removeItemSlot(opcao - 1, true);
                        }
                        else if (GameController.getCurrentState() == GAME_STATE.IN_INVENTORY && itemNull.getCurrentState() == TYPE_ITEM.IN_MAGIC)
                        {
                            sourceAudio = addAudioSource(audios.getAudioBattle(19));
                            sourceAudio.Play();
                            return;
                        }
                        else
                            inventory.removeItemSlot(opcao - 1, false);
                    }
                    else
                        nullItem.Play();
                }
                if (opcao == 5)
                {
                    if (itemSelect != null)
                    {
                        itemNull = itemSelect;
                        itemSelect = null;
                        if (itemNull.getCurrentState() == TYPE_ITEM.IN_POCAO)
                        {
                            inventory.removeItemSlot(opcao - 1, true);
                            if (GameController.getCurrentState() == GAME_STATE.IN_BATTLE)
                            {
                                sourceAudio = addAudioSource(audios.getAudioBattle(20));
                                sourceAudio.Play();
                                usarItem.usarItemMonster(itemNull);
                            }
                            else
                            {
                                sourceAudio = addAudioSource(audios.getAudioBattle(20));
                                sourceAudio.Play();
                                usarItem.useItemBoss(itemNull);
                            }
                        }
                        else if ((GameController.getCurrentState() == GAME_STATE.IN_BATTLE || GameController.getCurrentState() == GAME_STATE.IN_BOSS) && itemNull.getCurrentState() == TYPE_ITEM.IN_MAGIC)
                        {
                            if (GameController.getCurrentState() == GAME_STATE.IN_BATTLE)
                            {
                                sourceAudio = addAudioSource(audios.getAudioBattle(21));
                                sourceAudio.Play();
                                usarItem.usarItemMonster(itemNull);
                            }
                            else
                            {
                                sourceAudio = addAudioSource(audios.getAudioBattle(21));
                                sourceAudio.Play();
                                usarItem.useItemBoss(itemNull);
                            }
                            inventory.removeItemSlot(opcao - 1, true);
                        }
                        else if (GameController.getCurrentState() == GAME_STATE.IN_INVENTORY && itemNull.getCurrentState() == TYPE_ITEM.IN_MAGIC)
                        {
                            sourceAudio = addAudioSource(audios.getAudioBattle(19));
                            sourceAudio.Play();
                            return;
                        }
                        else
                            inventory.removeItemSlot(opcao - 1, false);
                    }
                    else
                        nullItem.Play();
                }
                if (opcao == 6)
                {
                    if (itemSelect != null)
                    {
                        itemNull = itemSelect;
                        itemSelect = null;
                        if (itemNull.getCurrentState() == TYPE_ITEM.IN_POCAO)
                        {
                            inventory.removeItemSlot(opcao - 1, true);
                            if (GameController.getCurrentState() == GAME_STATE.IN_BATTLE)
                            {
                                sourceAudio = addAudioSource(audios.getAudioBattle(20));
                                sourceAudio.Play();
                                usarItem.usarItemMonster(itemNull);
                            }
                            else
                            {
                                sourceAudio = addAudioSource(audios.getAudioBattle(20));
                                sourceAudio.Play();
                                usarItem.useItemBoss(itemNull);
                            }
                        }
                        else if ((GameController.getCurrentState() == GAME_STATE.IN_BATTLE || GameController.getCurrentState() == GAME_STATE.IN_BOSS) && itemNull.getCurrentState() == TYPE_ITEM.IN_MAGIC)
                        {
                            if (GameController.getCurrentState() == GAME_STATE.IN_BATTLE)
                            {
                                sourceAudio = addAudioSource(audios.getAudioBattle(21));
                                sourceAudio.Play();
                                usarItem.usarItemMonster(itemNull);
                            }
                            else
                            {
                                sourceAudio = addAudioSource(audios.getAudioBattle(21));
                                sourceAudio.Play();
                                usarItem.useItemBoss(itemNull);
                            }
                            inventory.removeItemSlot(opcao - 1, true);
                        }
                        else if (GameController.getCurrentState() == GAME_STATE.IN_INVENTORY && itemNull.getCurrentState() == TYPE_ITEM.IN_MAGIC)
                        {
                            sourceAudio = addAudioSource(audios.getAudioBattle(19));
                            sourceAudio.Play();
                            return;
                        }
                        else
                            inventory.removeItemSlot(opcao - 1, false);
                    }
                    else
                        nullItem.Play();
                }
                if (opcao == 7)
                {
                    if (itemSelect != null)
                    {
                        itemNull = itemSelect;
                        itemSelect = null;
                        if (itemNull.getCurrentState() == TYPE_ITEM.IN_POCAO)
                        {
                            inventory.removeItemSlot(opcao - 1, true);
                            if (GameController.getCurrentState() == GAME_STATE.IN_BATTLE)
                            {
                                sourceAudio = addAudioSource(audios.getAudioBattle(20));
                                sourceAudio.Play();
                                usarItem.usarItemMonster(itemNull);
                            }
                            else
                            {
                                sourceAudio = addAudioSource(audios.getAudioBattle(20));
                                sourceAudio.Play();
                                usarItem.useItemBoss(itemNull);
                            }
                        }
                        else if ((GameController.getCurrentState() == GAME_STATE.IN_BATTLE || GameController.getCurrentState() == GAME_STATE.IN_BOSS) && itemNull.getCurrentState() == TYPE_ITEM.IN_MAGIC)
                        {
                            if (GameController.getCurrentState() == GAME_STATE.IN_BATTLE)
                            {
                                sourceAudio = addAudioSource(audios.getAudioBattle(21));
                                sourceAudio.Play();
                                usarItem.usarItemMonster(itemNull);
                            }
                            else
                            {
                                sourceAudio = addAudioSource(audios.getAudioBattle(21));
                                sourceAudio.Play();
                                usarItem.useItemBoss(itemNull);
                            }
                            inventory.removeItemSlot(opcao - 1, true);
                        }
                        else if (GameController.getCurrentState() == GAME_STATE.IN_INVENTORY && itemNull.getCurrentState() == TYPE_ITEM.IN_MAGIC)
                        {
                            sourceAudio = addAudioSource(audios.getAudioBattle(19));
                            sourceAudio.Play();
                            return;
                        }
                        else
                            inventory.removeItemSlot(opcao - 1, false);
                    }
                    else
                        nullItem.Play();
                }
                if (opcao == 8)
                {
                    if (itemSelect != null)
                    {
                        itemNull = itemSelect;
                        itemSelect = null;
                        if (itemNull.getCurrentState() == TYPE_ITEM.IN_POCAO)
                        {
                            inventory.removeItemSlot(opcao - 1, true);
                            if (GameController.getCurrentState() == GAME_STATE.IN_BATTLE)
                            {
                                sourceAudio = addAudioSource(audios.getAudioBattle(20));
                                sourceAudio.Play();
                                usarItem.usarItemMonster(itemNull);
                            }
                            else
                            {
                                sourceAudio = addAudioSource(audios.getAudioBattle(20));
                                sourceAudio.Play();
                                usarItem.useItemBoss(itemNull);
                            }
                        }
                        else if ((GameController.getCurrentState() == GAME_STATE.IN_BATTLE || GameController.getCurrentState() == GAME_STATE.IN_BOSS) && itemNull.getCurrentState() == TYPE_ITEM.IN_MAGIC)
                        {
                            if (GameController.getCurrentState() == GAME_STATE.IN_BATTLE)
                            {
                                sourceAudio = addAudioSource(audios.getAudioBattle(21));
                                sourceAudio.Play();
                                usarItem.usarItemMonster(itemNull);
                            }
                            else
                            {
                                sourceAudio = addAudioSource(audios.getAudioBattle(21));
                                sourceAudio.Play();
                                usarItem.useItemBoss(itemNull);
                            }
                            inventory.removeItemSlot(opcao - 1, true);
                        }
                        else if (GameController.getCurrentState() == GAME_STATE.IN_INVENTORY && itemNull.getCurrentState() == TYPE_ITEM.IN_MAGIC)
                        {
                            sourceAudio = addAudioSource(audios.getAudioBattle(19));
                            sourceAudio.Play();
                            return;
                        }
                        else
                            inventory.removeItemSlot(opcao - 1, false);
                    }
                    else
                        nullItem.Play();
                }
                if (opcao == 9)
                {
                    if (itemSelect != null)
                    {
                        itemNull = itemSelect;
                        itemSelect = null;
                        if (itemNull.getCurrentState() == TYPE_ITEM.IN_POCAO)
                        {
                            inventory.removeItemSlot(opcao - 1, true);
                            if (GameController.getCurrentState() == GAME_STATE.IN_BATTLE)
                            {
                                sourceAudio = addAudioSource(audios.getAudioBattle(20));
                                sourceAudio.Play();
                                usarItem.usarItemMonster(itemNull);
                            }
                            else
                            {
                                sourceAudio = addAudioSource(audios.getAudioBattle(20));
                                sourceAudio.Play();
                                usarItem.useItemBoss(itemNull);
                            }
                        }
                        else if ((GameController.getCurrentState() == GAME_STATE.IN_BATTLE || GameController.getCurrentState() == GAME_STATE.IN_BOSS) && itemNull.getCurrentState() == TYPE_ITEM.IN_MAGIC)
                        {
                            if (GameController.getCurrentState() == GAME_STATE.IN_BATTLE)
                            {
                                sourceAudio = addAudioSource(audios.getAudioBattle(21));
                                sourceAudio.Play();
                                usarItem.usarItemMonster(itemNull);
                            }
                            else
                            {
                                sourceAudio = addAudioSource(audios.getAudioBattle(21));
                                sourceAudio.Play();
                                usarItem.useItemBoss(itemNull);
                            }
                            inventory.removeItemSlot(opcao - 1, true);
                        }
                        else if (GameController.getCurrentState() == GAME_STATE.IN_INVENTORY && itemNull.getCurrentState() == TYPE_ITEM.IN_MAGIC)
                        {
                            sourceAudio = addAudioSource(audios.getAudioBattle(19));
                            sourceAudio.Play();
                            return;
                        }
                        else
                            inventory.removeItemSlot(opcao - 1, false);
                    }
                    else
                        nullItem.Play();
                }
            }
        }        
    }

    public void BT_Inventario()
    {
        bt_inventario.enabled = true;
        audioInventario.Play();       
    }

    public void BT_Slot1()
    {
        
        bt_inventario.enabled = false;        
        audioInventario.Stop();
        if (opcao==2 && itemSelect != null)
        {
            itemSelect.getAudioNome().Stop();
        }
        opcao = 1;
        nullItem.Stop();
        itemSelect = inventory.selectItemSlot(opcao - 1);
        if (itemSelect != null)
        {
            itemSelect.getAudioNome().Play();
            Debug.Log("Item: " + itemSelect);
        }
    }
    public void BT_Slot2()
    {
        if ((opcao == 1 || opcao == 3)&& itemSelect !=null)
        {
            itemSelect.getAudioNome().Stop();
        }
        opcao = 2;
        nullItem.Stop();
        itemSelect = inventory.selectItemSlot(opcao - 1);
        if (itemSelect != null)
        {
            itemSelect.getAudioNome().Play();
            Debug.Log("Item2: " + itemSelect);
        }        
    }
    public void BT_Slot3()
    {
        if ((opcao == 2 || opcao == 4)&& itemSelect != null)
        {
            itemSelect.getAudioNome().Stop();
        }
        opcao = 3;
        nullItem.Stop();
        itemSelect = inventory.selectItemSlot(opcao - 1);
        if (itemSelect != null)
        {
            itemSelect.getAudioNome().Play();
            Debug.Log("Item3: " + itemSelect);
        }
    }
    public void BT_Slot4()
    {
        if ((opcao == 3 || opcao == 5) && itemSelect != null)
        {
            itemSelect.getAudioNome().Stop();
        }
        opcao = 4;
        nullItem.Stop();
        itemSelect = inventory.selectItemSlot(opcao - 1);
        if (itemSelect != null)
        {
            itemSelect.getAudioNome().Play();
            Debug.Log("Item4: " + itemSelect);
        }
    }
    public void BT_Slot5()
    {
        if ((opcao == 4 || opcao == 6) && itemSelect != null)
        {
            itemSelect.getAudioNome().Stop();
        }
        opcao = 5;
        nullItem.Stop();
        itemSelect = inventory.selectItemSlot(opcao - 1);
        if (itemSelect != null)
        {
            itemSelect.getAudioNome().Play();
            Debug.Log("Item5: " + itemSelect);
        }
    }
    public void BT_Slot6()
    {
        if ((opcao == 5 || opcao == 7) && itemSelect != null)
        {
            itemSelect.getAudioNome().Stop();
        }
        opcao = 6;
        nullItem.Stop();
        itemSelect = inventory.selectItemSlot(opcao - 1);
        if (itemSelect != null)
        {
            itemSelect.getAudioNome().Play();
            Debug.Log("Item6: " + itemSelect);
        }
    }
    public void BT_Slot7()
    {
        if ((opcao == 6 || opcao == 8) && itemSelect != null)
        {
            itemSelect.getAudioNome().Stop();
        }
        opcao = 7;
        nullItem.Stop();
        itemSelect = inventory.selectItemSlot(opcao - 1);
        if (itemSelect != null)
        {
            itemSelect.getAudioNome().Play();
            Debug.Log("Item7: " + itemSelect);
        }
    }
    public void BT_Slot8()
    {
        if ((opcao == 7 || opcao == 9) && itemSelect != null)
        {
            itemSelect.getAudioNome().Stop();
        }
        opcao = 8;
        nullItem.Stop();
        itemSelect = inventory.selectItemSlot(opcao - 1);
        if (itemSelect != null)
        {
            itemSelect.getAudioNome().Play();
            Debug.Log("Item8: " + itemSelect);
        }
    }

    public void BT_Slot9()
    {
        if (opcao == 8 && itemSelect != null)
        {
            itemSelect.getAudioNome().Stop();
        }
        opcao = 9;
        nullItem.Stop();
        itemSelect = inventory.selectItemSlot(opcao - 1);
        if (itemSelect != null)
        {
            itemSelect.getAudioNome().Play();
            Debug.Log("Item9: " + itemSelect);
        }
    }

    public AudioSource addAudioSource(AudioClip audio)
    {
        source.clip = audio;
        source.volume = 1;
        return source;
    }

}
