using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBattle : MonoBehaviour {

    public AudioClip audioEncontrouMonstro;
    public AudioClip audioDerrotouMonstro;
    public AudioClip audioEscolhaOpcBatalha;
    public AudioClip audioAtacar;
    public AudioClip audioUsarItem;
    public AudioClip audioFugir;
    public AudioClip playerAttack;
    public AudioClip audioSeuAtaqueFoi;
    public AudioClip audioMonstroEstaVivo;
    public AudioClip audioFaseDoMonstro;
    public AudioClip audioJogadorFugiu;
    public AudioClip audioJogadorNaoFugiu;
    public AudioClip audioJogadorMorreu;
    public AudioClip startBattle;    
    public AudioClip loserBattle;
    // audio dos status do jogo
    public AudioClip audioVida;
    public AudioClip audioNivel;
    public AudioClip audioForcaAtaque;
    public AudioClip incrementLevel;
    public AudioClip audioFaseDoJogador;
    public AudioClip magiaUsadaEmBatalha;
    public AudioClip usouPocao;
    public AudioClip usouMagia;
    // audio status do monstro
    public AudioClip nivelMonstro;
    //public AudioClip vidaMonstro;

    public List<AudioClip> audioBattleList;



    // Use this for initialization
    void Start () {
        addAudioList();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addAudioList()
    {
        audioBattleList.Add(audioEncontrouMonstro);
        audioBattleList.Add(audioDerrotouMonstro);
        audioBattleList.Add(audioEscolhaOpcBatalha);
        audioBattleList.Add(audioAtacar);
        audioBattleList.Add(audioUsarItem);
        audioBattleList.Add(audioFugir);
        audioBattleList.Add(playerAttack);
        audioBattleList.Add(audioSeuAtaqueFoi);
        audioBattleList.Add(audioMonstroEstaVivo);
        audioBattleList.Add(audioFaseDoMonstro);
        audioBattleList.Add(audioJogadorFugiu); //10
        audioBattleList.Add(audioJogadorNaoFugiu);
        audioBattleList.Add(audioJogadorMorreu);
        audioBattleList.Add(startBattle);        
        audioBattleList.Add(loserBattle);
        audioBattleList.Add(audioVida);
        audioBattleList.Add(audioNivel);        
        audioBattleList.Add(incrementLevel);
        audioBattleList.Add(audioFaseDoJogador);
        audioBattleList.Add(magiaUsadaEmBatalha);
        audioBattleList.Add(usouPocao);
        audioBattleList.Add(usouMagia);
        audioBattleList.Add(nivelMonstro); 
        audioBattleList.Add(audioForcaAtaque); //23

    }

    public AudioClip getAudioBattle(int index)
    {
        for (int i = 0; i < audioBattleList.Capacity; i++)
        {
            if(index == i)
            {                
                return audioBattleList[i];
            }
        }
        return null;
    }

    public int sizeAudioList()
    {
        return audioBattleList.Count;
    }
}
