using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TYPE_ABILITY
{
    IN_FIRE,
    IN_WATER,
    IN_ICE,
    IN_EARTH
}



public class Boss : MonoBehaviour {

    public TYPE_ABILITY currentStateBoss;
    private static TYPE_ABILITY nextState;
    public TYPE_ABILITY fraquesa;

    public string nomeBoss;
    public int vidaBoss;
    public int ataqueBoss;
    public int nivelBoss;
    public int xpBoss;
    public ItemBase drop;
    public AudioSource audioAtaqueMonster;
    public AudioSource growlMonster;

    public string getNomeBoss()
    {
        return nomeBoss;
    }

    public int getXPBoss()
    {
        return xpBoss;
    }

    public int getVidaBoss()
    {
        return vidaBoss;
    }

    public int getAtaqueBoss()
    {
        return ataqueBoss;
    }

    public int getNivelBoss()
    {
        return nivelBoss;
    } 
    
    public ItemBase getDropItem()
    {
        return drop;
    }

    public AudioSource getGrowlBoss()
    {
        return growlMonster;
    }

    public AudioSource getAudioAtaqueBoss()
    {
        return audioAtaqueMonster;
    }

    public void setNomeBoss(string nomeNovo)
    {
        nomeBoss = nomeNovo;
    }

    public void setVidaBoss(int vida)
    {
        vidaBoss = vida;
    }

    public void setAtaqueBoss(int ataque)
    {
        ataqueBoss = ataque;
    }

    public void setNivelBoss(int nivel)
    {
        nivelBoss = nivel;
    }

    public void setXpBoss(int xp)
    {
        xpBoss = xp;
    } 
    
    public void setDropItem(ItemBase dropNovo)
    {
        drop = dropNovo;
    }

    public void setGrowlBoss(AudioSource audioNovo)
    {
        growlMonster = audioNovo;
    }

    public void changeStateAbility(TYPE_ABILITY newState)
    {
        nextState = newState;
    }

    public TYPE_ABILITY getCurrentState()
    {
        return currentStateBoss;
    }

}
