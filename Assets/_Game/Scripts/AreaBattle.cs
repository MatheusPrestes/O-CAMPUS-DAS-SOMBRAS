using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using System.Threading;

public class AreaBattle : MonoBehaviour
{

    public float percentBattleFactor;
    public float timeToCheckBattle;
    private float currentTimeToCheckBattle;    

    public Numbers listNumbers;
    private AudioSource sourceNumbers;
    private AudioSource sourceNumbers2;

    public AreaBattle area1;
    public AreaBattle area2;
    public AreaBattle area3;

    public AudioSource playerAttack;
    public AudioSource nivelMontro;
    public AudioSource vidaMonstro;
    public AudioSource qntAtaquePlayer;
    public AudioSource monstroVivo;
    public AudioSource audioFaseMonstro;
    public AudioSource monstroMorreu;
    public AudioSource audioAtaqueMonstro;
    public AudioSource qntAtaqueMonstro;
    public AudioSource audioFaseJogador;
    public AudioSource audioJogadorMorreu;
    public AudioSource audioJogadorFugiu;
    public AudioSource audioJogadorNaofugiu;


    private Enemy inimigo = new Enemy();
    private GerarEnemy enemy = new GerarEnemy();
    public Enemy inimigo1;
    public Enemy inimigo2;
    public Enemy inimigo3;
    public Player jogador;

    public int indexArea;

    public InventoryController inventory;

    private bool activeItem;    
    private int highAttack = 0;



    void Start()
    {
        activeItem = false;        
        sourceNumbers = GetComponent<AudioSource>();
        sourceNumbers2 = GetComponent<AudioSource>();        
    }
    
    void Update()
    {
        modoBatalha();
        atalhosBatalha();
        if (GameController.getCurrentState() == GAME_STATE.IN_DEAD && !audioJogadorMorreu.isPlaying)
        {
            SceneManager.LoadScene("MenuPrincipal");
        }
    }

    void OnTriggerStay2D(Collider2D outro)
    {
        if (outro.gameObject.CompareTag("Player"))
        {
            currentTimeToCheckBattle += Time.deltaTime;

            if (currentTimeToCheckBattle > timeToCheckBattle)
            {
                currentTimeToCheckBattle = 0;
                float randPercent = Random.Range(0, 100);

                if (randPercent <= percentBattleFactor)
                {
                    pararSons();
                    abilitaAreas();
                    inimigo = enemy.criarInimigo(jogador, inimigo1, inimigo2, inimigo3);
                    inimigo.getGrowlMonster().Play();
                    audioFaseJogador.PlayDelayed(4);
                    GameController.changeState(GAME_STATE.IN_BATTLE);
                    if (getIndexArea() == 1)
                    {
                        area2.enabled = false;
                        area3.enabled = false;
                    }
                    if (getIndexArea() == 2)
                    {
                        area1.enabled = false;
                        area3.enabled = false;
                    }
                    if (getIndexArea() == 3)
                    {
                        area1.enabled = false;
                        area2.enabled = false;
                    }
                }
            }
        }
    }

    public AudioSource addAudioSourceNumbers(AudioClip audio)
    {
        sourceNumbers.clip = audio;
        sourceNumbers.volume = 1;
        return sourceNumbers;
    }   

    void modoBatalha()
    {
        if (GameController.getCurrentState() == GAME_STATE.IN_BATTLE)
        {            
            if (Input.GetKeyDown(KeyCode.Z) && ValidaTeclas.getCurrentStateButton() == BUTTON_STATE.IN_DEFFAULT)
            {                
                Debug.Log("atacar");
                pararSons();
                playerAttack.Play();
                fight(highAttack);
            }
            if (Input.GetKeyDown(KeyCode.X) && activeItem == false && ValidaTeclas.getCurrentStateButton() == BUTTON_STATE.IN_DEFFAULT)
            {
                pararSons();
                activeItem = true;
                Debug.Log("usar item");

            }
            if (Input.GetKeyDown(KeyCode.C) && ValidaTeclas.getCurrentStateButton() == BUTTON_STATE.IN_DEFFAULT)
            {
                pararSons();
                Debug.Log("fugir");
                fugir();
            }
        }
    }

    void atalhosBatalha()
    {
        if (Input.GetKeyDown(KeyCode.F4))
        {
            if (GameController.getCurrentState() == GAME_STATE.IN_BATTLE)
            {                
                nivelMontro.Play();
                Debug.Log("Nivel do inimigo " + inimigo.getNivelMonstro());
                sourceNumbers = addAudioSourceNumbers(listNumbers.getAudioNumbers(inimigo.getNivelMonstro()));
                sourceNumbers.PlayDelayed(2);
            }
        }
        if (Input.GetKeyDown(KeyCode.F5))
        {
            if (GameController.getCurrentState() == GAME_STATE.IN_BATTLE)
            {
                vidaMonstro.Play();
                Debug.Log("Vida do monstro " + inimigo.getVidaMonstro());
                sourceNumbers = addAudioSourceNumbers(listNumbers.getAudioNumbers(inimigo.getVidaMonstro()));
                sourceNumbers.PlayDelayed(2);
            }
        }
    }

