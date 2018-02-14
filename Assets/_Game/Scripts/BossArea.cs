using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossArea : MonoBehaviour {

    public Boss enemy;
    public Player jogador;
    public InventoryController inventory;
    private SlotInventory slotVazio;

    public BossArea area1;
    public BossArea area2;
    public BossArea area3;

    public int indexArea;

    public AudioBattle audioBattle;
    public Numbers listNumbers;    

    private AudioSource sourceBattle;
    private AudioSource sourceNumbers;

    public AudioSource batalha;
    public AudioSource playerAttack;
    public AudioSource vidaMonstro;
    public AudioSource nivelMonstro;
    public AudioSource qntAtaquePlayer;    
    public AudioSource monstroVivo;
    public AudioSource audioFaseMonstro;
    public AudioSource monstroMorreu;    
    public AudioSource qntAtaqueMonstro;
    public AudioSource audioFaseJogador;
    public AudioSource audioJogadorMorreu;

    public float timeToCheckBattle;
    private float currentTimeToCheckBattle;

    private bool activeItem;
    private int highAttack = 0;

    private bool isActive = true;

    void Start()
    {        
        sourceNumbers = GetComponent<AudioSource>();
        sourceBattle = GetComponent<AudioSource>();        
    }


    void Update()
    {
        modoBattle();       
        atalhosBatalha();
        if (GameController.getCurrentState() == GAME_STATE.IN_DEAD && !audioJogadorMorreu.isPlaying)
        {
            SceneManager.LoadScene("MenuPrincipal");
        }
    }

    void OnTriggerStay2D(Collider2D outro)
    {
        if (outro.gameObject.CompareTag("Player") && GameController.getCurrentState() == GAME_STATE.IN_EXPLORATION)
        {            
            currentTimeToCheckBattle += Time.deltaTime;

            if (currentTimeToCheckBattle > timeToCheckBattle && isActive == true)
            {
                pararSons();
                abilitaAreas();
                GameController.changeState(GAME_STATE.IN_BOSS);                
                enemy.getGrowlBoss().Play();
                audioFaseJogador.PlayDelayed(7);
                if (getIndexArea() == 1)
                {
                    Debug.Log("Area1");
                    area2.enabled = false;
                    area3.enabled = false;                        
                }
                if (getIndexArea() == 2)
                {
                    Debug.Log("Area2");
                    area1.enabled = false;
                    area3.enabled = false;
                }
                if (getIndexArea() == 3)
                {
                    Debug.Log("Area3");
                    area1.enabled = false;
                    area2.enabled = false;
                }
            }            
        }
    }

    private void OnTriggerExit2D(Collider2D outro)
    {
        if (outro.gameObject.CompareTag("Player"))
        {
            isActive = false;
        }
    }

    void modoBattle()
    {
        if (GameController.getCurrentState() == GAME_STATE.IN_BOSS)
        {
                           
            if (Input.GetKeyDown(KeyCode.Z) && ValidaTeclas.getCurrentStateButton() == BUTTON_STATE.IN_DEFFAULT)
            {
                Debug.Log("Atacar");
                pararSons();
                playerAttack.Play();
                fightBoss(highAttack);                
            }
            if (Input.GetKeyDown(KeyCode.X) && activeItem == false && ValidaTeclas.getCurrentStateButton() == BUTTON_STATE.IN_DEFFAULT)
            {
                pararSons();
                Debug.Log("Usar item");
            }            
        }
    }

    void atalhosBatalha()
    {
        if (Input.GetKeyDown(KeyCode.F4))
        {
            if (GameController.getCurrentState() == GAME_STATE.IN_BOSS)
            {
                nivelMonstro.Play();
                sourceNumbers = addAudioSourceNumbers(listNumbers.getAudioNumbers(enemy.getNivelBoss()));
                sourceNumbers.PlayDelayed(2);
            }
        }
        if (Input.GetKeyDown(KeyCode.F5))
        {
            if (GameController.getCurrentState() == GAME_STATE.IN_BOSS)
            {
                vidaMonstro.Play();
                Debug.Log("Vida do monstro " + enemy.getVidaBoss());
                sourceNumbers = addAudioSourceNumbers(listNumbers.getAudioNumbers(enemy.getVidaBoss()));
                sourceNumbers.PlayDelayed(2);
            }
        }
    }

    public AudioSource addAudioSourceNumbers(AudioClip audio)
    {
        sourceNumbers.clip = audio;
        sourceNumbers.volume = 1;
        return sourceNumbers;
    }

    public void fightBoss(int highAttack)
    {
        int ataquePlayer = Random.Range((jogador.getAtaque() / 2), jogador.getAtaque()) + highAttack; //ataque do jogador vai variar entre a metade do seu ataque e o valor total do ataque
        int vidaMonstro = enemy.getVidaBoss();
        int resultado = ataquePlayer - vidaMonstro;
        qntAtaquePlayer.PlayDelayed(2);
        Debug.Log("Seu ataque foi de " + ataquePlayer);
        sourceNumbers = addAudioSourceNumbers(listNumbers.getAudioNumbers(ataquePlayer));
        sourceNumbers.PlayDelayed(3);
        if (resultado >= 0)
        {
            isActive = false;
            bossDead(5);
        }
        else
        {
            enemy.setVidaBoss(vidaMonstro - ataquePlayer);            
            monstroVivo.PlayDelayed(5); // monstro esta vivo
            audioFaseMonstro.PlayDelayed(7); // fase do monstro            
            Debug.Log("Vida nova do Monstro: " + enemy.getVidaBoss());
            faseBoss(8);
        }        
    }

    public void bossDead(int index)
    {
        monstroMorreu.PlayDelayed(index);
        Debug.Log("monstro morreu");
        GameController.changeState(GAME_STATE.IN_EXPLORATION);
        jogador.setXP(jogador.getXP() + enemy.getXPBoss());
        //abilitaAreas();
        ValidaTeclas.changeStateButton(BUTTON_STATE.IN_DEFFAULT);
        slotVazio = inventory.selectSlot();
        inventory.addItemSlot(dropItem(), slotVazio);
        if (jogador.getXP() >= 100)
        {
            Debug.Log("Atualizando status jogador");
            int nivelAtual = jogador.getNivel();
            atualizaStatusJogador(nivelAtual + 1);            
        }
        return;
    }

    public void faseBoss(int index)
    {
        int vidaPlayer = jogador.getVida();
        int ataqueMonstro = enemy.getAtaqueBoss();
        int resultado = vidaPlayer - ataqueMonstro;
        enemy.getAudioAtaqueBoss().PlayDelayed(index + 1); // ataque do boss
        if (resultado > 0)
        {
            qntAtaqueMonstro.PlayDelayed(index + 3);
            Debug.Log("Monstro atacou com " + ataqueMonstro + " de ataque");
            sourceNumbers = addAudioSourceNumbers(listNumbers.getAudioNumbers(ataqueMonstro));
            sourceNumbers.PlayDelayed(index + 5);
            jogador.setVida(resultado);
            audioFaseJogador.PlayDelayed(index + 7);
            Debug.Log("Fase do jogador");
            ValidaTeclas.changeStateButton(BUTTON_STATE.IN_DEFFAULT);
            return;
        }
        else
        {
            qntAtaqueMonstro.PlayDelayed(index + 3);
            Debug.Log("Monstro atacou com " + ataqueMonstro + " de ataque");
            sourceNumbers = addAudioSourceNumbers(listNumbers.getAudioNumbers(ataqueMonstro));
            sourceNumbers.PlayDelayed(index + 5);
            audioJogadorMorreu.PlayDelayed(index + 7);
            Debug.Log("jogador morreu");
            if (audioJogadorMorreu.isPlaying)
            {
                GameController.changeState(GAME_STATE.IN_DEAD);
            }
        }
    }    

    //public void useItem(ItemBase item)
    //{
    //    int efeito = item.getEfeito();
    //    int vidaAtual = jogador.getVida();
    //    int aux = efeito + vidaAtual;

    //    if (GameController.getCurrentState() == GAME_STATE.IN_BOSS)
    //    {
    //        if (item.getCurrentState() == TYPE_ITEM.IN_POCAO)
    //        {
    //            if (aux > jogador.getMaxVida())
    //            {
    //                jogador.setVida(jogador.getMaxVida());
    //            }
    //            else if (aux < jogador.getMaxVida())
    //            {
    //                jogador.setVida(efeito + jogador.getVida());
    //            }
    //            Debug.Log("usou pocao");
    //            faseBoss(3);
    //        }
    //        else
    //        {
    //            int ataquePlayer = Random.Range((jogador.getAtaque() / 2), jogador.getAtaque());
    //            int efeitoMagia = item.getEfeito();
    //            Debug.Log("Ataque com magia: " + efeitoMagia);
    //            fightBoss(efeitoMagia);
    //        }
    //        inventory.gameObject.SetActive(!inventory.gameObject.activeSelf);
    //    }
    //    if (GameController.getCurrentState() == GAME_STATE.IN_INVENTORY)
    //    {
    //        if (item.getCurrentState() != TYPE_ITEM.IN_MAGIC)
    //        {
    //            if (aux > jogador.getMaxVida())
    //            {
    //                jogador.setVida(jogador.getMaxVida());
    //            }
    //            else if (aux < jogador.getMaxVida())
    //            {
    //                jogador.setVida(efeito + jogador.getVida());
    //            }
    //            Debug.Log("usou pocao");
    //        }        
    //    }
    //}

    public void atualizaStatusJogador(int nivel)
    {
        int vida = jogador.getMaxVida() + 10;
        int maxVida = vida;
        int ataque = jogador.getAtaque() + 10;
        int xp = jogador.getXP();

        jogador.setNivel(nivel);
        jogador.setVida(vida);
        jogador.setMaxVida(maxVida);
        jogador.setAtaque(ataque);

        if (xp >= 100)
        {
            //incrementLevel.PlayDelayed(5);
            Debug.Log("Aumentou de nivel");
            jogador.setXP(xp - 100);
        }
        else
        {
            jogador.setXP(xp);
        }
    }

    public ItemBase dropItem()
    {
        return enemy.getDropItem();
    }

    public int getIndexArea()
    {
        return indexArea;
    }

    public void abilitaAreas()
    {
        area1.enabled = true;
        area2.enabled = true;
        area3.enabled = true;
    }

    public void pararSons()
    {
        foreach (AudioSource objeto in Object.FindObjectsOfType(typeof(AudioSource)))
        {
            if (objeto.tag != "Som")
            {
                objeto.Stop();
            }
        }
    }


}
