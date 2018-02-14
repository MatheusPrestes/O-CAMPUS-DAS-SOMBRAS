using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeclasAtalhos : MonoBehaviour {

    public Player jogador;    
    private Boss chefao;
    public Numbers listNumbers;
    public AudioBattle listBattle;

    public AudioSource nivelPlayer;
    public AudioSource vidaPlayer;
    public AudioSource ataquePlayer;

    public AudioClip TeclasAtalhoModoBatalha;
    public AudioClip TeclasAtalho;
    public AudioClip SairDojogo;

    private AudioSource source;
    private AudioSource sourceAudio;

    private bool opcao = false;
    private bool bug = false;

    private GAME_STATE currentState;



    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();
        sourceAudio = GetComponent<AudioSource>();        
    }
	
	// Update is called once per frame
	void Update () {
        atalhos();
	}

    public void atalhos()
    {
        if(Input.GetKeyDown(KeyCode.F1))
        {
            foreach (AudioSource objeto in Object.FindObjectsOfType(typeof(AudioSource)))
            {
                if (objeto.tag != "Som")
                {
                    objeto.Stop();                    
                }
            }
            Debug.Log("Nivel do jogador " + jogador.getNivel());            
            sourceAudio.PlayOneShot(listBattle.getAudioBattle(16));
            source.PlayOneShot(listNumbers.getAudioNumbers(jogador.getNivel()));
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            foreach (AudioSource objeto in Object.FindObjectsOfType(typeof(AudioSource)))
            {
                if (objeto.tag != "Som")
                {
                    objeto.Stop();
                }
            }            
            Debug.Log("Vida do jogador " + jogador.getVida());                        
            sourceAudio.PlayOneShot(listBattle.getAudioBattle(15));
            source.PlayOneShot(listNumbers.getAudioNumbers(jogador.getVida()));
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            foreach (AudioSource objeto in Object.FindObjectsOfType(typeof(AudioSource)))
            {
                if (objeto.tag != "Som")
                {
                    objeto.Stop();
                }
            }
            Debug.Log("Ataque do jogador " + jogador.getAtaque());
            ataquePlayer.Play();
            sourceAudio.PlayOneShot(listBattle.getAudioBattle(23));
            source.PlayOneShot(listNumbers.getAudioNumbers(jogador.getAtaque()));
        }        
        
        if (Input.GetKeyDown(KeyCode.F6))
        {
            foreach (AudioSource objeto in Object.FindObjectsOfType(typeof(AudioSource)))
            {
                if (objeto.tag != "Som")
                {
                    objeto.Stop();
                }
            }
            Debug.Log("Pular musica");
        }

        if (Input.GetKeyDown(KeyCode.F11))
        {
            foreach (AudioSource objeto in Object.FindObjectsOfType(typeof(AudioSource)))
            {
                if (objeto.tag != "Som")
                {
                    objeto.Stop();                    
                }
                addAudioSource(TeclasAtalhoModoBatalha).Play();
            }
            Debug.Log("Atalhos modo de batalha");
        }

        if (Input.GetKeyDown(KeyCode.F12))
        {
            foreach (AudioSource objeto in Object.FindObjectsOfType(typeof(AudioSource)))
            {
                if (objeto.tag != "Som")
                {
                    objeto.Stop();                    
                }
                addAudioSource(TeclasAtalho).Play();
            }
            Debug.Log("Atalhos do jogo");
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Deseja sair do jogo?");
            foreach (AudioSource objeto in Object.FindObjectsOfType(typeof(AudioSource)))
            {
                if (objeto.tag != "Som")
                {
                    objeto.Stop();
                    addAudioSource(SairDojogo).Play();
                }
            }            
            currentState = GameController.getCurrentState();
            GameController.changeState(GAME_STATE.IN_HISTORY);
            opcao = true;                        
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && opcao == true)
        {            
            SceneManager.LoadScene("MenuPrincipal");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && opcao == true)
        {
            foreach (AudioSource objeto in Object.FindObjectsOfType(typeof(AudioSource)))
            {
                if (objeto.tag != "Som")
                {
                    objeto.Stop();                    
                }
            }
            GameController.changeState(currentState);
            opcao = false;
        }
    }   

    public AudioSource addAudioSource(AudioClip audio)
    {
        source.clip = audio;
        source.volume = 1;
        return source;
    }   

}
