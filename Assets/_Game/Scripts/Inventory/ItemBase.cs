using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TYPE_ITEM
{
    IN_POCAO,
    IN_MAGIC,
    IN_DIAMANTE
}

public class ItemBase : MonoBehaviour {

    public TYPE_ITEM currentState;
    private static TYPE_ITEM nextState;

    public string nomeItem;
    public int valorItem;
    public int efeitoItem;    
    public AudioSource audioNome;

    public static ItemBase instance;

    public ItemBase(string nomeItem, int valorItem, int efeitoItem, AudioSource audioNome)
    {
        instance = this;
        this.nomeItem = nomeItem;
        this.valorItem = valorItem;
        this.efeitoItem = efeitoItem;
        this.audioNome = audioNome;
    }    

    public string getNome()
    {
        return nomeItem;
    }

    public int getValor()
    {
        return valorItem;
    }

    public int getEfeito()
    {
        return efeitoItem;
    }
    
    public AudioSource getAudioNome()
    {
        return audioNome;
    }

    public void setNome(string nomeNovo)
    {
        nomeItem = nomeNovo;
    }

    public void setValor(int valorNovo)
    {
        valorItem = valorNovo;
    }

    public void setEfeito(int novoEfeito)
    {
        efeitoItem = novoEfeito;
    }

    public void changeState(TYPE_ITEM newState)
    {
        nextState = newState;
    }

    public TYPE_ITEM getCurrentState()
    {
        return currentState;
    }





}
