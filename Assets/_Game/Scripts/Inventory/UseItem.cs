using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour {

    public Player jogador;
    public AreaBattleController BTController;
    public InventoryController inventory;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void usarItemMonster(ItemBase item)
    {
        ValidaTeclas.changeStateButton(BUTTON_STATE.IN_USARITEM);
        int efeito = item.getEfeito();
        int vidaAtual = jogador.getVida();
        int aux = efeito + vidaAtual;

        if (GameController.getCurrentState() == GAME_STATE.IN_BATTLE)
        {
            inventory.gameObject.SetActive(!inventory.gameObject.activeSelf);
            if (item.getCurrentState() == TYPE_ITEM.IN_POCAO)
            {
                if (aux > jogador.getMaxVida())
                {
                    jogador.setVida(jogador.getMaxVida());
                }
                else if (aux < jogador.getMaxVida())
                {
                    jogador.setVida(efeito + jogador.getVida());
                }
                Debug.Log("usou pocao");
                BTController.selecionaItemBattleMonster(item, 0); //faseMonstro
            }
            else
            {
                int ataquePlayer = Random.Range((jogador.getAtaque() / 2), jogador.getAtaque());
                int efeitoMagia = item.getEfeito();
                Debug.Log("Ataque com magiaMonstro: " + efeitoMagia);
                BTController.selecionaItemBattleMonster(item, efeitoMagia); //fight(efeitoMagia);
            }
        }
        if (GameController.getCurrentState() == GAME_STATE.IN_INVENTORY)
        {
            inventory.gameObject.SetActive(!inventory.gameObject.activeSelf);
            GameController.changeState(GAME_STATE.IN_EXPLORATION);
            if (item.getCurrentState() == TYPE_ITEM.IN_POCAO)
            {
                if (aux > jogador.getMaxVida())
                {
                    jogador.setVida(jogador.getMaxVida());
                }
                else if (aux < jogador.getMaxVida())
                {
                    jogador.setVida(efeito + jogador.getVida());
                }
                Debug.Log("usou pocao");
                
            }            
        }
    }

    public void useItemBoss(ItemBase item)
    {
        ValidaTeclas.changeStateButton(BUTTON_STATE.IN_USARITEM);
        int efeito = item.getEfeito();
        int vidaAtual = jogador.getVida();
        int aux = efeito + vidaAtual;

        if (GameController.getCurrentState() == GAME_STATE.IN_BOSS)
        {
            inventory.gameObject.SetActive(!inventory.gameObject.activeSelf);
            if (item.getCurrentState() == TYPE_ITEM.IN_POCAO)
            {
                if (aux > jogador.getMaxVida())
                {
                    jogador.setVida(jogador.getMaxVida());
                }
                else if (aux < jogador.getMaxVida())
                {
                    jogador.setVida(efeito + jogador.getVida());
                }
                Debug.Log("usou pocao");
                BTController.selecionaItemBattleBoss(item, 0); //faseBoss(3);
            }
            else
            {
                int ataquePlayer = Random.Range((jogador.getAtaque() / 2), jogador.getAtaque());
                int efeitoMagia = item.getEfeito();
                Debug.Log("Ataque com magiaBoss: " + efeitoMagia);
                BTController.selecionaItemBattleBoss(item, efeitoMagia);                
            }            
        }
        if (GameController.getCurrentState() == GAME_STATE.IN_INVENTORY)
        {
            inventory.gameObject.SetActive(!inventory.gameObject.activeSelf);
            GameController.changeState(GAME_STATE.IN_EXPLORATION);            
            if (item.getCurrentState() != TYPE_ITEM.IN_MAGIC)
            {
                if (aux > jogador.getMaxVida())
                {
                    jogador.setVida(jogador.getMaxVida());
                }
                else if (aux < jogador.getMaxVida())
                {
                    jogador.setVida(efeito + jogador.getVida());
                }
                Debug.Log("usou pocao");
            }
        }
    }


}
