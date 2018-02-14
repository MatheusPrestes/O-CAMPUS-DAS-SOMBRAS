using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Batalha : MonoBehaviour {

    public float percentBattleFactor;
    public float timeToCheckBattle;
    private float currentTimeToCheckBattle;

    private AudioBattle audioBattle;
    private Numbers listNumbers;

    private AudioSource sourceBattle;
    private AudioSource teste;

    private AudioSource aux;
    private AudioSource btl;
    private AudioSource sourceNumbers;  


    private Enemy inimigo = new Enemy();
    private GerarEnemy enemy = new GerarEnemy();
    public Enemy inimigo1;
    public Enemy inimigo2;
    public Enemy inimigo3;
    public Player jogador;

    public InventoryController inventory;
    
    private bool activeItem;
    private bool activeBattle;
    private int highAttack = 0;
    
	void Start () {        
        aux = GetComponent<AudioSource>();
        activeItem = false;
        activeBattle = false;
        btl = GetComponent<AudioSource>();        
    }
	
	void Update () {
        modoBatalha();
        atalhosBatalha();
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
                    inimigo = enemy.criarInimigo(jogador,inimigo1, inimigo2, inimigo3);                    
                    inimigo.getGrowlMonster().Play();                    
                    //audioBattle.selectAudio(13).Play();
                    activeBattle = true;
                    GameController.changeState(GAME_STATE.IN_BATTLE);                    
                }
            }
        }
    }

    public AudioSource addAudioSourceNumbers(AudioClip audio)
    {
        aux.clip = audio;
        aux.volume = 1;
        return aux;
    }

    public AudioSource addAudioSourceBattle(AudioClip audioBt)
    {
        btl.clip = audioBt;
        btl.volume = 1;
        return btl;
    }

    void modoBatalha()
    {
        if (GameController.getCurrentState() == GAME_STATE.IN_BATTLE)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                sourceBattle.clip = audioBattle.getAudioBattle(6);
                Debug.Log("Atacar");                
                sourceBattle.Play();                
                fight(highAttack);                
            }
            if (Input.GetKeyDown(KeyCode.X) && activeItem == false)
            {
                activeItem = true;
                Debug.Log("usar item");
                sourceBattle.clip = audioBattle.getAudioBattle(4);
                sourceBattle.Play();                                
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                sourceBattle.clip = audioBattle.getAudioBattle(5);
                sourceBattle.Play();
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
                sourceBattle.clip = audioBattle.getAudioBattle(22);
                sourceBattle.volume = 1;                
                sourceBattle.Play();                
                sourceNumbers = addAudioSourceNumbers(listNumbers.getAudioNumbers(inimigo.getNivelMonstro())); 
                sourceNumbers.PlayDelayed(1);
            }
        }
        if (Input.GetKeyDown(KeyCode.F5))
        {
            if (GameController.getCurrentState() == GAME_STATE.IN_BATTLE)
            {
                Debug.Log("Vida do monstro " + inimigo.getVidaMonstro());                
            }
        }

    }

    //public void fight(int highAttack)
    //{

    //    Debug.Log("Batalha com monstros");
    //    activeBattle = false;
    //    int ataquePlayer = Random.Range((jogador.getAtaque()/2), jogador.getAtaque()) + highAttack; //ataque do jogador vai variar entre a metade do seu ataque e o valor total do ataque
    //    int defesaMonstro = inimigo.getVidaMonstro();
    //    int resultado = 0;
    //    if (ataquePlayer > defesaMonstro || (ataquePlayer + highAttack) > defesaMonstro)
    //    {
    //        resultado = (ataquePlayer - defesaMonstro) + highAttack;            
    //        //sourceBattle = addAudioSourceNumbers(audioBattle.selectAudio(7));  // seu ataque foi de
    //        sourceBattle.clip = audioBattle.getAudioBattle(7);
    //        sourceBattle.PlayDelayed(3);
    //        sourceNumbers = addAudioSourceNumbers(listNumbers.getAudioNumbers(ataquePlayer));
    //        sourceNumbers.PlayDelayed(4);
    //        //Debug.Log("Seu ataque foi de " + ataquePlayer);
    //        if(resultado >= inimigo.getVidaMonstro())
    //        {
    //            monsterDead();
    //        }
    //        else
    //        {
    //            //sourceNumbers = addAudioSourceNumbers(audioBattle.selectAudio(8)); // monstro esta vivo
    //            //sourceNumbers.PlayDelayed(2);
    //            sourceBattle.clip = audioBattle.getAudioBattle(8);
    //            sourceBattle.PlayDelayed(2);
    //            //sourceNumbers = addAudioSourceNumbers(audioBattle.selectAudio(9));
    //            //sourceNumbers.PlayDelayed(3);   // fase do monstro
    //            sourceBattle.clip = audioBattle.getAudioBattle(9);
    //            sourceBattle.PlayDelayed(3);
    //            inimigo.setVidaMonstro(resultado);
    //            Debug.Log("Vida nova do Monstro: " + inimigo.getVidaMonstro());
    //            faseMonstro();
    //        }            
    //    }        
    //    else
    //    {
    //        resultado = (defesaMonstro - ataquePlayer);
    //        Debug.Log("Seu ataque foi de " + ataquePlayer);
    //        sourceNumbers = addAudioSourceNumbers(audioBattle.getAudioBattle(7));
    //        sourceNumbers.PlayDelayed(3); // seu ataque foi de
           
    //        sourceNumbers = addAudioSourceNumbers(listNumbers.getAudioNumbers(ataquePlayer));  // numero do ataque
    //        sourceNumbers.PlayDelayed(4);
    //        sourceBattle.clip = audioBattle.getAudioBattle(8);
    //        sourceBattle.PlayDelayed(6);
    //        //sourceNumbers = addAudioSourceNumbers(audioBattle.selectAudio(8)); // montro esta vivo
    //        //sourceNumbers.PlayDelayed(6);
    //        sourceBattle.clip = audioBattle.getAudioBattle(9);
    //        sourceBattle.PlayDelayed(8);
    //        //sourceNumbers = addAudioSourceNumbers(audioBattle.selectAudio(9));
    //        //sourceNumbers.PlayDelayed(8); // fase do monstro            
    //        inimigo.setVidaMonstro(resultado);
    //        faseMonstro();
    //    }   
    //}

    public void fight(int highAttack)
    {
        activeBattle = false;
        int ataquePlayer = Random.Range((jogador.getAtaque() / 2), jogador.getAtaque()) + highAttack; //ataque do jogador vai variar entre a metade do seu ataque e o valor total do ataque
        int vidaMonstro = inimigo.getVidaMonstro();
        int resultado = ataquePlayer - vidaMonstro;        
        sourceBattle.clip = audioBattle.getAudioBattle(7);
        sourceBattle.PlayDelayed(3);
        Debug.Log("Seu ataque foi de " + ataquePlayer);
        sourceNumbers = addAudioSourceNumbers(listNumbers.getAudioNumbers(ataquePlayer));
        sourceNumbers.PlayDelayed(3);
        if (resultado >= 0)
        {
            monsterDead();
        }
        else
        {
            inimigo.setVidaMonstro(vidaMonstro - ataquePlayer);            
            //monstroVivo.PlayDelayed(5); // monstro esta vivo
            //audioFaseMonstro.PlayDelayed(7); // fase do monstro            
            Debug.Log("Vida nova do Monstro: " + inimigo.getVidaMonstro());
            faseMonstro();
        }
    }

    public void monsterDead()
    {
        sourceBattle.clip = audioBattle.getAudioBattle(1);
        sourceBattle.PlayDelayed(6);
        //sourceNumbers = addAudioSourceNumbers(audioBattle.selectAudio(1));
        //sourceNumbers.PlayDelayed(6); // monstro morreu
        Debug.Log("monstro morreu");
        GameController.changeState(GAME_STATE.IN_EXPLORATION);
        jogador.setXP(jogador.getXP() + inimigo.getXPMonstro());
        jogador.setMoeda(jogador.getMoeda() + inimigo.getMoeda());
        
        if (jogador.getXP() >= 100)
        {
            Debug.Log("Atualizando status jogador");
            int nivelAtual = jogador.getNivel();
            atualizaStatusJogador(nivelAtual + 1);
        }
    }   

    public void faseMonstro()
    {
        int vidaPlayer = jogador.getVida();
        int ataqueMonstro = inimigo.getAtaqueMonstro();
        int resultado = vidaPlayer - ataqueMonstro;
        // o ataque do monstro foi de
        if(resultado > 0)
        {
            Debug.Log("Monstro atacou com " + ataqueMonstro + " de ataque");
            jogador.setVida(resultado);
            sourceBattle.clip = audioBattle.getAudioBattle(18);
            sourceBattle.PlayDelayed(10);
            Debug.Log("Fase do jogador");
            //sourceNumbers = addAudioSourceNumbers(audioBattle.selectAudio(18));
            //sourceNumbers.PlayDelayed(10); // fase do jogador            
            return;
        }
        else
        {
            sourceBattle.clip = audioBattle.getAudioBattle(12);
            sourceBattle.PlayDelayed(10);
            //sourceNumbers = addAudioSourceNumbers(audioBattle.selectAudio(12));
            //sourceNumbers.PlayDelayed(10); // jogador morreu
            SceneManager.LoadScene("MenuPrincipal");
        }               
    }

    public void useItem(ItemBase item)
    {
        activeItem = true;
        if (item==null)
        {
            Debug.Log("Não possui item neste slot do intentario");
            return;
        }

        int efeito = item.getEfeito();
        int vidaAtual = jogador.getVida();
        int aux = efeito + vidaAtual;        

        if (GameController.getCurrentState() == GAME_STATE.IN_BATTLE)
        {
            if (item.getCurrentState() == TYPE_ITEM.IN_POCAO)
            {
                if(aux > jogador.getMaxVida())
                {
                    jogador.setVida(jogador.getMaxVida());                    
                }
                else if(aux < jogador.getMaxVida())
                {
                    jogador.setVida(efeito + jogador.getVida());                    
                }                    
                Debug.Log("usou pocao");
                faseMonstro();
            }
            else
            {
                int ataquePlayer = Random.Range((jogador.getAtaque() / 2), jogador.getAtaque());
                int efeitoMagia = item.getEfeito();                
                Debug.Log("Ataque com magia: " + efeitoMagia);
                fight(efeitoMagia);
            }
            inventory.gameObject.SetActive(!inventory.gameObject.activeSelf);            
        }
        if (GameController.getCurrentState() == GAME_STATE.IN_INVENTORY)
        {
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
            else
            {
                sourceBattle.clip = audioBattle.getAudioBattle(19);
                sourceBattle.Play();
                Debug.Log("magia não pode ser usada fora de batalha");
                //sourceNumbers = addAudioSourceNumbers(audioBattle.selectAudio(19));
                //sourceNumbers.Play(); // magia não pode ser usada fora de batalha
            }            
        }
    }

    public void fugir()
    {
        int sorte = Random.Range(jogador.getSorte(), (jogador.getNivel()*5));
        if (sorte > inimigo.getSorteMonstro())
        {
            sourceBattle.clip = audioBattle.getAudioBattle(10);
            sourceBattle.PlayDelayed(1);
            Debug.Log("jogador fugiu");
            //sourceNumbers = addAudioSourceNumbers(audioBattle.selectAudio(10));
            //sourceNumbers.PlayDelayed(1); // jogador fugiu            
            //sourceNumbers = addAudioSourceNumbers(audioBattle.selectAudio(10));
            //sourceNumbers.Stop();
            GameController.changeState(GAME_STATE.IN_EXPLORATION);
        }
        else
        {
            sourceBattle.clip = audioBattle.getAudioBattle(11);
            sourceBattle.Play();
            Debug.Log("jogador não fugiu");
            //sourceNumbers = addAudioSourceNumbers(audioBattle.selectAudio(11));
            //sourceNumbers.PlayDelayed(2); 
            sourceBattle.clip = audioBattle.getAudioBattle(9);
            sourceBattle.PlayDelayed(4);
            Debug.Log("fase monstro");
            //sourceNumbers = addAudioSourceNumbers(audioBattle.selectAudio(9));
            //sourceNumbers.PlayDelayed(4); // fase monstro
            faseMonstro();
        } 
    }

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
            sourceBattle.clip = audioBattle.getAudioBattle(17);
            sourceBattle.Play();
            //sourceNumbers = addAudioSourceNumbers(audioBattle.selectAudio(17));
            //sourceNumbers.Play(); // aumentou de nivel
            Debug.Log("Aumentou de nivel");
            jogador.setXP(xp-100);
        }
        else
        {
            jogador.setXP(xp);
        }        
    }
}
