using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public string nomeMonstro;
    public int vidaMonstro;
    public int ataqueMonstro;
    public int nivelMonstro;
    public int xpMonstro;
    public int sorteMonstro;
    public int moeda;
    public AudioSource growlMonster;
    public AudioSource audioAtaqueMonster;

    public string getNomeMonstro()
    {
        return nomeMonstro;
    }

    public int getXPMonstro()
    {
        return xpMonstro;
    }

    public int getVidaMonstro()
    {
        return vidaMonstro;
    }

    public int getAtaqueMonstro()
    {
        return ataqueMonstro;
    }

    public int getNivelMonstro()
    {
        return nivelMonstro;
    }

    public int getSorteMonstro()
    {
        return sorteMonstro;
    }

    public int getMoeda()
    {
        return moeda;
    }

    public AudioSource getGrowlMonster()
    {
        return growlMonster;
    }

    public AudioSource getAudioAtaqueMonster()
    {
        return audioAtaqueMonster;
    }

    public void setNomeMonstro(string nomeNovo)
    {
        nomeMonstro = nomeNovo;
    }

    public void setVidaMonstro(int vida)
    {
        vidaMonstro = vida;
    }

    public void setAtaqueMonstro(int ataque)
    {
        ataqueMonstro = ataque;
    }

    public void setNivelMonstro(int nivel)
    {
        nivelMonstro = nivel;
    }

    public void setXpMonstro(int xp)
    {
        xpMonstro = xp;
    }

    public void setSorteMonstro(int sorteNova)
    {
        sorteMonstro = sorteNova;
    }

    public void setMoeda(int moedaNova)
    {
        moeda = moedaNova;
    }  

}