    public void fight(int highAttack)
    {
        Debug.Log("Monstro: " + inimigo.getNomeMonstro());
        ValidaTeclas.changeStateButton(BUTTON_STATE.IN_ATAQUE);        
        int ataquePlayer = Random.Range((jogador.getAtaque() / 2), jogador.getAtaque()) + highAttack; //ataque do jogador vai variar entre a metade do seu ataque e o valor total do ataque
        int vidaMonstro = inimigo.getVidaMonstro();
        int resultado = ataquePlayer - vidaMonstro;
        qntAtaquePlayer.PlayDelayed(2);
        Debug.Log("Seu ataque foi de " + ataquePlayer);
        sourceNumbers = addAudioSourceNumbers(listNumbers.getAudioNumbers(ataquePlayer));        
        sourceNumbers.PlayDelayed(3);

        if (resultado >= 0)
        {
            monsterDead(5);
        }
        else
        {
            inimigo.setVidaMonstro(vidaMonstro - ataquePlayer);
            monstroVivo.PlayDelayed(5); // monstro esta vivo                         
            Debug.Log("Vida nova do Monstro: " + inimigo.getVidaMonstro());
            faseMonstro(6);
        }
    }

    public void monsterDead(int index)
    {
        monstroMorreu.PlayDelayed(index); // monstro morreu
        GameController.changeState(GAME_STATE.IN_EXPLORATION);
        jogador.setXP(jogador.getXP() + inimigo.getXPMonstro());
        jogador.setMoeda(jogador.getMoeda() + inimigo.getMoeda());        
        ValidaTeclas.changeStateButton(BUTTON_STATE.IN_DEFFAULT);

        if (jogador.getXP() >= 100)
        {
            Debug.Log("Atualizando status jogador");
            int nivelAtual = jogador.getNivel();
            atualizaStatusJogador(nivelAtual + 1);
        }
        return;
    }

    public void faseMonstro(int index)
    {
        audioFaseMonstro.PlayDelayed(index + 2);
        int vidaPlayer = jogador.getVida();
        int ataqueMonstro = inimigo.getAtaqueMonstro();
        int resultado = vidaPlayer - ataqueMonstro;

        inimigo.getAudioAtaqueMonster().PlayDelayed(index + 4);

        if (resultado > 0)
        {
            qntAtaqueMonstro.PlayDelayed(index + 6);
            Debug.Log("Monstro atacou com " + ataqueMonstro + " de ataque");
            sourceNumbers = addAudioSourceNumbers(listNumbers.getAudioNumbers(ataqueMonstro));
            sourceNumbers.PlayDelayed(index + 8);
            jogador.setVida(resultado);
            audioFaseJogador.PlayDelayed(index + 10); // fase do jogador
            ValidaTeclas.changeStateButton(BUTTON_STATE.IN_DEFFAULT);
            return;
        }
        else
        {
            audioJogadorMorreu.PlayDelayed(index + 6); // jogador morreu
            Debug.Log("Jogador morreu");           
            if (audioJogadorMorreu.isPlaying)
            {
                GameController.changeState(GAME_STATE.IN_DEAD);                
            }
        }
    }

    public void fugir()
    {
        ValidaTeclas.changeStateButton(BUTTON_STATE.IN_FUGIR);
        int sorte = Random.Range(jogador.getSorte(), (jogador.getNivel() * 5));
        if (sorte > inimigo.getSorteMonstro())
        {
            audioJogadorFugiu.Play(); // jogador fugiu
            GameController.changeState(GAME_STATE.IN_EXPLORATION);
            ValidaTeclas.changeStateButton(BUTTON_STATE.IN_DEFFAULT);
            return;
        }
        else
        {
            audioJogadorNaofugiu.Play(); // jogador não fugiu            
            ValidaTeclas.changeStateButton(BUTTON_STATE.IN_DEFFAULT);
            faseMonstro(1);            
        }
    }

    //public void useItem(ItemBase item)
    //{
    //    ValidaTeclas.changeStateButton(BUTTON_STATE.IN_USARITEM);
    //    inventory.gameObject.SetActive(!inventory.gameObject.activeSelf);
    //    activeItem = true;
    //    if (item == null)
    //    {
    //        Debug.Log("Não possui item neste slot do intentario");
    //        return;
    //    }

    //    int efeito = item.getEfeito();
    //    int vidaAtual = jogador.getVida();
    //    int aux = efeito + vidaAtual;

    //    if (GameController.getCurrentState() == GAME_STATE.IN_BATTLE)
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
    //            faseMonstro(3);
    //        }
    //        else
    //        {
    //            int ataquePlayer = Random.Range((jogador.getAtaque() / 2), jogador.getAtaque());
    //            int efeitoMagia = item.getEfeito();
    //            Debug.Log("Ataque com magia: " + efeitoMagia);
    //            fight(efeitoMagia);
    //        }            
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
        int vida = jogador.getMaxVida() + 3;
        int maxVida = vida;
        int ataque = jogador.getAtaque() + 3;
        int xp = jogador.getXP();

        jogador.setNivel(nivel);
        jogador.setVida(vida);
        jogador.setMaxVida(maxVida);
        jogador.setAtaque(ataque);

        if (xp >= 100)
        {
            // aumentou de nivel
            Debug.Log("Aumentou de nivel");
            jogador.setXP(xp - 100);
        }
        else
        {
            jogador.setXP(xp);
        }
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
